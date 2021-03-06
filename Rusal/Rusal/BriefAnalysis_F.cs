﻿using System;
using Equin.ApplicationFramework;
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
            Analysis.ExcelBriefExport(FirstDate, SecondDate,Temp);
            SystemArgs.PrintLog("Процедура экспорта данных анализа завершена");
        }

        DateTime FirstDate;//Начало периода
        DateTime SecondDate; //Конец периода
        BindingListView<WrapBriefData> Temp; //Обертка для выгрузки
        List<WrapBriefData> Data; //Результаты выгрузки

        String[] ListParams = { "Вес | Бригада", "Вес | Диаметр", "Вес | Описание", "Вес | Номер ТС", "Количество | Бригада", "Количество | Номер ТС", "Количество | Описание"};

        private void GetAnalisys(Int32 Key)
        {
            FirstDate = FirstDate_CM.SelectionStart.Date;
            SecondDate = SecondDate_CM.SelectionStart.Date;

            switch (Key)
            {
                case 0: //Вес | Бригада
                    Data = Analysis.BriefBrigadeWeight(pv, FirstDate, SecondDate);
                    DGV_Brief.Columns[0].HeaderText = "Бригада";
                    DGV_Brief.Columns[1].HeaderText = "Брак, тонн";
                    DGV_Brief.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    SystemArgs.PrintLog("Выполнение анализа по параметру: Вес | Бригада");
                    break;
                case 1: //Вес | Диаметр
                    Data = Analysis.BriefDiametrWeight(pv, FirstDate, SecondDate);
                    DGV_Brief.Columns[0].HeaderText = "Диаметр";
                    DGV_Brief.Columns[1].HeaderText = "Брак, тонн";
                    DGV_Brief.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    SystemArgs.PrintLog("Выполнение анализа по параметру: Вес | Диаметр");
                    break;
                case 2://Вес | Описание
                    Data = Analysis.BriefDescriptionWeight(pv, FirstDate, SecondDate);
                    DGV_Brief.Columns[0].HeaderText = "Дефект";
                    DGV_Brief.Columns[1].HeaderText = "Брак, тонн";
                    DGV_Brief.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    SystemArgs.PrintLog("Выполнение анализа по параметру: Вес | Описание");
                    break;
                case 3://Вес | Номер ТС
                    Data = Analysis.BriefNumTSWeight(pv, FirstDate, SecondDate);
                    DGV_Brief.Columns[0].HeaderText = "Номер ТС";
                    DGV_Brief.Columns[1].HeaderText = "Брак, тонн";
                    DGV_Brief.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    SystemArgs.PrintLog("Выполнение анализа по параметру: Вес | Номер ТС");
                    break;
                case 4://Количество | Бригада
                    Data = Analysis.BriefBrigadeCount(pv, FirstDate, SecondDate);
                    DGV_Brief.Columns[0].HeaderText = "Бригада";
                    DGV_Brief.Columns[1].HeaderText = "Количество";
                    DGV_Brief.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    SystemArgs.PrintLog("Выполнение анализа по параметру: Количество | Бригада");
                    break;
                case 5://Количество | Номер ТС
                    Data = Analysis.BriefNumTSCount(pv, FirstDate, SecondDate);
                    DGV_Brief.Columns[0].HeaderText = "Номер ТС";
                    DGV_Brief.Columns[1].HeaderText = "Количество";
                    DGV_Brief.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    SystemArgs.PrintLog("Выполнение анализа по параметру: Количество | Номер ТС");
                    break;
                case 6://Количество | Описание
                    Data = Analysis.BriefDescriptionCount(pv, FirstDate, SecondDate);
                    DGV_Brief.Columns[0].HeaderText = "Дефект";
                    DGV_Brief.Columns[1].HeaderText = "Количество";
                    DGV_Brief.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    SystemArgs.PrintLog("Выполнение анализа по параметру: Количество | Описание");
                    break;
            }
            Temp = new BindingListView<WrapBriefData>(Data);
            DGV_Brief.DataSource = Temp;
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
            if (MessageBox.Show("Завершить просмотр анализа?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Analysis.DisposeField();
                SystemArgs.PrintLog("Очистка памяти после выполнения анализа успешно завершена");
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void BriefAnalysis_F_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Show_B.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                Export_B.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Exit_B.PerformClick();
            }
        }
    }
}
