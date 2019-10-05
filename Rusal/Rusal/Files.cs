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
                    SystemArgs.PasswordDB = sr.ReadLine();//Encryption.DecryptRSA(sr.ReadLine())

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
                    sw.WriteLine(SystemArgs.PasswordDB); //Encryption.EncryptRSA()
                }
            }
            else
            {
                MessageBox.Show("Файл Param.conf не обнаружен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
