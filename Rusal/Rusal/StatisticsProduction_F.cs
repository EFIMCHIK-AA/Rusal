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
    public partial class StatisticsProduction_F : Form
    {
        public StatisticsProduction_F()
        {
            InitializeComponent();
        }

        DateTime FirstDate;//Начало периода
        DateTime SecondDate; //Конец периода

        private void StatisticsProduction_F_Load(object sender, EventArgs e)
        {
            Position_DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Show_B_Click(object sender, EventArgs e)
        {
            FirstDate = First_MC.SelectionStart.Date;
            SecondDate = Second_MC.SelectionStart.Date;
        }

        private void StatisticsProduction_F_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Show_B.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Exit_B.PerformClick();
            }
        }

        private void StatisticsProduction_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Завершить просмотр статистики?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Analysis.DisposeField();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
