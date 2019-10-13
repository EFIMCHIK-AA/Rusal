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
    public partial class SettingConfiguration_F : Form
    {
        public SettingConfiguration_F()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        String []ListParams = {"Номер бригады", "Номер смены", "Марка сплава", "Диаметер",
                                  "Описание", "Тип дефекта", "Номет ТС", "Место дефекта в производственном процессе",
                                  "Отметка о выполнении" };

        private void SettingConfiguration_F_Load(object sender, EventArgs e)
        {
            Params_CB.DataSource = ListParams;
        }

        object CurrentArgument = null;
        String NameTable = String.Empty;
        String NameColumn = String.Empty;

        private void RequestStart(bool Type, String Name)
        {
            if (CurrentArgument is ListBrigades)
            {
                ListBrigades Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as ListBrigades;

                if (Type)
                {
                    Operations.RequestChange(Temp.ID, Name, NameTable, NameColumn);
                }
                else
                {
                    Operations.RequestDelete(Temp.ID, NameTable);
                }
            }
            else if (CurrentArgument is ListSmen)
            {
                ListSmen Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as ListSmen;

                if (Type)
                {
                    Operations.RequestChange(Temp.ID, Name, NameTable, NameColumn);
                }
                else
                {
                    Operations.RequestDelete(Temp.ID, NameTable);
                }
            }
            else if (CurrentArgument is TypesAlloy)
            {
                TypesAlloy Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as TypesAlloy;

                if (Type)
                {
                    Operations.RequestChange(Temp.ID, Name, NameTable, NameColumn);
                }
                else
                {
                    Operations.RequestDelete(Temp.ID, NameTable);
                }
            }
            else if (CurrentArgument is DiameterIngot)
            {
                TypesAlloy Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as TypesAlloy;

                if (Type)
                {
                    Operations.RequestChange(Temp.ID, Name, NameTable, NameColumn);
                }
                else
                {
                    Operations.RequestDelete(Temp.ID, NameTable);
                }
            }
            else if (CurrentArgument is DescriptionDefect)
            {
                DescriptionDefect Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as DescriptionDefect;

                if (Type)
                {
                    Operations.RequestChange(Temp.ID, Name, NameTable, NameColumn);
                }
                else
                {
                    Operations.RequestDelete(Temp.ID, NameTable);
                }
            }
            else if (CurrentArgument is TypesDefect)
            {
                TypesDefect Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as TypesDefect;

                if (Type)
                {
                    Operations.RequestChange(Temp.ID, Name, NameTable, NameColumn);
                }
                else
                {
                    Operations.RequestDelete(Temp.ID, NameTable);
                }
            }
            else if (CurrentArgument is TSN)
            {
                TSN Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as TSN;

                if (Type)
                {
                    Operations.RequestChange(Temp.ID, Name, NameTable, NameColumn);
                }
                else
                {
                    Operations.RequestDelete(Temp.ID, NameTable);
                }
            }
            else if (CurrentArgument is DefectProduction)
            {
                DefectProduction Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as DefectProduction;

                if (Type)
                {
                    Operations.RequestChange(Temp.ID, Name, NameTable, NameColumn);
                }
                else
                {
                    Operations.RequestDelete(Temp.ID, NameTable);
                }
            }
            else
            {
                ProgressMark Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as ProgressMark;

                if (Type)
                {
                    Operations.RequestChange(Temp.ID, Name, NameTable, NameColumn);
                }
                else
                {
                    Operations.RequestDelete(Temp.ID, NameTable);
                }
            }

            RefreshDataSource();
        }

        private void ShowPosition(Int32 Key)
        {
            Spisok_LB.DataSource = null;
            Spisok_LB.ValueMember = "Name";
            Spisok_LB.Items.Clear();

            switch (Key)
            {
                case 0:
                    Spisok_LB.DataSource = SystemArgs.Brigades;
                    NameTable = "ListBrigades";
                    NameColumn = "N_Brigade";
                    break;
                case 1:
                    Spisok_LB.DataSource = SystemArgs.Smeny;
                    NameTable = "ListSmen";
                    NameColumn = "N_Smena";
                    break;
                case 2:
                    Spisok_LB.DataSource = SystemArgs.TypesAlloy;
                    NameTable = "TypesAlloy";
                    NameColumn = "N_Alloy";
                    break;
                case 3:
                    Spisok_LB.DataSource = SystemArgs.Diameters;
                    NameTable = "DiameterIngot";
                    NameColumn = "N_Diameter";
                    break;
                case 4:
                    Spisok_LB.DataSource = SystemArgs.Descriptions;
                    NameTable = "DescriptionDefect";
                    NameColumn = "N_Description";
                    break;
                case 5:
                    Spisok_LB.DataSource = SystemArgs.TypesDefect;
                    NameTable = "TypesDefect";
                    NameColumn = "N_Defect";
                    break;
                case 6:
                    Spisok_LB.DataSource = SystemArgs.TSN;
                    NameTable = "TSN";
                    NameColumn = "N_TSN";
                    break;
                case 7:
                    Spisok_LB.DataSource = SystemArgs.DefectLocProduction;
                    NameTable = "DefectLocationProduction";
                    NameColumn = "N_Location";
                    break;
                case 8:
                    Spisok_LB.DataSource = SystemArgs.ProgressMark;
                    NameTable = "ProgressMark";
                    NameColumn = "N_ProgressMark";
                    break;
            }
        }

        private void Params_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPosition(Params_CB.SelectedIndex);
        }

        private void Spisok_LB_Click(object sender, EventArgs e)
        {

        }

        private void RefreshDataSource()
        {
            Params_CB.DataSource = null;
            Params_CB.DataSource = ListParams;
        }

        private void Add_B_Click(object sender, EventArgs e)
        {
            CurrentArgument = Spisok_LB.SelectedItem;
            DescriptionArg_F Dialog = new DescriptionArg_F(CurrentArgument);

            Dialog.Name_L.Text = "Добавление аргумента";
            Dialog.ID_TB.Text = "Формируется после запроса";

            if(Dialog.ShowDialog() == DialogResult.OK)
            {
                Operations.RequestAdd(Dialog.Value_TB.Text.Trim(), NameTable, NameColumn);
                RefreshDataSource();
            }
        }

        private void Change_B_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Изменение аргумента приведет к изменению всех позиций, которые ссылаются на выбранный аргумент. Продолжить?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                CurrentArgument = Spisok_LB.SelectedItem;
                DescriptionArg_F Dialog = new DescriptionArg_F(CurrentArgument);

                Dialog.Name_L.Text = "Изменение аргумента";
                Dialog.ID_TB.Text = (Spisok_LB.Items[Spisok_LB.SelectedIndex] as BaseDictionary).ID.ToString();


                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    CurrentArgument = Spisok_LB.SelectedItem;
                    RequestStart(true, Dialog.Value_TB.Text.Trim());
                }
            }
        }

        private void Delete_B_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Удаление аргумента приведет к удалению всех позиций, которые ссылаются на выбранный аргумент. Продолжить?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                RequestStart(false, null);
            }
        }
    }
}
