using System;
using System.IO;
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
    public partial class SettingDB_F : Form
    {
        public SettingDB_F()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void SaveConnect_B_Click(object sender, EventArgs e)
        {
            SystemArgs.PrintLog($"Запук процедуры модификации параметров БД");
            String Error = String.Empty;

            try
            {
                if(String.IsNullOrEmpty(Name_TB.Text))
                {
                    Name_TB.Focus();
                    Error = "Наименование базы данных должно содержать значение";
                    throw new Exception();
                }

                if (String.IsNullOrEmpty(Server_TB.Text))
                {
                    Server_TB.Focus();
                    Error = "Сервер базы данных должен содержать значение";
                    throw new Exception(Error);
                }

                if (String.IsNullOrEmpty(Owner_TB.Text))
                {
                    Owner_TB.Focus();
                    Error = "Владелец базы данных должен содержать значение";
                    throw new Exception(Error);
                }

                if (String.IsNullOrEmpty(Port_TB.Text))
                {
                    Port_TB.Focus();
                    Error = "Порт базы данных должен содержать значение";
                    throw new Exception(Error);
                }

                try
                {
                    Int32 Temp = Convert.ToInt32(Port_TB.Text.Trim());
                }
                catch
                {
                    Error = "Порт должен состоять из цифр";
                    throw;
                }

                if (String.IsNullOrEmpty(Password_TB.Text))
                {
                    Password_TB.Focus();
                    Error = "Пароль базы данных должен содержать значение";
                    throw new Exception(Error);
                }

                //Прописать проверку на поля
                SystemArgs.NameDB = Name_TB.Text.Trim();
                SystemArgs.IPDB = Server_TB.Text.Trim();
                SystemArgs.OwnerDB = Owner_TB.Text.Trim();
                SystemArgs.PortDB = Port_TB.Text.Trim();
                SystemArgs.PasswordDB = Password_TB.Text.Trim();

                Files.SetParamDB();

                SystemArgs.PrintLog("Параметры подключения к базе данных успешно обновлены");
                SystemArgs.PrintLog($"Процедуры модификации параметров БД успешно завершена");
            }
            catch (Exception)
            {
                MessageBox.Show(Error, "Ошибка", MessageBoxButtons.OK,  MessageBoxIcon.Error);
                SystemArgs.PrintLog($"Ошибка при получении параметров подключении к базе данных: {Error}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SystemArgs.PrintLog($"Запуск процедуры выбора пути резервной копии БД");

            OpenFileDialog OPD = new OpenFileDialog()
            {
                DefaultExt = ".bat",
                Title = "Файл резервной копии",
                Filter = "Исполняемый файл Windows| *.bat",
                RestoreDirectory = true
            };

            if(OPD.ShowDialog() == DialogResult.OK)
            {
                Path_TB.Text = OPD.FileName;
                SystemArgs.PrintLog($"Процедура выбора пути резервной копии БД успешно завершена");
            }
        }

        private void StartBackup_B_Click(object sender, EventArgs e)
        {
            SystemArgs.PrintLog($"Запуск процедуры резервной копии БД");

            if (File.Exists(Path_TB.Text.Trim()))
            {
                System.Diagnostics.Process.Start(Path_TB.Text.Trim());

                MessageBox.Show("Резервная копия успешно создана", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SystemArgs.PrintLog($"Резервная копия успешно создана");
            }
            else
            {
                MessageBox.Show("Запрашиваемый файл не обнаружен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemArgs.PrintLog($"Запрашиваемый файл не обнаружен");
            }

            SystemArgs.PrintLog($"Процедура резервной копии БД завершена");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SystemArgs.PrintLog($"Запуск процедуры записи пути резервной копии БД");

            if (!String.IsNullOrEmpty(Path_TB.Text))
            {
                Files.SetBackupPath(Path_TB.Text.Trim());

                SystemArgs.PrintLog($"Процедурыа записи пути резервной копии БД завершена");
            }
            else
            {
                Path_TB.Focus();
                MessageBox.Show("В поле пути к файлу должно быть значние", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SettingDB_F_Load(object sender, EventArgs e)
        {

        }
    }
}
