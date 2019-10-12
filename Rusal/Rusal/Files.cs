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
                }
            }
            else
            {
                MessageBox.Show("Файл Param.conf не обнаружен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                }
            }
            else
            {
                MessageBox.Show("Файл Param.conf не обнаружен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            else
            {
                MessageBox.Show("Файл Backup.conf не обнаружен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static String GetBackupPath()
        {
            if (File.Exists(BackupPath))
            {
                using (StreamReader sr = new StreamReader(File.Open(BackupPath, FileMode.Open)))
                {
                    return sr.ReadLine();
                }
            }
            else
            {
                MessageBox.Show("Файл Backup.conf не обнаружен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return String.Empty;
            }
        }
    }
}
