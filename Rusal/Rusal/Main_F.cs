using System;
using Equin.ApplicationFramework;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Rusal
{
    public partial class Main_F : Form
    {
        public Main_F()
        {
            InitializeComponent();
        }

        private void EnableField()
        {
            if (Position_DGV.RowCount == 0)
            {
                Change_TSB.Enabled = false;
                Delete_TSB.Enabled = false;
                изменитьToolStripMenuItem.Enabled = false;
                удалитьToolStripMenuItem.Enabled = false;
                DefectLocation_B.Enabled = false;
                ChangeStatus_B.Enabled = false;
            }
            else
            {
                Change_TSB.Enabled = true;
                Delete_TSB.Enabled = true;
                изменитьToolStripMenuItem.Enabled = true;
                удалитьToolStripMenuItem.Enabled = true;
                DefectLocation_B.Enabled = true;
                ChangeStatus_B.Enabled = true;
            }
        }

        private void Main_F_Load(object sender, EventArgs e)
        {
            CheckParam_F Dialog = new CheckParam_F();
            Operations.StatusConnectAsync(this);
            Dialog.Show();
            Thread.Sleep(3500);
            Dialog.Close();

            if (SystemArgs.StatusConnect)
            {
                Position_DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GetAllData();
                ShowPosition(SystemArgs.Positions);

                EnableField();
            }
            else
            {
                MessageBox.Show("Не удалось подключиться к базе данных. Запуск программного обеспечения остановлен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void ShowPosition(List<Position> List)
        {
            SystemArgs.View = new BindingListView<Position>(List);

            Position_DGV.AutoGenerateColumns = false;
            Position_DGV.DataSource = SystemArgs.View;

            CountPos_TB.Text = SystemArgs.View.Count.ToString();
        }

        private void GetAllData()
        {
            ProgressBar_PB.Value = 2;

            Operations.GetArguments();
            Operations.GetPosition();

            ProgressBar_PB.Value = 100;
        }

        private void Exit_B_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Search_TSB_Click(object sender, EventArgs e)
        {
            if (SystemArgs.StatusConnect)
            {
                if (!String.IsNullOrEmpty(Search_TSTB.Text.Trim()))
                {
                    SystemArgs.ModePosition = true;

                    String SearchText = Search_TSTB.Text.Trim();

                    SystemArgs.Result = Operations.ResultSearch(SearchText);

                    if (SystemArgs.Result.Count > 0)
                    {
                        ShowPosition(SystemArgs.Result);
                    }
                    else
                    {
                        Search_TSTB.Focus();
                        MessageBox.Show("Поиск не дал результатов", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    Search_TSTB.Focus();
                    MessageBox.Show("Для поиска необходимо ввести значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetSearch()
        {
            Search_TSTB.Text = String.Empty;

            SystemArgs.ModePosition = false;

            SystemArgs.Result.Clear();
        }

        private void Reset_TSB_Click(object sender, EventArgs e)
        {
            ResetSearch();
            ShowPosition(SystemArgs.Positions);
        }

        private void базаДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingDB_F Dialog = new SettingDB_F();

            Dialog.Name_TB.Text = SystemArgs.NameDB;
            Dialog.Server_TB.Text = SystemArgs.IPDB;
            Dialog.Owner_TB.Text = SystemArgs.OwnerDB;
            Dialog.Port_TB.Text = SystemArgs.PortDB;
            Dialog.Password_TB.Text = SystemArgs.PasswordDB;
            Dialog.Path_TB.Text = Files.GetBackupPath();

            if (Dialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void конфигурацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingConfiguration_F Dialog = new SettingConfiguration_F();

            if(Dialog.ShowDialog() == DialogResult.OK)
            {
                Operations.GetPosition();
                ShowPosition(SystemArgs.Positions);
            }
        }

        private void ClearField()
        {
            Date_TB.Text = String.Empty;
            NumBrigade_TB.Text = String.Empty;
            NumSmeny_TB.Text = String.Empty;
            Melt_TB.Text = String.Empty;
            NumTC_TB.Text = String.Empty;
            Address_TB.Text = String.Empty;
            Description_TB.Text = String.Empty;
            Type_TB.Text = String.Empty;
            Count_TB.Text = String.Empty;
            Weight_TB.Text = String.Empty;
            Diameter_TB.Text = String.Empty;
            Reason_TB.Text = String.Empty;
            Correction_TB.Text = String.Empty;
            StatusCorrection_TB.Text = String.Empty;
            DefectLocProduction_TB.Text = String.Empty;

            DefectLocation_B.Enabled = false;

            StatusCorrection_TB.BackColor = Color.FromArgb(249, 249, 249);
        }

        private void обычныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BriefAnalysis_F Dialog = new BriefAnalysis_F();

            if (Dialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void расширенныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FullAnalysis_F Dialog = new FullAnalysis_F();

            if (Dialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void заПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SystemArgs.StatusConnect)
            {
                Report_F Dialog = new Report_F();

                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    Reports.ByDate(Dialog.First_MC.SelectionStart, Dialog.Second_MC.SelectionStart);
                }
            }
            else
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatePosition();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePosition();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletePosition();
        }

        private void Position_DGV_SelectionChanged(object sender, EventArgs e)
        {
            EnableField();

            if (Position_DGV.CurrentCell == null)
            {
                return;
            }

            if (Position_DGV.CurrentCell.RowIndex > SystemArgs.View.Count - 1)
            {
                return;
            }

            Position_DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Position Temp = SystemArgs.View.ElementAt(Position_DGV.CurrentCell.RowIndex);

            Date_TB.Text = Temp.DateFormation.ToShortDateString();
            NumBrigade_TB.Text = Temp.NumBrigade.Name;
            NumSmeny_TB.Text = Temp.NumSmeny.Name;
            Melt_TB.Text = Temp.NumMelt;
            NumTC_TB.Text = Temp.NumTS.Name;
            Address_TB.Text = Temp.Address;
            Description_TB.Text = Temp.Description.Name;
            Type_TB.Text = Temp.Defect.Name;
            Count_TB.Text = Temp.Count.ToString();
            Weight_TB.Text = Temp.Weight.ToString();
            Diameter_TB.Text = Temp.Diameter.Name.ToString();
            Reason_TB.Text = Temp.Reason;
            Correction_TB.Text = Temp.Correction;
            StatusCorrection_TB.Text = Temp.ProgressMark.Name.ToString();
            DefectLocProduction_TB.Text = Temp.DefectLocProduction.Name;

            if (Temp.ProgressMark.Name == "Выполнено")
            {
                StatusCorrection_TB.BackColor = Color.FromArgb(6, 176, 37);
                ChangeStatus_B.Text = "Отменить";
            }
            else
            {
                StatusCorrection_TB.BackColor = Color.FromArgb(255, 144, 0);
                ChangeStatus_B.Text = "Подтвердить";
            }
        }

        private void Position_DGV_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.SelectionBackColor = Color.FromArgb(220, 217, 217);
            e.CellStyle.SelectionForeColor = Color.Black;
        }

        private void DefectLocation_B_Click(object sender, EventArgs e)
        {
            DefectLocation Dialog = new DefectLocation();

            if(SystemArgs.View.Count > 0)
            {
                if (SystemArgs.Positions[Position_DGV.CurrentCell.RowIndex].DefectLocIngot != null)
                {
                    String[] DefectLocIngot = SystemArgs.Positions[Position_DGV.CurrentCell.RowIndex].DefectLocIngot.Split('_');

                    foreach (String Name in DefectLocIngot)
                    {
                        foreach (Control TypeControl in Dialog.Controls)
                        {
                            if (TypeControl is CheckBox)
                            {
                                if (TypeControl.Text == Name)
                                {
                                    (TypeControl as CheckBox).Checked = true;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }


            if (Dialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void CreatePosition()
        {
            if (SystemArgs.StatusConnect)
            {
                Operations.AddPosition();

                ResetSearch();

                ShowPosition(SystemArgs.Positions);
            }
            else
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_TSB_Click(object sender, EventArgs e)
        {
            CreatePosition();
        }

        private void ChangePosition()
        {
            if (SystemArgs.StatusConnect)
            {
                if (Position_DGV.CurrentCell != null)
                {
                    Operations.ChangePosition((Position)SystemArgs.View[Position_DGV.CurrentCell.RowIndex]);
                    ResetSearch();

                    ShowPosition(SystemArgs.Positions);
                }
            }
            else
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Change_TSB_Click(object sender, EventArgs e)
        {
            ChangePosition();
        }

        private void DeletePosition()
        {
            if (SystemArgs.StatusConnect)
            {
                if (Position_DGV.CurrentCell != null)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить позицию?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Operations.DeletePosition((Position)SystemArgs.View[Position_DGV.CurrentCell.RowIndex]);
                        ResetSearch();

                        ShowPosition(SystemArgs.Positions);
                        Position_DGV.ClearSelection();
                        ClearField();
                    }
                }
            }
            else
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            EnableField();
        }

        private void Delete_TSB_Click(object sender, EventArgs e)
        {
            DeletePosition();
        }

        private void ChangeStatus_B_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите изменить статус выполнения корректирующего действия?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Position Temp = SystemArgs.View.ElementAt(Position_DGV.CurrentCell.RowIndex);

                if(Temp.ProgressMark.Name == "Не выполнено")
                {
                    Operations.UpdateStatusCorrection(Temp.ID, "Выполнено");
                    SystemArgs.Positions.Remove(Temp);
                    Temp.ProgressMark.Name = "Выполнено";
                    SystemArgs.Positions.Add(Temp);
                }
                else if(Temp.ProgressMark.Name == "Выполнено")
                {
                    Operations.UpdateStatusCorrection(Temp.ID, "Не выполнено");
                    SystemArgs.Positions.Remove(Temp);
                    Temp.ProgressMark.Name = "Не выполнено";
                    SystemArgs.Positions.Add(Temp);
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при попытке обновления статуса. Пожалуйста воспользуйтесь функцией изменения позиции", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ShowPosition(SystemArgs.Positions);
        }

        private void Position_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
