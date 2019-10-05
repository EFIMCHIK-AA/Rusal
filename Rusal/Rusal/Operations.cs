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

                    using (var Command = new NpgsqlCommand($"START TRANSACTION;" +
                                                           $"SELECT public.\"Ingot\".\"SysDateCreate\", public.\"Ingot\".\"DateFormation\", public.\"Ingot\".\"NumMelt\", public.\"Ingot\".\"CountIngot\", public.\"Ingot\".\"WeightIngots\", public.\"Ingot\".\"DefectLocIngot\", public.\"Ingot\".\"Correction\", public.\"Ingot\".\"Address\"," +
                                                           "public.\"TSN\".\"N_TSN\", public.\"ListBrigades\".\"N_Brigade\", public.\"DefectLocationProduction\".\"N_Location\", public.\"ListSmen\".\"N_Smena\", public.\"TypesDefect\".\"N_Defect\", public.\"TypesAlloy\".\"N_Alloy\"," +
                                                           "public.\"DescriptionDefect\".\"N_Description\", public.\"DiameterIngot\".\"N_Diameter\", public.\"ProgressMark\".\"N_ProgressMark\"" +
                                                           "FROM public.\"Ingot\", public.\"DefectLocationProduction\", public.\"DescriptionDefect\", public.\"DiameterIngot\", public.\"ListBrigades\", public.\"ListSmen\", public.\"ProgressMark\", public.\"TSN\", public.\"TypesAlloy\", public.\"TypesDefect\"" +
                                                           "WHERE public.\"TSN\".\"ID\" = public.\"Ingot\".\"NumTSN\"" +
                                                           "AND public.\"ListBrigades\".\"ID\" = public.\"Ingot\".\"NumBrigade\"" +
                                                           "AND public.\"DefectLocationProduction\".\"ID\" = public.\"Ingot\".\"DefLocProduction\"" +
                                                           "AND public.\"ListSmen\".\"ID\" = public.\"Ingot\".\"NumSmen\"" +
                                                           "AND public.\"TypesDefect\".\"ID\" = public.\"Ingot\".\"Defect\"" +
                                                           "AND public.\"TypesAlloy\".\"ID\" = public.\"Ingot\".\"TypeAlloy\"" +
                                                           "AND public.\"DescriptionDefect\".\"ID\" = public.\"Ingot\".\"Description\"" +
                                                           "AND public.\"DiameterIngot\".\"ID\" = public.\"Ingot\".\"Diameter\"" +
                                                           "AND public.\"ProgressMark\".\"ID\" = public.\"Ingot\".\"ProgressMark\";" +
                                                           "COMMIT;", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                SystemArgs.Positions.Add(new Position(Reader.GetDateTime(0), Reader.GetDateTime(1), Reader.GetString(2), Reader.GetInt64(3), Reader.GetDouble(4), Reader.GetString(5), Reader.GetString(6), Reader.GetString(7), Reader.GetString(8),
                                                         Reader.GetString(9), Reader.GetString(10), Reader.GetString(11), Reader.GetString(12), Reader.GetString(13), Reader.GetString(14), Reader.GetDouble(15), Reader.GetString(16)));
                            }
                        }
                    }

                    Connect.Close();
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
