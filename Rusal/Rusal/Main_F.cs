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

        private void GetStatusConnect()
        {
            Timer_T.Start();
        }

        private void GetParamDB()
        {
            NameDB_S.Text = $"Название: {SystemArgs.NameDB}";
            UserDB_S.Text = $"Владелец: {SystemArgs.OwnerDB}";
        }

        private void Main_F_Load(object sender, EventArgs e)
        {
            Position_DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GetStatusConnect();
            Files.GetParamDB();
            GetParamDB();
            GetAllData();
            ShowPosition(SystemArgs.Positions);
        }

        private void ShowPosition(List<Position> List)
        {
            SystemArgs.View = new BindingListView<Position>(List);

            Position_DGV.AutoGenerateColumns = false;
            Position_DGV.DataSource = SystemArgs.View;

            //Position_DGV.RowCount = 0;

            //foreach (Position Position in List)
            //{
            //    Position_DGV.RowCount++;

            //    Position_DGV[0, Position_DGV.RowCount - 1].Value = Position.DateFormation.ToShortDateString();
            //    Position_DGV[1, Position_DGV.RowCount - 1].Value = Position.Diameter.Name;
            //    Position_DGV[2, Position_DGV.RowCount - 1].Value = Position.NumTS.Name;
            //    Position_DGV[3, Position_DGV.RowCount - 1].Value = Position.Count;
            //    Position_DGV[4, Position_DGV.RowCount - 1].Value = Position.Weight;
            //}
        }

        private void GetAllData()
        {
            ProgressBar_PB.Value = 2;

            Operations.GetAllData();

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

        private void Timer_T_Tick(object sender, EventArgs e)
        {
            if (Operations.StatusConnect())
            {
                CennectDB_S.Text = "Соеднинение: Установлено";
                CennectDB_S.BackColor = Color.Green;

                ButtonMode(true);
            }
            else
            {
                CennectDB_S.Text = "Соеднинение: Не установлено";
                CennectDB_S.BackColor = Color.Red;

                MessageBox.Show("Связь с сервером потеряна. Управление формой будет заблокировано до восстановления подключения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                ButtonMode(false);
            }
        }

        private void ReportStart_B_Click(object sender, EventArgs e)
        {

        }

        private void Add_B_Click(object sender, EventArgs e)
        {
            Operations.AddPosition();

            ResetSearch();

            ShowPosition(SystemArgs.Positions);
        }

        private void Change_B_Click(object sender, EventArgs e)
        {
            Operations.ChangePosition((Position)SystemArgs.View[Position_DGV.CurrentCell.RowIndex]);
            ResetSearch();

            ShowPosition(SystemArgs.Positions);
        }

        private void Position_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Delete_B_Click(object sender, EventArgs e)
        {
            Operations.DeletePosition((Position)SystemArgs.View[Position_DGV.CurrentCell.RowIndex]);
            ResetSearch();

            ShowPosition(SystemArgs.Positions);
        }

        private void Position_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Search_TSB_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(Search_TSTB.Text.Trim()))
            {
                SystemArgs.ModePosition = true;

                String SearchText = Search_TSTB.Text.Trim();

                SystemArgs.Result = Operations.ResultSearch(SearchText);

                if(SystemArgs.Result.Count > 0)
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
    }
}
