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
            SystemArgs.PrintLog("Процедура проверки целостности файлов запущена...");
            Dialog.Show();
            Thread.Sleep(6000);
            Dialog.Close();
            Position_DGV.AutoGenerateColumns = false;

            ProgressBar_PB.Value = 10;

            if (SystemArgs.StatusConnect)
            {
                SystemArgs.PrintLog("Подключение к БД успешно установлено");
                Position_DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GetAllData();
                ShowPosition(SystemArgs.Positions);

                EnableField();
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                MessageBox.Show("Не удалось подключиться к базе данных. Запуск программного обеспечения остановлен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemArgs.PrintLog("Ошибка при подключении к БД. Работа приложения остановлена");
                Application.Exit();
            }

            ProgressBar_PB.Value = 100;
            
            ProgressBar_PB.Value = 0;
        }

        private void ShowPosition(List<Position> List)
        {
            SystemArgs.View = null;
            Position_DGV.DataSource = null;
            SystemArgs.View = new BindingListView<Position>(List);

            Position_DGV.DataSource = SystemArgs.View;

            CountPos_TB.Text = SystemArgs.View.Count.ToString();
        }

        private void GetAllData()
        {
            ProgressBar_PB.Value = 10;

            SystemArgs.PrintLog("Инициализация процедуры получения параметров с БД");

            Operations.GetArguments();
            ProgressBar_PB.Value = 50;
            Operations.GetPosition();

            SystemArgs.PrintLog("Процедура получения параметров с БД успешно завершена");

            ProgressBar_PB.Value = 100;
            
            ProgressBar_PB.Value = 0;
        }

        private void Exit_B_Click(object sender, EventArgs e)
        {
            ProgressBar_PB.Value = 10;

            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SystemArgs.PrintLog("Успешное подтверждение выхода из программного обеспечения. Остановка работы ПО");
                Application.Exit();
            }

            ProgressBar_PB.Value = 100;
            
            ProgressBar_PB.Value = 0;
        }

        private void Search_TSB_Click(object sender, EventArgs e)
        {
            SystemArgs.PrintLog("Запуск процеры поиска по параметрам");

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
                        SystemArgs.PrintLog("Отображение позиций по заданным параметрам");
                    }
                    else
                    {
                        Search_TSTB.Focus();
                        MessageBox.Show("Поиск не дал результатов", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        SystemArgs.PrintLog("Количество объектов по параметрам поиска 0");
                    }
                }
                else
                {
                    Search_TSTB.Focus();
                    MessageBox.Show("Для поиска необходимо ввести значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SystemArgs.PrintLog("Получено пустое значение параметра поиска");
                }
            }
            else
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemArgs.PrintLog("Ошибка при подключении к БД");
            }

            SystemArgs.PrintLog("Процеры поиска по параметрам завершена");
        }

        private void ResetSearch()
        {
            Search_TSTB.Text = String.Empty;

            SystemArgs.ModePosition = false;

            SystemArgs.Result.Clear();
        }

        private void Reset_TSB_Click(object sender, EventArgs e)
        {
            SystemArgs.PrintLog("Запуск процеду сброса параметров фильтрации");
            ResetSearch();

            ShowPosition(SystemArgs.Positions);

            SystemArgs.PrintLog("Процедура сброса параметров фильтрации успешно завершена");
        }

        private void базаДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgressBar_PB.Value = 10;

            SystemArgs.PrintLog("Запуск процедуру изменения параметров БД");
            SettingDB_F Dialog = new SettingDB_F();

            Dialog.Name_TB.Text = SystemArgs.NameDB;
            Dialog.Server_TB.Text = SystemArgs.IPDB;
            Dialog.Owner_TB.Text = SystemArgs.OwnerDB;
            Dialog.Port_TB.Text = SystemArgs.PortDB;
            Dialog.Password_TB.Text = SystemArgs.PasswordDB;
            Dialog.Path_TB.Text = Files.GetBackupPath();

            ProgressBar_PB.Value = 50;

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                SystemArgs.PrintLog("Процедура изменения параметров БД успешно завершена");
            }

            ProgressBar_PB.Value = 100;
            
            ProgressBar_PB.Value = 0;
        }

        private void конфигурацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgressBar_PB.Value = 10;

            SystemArgs.PrintLog("Запуск процедуры изменения конфигурации ПО");
            SettingConfiguration_F Dialog = new SettingConfiguration_F();

            ProgressBar_PB.Value = 50;

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                Operations.GetPosition();
                ShowPosition(SystemArgs.Positions);
                SystemArgs.PrintLog("Процедура изменения конфигурации ПО успешно завершена");
            }

            ProgressBar_PB.Value = 100;
            
            ProgressBar_PB.Value = 0;
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
            ProgressBar_PB.Value = 10;

            SystemArgs.PrintLog("Запуск процедура обычного анализа");

            BriefAnalysis_F Dialog = new BriefAnalysis_F();

            ProgressBar_PB.Value = 50;

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                SystemArgs.PrintLog("Процедура обычного анализа успешно завершена");
            }

            ProgressBar_PB.Value = 100;
            
            ProgressBar_PB.Value = 0;
        }

        private void расширенныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgressBar_PB.Value = 10;

            SystemArgs.PrintLog("Запуск процедуры расширенного анализа");

            FullAnalysis_F Dialog = new FullAnalysis_F();

            ProgressBar_PB.Value = 50;

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                SystemArgs.PrintLog("Процедура расширенного анализа успешно завершена");
            }

            ProgressBar_PB.Value = 100;
            
            ProgressBar_PB.Value = 0;
        }

        private void заПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgressBar_PB.Value = 10;

            SystemArgs.PrintLog("Запуск процедуры построение отчета");

            if (SystemArgs.StatusConnect)
            {
                Report_F Dialog = new Report_F();

                ProgressBar_PB.Value = 50;

                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    Reports.ByDate(Dialog.First_MC.SelectionStart, Dialog.Second_MC.SelectionStart);

                    SystemArgs.PrintLog("Процедура построения отчета успешно завершена");
                }
            }
            else
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemArgs.PrintLog("Ошибка при подключении к базе данных");
            }

            ProgressBar_PB.Value = 100;
            
            ProgressBar_PB.Value = 0;
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

            if (SystemArgs.View == null)
            {
                return;
            }

            if (Position_DGV.CurrentCell == null)
            {
                return;
            }

            if (Position_DGV.CurrentCell.RowIndex > SystemArgs.View.Count)
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
            else if (Temp.ProgressMark.Name == "Не выполнено")
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
            ProgressBar_PB.Value = 10;

            SystemArgs.PrintLog("Запуск процедуры демонстрации места дефекта на слитке");

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

            ProgressBar_PB.Value = 50;

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                SystemArgs.PrintLog("Процедуры демонстрации места дефекта на слитке успешна завершена");
            }

            ProgressBar_PB.Value = 100;
            
            ProgressBar_PB.Value = 0;
        }

        private void CreatePosition()
        {
            ProgressBar_PB.Value = 10;

            SystemArgs.PrintLog("Запуск процедуры добавления позиции");

            if (SystemArgs.StatusConnect)
            {
                Operations.AddPosition();

                ResetSearch();

                ShowPosition(SystemArgs.Positions);

                ProgressBar_PB.Value = 80;
            }
            else
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemArgs.PrintLog("Ошибка при подключении к базе данных");
            }

            SystemArgs.PrintLog("Процедура добавления позиции завершена");

            ProgressBar_PB.Value = 100;
            
            ProgressBar_PB.Value = 0;
        }

        private void Add_TSB_Click(object sender, EventArgs e)
        {
            CreatePosition();
        }

        private void ChangePosition()
        {
            ProgressBar_PB.Value = 10;

            SystemArgs.PrintLog("Запуск процедуры изменения позиции");

            if (SystemArgs.StatusConnect)
            {
                if (Position_DGV.CurrentCell != null)
                {
                    Operations.ChangePosition((Position)SystemArgs.View[Position_DGV.CurrentCell.RowIndex]);
                    ResetSearch();

                    ProgressBar_PB.Value = 50;

                    ShowPosition(SystemArgs.Positions);
                }
            }
            else
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemArgs.PrintLog("Ошибка при подключении к базе данных");
            }

            SystemArgs.PrintLog("Процедура изменения позиции завершена");

            ProgressBar_PB.Value = 100;
            
            ProgressBar_PB.Value = 0;
        }

        private void Change_TSB_Click(object sender, EventArgs e)
        {
            ChangePosition();
        }

        private void DeletePosition()
        {
            ProgressBar_PB.Value = 10;

            SystemArgs.PrintLog("Запуск процедуры удаления позиции");

            if (SystemArgs.StatusConnect)
            {
                if (Position_DGV.CurrentCell != null)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить позицию?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Operations.DeletePosition((Position)SystemArgs.View[Position_DGV.CurrentCell.RowIndex]);
                        ResetSearch();

                        ShowPosition(SystemArgs.Positions);

                        ProgressBar_PB.Value = 50;

                        //Position_DGV.ClearSelection();
                        ClearField();
                    }
                }
            }
            else
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemArgs.PrintLog("Ошибка при подключении к базе данных");
            }

            SystemArgs.PrintLog("Процедура удаления позиции завершена");

            EnableField();

            ProgressBar_PB.Value = 100;
            
            ProgressBar_PB.Value = 0;
        }

        private void Delete_TSB_Click(object sender, EventArgs e)
        {
            DeletePosition();
        }

        private void ChangeStatus_B_Click(object sender, EventArgs e)
        {
            ProgressBar_PB.Value = 10;

            if (MessageBox.Show("Вы действительно хотите изменить статус выполнения корректирующего действия?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Position Temp = (Position)SystemArgs.View[Position_DGV.CurrentCell.RowIndex];

                if (Temp.ProgressMark.Name == "Не выполнено")
                {
                    Operations.UpdateStatusCorrection(Temp, "Выполнено");
                }
                else if(Temp.ProgressMark.Name == "Выполнено")
                {
                    Operations.UpdateStatusCorrection(Temp, "Не выполнено");
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при попытке обновления статуса. Пожалуйста воспользуйтесь функцией изменения позиции", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Operations.GetArguments();
                Operations.GetPosition();

                ShowPosition(SystemArgs.Positions);
            }

            ProgressBar_PB.Value = 100;

            ResetSearch();

            ProgressBar_PB.Value = 0;
        }

        private void Position_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Menu_MS_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void SearchParam_TSB_Click(object sender, EventArgs e)
        {
            SystemArgs.PrintLog("Запуск процеры поиска по параметрам");

            if (SystemArgs.StatusConnect)
            {
                ParamSearch_F Dialog = new ParamSearch_F();

                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    DateTime TempDate = Dialog.Calendar_DP.Value.Date;

                    SystemArgs.Result = SystemArgs.Positions;

                    SystemArgs.Result = SystemArgs.Result.Where(p => p.DateFormation == TempDate).ToList();

                    if (Dialog.NumSmeny_CB.SelectedIndex != 0)
                    {
                        SystemArgs.Result = SystemArgs.Result.Where(p => p.NumSmeny == Dialog.NumSmeny_CB.SelectedItem).ToList();
                    }

                    if (!String.IsNullOrEmpty(Dialog.NumMelt_TB.Text))
                    {
                        SystemArgs.Result = SystemArgs.Result.Where(p => p.NumMelt == Dialog.NumMelt_TB.Text.Trim()).ToList();
                    }

                    if (Dialog.TypeAlloy_CB.SelectedIndex != 0)
                    {
                        SystemArgs.Result = SystemArgs.Result.Where(p => p.TypeAlloy == Dialog.TypeAlloy_CB.SelectedItem).ToList();
                    }

                    if (!String.IsNullOrEmpty(Dialog.Address_TB.Text))
                    {
                        SystemArgs.Result = SystemArgs.Result.Where(p => p.Address == Dialog.Address_TB.Text.Trim()).ToList();
                    }

                    if (!String.IsNullOrEmpty(Dialog.Count_TB.Text))
                    {
                        SystemArgs.Result = SystemArgs.Result.Where(p => p.Count == Convert.ToInt64(Dialog.Count_TB.Text.Trim())).ToList();
                    }

                    if (!String.IsNullOrEmpty(Dialog.Weight_TB.Text))
                    {
                        SystemArgs.Result = SystemArgs.Result.Where(p => p.Weight == Convert.ToDouble(Dialog.Weight_TB.Text.Trim())).ToList();
                    }

                    if (Dialog.Diameter_CB.SelectedIndex != 0)
                    {
                        SystemArgs.Result = SystemArgs.Result.Where(p => p.Diameter == Dialog.Diameter_CB.SelectedItem).ToList();
                    }

                    if (Dialog.Description_CB.SelectedIndex != 0)
                    {
                        SystemArgs.Result = SystemArgs.Result.Where(p => p.Description == Dialog.Description_CB.SelectedItem).ToList();
                    }

                    if (Dialog.TypeDefect_CB.SelectedIndex != 0)
                    {
                        SystemArgs.Result = SystemArgs.Result.Where(p => p.Defect == Dialog.TypeDefect_CB.SelectedItem).ToList();
                    }

                    if (Dialog.NumTS_CB.SelectedIndex != 0)
                    {
                        SystemArgs.Result = SystemArgs.Result.Where(p => p.NumTS == Dialog.NumTS_CB.SelectedItem).ToList();
                    }

                    if (Dialog.NumBrigade_CB.SelectedIndex != 0)
                    {
                        SystemArgs.Result = SystemArgs.Result.Where(p => p.NumBrigade == Dialog.NumBrigade_CB.SelectedItem).ToList();
                    }

                    if (Dialog.LocationProduction_CB.SelectedIndex != 0)
                    {
                        SystemArgs.Result = SystemArgs.Result.Where(p => p.DefectLocProduction == Dialog.LocationProduction_CB.SelectedItem).ToList();
                    }

                    if (Dialog.ProgressMark_CB.SelectedIndex != 0)
                    {
                        SystemArgs.Result = SystemArgs.Result.Where(p => p.ProgressMark == Dialog.ProgressMark_CB.SelectedItem).ToList();
                    }

                    if (SystemArgs.Result.Count == 0)
                    {
                        MessageBox.Show("Расширенный поиск не дал результатов", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        ShowPosition(SystemArgs.Result);
                        SystemArgs.PrintLog("Отображение позиций по заданным параметрам");
                        MessageBox.Show($"Объектов найдено: {SystemArgs.Result.Count}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemArgs.PrintLog("Ошибка при подключении к БД");
            }

            SystemArgs.PrintLog("Процеры поиска по параметрам завершена");
        }
    }
}
