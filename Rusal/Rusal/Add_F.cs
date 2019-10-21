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
                    if(Description_CB.SelectedIndex == -1)
                    {
                        Description_CB.Focus();
                        Error = "Описание дефекта должно содержать значение";
                        throw new Exception(Error);
                    }

                    if (Diameter_CB.SelectedIndex == -1)
                    {
                        Diameter_CB.Focus();
                        Error = "Диаметер дефекта должен содержать значение";
                        throw new Exception(Error);
                    }

                    if (LocationProduction_CB.SelectedIndex == -1)
                    {
                        LocationProduction_CB.Focus();
                        Error = "Место дефекта в производстве должно содержать значение";
                        throw new Exception(Error);
                    }

                    if (NumBrigade_CB.SelectedIndex == -1)
                    {
                        NumBrigade_CB.Focus();
                        Error = "Номер бригады должен содержать значение";
                        throw new Exception(Error);
                    }

                    if (NumSmeny_CB.SelectedIndex == -1)
                    {
                        NumSmeny_CB.Focus();
                        Error = "Номер смены должен содержать значение";
                        throw new Exception(Error);
                    }

                    if (NumTS_CB.SelectedIndex == -1)
                    {
                        NumTS_CB.Focus();
                        Error = "Номер ТС должен содержать значение";
                        throw new Exception(Error);
                    }

                    if (ProgressMark_CB.SelectedIndex == -1)
                    {
                        ProgressMark_CB.Focus();
                        Error = "Прогресс выполнения должен содержать значение";
                        throw new Exception(Error);
                    }

                    if (TypeAlloy_CB.SelectedIndex == -1)
                    {
                        TypeAlloy_CB.Focus();
                        Error = "Марка сплава должна содержать значение";
                        throw new Exception(Error);
                    }

                    if (TypeDefect_CB.SelectedIndex == -1)
                    {
                        TypeDefect_CB.Focus();
                        Error = "Тип дефекта должен содержать значение";
                        throw new Exception(Error);
                    }

                    if (String.IsNullOrEmpty(NumMelt_TB.Text))
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


                    if (String.IsNullOrEmpty(Correction_TB.Text))
                    {
                        Correction_TB.Focus();
                        Error = "Поле коррекции должно содержать значение";
                        throw new Exception(Error);
                    }


                    if (String.IsNullOrEmpty(Reason_TB.Text))
                    {
                        Reason_TB.Focus();
                        Error = "Поле коррекции должно содержать значение";
                        throw new Exception(Error);
                    }

                    SystemArgs.PrintLog("Данные модификации позиции успешно получены");
                }
                catch(Exception)
                {
                    MessageBox.Show(Error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SystemArgs.PrintLog($"Ошибка получения параметров модификации позиции: {Error}");
                    e.Cancel = true;
                }
            }
        }

        private void Add_F_Load(object sender, EventArgs e)
        {
        }

        private void West_CB_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
