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

        private void GetParamDB()
        {
            NameDB_S.Text = $"Название: {SystemArgs.NameDB}";
            UserDB_S.Text = $"Владелец: {SystemArgs.OwnerDB}";
        }

        private void Main_F_Load(object sender, EventArgs e)
        {
            Files.GetParamDB();
            Operations.StatusConnectAsync(this);

            Thread.Sleep(1000);

            if (SystemArgs.StatusConnect)
            {
                Position_DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GetParamDB();
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
        }

        private void GetAllData()
        {
            ProgressBar_PB.Value = 2;

            Operations.GetArguments();
            Operations.GetPosition();

            ProgressBar_PB.Value = 100;
        }

        private void ButtonMode(bool Mode)
        {
            Add_B.Enabled = Mode;
            Change_B.Enabled = Mode;
            Delete_B.Enabled = Mode;
            Analysis_CB.Enabled = Mode;
            AnalysisStart_B.Enabled = Mode;
            Report_CB.Enabled = Mode;
            ReportStart_B.Enabled = Mode;
        }

        private void Exit_B_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void ReportStart_B_Click(object sender, EventArgs e)
        {
            if(SystemArgs.StatusConnect)
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

        private void Add_B_Click(object sender, EventArgs e)
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

        private void Change_B_Click(object sender, EventArgs e)
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

        private void Delete_B_Click(object sender, EventArgs e)
        {
            if (SystemArgs.StatusConnect)
            {
                if (Position_DGV.CurrentCell != null)
                {
                    Operations.DeletePosition((Position)SystemArgs.View[Position_DGV.CurrentCell.RowIndex]);
                    ResetSearch();

                    ShowPosition(SystemArgs.Positions);
                }
            }
            else
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            Analysis.BriefDiametrWeight(new DateTime(2019,10,1),new DateTime(2019,10,30));
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
    }
}
