﻿using System;
using System.Windows.Forms;
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
        public static void ByDate(DateTime DateStart, DateTime DateFinish)
        {
            SystemArgs.PrintLog("Началось формирование отчета");
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "";
            sfd.Title = "Сохранение отчета";
            sfd.Filter = "Файл Excel| *.xlsx";
            sfd.FileName = "Отчет от " + DateTime.Now.ToString().Replace('.', '_').Replace(':', '_');
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SystemArgs.PrintLog("Выбрано место сохранения отчета");
                if (!String.IsNullOrEmpty(sfd.FileName))
                {
                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        //Настройки excel отчета
                        excelPackage.Workbook.Properties.Author = "Дефекты";
                        excelPackage.Workbook.Properties.Title = "Отчет за период от " + DateStart.ToShortDateString() + " до " + DateFinish.ToShortDateString();
                        excelPackage.Workbook.Properties.Created = DateTime.Now;

                        //Создания листа
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Отчет");
                        //Добавление шапки
                        worksheet.Cells["G1:M1"].Merge = true;
                        worksheet.Cells["G1"].Value = "Отчет по дефектности";
                        worksheet.Cells["G1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells["G2:M2"].Merge = true;
                        worksheet.Cells["G2"].Value = "слитков цилиндрических";
                        worksheet.Cells["G2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells["G3:M3"].Merge = true;
                        worksheet.Cells["G3"].Value = "за период с " + DateStart.ToShortDateString() + " по " + DateFinish.ToShortDateString();
                        worksheet.Cells["G3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        var PositionsReport = SystemArgs.Positions.Where(date => (date.DateCreate >= DateStart) && (date.DateCreate <= DateFinish)).ToList();
                        //Брак
                        worksheet.Cells["A6"].Value = "Брак:";
                        var WeightReport = PositionsReport.Sum(pos => pos.Weight);
                        var CountReport = PositionsReport.Sum(pos => pos.Count);
                        worksheet.Cells["A7"].Value = "-";
                        worksheet.Cells["A8"].Value = "-";
                        worksheet.Cells["B7"].Value = WeightReport.ToString() + " тонн(ы)";
                        worksheet.Cells["B8"].Value = CountReport.ToString() + " слитки(ов)";
                        //По видам деффектов
                        worksheet.Cells["A10:F10"].Merge = true;
                        worksheet.Cells["A10"].Value = "По видам деффектов (пропуская нулевые):";
                        var DefectCount = from dc in PositionsReport
                                          group dc by dc.Description.Name into g
                                          select new { NameDefect = g.Key, Value = g.Count() };
                        int DimensionEndRow;
                        foreach (var item in DefectCount)
                        {
                            DimensionEndRow = worksheet.Dimension.End.Row + 1;
                            worksheet.Cells["A" + DimensionEndRow.ToString()].Value = "-";
                            worksheet.Cells["B" + DimensionEndRow.ToString()].Value = item.NameDefect;
                            worksheet.Cells["C" + DimensionEndRow.ToString()].Value = item.Value;
                        }
                        //По бригадам (включая нулевые)
                        DimensionEndRow = worksheet.Dimension.End.Row + 2;
                        int ForDiag = DimensionEndRow + 1;
                        worksheet.Cells["A" + DimensionEndRow.ToString() + ":F" + DimensionEndRow.ToString()].Merge = true;
                        worksheet.Cells["A" + DimensionEndRow.ToString()].Value = "По бригадам (включая нулевые):";
                        var BrigadeCount = from dc in PositionsReport
                                           group dc by dc.NumBrigade.Name into g
                                           select new { NameBrigade = g.Key, Weight = g.Sum(t => t.Weight), Melt = g.Count() };
                        foreach (var item in BrigadeCount)
                        {
                            DimensionEndRow = worksheet.Dimension.End.Row + 1;
                            worksheet.Cells["A" + DimensionEndRow.ToString()].Value = "-";
                            worksheet.Cells["B" + DimensionEndRow.ToString()].Value = item.NameBrigade;
                            worksheet.Cells["C" + DimensionEndRow.ToString()].Value = item.Weight;
                            worksheet.Cells["D" + DimensionEndRow.ToString()].Value = " тонн(ы)";
                            worksheet.Cells["E" + DimensionEndRow.ToString()].Value = item.Melt;
                            worksheet.Cells["F" + DimensionEndRow.ToString()].Value = " плавка(и)";
                        }
                        worksheet.Cells["A6:F" + DimensionEndRow + 1.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells["B7:B8"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        worksheet.Cells["A6:G" + DimensionEndRow + 1.ToString()].AutoFitColumns();
                        //Добавление диаграммы
                        var chart = (ExcelBarChart)worksheet.Drawings.AddChart("Отчет по параметрам", eChartType.ColumnClustered);
                        chart.Legend.Position = eLegendPosition.Bottom;
                        chart.SetSize(600, 300);
                        chart.SetPosition(4, 0, 10, 0);
                        chart.Title.Text = "Отчет по параметрам";
                        chart.Series.Add(ExcelRange.GetAddress(ForDiag, 3, DimensionEndRow, 3), ExcelRange.GetAddress(ForDiag, 2, DimensionEndRow, 2));
                        chart.Series[0].Header = "тонн(ы)";
                        var chartType2 = chart.PlotArea.ChartTypes.Add(eChartType.LineMarkers);
                        var serie2 = chartType2.Series.Add(ExcelRange.GetAddress(ForDiag, 5, DimensionEndRow, 5), ExcelRange.GetAddress(ForDiag, 2, DimensionEndRow, 2));
                        serie2.Header = "плавка(и)";
                        //Сохранение
                        try
                        {
                            FileInfo fi = new FileInfo(sfd.FileName);
                            excelPackage.SaveAs(fi);
                        }
                        catch
                        {
                            SystemArgs.PrintLog("Директория для сохранения отчета была утеряна");
                            MessageBox.Show("Невозможно найти директорию для сохранения отчета", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    SystemArgs.PrintLog("Место сохранения отчета равно null");
                    MessageBox.Show("Необходимо ввести названия файла", "Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
    }
}
