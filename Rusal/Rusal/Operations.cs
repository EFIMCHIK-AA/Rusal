using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Threading.Tasks;

namespace Rusal
{
    public static class Operations
    {
        public static bool StatusConnect()
        {
            try
            {
                using (var Connect = new NpgsqlConnection(SystemArgs.ConnectString))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand("SELECT 1", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static void  GetAllPosition()
        {
            try
            {
                using (var Connect = new NpgsqlConnection(SystemArgs.ConnectString))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand("SELECT 1", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                SystemArgs.Positions.Add(new Position());
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при получении данных с сервера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
