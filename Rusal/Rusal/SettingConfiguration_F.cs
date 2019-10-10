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

        private void SettingConfiguration_F_Load(object sender, EventArgs e)
        {
            String[] ListParams = {"Номер бригады", "Номер смены", "Марка сплава", "Диаметер",
                                  "Описание", "Тип дефекта", "Номет ТС", "Место дефекта в производственном процессе",
                                  "Отметка о выполнении" };

            Params_CB.DataSource = ListParams;
        }

        object CurrentArgument = null;

        delegate void Request(Int64 ID, String Name, String NameTable, String NameColumn);

        private void RequestStart(Request Request)
        {
            if (CurrentArgument is ListBrigades)
            {
                ListBrigades Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as ListBrigades;
                Request(Temp.ID, Temp.Name);
            }
            else if (CurrentArgument is ListSmen)
            {
                ListSmen Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as ListSmen;
                Request(Temp.ID, Temp.Name);
            }
            else if (CurrentArgument is TypesAlloy)
            {
                TypesAlloy Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as TypesAlloy;
                Request(Temp.ID, Temp.Name);
            }
            else if (CurrentArgument is DiameterIngot)
            {
                TypesAlloy Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as TypesAlloy;
                Request(Temp.ID, Temp.Name);
            }
            else if (CurrentArgument is DescriptionDefect)
            {
                DescriptionDefect Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as DescriptionDefect;
                Request(Temp.ID, Temp.Name);
            }
            else if (CurrentArgument is TypesDefect)
            {
                TypesDefect Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as TypesDefect;
                Request(Temp.ID, Temp.Name);
            }
            else if (CurrentArgument is TSN)
            {
                TSN Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as TSN;
                Request(Temp.ID, Temp.Name);
            }
            else if (CurrentArgument is DefectProduction)
            {
                DefectProduction Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as DefectProduction;
                Request(Temp.ID, Temp.Name);
            }
            else
            {
                ProgressMark Temp = Spisok_LB.Items[Spisok_LB.SelectedIndex] as ProgressMark;
                Request(Temp.ID, Temp.Name);
            }
        }

        private void ShowPosition(Int32 Key)
        {
            Spisok_LB.ValueMember = "Name";
           
            switch (Key)
            {
                case 0:
                    Spisok_LB.DataSource = SystemArgs.Brigades;
                    break;
                case 1:
                    Spisok_LB.DataSource = SystemArgs.Smeny;
                    break;
                case 2:
                    Spisok_LB.DataSource = SystemArgs.TypesAlloy;
                    break;
                case 3:
                    Spisok_LB.DataSource = SystemArgs.Diameters;
                    break;
                case 4:
                    Spisok_LB.DataSource = SystemArgs.Descriptions;
                    break;
                case 5:
                    Spisok_LB.DataSource = SystemArgs.TypesDefect;
                    break;
                case 6:
                    Spisok_LB.DataSource = SystemArgs.TSN;
                    break;
                case 7:
                    Spisok_LB.DataSource = SystemArgs.DefectLocProduction;
                    break;
                case 8:
                    Spisok_LB.DataSource = SystemArgs.ProgressMark;
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

        private void Add_B_Click(object sender, EventArgs e)
        {
            DescriptionArg_F Dialog = new DescriptionArg_F();

            Dialog.Name_L.Text = "Добавление аргумента";

            if(Dialog.ShowDialog() == DialogResult.OK)
            {
                Request Request = Operations.RequestAdd;
            }
        }
    }
}
