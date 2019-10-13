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
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Rusal
{
    public static class Analysis
    {
        private struct DataExport
        {
            public string Name;
            public double Value;
        }
        private static List<DataExport> dataExports;
        private static CategoryAxis xaxis;
        private static LinearAxis yaxis;
        private static ColumnSeries histogramm;
        public static Analysis_F Dialog;
        private static string Title;
        private static string TitleX;
        private static string TitleY;
        private static void SetParamHistogramm()
        {
            Dialog = new Analysis_F();
            Dialog.Text = Title;
            Dialog.label_x.Text = TitleX;
            Dialog.label_y.Text = TitleY;
            dataExports = new List<DataExport>();
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
            Dialog.pv.Model = new PlotModel
            {
                Title = Title
            };
            Dialog.pv.Model.DefaultColors = new List<OxyColor>
            {
                OxyColor.FromRgb(30, 144, 255)
            };
            Dialog.pv.Model.Axes.Add(yaxis);
            Dialog.pv.Model.Axes.Add(xaxis);
            Dialog.pv.Model.Series.Add(histogramm);
        }
        public static void BriefDiametrWeight(DateTime datestart, DateTime datefinish)
        {
            Title = "Дефектность по диаметрам за период";
            TitleX = "Диаметр";
            TitleY = "Брак, тонн";
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.Diameter.Name into g
                        select new { Name = g.Key, Value = g.Sum(w => w.Weight) };
            SetParamHistogramm();
            foreach (var item in Group)
            {
                Dialog.listBox1.Items.Add(item.Name);
                Dialog.listBox2.Items.Add(item.Value);
                histogramm.Items.Add(new ColumnItem(item.Value));
                xaxis.Labels.Add(item.Name.ToString());
                dataExports.Add(new DataExport() { Name = item.Name.ToString(), Value=item.Value });
            }

            Dialog.ShowDialog();

        }
        public static void BriefBrigadeWeight(DateTime datestart, DateTime datefinish)
        {
            Title = "Дефектность по бригадам за период";
            TitleX = "Бригада";
            TitleY = "Брак, тонн";
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.NumBrigade.Name into g
                        select new { Name = g.Key, Value = g.Sum(w => w.Weight) };
            SetParamHistogramm();
            foreach (var item in Group)
            {
                Dialog.listBox1.Items.Add(item.Name);
                Dialog.listBox2.Items.Add(item.Value);
                histogramm.Items.Add(new ColumnItem(item.Value));
                xaxis.Labels.Add(item.Name.ToString());
                dataExports.Add(new DataExport() { Name = item.Name.ToString(), Value = item.Value });
            }

            Dialog.ShowDialog();
        }
        public static void BriefNumTSWeight(DateTime datestart, DateTime datefinish)
        {
            Title = "Дефектность по номерам ТС за период";
            TitleX = "Номер ТС";
            TitleY = "Брак, тонн";

            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.NumTS.Name into g
                        select new { Name = g.Key, Value = g.Sum(w => w.Weight) };

            SetParamHistogramm();

            foreach (var item in Group)
            {
                Dialog.listBox1.Items.Add(item.Name);
                Dialog.listBox2.Items.Add(item.Value);
                histogramm.Items.Add(new ColumnItem(item.Value));
                xaxis.Labels.Add(item.Name.ToString());
                dataExports.Add(new DataExport() { Name = item.Name.ToString(), Value = item.Value });
            }

            Dialog.ShowDialog();
        }
        public static void BriefDescriptionWeight(DateTime datestart, DateTime datefinish)
        {
            Title = "Дефектность по типам дефектов за период";
            TitleX = "Дефект";
            TitleY = "Брак, тонн";

            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.Description.Name into g
                        select new { Name = g.Key, Value = g.Sum(w => w.Weight) };

            SetParamHistogramm();

            foreach (var item in Group)
            {
                Dialog.listBox1.Items.Add(item.Name);
                Dialog.listBox2.Items.Add(item.Value);
                histogramm.Items.Add(new ColumnItem(item.Value));
                xaxis.Labels.Add(item.Name.ToString());
                dataExports.Add(new DataExport() { Name = item.Name.ToString(), Value = item.Value });
            }

            Dialog.ShowDialog();
        }
        public static void BriefBrigadeCount(DateTime datestart, DateTime datefinish)
        {
            Title = "Дефектность по бригадам за период";
            TitleX = "Бригада";
            TitleY = "Количество";

            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.NumBrigade.Name into g
                        select new { Name = g.Key, Value = g.Count() };

            SetParamHistogramm();

            foreach (var item in Group)
            {
                Dialog.listBox1.Items.Add(item.Name);
                Dialog.listBox2.Items.Add(item.Value);
                histogramm.Items.Add(new ColumnItem(item.Value));
                xaxis.Labels.Add(item.Name.ToString());
                dataExports.Add(new DataExport() { Name = item.Name.ToString(), Value = item.Value });
            }

            Dialog.ShowDialog();
        }
        public static void BriefNumTSCount(DateTime datestart, DateTime datefinish)
        {
            Title = "Дефектность по номерам тс за период";
            TitleX = "Номер ТС";
            TitleY = "Количество";

            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.NumBrigade.Name into g
                        select new { Name = g.Key, Value = g.Count() };

            SetParamHistogramm();

            foreach (var item in Group)
            {
                Dialog.listBox1.Items.Add(item.Name);
                Dialog.listBox2.Items.Add(item.Value);
                histogramm.Items.Add(new ColumnItem(item.Value));
                xaxis.Labels.Add(item.Name.ToString());
                dataExports.Add(new DataExport() { Name = item.Name.ToString(), Value = item.Value });
            }

            Dialog.ShowDialog();
        }
        public static void BriefDescriptionCount(DateTime datestart, DateTime datefinish)
        {
            Title = "Дефектность по типам дефектов за период";
            TitleX = "Дефект";
            TitleY = "Количество";

            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.Description.Name into g
                        select new { Name = g.Key, Value = g.Count() };

            SetParamHistogramm();

            foreach (var item in Group)
            {
                Dialog.listBox1.Items.Add(item.Name);
                Dialog.listBox2.Items.Add(item.Value);
                histogramm.Items.Add(new ColumnItem(item.Value));
                xaxis.Labels.Add(item.Name.ToString());
                dataExports.Add(new DataExport() { Name = item.Name.ToString(), Value = item.Value });
            }

            Dialog.ShowDialog();
        }
        public static void ExcelBriefExport(DateTime datestart, DateTime datefinish)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "";
            sfd.Title = "Сохранение анализа";
            sfd.Filter = "Файл Excel| *.xlsx";
            sfd.FileName = Title+" от " + DateTime.Now.ToString().Replace('.', '_').Replace(':', '_');
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
                        foreach (var item in dataExports)
                        {
                            DimensionEndRow = worksheet.Dimension.End.Row + 1;
                            worksheet.Cells["B"+ DimensionEndRow.ToString()+":C" + DimensionEndRow.ToString()].Merge = true;
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
                        chart.YAxis.Title.Font.Size=14;
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
