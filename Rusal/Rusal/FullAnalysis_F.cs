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
        Int32 IndexExport; // Индекс Экспорта

        private void GetAnalisys(Int32 Key)
        {
            FirstDate = FirstDate_CM.SelectionStart;
            SecondDate = SecondDate_CM.SelectionStart;
            String Param = ListArgumnts_CB.SelectedItem.ToString(); //Параметр в строковом представлении

            switch (Key)
            {
                case 0: //Бригады
                    Analysis.FullBrigadeWeight(FirstDate, SecondDate, Param, plotView1, plotView2, dataGridView1);
                    break;
                case 1: //Диаметр
                    Analysis.FullDiameterWeight(FirstDate, SecondDate, Param, plotView1, plotView2, dataGridView1);
                    break;
                case 2://Описание
                    Analysis.FullDiscriptionWeight(FirstDate, SecondDate, Param, plotView1, plotView2, dataGridView1);
                    break;
                case 3://Номер ТС
                    Analysis.FullNumTSWeight(FirstDate, SecondDate, Param, plotView1, plotView2, dataGridView1);
                    break;
            }
        }

        private void GetExport(Int32 Key)
        {
            switch (Key)
            {
                case 0: //Бригады
                    //Вызвать метод
                    break;
                case 1: //Диаметр
                        //Вызвать метод
                    break;
                case 2://Описание
                       //Вызвать метод
                    break;
                case 3://Номер ТС
                       //Вызвать метод
                    break;
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
            GetAnalisys(TypeArgument_CB.SelectedIndex);
            IndexExport = TypeArgument_CB.SelectedIndex;
        }

        private void FullAnalysis_F_Load(object sender, EventArgs e)
        {
            TypeArgument_CB.DataSource = ListParams;
        }

        private void TypeArgument_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPosition(TypeArgument_CB.SelectedIndex);
        }

        private void Export_B_Click(object sender, EventArgs e)
        {
            //GetExport(Индекс);
        }
    }
}
