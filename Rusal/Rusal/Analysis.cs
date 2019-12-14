using System;
using Equin.ApplicationFramework;
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
        struct FullGroup
        {
            public DateTime Date;
            public double SumWeight;
            public double SumParameter;
        }

        private static List<WrapFullData> dataFullExports;
        private static List<WrapBriefData> dataBriefExports;
        private static CategoryAxis Axis_X;
        private static LinearAxis Axis_Y;
        private static ColumnSeries BriefDiagramm;
        private static LineSeries FullLineFirst;
        private static LineSeries FullLineSecond;

        private static string Title;
        private static string TitleL1;
        private static string TitleL2;
        private static string TitleX;
        private static string TitleY;

        public static void DisposeField()
        {
            dataBriefExports = null;
            dataFullExports = null;
            Axis_X = null;
            Axis_Y = null;
            BriefDiagramm = null;
            FullLineFirst = null;
            FullLineSecond = null;
            Title = null;
            TitleL1 = null;
            TitleL2 = null;
            TitleX = null;
            TitleY = null;
            SystemArgs.PrintLog("Были очищены все поля класса анализа");
        }

        private static void SetParamDiagramm(PlotView pv,DateTime start,DateTime finish,bool FirstDiagramm)
        {
            FullLineFirst = new LineSeries()
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

            FullLineSecond = new LineSeries()
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
            pv.Model.Series.Add(FullLineFirst);
            pv.Model.Series.Add(FullLineSecond);

            if(FirstDiagramm)
            {
                for (int i = 0; i < dataFullExports.Count; i++)
                {
                    FullLineFirst.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dataFullExports[i].DateFormation), dataFullExports[i].SumWeight));
                    FullLineSecond.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dataFullExports[i].DateFormation), dataFullExports[i].AccumulationWeight));
                }
                SystemArgs.PrintLog("Создание первой диаграммы расширенного отчета завершено успешно");
            }
            else
            {
                for (int i = 0; i < dataFullExports.Count; i++)
                {
                    FullLineFirst.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dataFullExports[i].DateFormation), dataFullExports[i].DiameterWeight));
                    FullLineSecond.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dataFullExports[i].DateFormation), dataFullExports[i].AccumulationDiameter));
                }
                SystemArgs.PrintLog("Создание второй диаграммы расширенного отчета завершено успешно");
            }
        }

        //Метод создания гистограммы и добавления данных в неё
        private static void SetParamBriefDiagramm(PlotView pv)
        {
            Axis_X = new CategoryAxis()
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

            BriefDiagramm = new ColumnSeries()
            {
                IsStacked = true
            };

            Axis_Y = new LinearAxis()
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

            pv.Model.Axes.Add(Axis_Y);
            pv.Model.Axes.Add(Axis_X);
            pv.Model.Series.Add(BriefDiagramm);

            for(int i=0;i<dataBriefExports.Count;i++)
            {
                BriefDiagramm.Items.Add(new ColumnItem(dataBriefExports[i].Value));
                Axis_X.Labels.Add(dataBriefExports[i].Name);
            }
            SystemArgs.PrintLog("Создание диаграммы краткого отчета завершено успешно");
        }

        private static void SetFullDataGridView(DataGridView DGV)
        {
            DGV.DataSource = dataFullExports;
            DGV.Columns[0].HeaderText = "Дата";
            DGV.Columns[1].HeaderText = "Сумма брака, тонн";
            DGV.Columns[2].HeaderText = TitleL2;
            DGV.Columns[3].HeaderText = TitleL1;
            DGV.Columns[4].HeaderText = TitleL2;


            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SystemArgs.PrintLog("Заполнение таблицы расширенного отчета завершено успешно");
        }

        public static List<WrapBriefData> BriefDiametrWeight(PlotView pv,DateTime datestart, DateTime datefinish)
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

            SetParamBriefDiagramm(pv);

            SystemArgs.PrintLog("Краткий анализ диаметр вес выполнен");
            return dataBriefExports;
        }

        public static List<WrapBriefData> BriefBrigadeWeight(PlotView pv, DateTime datestart, DateTime datefinish)
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

            SetParamBriefDiagramm(pv);

            SystemArgs.PrintLog("Краткий анализ бригада вес выполнен");
            return dataBriefExports;
        }

        public static List<WrapBriefData> BriefNumTSWeight(PlotView pv, DateTime datestart, DateTime datefinish)
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

            SetParamBriefDiagramm(pv);

            SystemArgs.PrintLog("Краткий анализ номер ТС вес выполнен");
            return dataBriefExports;
        }
        public static List<WrapBriefData> BriefDescriptionWeight(PlotView pv, DateTime datestart, DateTime datefinish)
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

            SetParamBriefDiagramm(pv);

            SystemArgs.PrintLog("Краткий анализ описание вес выполнен");
            return dataBriefExports;
        }
        public static List<WrapBriefData> BriefBrigadeCount(PlotView pv, DateTime datestart, DateTime datefinish)
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

            SetParamBriefDiagramm(pv);

            SystemArgs.PrintLog("Краткий анализ бригада количество выполнен");
            return dataBriefExports;
        }
        public static List<WrapBriefData> BriefNumTSCount(PlotView pv, DateTime datestart, DateTime datefinish)
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

            SetParamBriefDiagramm(pv);

            SystemArgs.PrintLog("Краткий анализ номер ТС количество выполнен");
            return dataBriefExports;
        }
        public static List<WrapBriefData> BriefDescriptionCount(PlotView pv, DateTime datestart, DateTime datefinish)
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

            SetParamBriefDiagramm(pv);

            SystemArgs.PrintLog("Краткий анализ описание количество выполнен");
            return dataBriefExports;
        }
        private static IEnumerable<IGrouping<DateTime,Position>> FullDataSelect(DateTime datestart, DateTime datefinish)
        {
            var Group = SystemArgs.Positions.Where(gp => gp.DateFormation >= datestart && gp.DateFormation <= datefinish).GroupBy(gp => gp.DateFormation).OrderBy(gp => gp.Key);
            SystemArgs.PrintLog("Группировка для расширенного анализа выполнена успешно");
            return Group;
        }
        private static void FullDataExportToList(IEnumerable<FullGroup> Group1)
        {
            dataFullExports = new List<WrapFullData>();

            foreach (var item in Group1)
            {
                if (dataFullExports.Count > 0)
                {

                    dataFullExports.Add(new WrapFullData() { DateFormation = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight + dataFullExports[dataFullExports.Count - 1].AccumulationWeight, DiameterWeight = item.SumParameter, AccumulationDiameter = item.SumParameter + dataFullExports[dataFullExports.Count - 1].AccumulationDiameter });

                }
                else
                {

                    dataFullExports.Add(new WrapFullData() { DateFormation = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight, DiameterWeight = item.SumParameter, AccumulationDiameter = item.SumParameter });

                }
            }

            Title = "Общая дефектность за период";
            TitleL1 = "Сумма брака, тонн";
            TitleL2 = "Накопление брака, тонн";
            TitleY = "Брак, тонн";
            SystemArgs.PrintLog("Экспорт данных в лист выполнен успешно");

        }
        public static void FullDiameterWeight(DateTime datestart, DateTime datefinish, string Diameter,PlotView pv1,PlotView pv2,DataGridView DGV)
        {
            var DataGroup = from g in FullDataSelect(datestart, datefinish)
                            select new FullGroup { Date = g.Key, SumWeight = g.Sum(t => t.Weight), SumParameter = g.Where(t => t.Diameter.Name == Convert.ToDouble(Diameter)).Sum(t => t.Weight) };

            FullDataExportToList(DataGroup);

            SetParamDiagramm(pv1, datestart, datefinish,true);

            Title = "Дефектность по диаметру "+Diameter.ToString()+" за период";
            TitleL1 = "Сумма брака по диаметру " + Diameter.ToString() + ", тонн";
            TitleL2 = "Накопление брака, тонн";
            TitleY = "Брак, тонн";

            SetParamDiagramm(pv2, datestart, datefinish,false);

            SetFullDataGridView(DGV);
            SystemArgs.PrintLog("Расширенный анализ диаметр вес выполнен успешно");

        }
        public static void FullDiscriptionWeight(DateTime datestart, DateTime datefinish, string Discription, PlotView pv1, PlotView pv2, DataGridView DGV)
        {
            var DataGroup = from g in FullDataSelect(datestart,datefinish)
                         select new FullGroup { Date = g.Key, SumWeight = g.Sum(t => t.Weight), SumParameter = g.Where(t => t.Description.Name == Discription).Sum(t => t.Weight) };

            FullDataExportToList(DataGroup);

            SetParamDiagramm(pv1, datestart, datefinish, true);

            Title = "Дефектность по дефекту " + Discription + " за период";
            TitleL1 = "Сумма брака по дефекту " + Discription + ", тонн";
            TitleL2 = "Накопление брака, тонн";
            TitleY = "Брак, тонн";

            SetParamDiagramm(pv2, datestart, datefinish, false);

            SetFullDataGridView(DGV);
            SystemArgs.PrintLog("Расширенный анализ описание вес выполнен успешно");

        }
        public static void FullNumTSWeight(DateTime datestart, DateTime datefinish, string NumTS, PlotView pv1, PlotView pv2, DataGridView DGV)
        {
            var DataGroup = from g in FullDataSelect(datestart, datefinish)
                            select new FullGroup { Date = g.Key, SumWeight = g.Sum(t => t.Weight), SumParameter = g.Where(t => t.NumTS.Name == NumTS).Sum(t => t.Weight) };

            FullDataExportToList(DataGroup);

            SetParamDiagramm(pv1, datestart, datefinish, true);

            Title = "Дефектность по номеру ТС " + NumTS + " за период";
            TitleL1 = "Сумма брака по номеру ТС " + NumTS + ", тонн";
            TitleL2 = "Накопление брака, тонн";
            TitleY = "Брак, тонн";

            SetParamDiagramm(pv2, datestart, datefinish, false);

            SetFullDataGridView(DGV);
            SystemArgs.PrintLog("Расширенный анализ номер ТС вес выполнен успешно");

        }
        public static void FullBrigadeWeight(DateTime datestart, DateTime datefinish, string Brigade, PlotView pv1, PlotView pv2, DataGridView DGV)
        {
            var DataGroup = from g in FullDataSelect(datestart, datefinish)
                            select new FullGroup { Date = g.Key, SumWeight = g.Sum(t => t.Weight), SumParameter = g.Where(t => t.NumBrigade.Name == Brigade).Sum(t => t.Weight) };

            FullDataExportToList(DataGroup);

            SetParamDiagramm(pv1, datestart, datefinish, true);

            Title = "Дефектность по бригаде " + Brigade + " за период";
            TitleL1 = "Сумма брака по бригаде " + Brigade + ", тонн";
            TitleL2 = "Накопление брака, тонн";
            TitleY = "Брак, тонн";

            SetParamDiagramm(pv2, datestart, datefinish, false);

            SetFullDataGridView(DGV);
            SystemArgs.PrintLog("Расширенный анализ бригада вес выполнен успешно");

        }
        public static void ExcelFullExport(DateTime datestart, DateTime datefinish)
        {
            if (dataFullExports!= null)
            {
                SystemArgs.PrintLog("Началось формирование выгрузки расширенного анализа");
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    DefaultExt = "",
                    Title = "Сохранение анализа",
                    Filter = "Файл Excel| *.xlsx",
                    FileName = Title + " от " + DateTime.Now.ToString().Replace('.', '_').Replace(':', '_'),
                    RestoreDirectory = true
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!String.IsNullOrEmpty(sfd.FileName))
                    {
                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            excelPackage.Workbook.Properties.Author = "Дефекты";
                            excelPackage.Workbook.Properties.Title = Title + " от " + datestart.ToShortDateString() + " до " + datefinish.ToShortDateString();
                            excelPackage.Workbook.Properties.Created = DateTime.Now;

                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Анализ");

                            worksheet.Cells["E1:H1"].Merge = true;
                            worksheet.Cells["E1"].Value = "Анализ по дефектности";
                            worksheet.Cells["E1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            worksheet.Cells["E2:H2"].Merge = true;
                            worksheet.Cells["E2"].Value = "слитков цилиндрических";
                            worksheet.Cells["E2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            worksheet.Cells["E3:H3"].Merge = true;
                            worksheet.Cells["E3"].Value = "за период с " + datestart.ToShortDateString() + " по " + datefinish.ToShortDateString();
                            worksheet.Cells["E3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

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

                            FileInfo fi = new FileInfo(sfd.FileName);
                            excelPackage.SaveAs(fi);
                        }

                    }
                    else
                    {
                        SystemArgs.PrintLog("Место сохранения отчета равно null");
                        MessageBox.Show("Необходимо ввести названия файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                SystemArgs.PrintLog("Не смогло начатся формирование выгрузки расширенного отчета лист равен null");
                MessageBox.Show("Для экспорта необходимо сформировать анализ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void ExcelBriefExport(DateTime datestart, DateTime datefinish,BindingListView<WrapBriefData> Data)
        {
            if (Data != null)
            {
                SystemArgs.PrintLog("Началось формирование выгрузки краткого анализа");
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    DefaultExt = "",
                    Title = "Сохранение анализа",
                    Filter = "Файл Excel| *.xlsx",
                    FileName = Title + " от " + DateTime.Now.ToString().Replace('.', '_').Replace(':', '_'),
                    RestoreDirectory = true
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!String.IsNullOrEmpty(sfd.FileName))
                    {
                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            excelPackage.Workbook.Properties.Author = "Дефекты";
                            excelPackage.Workbook.Properties.Title = "Анализ за период от " + datestart.ToShortDateString() + " до " + datefinish.ToShortDateString();
                            excelPackage.Workbook.Properties.Created = DateTime.Now;

                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Анализ");

                            worksheet.Cells["G1:M1"].Merge = true;
                            worksheet.Cells["G1"].Value = "Анализ по дефектности";
                            worksheet.Cells["G1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            worksheet.Cells["G2:M2"].Merge = true;
                            worksheet.Cells["G2"].Value = "слитков цилиндрических";
                            worksheet.Cells["G2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            worksheet.Cells["G3:M3"].Merge = true;
                            worksheet.Cells["G3"].Value = "за период с " + datestart.ToShortDateString() + " по " + datefinish.ToShortDateString();
                            worksheet.Cells["G3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            worksheet.Cells["B7"].Value = TitleX;
                            worksheet.Cells["C7"].Value = TitleY;

                            int DimensionEndRow;

                            foreach(var item in Data)
                            {
                                DimensionEndRow = worksheet.Dimension.End.Row + 1;
                                worksheet.Cells["B" + DimensionEndRow.ToString()].Value = item.Name;
                                worksheet.Cells["C" + DimensionEndRow.ToString()].Value = item.Value;
                            }

                            DimensionEndRow = worksheet.Dimension.End.Row;

                            var modelTable = worksheet.Cells["B7:C" + DimensionEndRow.ToString()];
                            modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            modelTable.AutoFitColumns();

                            var chart = (ExcelBarChart)worksheet.Drawings.AddChart(Title, eChartType.ColumnClustered);
                            chart.SetSize(600, 600);
                            chart.SetPosition(6, 0, 10, 0);
                            chart.Title.Text = Title;
                            chart.Series.Add(ExcelRange.GetAddress(8, 3, DimensionEndRow, 3), ExcelRange.GetAddress(8, 2, DimensionEndRow, 2));
                            chart.Legend.Remove();
                            chart.XAxis.Title.Text = TitleX;
                            chart.YAxis.Title.Font.Size = 14;
                            chart.XAxis.Title.Font.Size = 14;
                            chart.YAxis.Title.Text = TitleY;

                            FileInfo fi = new FileInfo(sfd.FileName);
                            excelPackage.SaveAs(fi);
                        }

                    }
                    else
                    {
                        SystemArgs.PrintLog("Место сохранения отчета равно null");
                        MessageBox.Show("Необходимо ввести названия файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                SystemArgs.PrintLog("Не смогло начатся формирование выгрузки краткого отчета лист равен null");
                MessageBox.Show("Для экспорта необходимо сформировать анализ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
