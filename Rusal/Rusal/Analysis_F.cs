﻿using System;
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
    public partial class Analysis_F : Form
    {
        public Analysis_F()
        {
            InitializeComponent();
        }

        private void Export_B_Click(object sender, EventArgs e)
        {
            Analysis.ExcelExport(new DateTime(2019,10,1),new DateTime(2019,10,30));
        }
    }
}
