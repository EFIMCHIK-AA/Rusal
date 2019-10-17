using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using OfficeOpenXml.Drawing.Chart;
using OxyPlot;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Rusal
{
    public static class Analysis
    {
        private static List<WrapFullData> dataFullExports;
        private static List<WrapBriefData> dataBriefExports;
        private static CategoryAxis xaxis;
        private static LinearAxis yaxis;
        private static ColumnSeries histogramm;
        private static LineSeries diagrammline1;
        private static LineSeries diagrammline2;
        private static string Title;
        private static string TitleL1;
        private static string TitleL2;
        private static string TitleX;
        private static string TitleY;
        //Метод создания диаграммы и добавления данных в неё
        private static void SetParamDiagramm(PlotView pv,DateTime start,DateTime finish,bool FirstDiagramm)
        {
            diagrammline1 = new LineSeries()
            {
                TrackerFormatString = "{0}\r\n{3} : {4:0.###}",
                Title = TitleL1,
                StrokeThickness = 3,
                LineStyle = LineStyle.Automatic,
                MarkerType = MarkerType.Circle,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Automatic,
                MarkerStrokeThickness = 1.5

            };
            diagrammline2 = new LineSeries()
            {
                TrackerFormatString = "{0}\r\n{3} : {4:0.###}",
                Title = TitleL2,
                StrokeThickness = 3,
                LineStyle = LineStyle.Automatic,
                MarkerType = MarkerType.Circle,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Automatic,
                MarkerStrokeThickness = 1.5
            };
            pv.Model = new PlotModel
            {
                Title = Title
            };
            pv.Model.DefaultColors = new List<OxyColor>
            {
                OxyColor.FromRgb(30, 144, 255),
                OxyColor.FromRgb(245, 37, 37)
            };
            var minValue = DateTimeAxis.ToDouble(start.Date);
            var maxValue = DateTimeAxis.ToDouble(finish.Date);
            pv.Model.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                IntervalType = DateTimeIntervalType.Days,
                MajorStep = 7,
                MinorIntervalType = DateTimeIntervalType.Days,
                MinorStep = 7,
                Minimum = minValue,
                Maximum = maxValue,
                Angle = 90,
                StringFormat = "dd.MM.yy",
                IsZoomEnabled = false,
                IsPanEnabled = false
            });
            var leftAxisY = new LinearAxis 
            { 
                Position = AxisPosition.Left,
                MajorGridlineStyle = LineStyle.Dot,
                Title = TitleY,
                AxisDistance = 10,
                TitleFontSize = 14,
                IsZoomEnabled = false,
                IsPanEnabled = false
        };
            pv.Model.Axes.Add(leftAxisY);
            pv.Model.Series.Add(diagrammline1);
            pv.Model.Series.Add(diagrammline2);
            if(FirstDiagramm)
            {
                for (int i = 0; i < dataFullExports.Count; i++)
                {
                    diagrammline1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dataFullExports[i].DateFormation), dataFullExports[i].SumWeight));
                    diagrammline2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dataFullExports[i].DateFormation), dataFullExports[i].AccumulationWeight));
                }
            }
            else
            {
                for (int i = 0; i < dataFullExports.Count; i++)
                {
                    diagrammline1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dataFullExports[i].DateFormation), dataFullExports[i].DiameterWeight));
                    diagrammline2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dataFullExports[i].DateFormation), dataFullExports[i].AccumulationDiameter));
                }
            }
        }
        //Метод создания гистограммы и добавления данных в неё
        private static void SetParamHistogramm(PlotView pv)
        {
            xaxis = new CategoryAxis()
            {
                Position = AxisPosition.Bottom,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Title = TitleX,
                AxisDistance = 5,
                TitleFontSize = 14,
                IsZoomEnabled = false,
                IsPanEnabled = false

            };
            histogramm = new ColumnSeries()
            {
                IsStacked = true
            };
            yaxis = new LinearAxis()
            {
                Position = AxisPosition.Left,
                MajorGridlineStyle = LineStyle.Dot,
                Title = TitleY,
                AxisDistance = 10,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                TitleFontSize = 14
            };
            pv.Model = new PlotModel
            {
                Title = Title
            };
            pv.Model.DefaultColors = new List<OxyColor>
            {
                OxyColor.FromRgb(30, 144, 255)
            };
            pv.Model.Axes.Add(yaxis);
            pv.Model.Axes.Add(xaxis);
            pv.Model.Series.Add(histogramm);
            for(int i=0;i<dataBriefExports.Count;i++)
            {
                histogramm.Items.Add(new ColumnItem(dataBriefExports[i].Value));
                xaxis.Labels.Add(dataBriefExports[i].Name);
            }
        }
        private static void SetBriefDataGridView(DataGridView DGV)
        {
            DGV.DataSource = dataBriefExports;
            DGV.Columns[0].HeaderText = TitleX;
            DGV.Columns[1].HeaderText = TitleY;
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private static void SetFullDataGridView(DataGridView DGV)
        {
            DGV.DataSource = dataFullExports;
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        public static void BriefDiametrWeight(PlotView pv,DateTime datestart, DateTime datefinish,DataGridView DGV)
        {
            dataBriefExports = new List<WrapBriefData>();
            Title = "Дефектность по диаметрам за период";
            TitleX = "Диаметр";
            TitleY = "Брак, тонн";
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateFormation >= datestart) && (gp.DateFormation <= datefinish)
                        group gp by gp.Diameter.Name into g
                        select new { Name = g.Key, Value = g.Sum(w => w.Weight) };

            foreach (var item in Group)
            {     
                dataBriefExports.Add(new WrapBriefData() { Name = item.Name.ToString(), Value = item.Value });
            }
            SetParamHistogramm(pv);
            SetBriefDataGridView(DGV);

        }
        public static void BriefBrigadeWeight(PlotView pv, DateTime datestart, DateTime datefinish, DataGridView DGV)
        {
            dataBriefExports = new List<WrapBriefData>();
            Title = "Дефектность по бригадам за период";
            TitleX = "Бригада";
            TitleY = "Брак, тонн";
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateFormation >= datestart) && (gp.DateFormation <= datefinish)
                        group gp by gp.NumBrigade.Name into g
                        select new { Name = g.Key, Value = g.Sum(w => w.Weight) };
            foreach (var item in Group)
            {
                dataBriefExports.Add(new WrapBriefData() { Name = item.Name.ToString(), Value = item.Value });
            }
            SetParamHistogramm(pv);
            SetBriefDataGridView(DGV);
        }
        public static void BriefNumTSWeight(PlotView pv, DateTime datestart, DateTime datefinish, DataGridView DGV)
        {
            dataBriefExports = new List<WrapBriefData>();
            Title = "Дефектность по номерам ТС за период";
            TitleX = "Номер ТС";
            TitleY = "Брак, тонн";

            var Group = from gp in SystemArgs.Positions
                        where (gp.DateFormation >= datestart) && (gp.DateFormation <= datefinish)
                        group gp by gp.NumTS.Name into g
                        select new { Name = g.Key, Value = g.Sum(w => w.Weight) };

            foreach (var item in Group)
            {
                dataBriefExports.Add(new WrapBriefData() { Name = item.Name.ToString(), Value = item.Value });
            }
            SetParamHistogramm(pv);
            SetBriefDataGridView(DGV);
        }
        public static void BriefDescriptionWeight(PlotView pv, DateTime datestart, DateTime datefinish, DataGridView DGV)
        {
            dataBriefExports = new List<WrapBriefData>();
            Title = "Дефектность по типам дефектов за период";
            TitleX = "Дефект";
            TitleY = "Брак, тонн";

            var Group = from gp in SystemArgs.Positions
                        where (gp.DateFormation >= datestart) && (gp.DateFormation <= datefinish)
                        group gp by gp.Description.Name into g
                        select new { Name = g.Key, Value = g.Sum(w => w.Weight) };

            foreach (var item in Group)
            {
                dataBriefExports.Add(new WrapBriefData() { Name = item.Name.ToString(), Value = item.Value });
            }
            SetParamHistogramm(pv);
            SetBriefDataGridView(DGV);
        }
        public static void BriefBrigadeCount(PlotView pv, DateTime datestart, DateTime datefinish, DataGridView DGV)
        {
            dataBriefExports = new List<WrapBriefData>();
            Title = "Дефектность по бригадам за период";
            TitleX = "Бригада";
            TitleY = "Количество";

            var Group = from gp in SystemArgs.Positions
                        where (gp.DateFormation >= datestart) && (gp.DateFormation <= datefinish)
                        group gp by gp.NumBrigade.Name into g
                        select new { Name = g.Key, Value = g.Count() };

            foreach (var item in Group)
            {
                dataBriefExports.Add(new WrapBriefData() { Name = item.Name.ToString(), Value = item.Value });
            }
            SetParamHistogramm(pv);
            SetBriefDataGridView(DGV);
        }
        public static void BriefNumTSCount(PlotView pv, DateTime datestart, DateTime datefinish, DataGridView DGV)
        {
            dataBriefExports = new List<WrapBriefData>();
            Title = "Дефектность по номерам тс за период";
            TitleX = "Номер ТС";
            TitleY = "Количество";

            var Group = from gp in SystemArgs.Positions
                        where (gp.DateFormation >= datestart) && (gp.DateFormation <= datefinish)
                        group gp by gp.NumBrigade.Name into g
                        select new { Name = g.Key, Value = g.Count() };

            foreach (var item in Group)
            {
                dataBriefExports.Add(new WrapBriefData() { Name = item.Name.ToString(), Value = item.Value });
            }
            SetParamHistogramm(pv);
            SetBriefDataGridView(DGV);
        }
        public static void BriefDescriptionCount(PlotView pv, DateTime datestart, DateTime datefinish, DataGridView DGV)
        {
            dataBriefExports = new List<WrapBriefData>();
            Title = "Дефектность по типам дефектов за период";
            TitleX = "Дефект";
            TitleY = "Количество";

            var Group = from gp in SystemArgs.Positions
                        where (gp.DateFormation >= datestart) && (gp.DateFormation <= datefinish)
                        group gp by gp.Description.Name into g
                        select new { Name = g.Key, Value = g.Count() };

            foreach (var item in Group)
            {
                dataBriefExports.Add(new WrapBriefData() { Name = item.Name.ToString(), Value = item.Value });
            }
            SetParamHistogramm(pv);
            SetBriefDataGridView(DGV);
        }
        public static void FullDiameterWeight(DateTime datestart, DateTime datefinish, string Diameter,PlotView pv1,PlotView pv2,DataGridView DGV)
        {
            //Создание листа для хранения данных
            dataFullExports = new List<WrapFullData>();
            //Запрос на получение данных
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateFormation >= datestart) && (gp.DateFormation <= datefinish)
                        orderby gp.DateFormation ascending
                        group gp by gp.DateFormation into g
                        select new { Date = g.Key, SumWeight = g.Sum(t => t.Weight), SumDiameter = g.Where(t => t.Diameter.Name == Convert.ToDouble(Diameter)).Sum(t => t.Weight) };
            //Запись данных
            foreach (var item in Group)
            {
                if (dataFullExports.Count > 0)
                {

                    dataFullExports.Add(new WrapFullData() { DateFormation = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight + dataFullExports[dataFullExports.Count - 1].AccumulationWeight, DiameterWeight = item.SumDiameter, AccumulationDiameter = item.SumDiameter + dataFullExports[dataFullExports.Count - 1].AccumulationDiameter });

                }
                else
                {

                    dataFullExports.Add(new WrapFullData() { DateFormation = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight, DiameterWeight = item.SumDiameter, AccumulationDiameter = item.SumDiameter });

                }
            }

            //Задание тайтлов первой диаграммы
            Title = "Общая дефектность за период";
            TitleL1 = "Сумма брака, тонн";
            TitleL2 = "Накопление брака, тонн";
            TitleY = "Брак, тонн";
            SetParamDiagramm(pv1, datestart, datefinish,true);
            //Задание тайтлов второй диаграммы
            Title = "Дефектность по диаметру "+Diameter.ToString()+" за период";
            TitleL1 = "Сумма брака по диаметру " + Diameter.ToString() + ", тонн";
            TitleL2 = "Накопление брака, тонн";
            TitleY = "Брак, тонн";
            SetParamDiagramm(pv2, datestart, datefinish,false);
            SetFullDataGridView(DGV);

        }
        public static void FullDiscriptionWeight(DateTime datestart, DateTime datefinish, string Discription, PlotView pv1, PlotView pv2, DataGridView DGV)
        {
            //Создание листа для хранения данных
            dataFullExports = new List<WrapFullData>();
            //Запрос на получение данных
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateFormation >= datestart) && (gp.DateFormation <= datefinish)
                        orderby gp.DateFormation ascending
                        group gp by gp.DateFormation into g
                        select new { Date = g.Key, SumWeight = g.Sum(t => t.Weight), SumDiscription = g.Where(t => t.Description.Name == Discription).Sum(t => t.Weight) };
            //Запись данных
            foreach (var item in Group)
            {
                if (dataFullExports.Count > 0)
                {

                    dataFullExports.Add(new WrapFullData() { DateFormation = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight + dataFullExports[dataFullExports.Count - 1].AccumulationWeight, DiameterWeight = item.SumDiscription, AccumulationDiameter = item.SumDiscription + dataFullExports[dataFullExports.Count - 1].AccumulationDiameter });

                }
                else
                {

                    dataFullExports.Add(new WrapFullData() { DateFormation = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight, DiameterWeight = item.SumDiscription, AccumulationDiameter = item.SumDiscription });

                }
            }

            //Задание тайтлов первой диаграммы
            Title = "Общая дефектность за период";
            TitleL1 = "Сумма брака, тонн";
            TitleL2 = "Накопление брака, тонн";
            TitleY = "Брак, тонн";
            SetParamDiagramm(pv1, datestart, datefinish, true);
            //Задание тайтлов второй диаграммы
            Title = "Дефектность по дефекту " + Discription + " за период";
            TitleL1 = "Сумма брака по дефекту " + Discription + ", тонн";
            TitleL2 = "Накопление брака, тонн";
            TitleY = "Брак, тонн";
            SetParamDiagramm(pv2, datestart, datefinish, false);
            SetFullDataGridView(DGV);

        }
        public static void FullNumTSWeight(DateTime datestart, DateTime datefinish, string NumTS, PlotView pv1, PlotView pv2, DataGridView DGV)
        {
            //Создание листа для хранения данных
            dataFullExports = new List<WrapFullData>();
            //Запрос на получение данных
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateFormation >= datestart) && (gp.DateFormation <= datefinish)
                        orderby gp.DateFormation ascending
                        group gp by gp.DateFormation into g
                        select new { Date = g.Key, SumWeight = g.Sum(t => t.Weight), SumNumTS = g.Where(t => t.NumTS.Name == NumTS).Sum(t => t.Weight) };
            //Запись данных
            foreach (var item in Group)
            {
                if (dataFullExports.Count > 0)
                {

                    dataFullExports.Add(new WrapFullData() { DateFormation = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight + dataFullExports[dataFullExports.Count - 1].AccumulationWeight, DiameterWeight = item.SumNumTS, AccumulationDiameter = item.SumNumTS + dataFullExports[dataFullExports.Count - 1].AccumulationDiameter });

                }
                else
                {

                    dataFullExports.Add(new WrapFullData() { DateFormation = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight, DiameterWeight = item.SumNumTS, AccumulationDiameter = item.SumNumTS });

                }
            }

            //Задание тайтлов первой диаграммы
            Title = "Общая дефектность за период";
            TitleL1 = "Сумма брака, тонн";
            TitleL2 = "Накопление брака, тонн";
            TitleY = "Брак, тонн";
            SetParamDiagramm(pv1, datestart, datefinish, true);
            //Задание тайтлов второй диаграммы
            Title = "Дефектность по номеру ТС " + NumTS + " за период";
            TitleL1 = "Сумма брака по номеру ТС " + NumTS + ", тонн";
            TitleL2 = "Накопление брака, тонн";
            TitleY = "Брак, тонн";
            SetParamDiagramm(pv2, datestart, datefinish, false);
            SetFullDataGridView(DGV);

        }
        public static void FullBrigadeWeight(DateTime datestart, DateTime datefinish, string Brigade, PlotView pv1, PlotView pv2, DataGridView DGV)
        {
            //Создание листа для хранения данных
            dataFullExports = new List<WrapFullData>();
            //Запрос на получение данных
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateFormation >= datestart) && (gp.DateFormation <= datefinish)
                        orderby gp.DateFormation ascending
                        group gp by gp.DateFormation into g
                        select new { Date = g.Key, SumWeight = g.Sum(t => t.Weight), SumBrigade = g.Where(t => t.NumBrigade.Name == Brigade).Sum(t => t.Weight) };
            //Запись данных
            foreach (var item in Group)
            {
                if (dataFullExports.Count > 0)
                {

                    dataFullExports.Add(new WrapFullData() { DateFormation = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight + dataFullExports[dataFullExports.Count - 1].AccumulationWeight, DiameterWeight = item.SumBrigade, AccumulationDiameter = item.SumBrigade + dataFullExports[dataFullExports.Count - 1].AccumulationDiameter });

                }
                else
                {

                    dataFullExports.Add(new WrapFullData() { DateFormation = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight, DiameterWeight = item.SumBrigade, AccumulationDiameter = item.SumBrigade });

                }
            }

            //Задание тайтлов первой диаграммы
            Title = "Общая дефектность за период";
            TitleL1 = "Сумма брака, тонн";
            TitleL2 = "Накопление брака, тонн";
            TitleY = "Брак, тонн";
            SetParamDiagramm(pv1, datestart, datefinish, true);
            //Задание тайтлов второй диаграммы
            Title = "Дефектность по бригаде " + Brigade + " за период";
            TitleL1 = "Сумма брака по бригаде " + Brigade + ", тонн";
            TitleL2 = "Накопление брака, тонн";
            TitleY = "Брак, тонн";
            SetParamDiagramm(pv2, datestart, datefinish, false);
            SetFullDataGridView(DGV);

        }
        public static void ExcelFullExport(DateTime datestart, DateTime datefinish)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "";
            sfd.Title = "Сохранение анализа";
            sfd.Filter = "Файл Excel| *.xlsx";
            sfd.FileName = Title + " от " + DateTime.Now.ToString().Replace('.', '_').Replace(':', '_');
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(sfd.FileName))
                {
                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        //Настройки excel отчета
                        excelPackage.Workbook.Properties.Author = "Дефекты";
                        excelPackage.Workbook.Properties.Title = Title + " от " + datestart.ToShortDateString() + " до " + datefinish.ToShortDateString();
                        excelPackage.Workbook.Properties.Created = DateTime.Now;

                        //Создания листа
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Анализ");
                        //Добавление шапки
                        worksheet.Cells["E1:H1"].Merge = true;
                        worksheet.Cells["E1"].Value = "Анализ по дефектности";
                        worksheet.Cells["E1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells["E2:H2"].Merge = true;
                        worksheet.Cells["E2"].Value = "слитков цилиндрических";
                        worksheet.Cells["E2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells["E3:H3"].Merge = true;
                        worksheet.Cells["E3"].Value = "за период с " + datestart.ToShortDateString() + " по " + datefinish.ToShortDateString();
                        worksheet.Cells["E3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        //Создание таблицы
                        worksheet.Cells["A7"].Value = "Дата формирования";
                        worksheet.Cells["B7"].Value = "Сумма брака, тонн";
                        worksheet.Cells["C7"].Value = TitleL2;
                        worksheet.Cells["D7"].Value = TitleL1;
                        worksheet.Cells["E7"].Value = TitleL2;
                        int DimensionEndRow;
                        foreach (var item in dataFullExports)
                        {
                            DimensionEndRow = worksheet.Dimension.End.Row + 1;
                            worksheet.Cells["A" + DimensionEndRow.ToString()].Value = item.DateFormation.GetDateTimeFormats();
                            worksheet.Cells["B" + DimensionEndRow.ToString()].Value = item.SumWeight;
                            worksheet.Cells["C" + DimensionEndRow.ToString()].Value = item.AccumulationWeight;
                            worksheet.Cells["D" + DimensionEndRow.ToString()].Value = item.DiameterWeight;
                            worksheet.Cells["E" + DimensionEndRow.ToString()].Value = item.AccumulationDiameter;
                        }
                        DimensionEndRow = worksheet.Dimension.End.Row;
                        var modelTable = worksheet.Cells["A7:E" + DimensionEndRow.ToString()];
                        modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        modelTable.AutoFitColumns();
                        modelTable.Style.WrapText = true;
                        modelTable.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        //Добавление диаграммы
                        var chartOne = worksheet.Drawings.AddChart("Общая", eChartType.Line);
                        chartOne.SetSize(800, 300);
                        chartOne.SetPosition(6, 0, 6, 0);
                        chartOne.Title.Text = "Общая дефектность за период";
                        chartOne.Series.Add(worksheet.Cells[8, 2, DimensionEndRow, 2], worksheet.Cells[8, 1, DimensionEndRow, 1]);
                        var chartOneb = chartOne.PlotArea.ChartTypes.Add(eChartType.Line);
                        chartOneb.Series.Add(worksheet.Cells[8, 3, DimensionEndRow, 3], worksheet.Cells[8, 1, DimensionEndRow, 1]);
                        chartOne.Series[0].Header = "Сумма брака, тонн";
                        chartOneb.Series[0].Header = "Накопление брака, тонн";
                        chartOneb.UseSecondaryAxis = true;
                        chartOne.Legend.Position = eLegendPosition.Bottom;
                        chartOne.YAxis.Title.Font.Size = 14;
                        chartOne.YAxis.Title.Text = TitleY;
                        var chartTwo = worksheet.Drawings.AddChart("По параметру", eChartType.Line);
                        chartTwo.SetSize(800, 400);
                        chartTwo.SetPosition(21, 0, 6, 0);
                        chartTwo.Title.Text = Title;
                        chartTwo.Series.Add(worksheet.Cells[8, 4, DimensionEndRow, 4], worksheet.Cells[8, 1, DimensionEndRow, 1]);
                        var chartTwob = chartTwo.PlotArea.ChartTypes.Add(eChartType.Line);
                        chartTwob.Series.Add(worksheet.Cells[8, 5, DimensionEndRow, 5], worksheet.Cells[8, 1, DimensionEndRow, 1]);
                        chartTwo.Series[0].Header = TitleL1;
                        chartTwob.Series[0].Header = TitleL2;
                        chartTwob.UseSecondaryAxis = true;
                        chartTwo.Legend.Position = eLegendPosition.Bottom;
                        chartTwo.YAxis.Title.Font.Size = 14;
                        chartTwo.YAxis.Title.Text = TitleY;
                        //Изменение шрифта во всем документе
                        var allCells = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column];
                        var cellFont = allCells.Style.Font;
                        cellFont.SetFromFont(new Font("Times New Roman", 14));
                        //Сохранение
                        FileInfo fi = new FileInfo(sfd.FileName);
                        excelPackage.SaveAs(fi);
                    }

                }
                else
                {
                    MessageBox.Show("Необходимо ввести названия файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static void ExcelBriefExport(DateTime datestart, DateTime datefinish)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "";
            sfd.Title = "Сохранение анализа";
            sfd.Filter = "Файл Excel| *.xlsx";
            sfd.FileName = Title + " от " + DateTime.Now.ToString().Replace('.', '_').Replace(':', '_');
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(sfd.FileName))
                {
                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        //Настройки excel отчета
                        excelPackage.Workbook.Properties.Author = "Дефекты";
                        excelPackage.Workbook.Properties.Title = "Анализ за период от " + datestart.ToShortDateString() + " до " + datefinish.ToShortDateString();
                        excelPackage.Workbook.Properties.Created = DateTime.Now;

                        //Создания листа
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Анализ");
                        //Добавление шапки
                        worksheet.Cells["G1:M1"].Merge = true;
                        worksheet.Cells["G1"].Value = "Анализ по дефектности";
                        worksheet.Cells["G1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells["G2:M2"].Merge = true;
                        worksheet.Cells["G2"].Value = "слитков цилиндрических";
                        worksheet.Cells["G2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells["G3:M3"].Merge = true;
                        worksheet.Cells["G3"].Value = "за период с " + datestart.ToShortDateString() + " по " + datefinish.ToShortDateString();
                        worksheet.Cells["G3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        //Создание таблицы
                        worksheet.Cells["B7:C7"].Merge = true;
                        worksheet.Cells["D7:E7"].Merge = true;
                        worksheet.Cells["B7"].Value = TitleX;
                        worksheet.Cells["D7"].Value = TitleY;
                        int DimensionEndRow;
                        foreach (var item in dataBriefExports)
                        {
                            DimensionEndRow = worksheet.Dimension.End.Row + 1;
                            worksheet.Cells["B" + DimensionEndRow.ToString() + ":C" + DimensionEndRow.ToString()].Merge = true;
                            worksheet.Cells["D" + DimensionEndRow.ToString() + ":E" + DimensionEndRow.ToString()].Merge = true;
                            worksheet.Cells["D5:E5"].Merge = true;
                            worksheet.Cells["B" + DimensionEndRow.ToString()].Value = item.Name;
                            worksheet.Cells["D" + DimensionEndRow.ToString()].Value = item.Value;
                        }
                        DimensionEndRow = worksheet.Dimension.End.Row;
                        var modelTable = worksheet.Cells["B7:E" + DimensionEndRow.ToString()];
                        modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        modelTable.AutoFitColumns();
                        //Добавление диаграммы
                        var chart = (ExcelBarChart)worksheet.Drawings.AddChart(Title, eChartType.ColumnClustered);
                        chart.SetSize(600, 600);
                        chart.SetPosition(6, 0, 10, 0);
                        chart.Title.Text = Title;
                        chart.Series.Add(ExcelRange.GetAddress(8, 4, DimensionEndRow, 4), ExcelRange.GetAddress(8, 2, DimensionEndRow, 2));
                        chart.Legend.Remove();
                        chart.XAxis.Title.Text = TitleX;
                        chart.YAxis.Title.Font.Size = 14;
                        chart.XAxis.Title.Font.Size = 14;
                        chart.YAxis.Title.Text = TitleY;
                        //Изменение шрифта во всем документе
                        var allCells = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column];
                        var cellFont = allCells.Style.Font;
                        cellFont.SetFromFont(new Font("Times New Roman", 14));
                        //Сохранение
                        FileInfo fi = new FileInfo(sfd.FileName);
                        excelPackage.SaveAs(fi);
                    }

                }
                else
                {
                    MessageBox.Show("Необходимо ввести названия файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
