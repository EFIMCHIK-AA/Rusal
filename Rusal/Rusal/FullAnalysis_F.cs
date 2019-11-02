using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rusal
{
    public partial class FullAnalysis_F : Form
    {
        public FullAnalysis_F()
        {
            InitializeComponent();
        }

        String[] ListParams = { "Номер бригады", "Диаметер", "Описание", "Номет ТС" };
        DateTime FirstDate; //Начало периода
        DateTime SecondDate; //Конец периода

        private void GetAnalisys(Int32 Key)
        {
            FirstDate = FirstDate_CM.SelectionStart;
            SecondDate = SecondDate_CM.SelectionStart;
            String Param = ListArgumnts_CB.SelectedItem.ToString(); //Параметр в строковом представлении

            if(Param != String.Empty)
            {
                switch (Key)
                {
                    case 0: //Бригады
                        Analysis.FullBrigadeWeight(FirstDate, SecondDate, Param, plotView1, plotView2, dataGridView1);
                        SystemArgs.PrintLog("Выполнение анализа по параметрам: Бригады");
                        break;
                    case 1: //Диаметр
                        Analysis.FullDiameterWeight(FirstDate, SecondDate, Param, plotView1, plotView2, dataGridView1);
                        SystemArgs.PrintLog("Выполнение анализа по параметрам: Диаметр");
                        break;
                    case 2://Описание
                        Analysis.FullDiscriptionWeight(FirstDate, SecondDate, Param, plotView1, plotView2, dataGridView1);
                        SystemArgs.PrintLog("Выполнение анализа по параметрам: Описание");
                        break;
                    case 3://Номер ТС
                        Analysis.FullNumTSWeight(FirstDate, SecondDate, Param, plotView1, plotView2, dataGridView1);
                        SystemArgs.PrintLog("Выполнение анализа по параметрам: Номер ТС");
                        break;
                }

                Export_B.Enabled = true;
            }
        }

        private void ShowPosition(Int32 Key)
        {
            ListArgumnts_CB.DataSource = null;
            ListArgumnts_CB.ValueMember = "Name";

            switch (Key)
            {
                case 0:
                    ListArgumnts_CB.DataSource = SystemArgs.Brigades;
                    break;
                case 1:
                    ListArgumnts_CB.DataSource = SystemArgs.Diameters;
                    break;
                case 2:
                    ListArgumnts_CB.DataSource = SystemArgs.Descriptions;
                    break;
                case 3:
                    ListArgumnts_CB.DataSource = SystemArgs.TSN;
                    break;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SystemArgs.PrintLog("Запуск процедуры получения анализа");
            GetAnalisys(TypeArgument_CB.SelectedIndex);
            SystemArgs.PrintLog("Процедура получения анализа завершена");
        }

        private void FullAnalysis_F_Load(object sender, EventArgs e)
        {
            TypeArgument_CB.DataSource = ListParams;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Export_B.Enabled = false;
        }

        private void TypeArgument_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPosition(TypeArgument_CB.SelectedIndex);
        }

        private void Export_B_Click(object sender, EventArgs e)
        {
            SystemArgs.PrintLog("Запуск процедуры экспорта данных анализа");
            Analysis.ExcelFullExport(FirstDate, SecondDate);
            SystemArgs.PrintLog("Процедуры экспорта данных анализа завершена");
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.SelectionBackColor = Color.FromArgb(220, 217, 217);
            e.CellStyle.SelectionForeColor = Color.Black;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //Выделение строки
        }

        private void FullAnalysis_F_FormClosing(object sender, FormClosingEventArgs e)
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

        private void FullAnalysis_F_KeyDown(object sender, KeyEventArgs e)
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
