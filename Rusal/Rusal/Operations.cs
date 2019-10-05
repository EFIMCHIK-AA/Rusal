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

        public static void  GetAllData()
        {
            try
            {
                using (var Connect = new NpgsqlConnection(SystemArgs.ConnectString))
                {
                    Connect.Open();

                    //Получаем данные со словарей из БД
                    using (var Command = new NpgsqlCommand($"SELECT \"ID\", \"N_Location\"" +
                                                            "FROM public.\"DefectLocationProduction\";", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                SystemArgs.DefectLocProduction.Add(new DefectProduction(Reader.GetInt32(0),Reader.GetString(1)));
                            }
                        }
                    }

                    using (var Command = new NpgsqlCommand($"SELECT \"ID\", \"N_Description\"" +
                                                            "FROM public.\"DescriptionDefect\";", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                SystemArgs.Descriptions.Add(new DescriptionDefect(Reader.GetInt32(0), Reader.GetString(1)));
                            }
                        }
                    }

                    using (var Command = new NpgsqlCommand($"SELECT \"ID\", \"N_Diameter\"" +
                                                            "FROM public.\"DiameterIngot\";", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                SystemArgs.Diameters.Add(new DiameterIngot(Reader.GetInt32(0), Reader.GetDouble(1)));
                            }
                        }
                    }

                    using (var Command = new NpgsqlCommand($"SELECT \"ID\", \"N_Brigade\"" +
                                                            "FROM public.\"ListBrigades\";", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                SystemArgs.Brigades.Add(new ListBrigades(Reader.GetInt32(0), Reader.GetString(1)));
                            }
                        }
                    }

                    using (var Command = new NpgsqlCommand($"SELECT \"ID\", \"N_Smena\"" +
                                                            "FROM public.\"ListSmen\";", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                SystemArgs.Smeny.Add(new ListSmen(Reader.GetInt32(0), Reader.GetString(1)));
                            }
                        }
                    }

                    using (var Command = new NpgsqlCommand($"SELECT \"ID\", \"N_ProgressMark\"" +
                                                            "FROM public.\"ProgressMark\";", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                SystemArgs.ProgressMark.Add(new ProgressMark(Reader.GetInt32(0), Reader.GetString(1)));
                            }
                        }
                    }

                    using (var Command = new NpgsqlCommand($"SELECT \"ID\", \"N_TSN\"" +
                                                            "FROM public.\"TSN\";", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                SystemArgs.TSN.Add(new TSN(Reader.GetInt32(0), Reader.GetString(1)));
                            }
                        }
                    }

                    using (var Command = new NpgsqlCommand($"SELECT \"ID\", \"N_Alloy\"" +
                                                            "FROM public.\"TypesAlloy\";", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                SystemArgs.TypesAlloy.Add(new TypesAlloy(Reader.GetInt32(0), Reader.GetString(1)));
                            }
                        }
                    }

                    using (var Command = new NpgsqlCommand($"SELECT \"ID\", \"N_Defect\"" +
                                                            "FROM public.\"TypesDefect\";", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                SystemArgs.TypesDefect.Add(new TypesDefect(Reader.GetInt32(0), Reader.GetString(1)));
                            }
                        }
                    }

                    //Получаем список всех позиций из БД

                    using (var Command = new NpgsqlCommand($"SELECT \"ID\", \"SysDateCreate\", \"DateFormation\", \"NumMelt\", \"CountIngot\", \"WeightIngots\"," +
                                                                 $" \"DefectLocIngot\", \"Correction\", \"Address\", \"NumTSN\", \"NumBrigade\", \"DefLocProduction\"," +
                                                                 $" \"NumSmen\", \"Defect\", \"TypeAlloy\", \"Description\", \"Diameter\", \"ProgressMark\"" +
                                                            "FROM public.\"Ingot\";", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                //Текущие значения позиции
                                TSN [] TSN = SystemArgs.TSN.Where(t => t.ID == Reader.GetInt64(9)).ToArray();
                                ListBrigades [] Brigade = SystemArgs.Brigades.Where(t => t.ID == Reader.GetInt64(10)).ToArray();
                                DefectProduction [] DefProduction = SystemArgs.DefectLocProduction.Where(t => t.ID == Reader.GetInt64(11)).ToArray();
                                ListSmen [] Smena = SystemArgs.Smeny.Where(t => t.ID == Reader.GetInt64(12)).ToArray();
                                TypesDefect [] Defect = SystemArgs.TypesDefect.Where(t => t.ID == Reader.GetInt64(13)).ToArray();
                                TypesAlloy[] Alloy = SystemArgs.TypesAlloy.Where(t => t.ID == Reader.GetInt64(14)).ToArray();
                                DescriptionDefect[] Description = SystemArgs.Descriptions.Where(t => t.ID == Reader.GetInt64(15)).ToArray();
                                DiameterIngot[] Diameter = SystemArgs.Diameters.Where(t => t.ID == Reader.GetInt64(16)).ToArray();
                                ProgressMark[] ProgressMark = SystemArgs.ProgressMark.Where(t => t.ID == Reader.GetInt64(17)).ToArray();

                                //Добавляем позиция в список
                                SystemArgs.Positions.Add(new Position(Reader.GetInt32(0), Reader.GetDateTime(1), Reader.GetDateTime(2), Reader.GetString(3), Reader.GetInt64(4), Reader.GetDouble(5),
                                                                      Reader.GetString(6), Reader.GetString(7), Reader.GetString(8), TSN[0], Brigade[0], DefProduction[0], Smena[0], Defect[0], Alloy[0],
                                                                      Description[0], Diameter[0], ProgressMark[0]));
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

        static void AddPosition(Position Position)
        {
            try
            {
                using (var Connect = new NpgsqlConnection(SystemArgs.ConnectString))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {

                            }
                        }
                    }

                    Connect.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при добавлении данных на сервер", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
