using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Drawing.Chart;

namespace Rusal
{
    public partial class BriefAnalysis_F : Form
    {
        public BriefAnalysis_F()
        {
            InitializeComponent();
        }

        private void Export_B_Click(object sender, EventArgs e)
        {
            SystemArgs.PrintLog("Запуск процедуры экспорта данных анализа");
            Analysis.ExcelBriefExport(FirstDate, SecondDate);
            SystemArgs.PrintLog("Процедура экспорта данных анализа завершена");
        }

        DateTime FirstDate;//Начало периода
        DateTime SecondDate; //Конец периода

        String[] ListParams = { "Вес | Бригада", "Вес | Диаметр", "Вес | Описание", "Вес | Номер ТС", "Количество | Бригада", "Количество | Номер ТС", "Количество | Описание"};

        private void GetAnalisys(Int32 Key)
        {
            FirstDate = FirstDate_CM.SelectionStart;
            SecondDate = SecondDate_CM.SelectionStart;

            switch (Key)
            {
                case 0: //Вес | Бригада
                    Analysis.BriefBrigadeWeight(pv, FirstDate, SecondDate, DGV_Brief);
                    SystemArgs.PrintLog("Выполнение анализа по параметру: Вес | Бригада");
                    break;
                case 1: //Вес | Диаметр
                    Analysis.BriefDiametrWeight(pv, FirstDate, SecondDate, DGV_Brief);
                    SystemArgs.PrintLog("Выполнение анализа по параметру: Вес | Диаметр");
                    break;
                case 2://Вес | Описание
                    Analysis.BriefDescriptionWeight(pv, FirstDate, SecondDate, DGV_Brief);
                    SystemArgs.PrintLog("Выполнение анализа по параметру: Вес | Описание");
                    break;
                case 3://Вес | Номер ТС
                    Analysis.BriefNumTSWeight(pv, FirstDate, SecondDate, DGV_Brief);
                    SystemArgs.PrintLog("Выполнение анализа по параметру: Вес | Номер ТС");
                    break;
                case 4://Количество | Бригада
                    Analysis.BriefBrigadeCount(pv, FirstDate, SecondDate, DGV_Brief);
                    SystemArgs.PrintLog("Выполнение анализа по параметру: Количество | Бригада");
                    break;
                case 5://Количество | Номер ТС
                    Analysis.BriefNumTSCount(pv, FirstDate, SecondDate, DGV_Brief);
                    SystemArgs.PrintLog("Выполнение анализа по параметру: Количество | Номер ТС");
                    break;
                case 6://Количество | Описание
                    Analysis.BriefDescriptionCount(pv, FirstDate, SecondDate, DGV_Brief);
                    SystemArgs.PrintLog("Выполнение анализа по параметру: Количество | Описание");
                    break;
            }
        }

        private void BriefAnalysis_F_Load(object sender, EventArgs e)
        {
            TypeArgumnts_CB.DataSource = ListParams;
            DGV_Brief.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Export_B.Enabled = false;
        }

        private void TypeArgumnts_CB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Show_B_Click(object sender, EventArgs e)
        {
            SystemArgs.PrintLog("Запуск процедуры получения анализа");
            GetAnalisys(TypeArgumnts_CB.SelectedIndex);
            Export_B.Enabled = true;
            SystemArgs.PrintLog("Процедура получения анализа завершена");
        }

        private void DGV_Brief_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.SelectionBackColor = Color.FromArgb(220, 217, 217);
            e.CellStyle.SelectionForeColor = Color.Black;
        }

        private void DGV_Brief_SelectionChanged(object sender, EventArgs e)
        {
            DGV_Brief.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //Выделение строки
        }

        private void BriefAnalysis_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            Analysis.DisposeField();
            SystemArgs.PrintLog("Очистка памяти после выполнения анализа успешно завершена");
        }
    }
}
