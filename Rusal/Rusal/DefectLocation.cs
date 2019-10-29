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
    public partial class DefectLocation : Form
    {
        public DefectLocation()
        {
            InitializeComponent();
        }

        private void DefectLocation_Load(object sender, EventArgs e)
        {

        }

        private void North_CB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void North_CB_Click(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                ((CheckBox)sender).Checked = !((CheckBox)sender).Checked;
            }
        }
    }
}
