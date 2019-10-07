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
    public partial class Add_F : Form
    {
        public Add_F()
        {
            InitializeComponent();
        }


        private void Add_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult == DialogResult.OK)
            {
                String Error = String.Empty;

                try
                {
                    if(String.IsNullOrEmpty(NumMelt_TB.Text))
                    {
                        NumMelt_TB.Focus();
                        Error = "Поле номера плавки должно содержать значение";
                        throw new Exception(Error);
                    }

                    if (String.IsNullOrEmpty(Address_TB.Text))
                    {
                        Address_TB.Focus();
                        Error = "Поле адреса должно содержать значение";
                        throw new Exception(Error);
                    }

                    if (String.IsNullOrEmpty(Correction_TB.Text))
                    {
                        Correction_TB.Focus();
                        Error = "Поле коррекции должно содержать значение";
                        throw new Exception(Error);
                    }

                    if (String.IsNullOrEmpty(Count_TB.Text))
                    {
                        Count_TB.Focus();
                        Error = "Поле количества слитков должно содержать значение";
                        throw new Exception(Error);
                    }

                    try
                    {
                        Int64 Temp = Convert.ToInt64(Count_TB.Text.Trim());
                    }
                    catch
                    {
                        Count_TB.Focus();
                        Error = "Значение количества должно состоять из цифр";
                        throw;
                    }

                    if (String.IsNullOrEmpty(Weight_TB.Text))
                    {
                        Weight_TB.Focus();
                        Error = "Поле веса слитков должно содержать значение";
                        throw new Exception(Error);
                    }

                    try
                    {
                        Double Temp = Convert.ToDouble(Weight_TB.Text.Trim());
                    }
                    catch
                    {
                        Weight_TB.Focus();
                        Error = "Значение веса слитков должно состоять из цифр";
                        throw;
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show(Error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void Add_F_Load(object sender, EventArgs e)
        {
        }
    }
}
