using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rusal
{
    public static class Files
    {
        public static String LogPath = $@"Log"; //Место записи логов
        public static String ParamDBPath = $@"System\Connect\Param.conf"; //Место аргументов БД
        public static String BackupPath = $@"System\Backup\Backup.conf"; //Место хранения файла бэкапа

        public static void GetParamDB()
        {
            if (File.Exists(ParamDBPath))
            {
                using (StreamReader sr = new StreamReader(File.Open(ParamDBPath, FileMode.Open)))
                {
                    SystemArgs.NameDB = sr.ReadLine();
                    SystemArgs.OwnerDB = sr.ReadLine();
                    SystemArgs.IPDB = sr.ReadLine();
                    SystemArgs.PortDB = sr.ReadLine();
                    SystemArgs.PasswordDB = Encryption.DecryptRSA(sr.ReadLine());

                    SystemArgs.ConnectString = $@"Server = {SystemArgs.IPDB}; Port = {SystemArgs.PortDB}; User Id = {SystemArgs.OwnerDB}; Password = {SystemArgs.PasswordDB}; Database = {SystemArgs.NameDB};";

                    SystemArgs.PrintLog("Процедура проверки целостности файлов успешно завершена");
                }
            }
            else
            {
                MessageBox.Show("Файл Param.conf не обнаружен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                SystemArgs.PrintLog("Процедура проверки целостности файлов завершена аварийно. Остановка работы программного обеспечения");
                Application.Exit();
            }
        }

        public static void SetParamDB()
        {
            if (File.Exists(ParamDBPath))
            {
                using (StreamWriter sw = new StreamWriter(File.Open(ParamDBPath, FileMode.Create)))
                {
                    sw.WriteLine(SystemArgs.NameDB);
                    sw.WriteLine(SystemArgs.OwnerDB);
                    sw.WriteLine(SystemArgs.IPDB);
                    sw.WriteLine(SystemArgs.PortDB);
                    sw.WriteLine(Encryption.EncryptRSA(SystemArgs.PasswordDB));

                    MessageBox.Show("Параметры подключения успешно обновлены", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SystemArgs.PrintLog("Запись параметров подлючения к БД успешно завершена");
                }
            }
            else
            {
                MessageBox.Show("Файл Param.conf не обнаружен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                SystemArgs.PrintLog("Ошибка при записи параметров подлючения к БД");
            }
        }

        public static void SetBackupPath(String Path)
        {
            if (File.Exists(BackupPath))
            {
                using (StreamWriter sw = new StreamWriter(File.Open(BackupPath, FileMode.Create)))
                {
                    sw.WriteLine(Path);
                }

                MessageBox.Show("Путь к файлу резервной копии успешно найден и сохранен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SystemArgs.PrintLog("Запись системного пути резервной копии БД успешно завершена");
            }
            else
            {
                MessageBox.Show("Файл Backup.conf не обнаружен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                SystemArgs.PrintLog("Файл Backup.conf не обнаружен");
            }
        }

        public static String GetBackupPath()
        {
            if (File.Exists(BackupPath))
            {
                using (StreamReader sr = new StreamReader(File.Open(BackupPath, FileMode.Open)))
                {
                    SystemArgs.PrintLog("Получение системного пути резервной копии БД успешно завершено");

                    return sr.ReadLine();
                }
            }
            else
            {
                MessageBox.Show("Файл Backup.conf не обнаружен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                SystemArgs.PrintLog("Файл Backup.conf не обнаружен");

                return String.Empty;
            }
        }
    }
}
