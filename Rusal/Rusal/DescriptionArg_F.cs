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
    public partial class DescriptionArg_F : Form
    {
        public DescriptionArg_F(object Current)
        {
            InitializeComponent();
            CurrentObject = Current;
        }

        object CurrentObject;

        private void DescriptionArg_F_Load(object sender, EventArgs e)
        {

        }

        private void DescriptionArg_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult == DialogResult.OK)
            {
                String Error = String.Empty;
                try
                {
                    if (String.IsNullOrEmpty(ID_TB.Text))
                    {
                        ID_TB.Focus();
                        Error = "В поле ID должно быть значение";
                        throw new Exception(Error);
                    }

                    if (String.IsNullOrEmpty(Value_TB.Text))
                    {
                        Value_TB.Focus();
                        Error = "В поле значение должны быть данные";
                        throw new Exception(Error);
                    }

                    if(CurrentObject is DiameterIngot)
                    {
                        try
                        {
                            Double Temp = Convert.ToDouble(Value_TB.Text.Trim());
                        }
                        catch
                        {
                            Value_TB.Focus();
                            Error = "Поле значение должно содержать числовое значение";
                            throw;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(Error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }

            }
        }
    }
}
