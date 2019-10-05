using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using OfficeOpenXml.Drawing.Chart;

namespace Rusal
{
    public static class Reports
    {
        public static void ReportCreate(DateTime DateStart, DateTime DateFinish)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                //Настройки excel отчета
                excelPackage.Workbook.Properties.Author = "Дефекты";
                excelPackage.Workbook.Properties.Title = "Отчет за период от " + DateStart + " до " + DateFinish;
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                //Создания листа
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
                //Добавление шапки
                worksheet.Cells["G1:I1"].Merge = true;
                worksheet.Cells["G1"].Value = "Отчет по дефектности";
                worksheet.Cells["G1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["F2:J2"].Merge = true;
                worksheet.Cells["F2"].Value = "слитков цилиндрических";
                worksheet.Cells["F2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["E3:K3"].Merge = true;
                worksheet.Cells["E3"].Value = "за период с " + DateStart.ToString() + " по " + DateFinish.ToString();
                worksheet.Cells["E3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                var PositionsReport = SystemArgs.Positions.Where(date => (date.DateCreate >= DateStart) && (date.DateCreate <= DateFinish)).ToList();
                //Брак
                worksheet.Cells["A6"].Value = "Брак:";
                var WeightReport = PositionsReport.Sum(pos => pos.Weight);
                var CountReport = PositionsReport.Sum(pos => pos.Count);
                worksheet.Cells["A7"].Value = "-";
                worksheet.Cells["A7"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A8"].Value = "-";
                worksheet.Cells["A8"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["B7:D7"].Merge = true;
                worksheet.Cells["B7"].Value = WeightReport.ToString() + " тонн(ы)";
                worksheet.Cells["B8:D8"].Merge = true;
                worksheet.Cells["B8"].Value = CountReport.ToString() + " слитки(ов)";
                //По видам деффектов
                worksheet.Cells["A10:F10"].Merge = true;
                worksheet.Cells["A10"].Value = "По видам деффектов (пропуская нулевые):";
                var DefectCount = from dc in PositionsReport
                                  group dc by dc.Description into g
                                  select new { NameDefect = g.Key, Value = g.Count() };
                int DimensionEndRow;
                foreach (var item in DefectCount)
                {
                    DimensionEndRow = worksheet.Dimension.End.Row;
                    worksheet.Cells["A" + DimensionEndRow.ToString()].Value = "-";
                    worksheet.Cells["B" + DimensionEndRow.ToString() + ":C" + DimensionEndRow.ToString()].Merge = true;
                    worksheet.Cells["B" + DimensionEndRow.ToString()].Value = item.NameDefect.ToString();
                    worksheet.Cells["D" + DimensionEndRow.ToString()].Value = item.Value.ToString();
                }
                //По бригадам (включая нулевые)
                DimensionEndRow = worksheet.Dimension.End.Row + 2;
                int ForDiag = DimensionEndRow + 1;
                worksheet.Cells["A" + DimensionEndRow.ToString() + ":F" + DimensionEndRow.ToString()].Merge = true;
                worksheet.Cells["A" + DimensionEndRow.ToString()].Value = "По бригадам (включая нулевые):";
                var BrigadeCount = from dc in PositionsReport
                                   group dc by dc.NumBrigade into g
                                   select new { NameBrigade = g.Key, Weight = g.Sum(t => t.Weight), Melt = g.Count() };
                foreach (var item in BrigadeCount)
                {
                    DimensionEndRow = worksheet.Dimension.End.Row;
                    worksheet.Cells["A" + DimensionEndRow.ToString()].Value = "-";
                    worksheet.Cells["B" + DimensionEndRow.ToString() + ":C" + DimensionEndRow.ToString()].Merge = true;
                    worksheet.Cells["B" + DimensionEndRow.ToString()].Value = item.NameBrigade.ToString();
                    worksheet.Cells["D" + DimensionEndRow.ToString()].Value = item.Weight.ToString();
                    worksheet.Cells["E" + DimensionEndRow.ToString()].Value = " тонн(ы)";
                    worksheet.Cells["F" + DimensionEndRow.ToString()].Value = item.Melt.ToString();
                    worksheet.Cells["G" + DimensionEndRow.ToString()].Value = " плавка(и)";
                }
                //ExcelLineChart lineChart = worksheet.Drawings.AddChart("Отчет по параметрам", eChartType.Line) as ExcelLineChart;
                //lineChart.Title.Text = "Отчет по параметрам";
                ////create the ranges for the chart
                //var rangeLabel = worksheet.Cells["B" + ForDiag.ToString() + ":B" + DimensionEndRow.ToString()];
                //var range1 = worksheet.Cells["D" + ForDiag.ToString() + ":D" + DimensionEndRow.ToString()];
                //var range2 = worksheet.Cells["F" + ForDiag.ToString() + ":F" + DimensionEndRow.ToString()];

                ////add the ranges to the chart
                //lineChart.Series.Add(range1, rangeLabel);
                //lineChart.Series.Add(range2, rangeLabel);

                ////set the names of the legend
                //lineChart.Series[0].Header = "тонн(ы)";
                //lineChart.Series[1].Header = "плавка(и)";

                ////position of the legend
                //lineChart.Legend.Position = eLegendPosition.Bottom;

                ////size of the chart
                //lineChart.SetSize(600, 300);

                ////add the chart at cell B6
                //lineChart.SetPosition(5, 0, 1, 0);
                //Изменение шрифта во всем документе
                var allCells = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column];
                var cellFont = allCells.Style.Font;
                cellFont.SetFromFont(new Font("Times New Roman", 14));
                //Сохранение
                FileInfo fi = new FileInfo("Отчет от " + DateTime.Now.ToString().Replace('.', '_').Replace(':', '_') + ".xlsx");
                excelPackage.SaveAs(fi);
            }
        }
    }
}
