﻿using System;
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
        private struct DataBriefExport
        {
            public string Name;
            public double Value;
        }
        private static List<WrapData> dataFullExports;
        private static List<DataBriefExport> dataBriefExports;
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
            var minValue = DateTimeAxis.ToDouble(start);
            var maxValue = DateTimeAxis.ToDouble(finish);
            pv.Model.Axes.Add(new DateTimeAxis 
            {   
                Position = AxisPosition.Bottom,
                IntervalType = DateTimeIntervalType.Days,
                MajorStep = 1,
                MinorIntervalType = DateTimeIntervalType.Days,
                MinorStep = 3,
                Minimum = minValue,
                Maximum = maxValue,
                Angle = 90,
                StringFormat = "dd.MM.yy" 
            });
            var leftAxisY = new LinearAxis 
            { 
                Position = AxisPosition.Left,
                MajorGridlineStyle = LineStyle.Dot,
                Title = TitleY,
                AxisDistance = 10,
                TitleFontSize = 14
            };
            pv.Model.Axes.Add(leftAxisY);
            pv.Model.Series.Add(diagrammline1);
            pv.Model.Series.Add(diagrammline2);
            if(FirstDiagramm)
            {
                for (int i = 0; i < dataFullExports.Count; i++)
                {
                    diagrammline1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dataFullExports[i].DateCreate), dataFullExports[i].SumWeight));
                    diagrammline2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dataFullExports[i].DateCreate), dataFullExports[i].AccumulationWeight));
                }
            }
            else
            {
                for (int i = 0; i < dataFullExports.Count; i++)
                {
                    diagrammline1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dataFullExports[i].DateCreate), dataFullExports[i].DiameterWeight));
                    diagrammline2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dataFullExports[i].DateCreate), dataFullExports[i].AccumulationDiameter));
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
                TitleFontSize = 14

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
        private static void SetDataListbox(ListBox lb1,ListBox lb2,Label l1,Label l2)
        {
            lb1.Items.Clear();
            lb2.Items.Clear();
            l1.Text = TitleX;
            l2.Text = TitleY;
            for (int i = 0; i < dataBriefExports.Count; i++)
            {
                lb1.Items.Add(dataBriefExports[i].Name);
                lb2.Items.Add(dataBriefExports[i].Value);
            }
        }
        public static void BriefDiametrWeight(PlotView pv,DateTime datestart, DateTime datefinish,ListBox lb1,ListBox lb2,Label l1,Label l2)
        {
            dataBriefExports = new List<DataBriefExport>();
            Title = "Дефектность по диаметрам за период";
            TitleX = "Диаметр";
            TitleY = "Брак, тонн";
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.Diameter.Name into g
                        select new { Name = g.Key, Value = g.Sum(w => w.Weight) };

            foreach (var item in Group)
            {     
                dataBriefExports.Add(new DataBriefExport() { Name = item.Name.ToString(), Value = item.Value });
            }
            SetParamHistogramm(pv);
            SetDataListbox(lb1,lb2,l1,l2);

        }
        public static void BriefBrigadeWeight(PlotView pv, DateTime datestart, DateTime datefinish, ListBox lb1, ListBox lb2, Label l1, Label l2)
        {
            dataBriefExports = new List<DataBriefExport>();
            Title = "Дефектность по бригадам за период";
            TitleX = "Бригада";
            TitleY = "Брак, тонн";
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.NumBrigade.Name into g
                        select new { Name = g.Key, Value = g.Sum(w => w.Weight) };
            foreach (var item in Group)
            {
                dataBriefExports.Add(new DataBriefExport() { Name = item.Name.ToString(), Value = item.Value });
            }
            SetParamHistogramm(pv);
            SetDataListbox(lb1, lb2, l1, l2);
        }
        public static void BriefNumTSWeight(PlotView pv, DateTime datestart, DateTime datefinish, ListBox lb1, ListBox lb2, Label l1, Label l2)
        {
            dataBriefExports = new List<DataBriefExport>();
            Title = "Дефектность по номерам ТС за период";
            TitleX = "Номер ТС";
            TitleY = "Брак, тонн";

            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.NumTS.Name into g
                        select new { Name = g.Key, Value = g.Sum(w => w.Weight) };

            foreach (var item in Group)
            {
                dataBriefExports.Add(new DataBriefExport() { Name = item.Name.ToString(), Value = item.Value });
            }
            SetParamHistogramm(pv);
            SetDataListbox(lb1, lb2, l1, l2);
        }
        public static void BriefDescriptionWeight(PlotView pv, DateTime datestart, DateTime datefinish, ListBox lb1, ListBox lb2, Label l1, Label l2)
        {
            dataBriefExports = new List<DataBriefExport>();
            Title = "Дефектность по типам дефектов за период";
            TitleX = "Дефект";
            TitleY = "Брак, тонн";

            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.Description.Name into g
                        select new { Name = g.Key, Value = g.Sum(w => w.Weight) };

            foreach (var item in Group)
            {
                dataBriefExports.Add(new DataBriefExport() { Name = item.Name.ToString(), Value = item.Value });
            }
            SetParamHistogramm(pv);
            SetDataListbox(lb1, lb2, l1, l2);
        }
        public static void BriefBrigadeCount(PlotView pv, DateTime datestart, DateTime datefinish, ListBox lb1, ListBox lb2, Label l1, Label l2)
        {
            dataBriefExports = new List<DataBriefExport>();
            Title = "Дефектность по бригадам за период";
            TitleX = "Бригада";
            TitleY = "Количество";

            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.NumBrigade.Name into g
                        select new { Name = g.Key, Value = g.Count() };

            foreach (var item in Group)
            {
                dataBriefExports.Add(new DataBriefExport() { Name = item.Name.ToString(), Value = item.Value });
            }
            SetParamHistogramm(pv);
            SetDataListbox(lb1, lb2, l1, l2);
        }
        public static void BriefNumTSCount(PlotView pv, DateTime datestart, DateTime datefinish, ListBox lb1, ListBox lb2, Label l1, Label l2)
        {
            dataBriefExports = new List<DataBriefExport>();
            Title = "Дефектность по номерам тс за период";
            TitleX = "Номер ТС";
            TitleY = "Количество";

            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.NumBrigade.Name into g
                        select new { Name = g.Key, Value = g.Count() };

            foreach (var item in Group)
            {
                dataBriefExports.Add(new DataBriefExport() { Name = item.Name.ToString(), Value = item.Value });
            }
            SetParamHistogramm(pv);
            SetDataListbox(lb1, lb2, l1, l2);
        }
        public static void BriefDescriptionCount(PlotView pv, DateTime datestart, DateTime datefinish, ListBox lb1, ListBox lb2, Label l1, Label l2)
        {
            dataBriefExports = new List<DataBriefExport>();
            Title = "Дефектность по типам дефектов за период";
            TitleX = "Дефект";
            TitleY = "Количество";

            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.Description.Name into g
                        select new { Name = g.Key, Value = g.Count() };

            foreach (var item in Group)
            {
                dataBriefExports.Add(new DataBriefExport() { Name = item.Name.ToString(), Value = item.Value });
            }
            SetParamHistogramm(pv);
            SetDataListbox(lb1, lb2, l1, l2);
        }
        public static void FullDiameterWeight(DateTime datestart, DateTime datefinish, string Diameter,PlotView pv1,PlotView pv2,DataGridView DGV)
        {
            //Создание листа для хранения данных
            dataFullExports = new List<WrapData>();
            //Запрос на получение данных
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        orderby gp.DateCreate ascending
                        group gp by gp.DateCreate into g
                        select new { Date = g.Key, SumWeight = g.Sum(t => t.Weight), SumDiameter = g.Where(t => t.Diameter.Name == Convert.ToDouble(Diameter)).Sum(t => t.Weight) };
            //Запись данных
            foreach (var item in Group)
            {
                if (dataFullExports.Count > 0)
                {

                    dataFullExports.Add(new WrapData() { DateCreate = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight + dataFullExports[dataFullExports.Count - 1].AccumulationWeight, DiameterWeight = item.SumDiameter, AccumulationDiameter = item.SumDiameter + dataFullExports[dataFullExports.Count - 1].AccumulationDiameter });

                }
                else
                {

                    dataFullExports.Add(new WrapData() { DateCreate = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight, DiameterWeight = item.SumDiameter, AccumulationDiameter = item.SumDiameter });

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
            TitleL1 = "Накопление брака, тонн";
            TitleL2 = "Сумма брака по диаметру " + Diameter.ToString() + ", тонн";
            TitleY = "Брак, тонн";
            SetParamDiagramm(pv2, datestart, datefinish,false);
            GetDataDGV(DGV);

        }
        public static void FullDiscriptionWeight(DateTime datestart, DateTime datefinish, string Discription, PlotView pv1, PlotView pv2, DataGridView DGV)
        {
            //Создание листа для хранения данных
            dataFullExports = new List<WrapData>();
            //Запрос на получение данных
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        orderby gp.DateCreate ascending
                        group gp by gp.DateCreate into g
                        select new { Date = g.Key, SumWeight = g.Sum(t => t.Weight), SumDiameter = g.Where(t => t.Description.Name == Discription).Sum(t => t.Weight) };
            //Запись данных
            foreach (var item in Group)
            {
                if (dataFullExports.Count > 0)
                {

                    dataFullExports.Add(new WrapData() { DateCreate = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight + dataFullExports[dataFullExports.Count - 1].AccumulationWeight, DiameterWeight = item.SumDiameter, AccumulationDiameter = item.SumDiameter + dataFullExports[dataFullExports.Count - 1].AccumulationDiameter });

                }
                else
                {

                    dataFullExports.Add(new WrapData() { DateCreate = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight, DiameterWeight = item.SumDiameter, AccumulationDiameter = item.SumDiameter });

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
            TitleL1 = "Накопление брака, тонн";
            TitleL2 = "Сумма брака по дефекту " + Discription + ", тонн";
            TitleY = "Брак, тонн";
            SetParamDiagramm(pv2, datestart, datefinish, false);
            GetDataDGV(DGV);

        }
        public static void FullNumTSWeight(DateTime datestart, DateTime datefinish, string NumTS, PlotView pv1, PlotView pv2, DataGridView DGV)
        {
            //Создание листа для хранения данных
            dataFullExports = new List<WrapData>();
            //Запрос на получение данных
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        orderby gp.DateCreate ascending
                        group gp by gp.DateCreate into g
                        select new { Date = g.Key, SumWeight = g.Sum(t => t.Weight), SumDiameter = g.Where(t => t.NumTS.Name == NumTS).Sum(t => t.Weight) };
            //Запись данных
            foreach (var item in Group)
            {
                if (dataFullExports.Count > 0)
                {

                    dataFullExports.Add(new WrapData() { DateCreate = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight + dataFullExports[dataFullExports.Count - 1].AccumulationWeight, DiameterWeight = item.SumDiameter, AccumulationDiameter = item.SumDiameter + dataFullExports[dataFullExports.Count - 1].AccumulationDiameter });

                }
                else
                {

                    dataFullExports.Add(new WrapData() { DateCreate = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight, DiameterWeight = item.SumDiameter, AccumulationDiameter = item.SumDiameter });

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
            TitleL1 = "Накопление брака, тонн";
            TitleL2 = "Сумма брака по номеру ТС " + NumTS + ", тонн";
            TitleY = "Брак, тонн";
            SetParamDiagramm(pv2, datestart, datefinish, false);
            GetDataDGV(DGV);

        }
        public static void FullBrigadeWeight(DateTime datestart, DateTime datefinish, string Brigade, PlotView pv1, PlotView pv2, DataGridView DGV)
        {
            //Создание листа для хранения данных
            dataFullExports = new List<WrapData>();
            //Запрос на получение данных
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        orderby gp.DateCreate ascending
                        group gp by gp.DateCreate into g
                        select new { Date = g.Key, SumWeight = g.Sum(t => t.Weight), SumDiameter = g.Where(t => t.NumBrigade.Name == Brigade).Sum(t => t.Weight) };
            //Запись данных
            foreach (var item in Group)
            {
                if (dataFullExports.Count > 0)
                {

                    dataFullExports.Add(new WrapData() { DateCreate = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight + dataFullExports[dataFullExports.Count - 1].AccumulationWeight, DiameterWeight = item.SumDiameter, AccumulationDiameter = item.SumDiameter + dataFullExports[dataFullExports.Count - 1].AccumulationDiameter });

                }
                else
                {

                    dataFullExports.Add(new WrapData() { DateCreate = item.Date, SumWeight = item.SumWeight, AccumulationWeight = item.SumWeight, DiameterWeight = item.SumDiameter, AccumulationDiameter = item.SumDiameter });

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
            TitleL1 = "Накопление брака, тонн";
            TitleL2 = "Сумма брака по бригаде " + Brigade + ", тонн";
            TitleY = "Брак, тонн";
            SetParamDiagramm(pv2, datestart, datefinish, false);
            GetDataDGV(DGV);

        }
        public static void GetDataDGV(DataGridView DGV)
        {
            DGV.DataSource = dataFullExports;
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
