﻿using System;
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
            //GetStatusConnect();
            Files.GetParamDB();
            GetParamDB();
            Operations.GetAllPosition();
            PositionToDGV();
        }

        private void PositionToDGV()
        {
            ProgressBar_PB.Value = 2;

            Operations.GetAllPosition();
            ProgressBar_PB.Value = 50;

            foreach(Position Position in SystemArgs.Positions)
            {
                Position_DGV.RowCount++;

                Position_DGV[0, Position_DGV.RowCount - 1].Value = Position.DateFormation;
                Position_DGV[1, Position_DGV.RowCount - 1].Value = Position.Diameter;
                Position_DGV[2, Position_DGV.RowCount - 1].Value = Position.NumTS;
                Position_DGV[3, Position_DGV.RowCount - 1].Value = Position.Count;
                Position_DGV[4, Position_DGV.RowCount - 1].Value = Position.Weight;
            }
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
                CennectDB_S.BackColor = Color.Blue;

                ButtonMode(true);
            }
            else
            {
                CennectDB_S.Text = "Соеднинение: Не установлено";
                CennectDB_S.BackColor = Color.Red;

                //MessageBox.Show("Связь с сервером потеряна. Управление формой будет заблокировано до восстановления подключения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                ButtonMode(false);
            }
        }

        private void ReportStart_B_Click(object sender, EventArgs e)
        {

        }
    }
}