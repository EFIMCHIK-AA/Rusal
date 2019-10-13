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

        private void Button1_Click(object sender, EventArgs e)
        {
            Analysis.FullDiameterWeight(new DateTime(2019, 10, 1), new DateTime(2019, 10, 30), 123);
            Analysis.GetDataDGV(dataGridView1);
        }
    }
}
