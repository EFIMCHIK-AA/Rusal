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
    public partial class StatisticsIngot_F : Form
    {
        public StatisticsIngot_F()
        {
            InitializeComponent();
        }

        DateTime FirstDate;//Начало периода
        DateTime SecondDate; //Конец периода

        private void StatisticsIngot_F_FormClosing(object sender, FormClosingEventArgs e)
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

        private void StatisticsIngot_F_Load(object sender, EventArgs e)
        {

        }

        private void OK_B_Click(object sender, EventArgs e)
        {
            FirstDate = First_MC.SelectionStart.Date;
            SecondDate = Second_MC.SelectionStart.Date;
        }

        private void StatisticsIngot_F_KeyDown(object sender, KeyEventArgs e)
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
    }
}
