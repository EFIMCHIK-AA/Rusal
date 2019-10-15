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

        private void Main_F_Load(object sender, EventArgs e)
        {
            Files.GetParamDB();
            Operations.StatusConnectAsync(this);

            Thread.Sleep(1000);

            if (SystemArgs.StatusConnect)
            {
                Position_DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GetAllData();
                ShowPosition(SystemArgs.Positions);
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

        //private void ButtonMode(bool Mode)
        //{
        //    Add_B.Enabled = Mode;
        //    Change_B.Enabled = Mode;
        //    Delete_B.Enabled = Mode;
        //    Analysis_CB.Enabled = Mode;
        //    AnalysisStart_B.Enabled = Mode;
        //    Report_CB.Enabled = Mode;
        //    ReportStart_B.Enabled = Mode;
        //}

        private void Exit_B_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void ReportStart_B_Click(object sender, EventArgs e)
        {

        }

        private void Add_B_Click(object sender, EventArgs e)
        {

        }

        private void Change_B_Click(object sender, EventArgs e)
        {

        }

        private void Delete_B_Click(object sender, EventArgs e)
        {

        }

        private void Position_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void Position_DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

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
            }
        }

        private void ВесToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FullAnalysis_F fullAnalysis_F = new FullAnalysis_F();
            fullAnalysis_F.ShowDialog();
        }

        private void ВесToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Analysis.BriefBrigadeWeight(new DateTime(2019, 10, 1), new DateTime(2019, 10, 30));
        }

        private void ВесНомерТСToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Analysis.BriefNumTSWeight(new DateTime(2019, 10, 1), new DateTime(2019, 10, 30));
        }

        private void ВесТипДефектаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Analysis.BriefDescriptionWeight(new DateTime(2019, 10, 1), new DateTime(2019, 10, 30));
        }

        private void КоличествоБригадаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Analysis.BriefBrigadeCount(new DateTime(2019, 10, 1), new DateTime(2019, 10, 30));
        }

        private void КоличествоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Analysis.BriefNumTSCount(new DateTime(2019, 10, 1), new DateTime(2019, 10, 30));
        }

        private void КоличествоОписаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Analysis.BriefDescriptionCount(new DateTime(2019, 10, 1), new DateTime(2019, 10, 30));
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

            North_CB.Checked = false;
            West_CB.Checked = false;
            East_CB.Checked = false;
            South_CB.Checked = false;
            One_CB.Checked = false;
            Two_CB.Checked = false;
            Three_CB.Checked = false;
            Four_CB.Checked = false;
            Five_CB.Checked = false;
            Six_CB.Checked = false;
        }

        private void Position_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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

            North_CB.Checked = false;
            West_CB.Checked = false;
            East_CB.Checked = false;
            South_CB.Checked = false;
            One_CB.Checked = false;
            Two_CB.Checked = false;
            Three_CB.Checked = false;
            Four_CB.Checked = false;
            Five_CB.Checked = false;
            Six_CB.Checked = false;
            
            if (Temp.DefectLocIngot != null)
            {
                String[] DefectLocIngot = Temp.DefectLocIngot.Split('_');

                foreach (String Name in DefectLocIngot)
                {
                    foreach (Control TypeControl in panel2.Controls)
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

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void Menu_MS_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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

        private void AnalysisStart_B_Click(object sender, EventArgs e)
        {

        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SystemArgs.StatusConnect)
            {
                if (Position_DGV.CurrentCell != null)
                {
                    Operations.ChangePosition((Position)SystemArgs.View[Position_DGV.CurrentCell.RowIndex]);
                    ResetSearch();

                    ShowPosition(SystemArgs.Positions);
                    ClearField();
                }
            }
            else
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SystemArgs.StatusConnect)
            {
                if (Position_DGV.CurrentCell != null)
                {
                    Operations.DeletePosition((Position)SystemArgs.View[Position_DGV.CurrentCell.RowIndex]);
                    ResetSearch();

                    ShowPosition(SystemArgs.Positions);
                    ClearField();
                }
            }
            else
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
