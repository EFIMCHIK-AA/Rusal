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
    public partial class CheckParam_F : Form
    {
        public CheckParam_F()
        {
            InitializeComponent();
        }

        private void CheckParam_F_Load(object sender, EventArgs e)
        {
            Files.GetParamDB();
        }
    }
}
