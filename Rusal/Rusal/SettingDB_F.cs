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
            }
            catch (Exception)
            {
                MessageBox.Show(Error, "Ошибка", MessageBoxButtons.OK,  MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPD = new OpenFileDialog()
            {
                DefaultExt = ".bat",
                Title = "Файл бэкапа",
                Filter = "Исполняемый файл Windows| *.bat",
                RestoreDirectory = true
            };

            if(OPD.ShowDialog() == DialogResult.OK)
            {
                Path_TB.Text = OPD.FileName;
            }
        }

        private void StartBackup_B_Click(object sender, EventArgs e)
        {
            if(File.Exists(Files.GetBackupPath()))
            {
                System.Diagnostics.Process.Start(Files.GetBackupPath());
            }
            else
            {
                MessageBox.Show("Запрашиваемый файл не обнаружен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(Path_TB.Text))
            {
                Files.SetBackupPath(Path_TB.Text.Trim());
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
