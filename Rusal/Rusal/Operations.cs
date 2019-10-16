using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace Rusal
{
    public static class Operations
    {
        public static async void StatusConnectAsync(Main_F Form)
        {
            await Task.Run(() => StatusConnect(Form));
        }

        private static void StatusConnect(Main_F Form)
        {
            while (true)
            {
                bool Status = false;

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
                                    Status = true;
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Status = false;
                }

                SystemArgs.StatusConnect = Status;

                if (Status)
                {
                    Form.ConnectDB_TB.BeginInvoke(new MethodInvoker(delegate
                    {
                        Form.ConnectDB_TB.Text = "Установлено";
                        Form.ConnectDB_TB.BackColor = Color.FromArgb(188, 220, 244);
                    }));
                }
                else
                {
                    Form.ConnectDB_TB.BeginInvoke(new MethodInvoker(delegate
                    {
                        Form.ConnectDB_TB.Text = "Не установлено";
                        Form.ConnectDB_TB.BackColor = Color.Red;
                    }));
                }

                Thread.Sleep(3000);
            }
        }

        public static void GetPosition()
        {
            if (!SystemArgs.StatusConnect)
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SystemArgs.Positions.Clear();
                SystemArgs.Result.Clear();

                using (var Connect = new NpgsqlConnection(SystemArgs.ConnectString))
                {
                    Connect.Open();

                    //Получаем список всех позиций из БД
                    using (var Command = new NpgsqlCommand($"SELECT \"ID\", \"SysDateCreate\", \"DateFormation\", \"NumMelt\", \"CountIngot\", \"WeightIngots\"," +
                                                                 $" \"DefectLocIngot\", \"Correction\", \"Address\", \"Reason\", \"NumTSN\", \"NumBrigade\", \"DefLocProduction\"," +
                                                                 $" \"NumSmen\", \"Defect\", \"TypeAlloy\", \"Description\", \"Diameter\", \"ProgressMark\"" +
                                                            "FROM public.\"Ingot\";", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                //Текущие значения позиции
                                TSN[] TSN = SystemArgs.TSN.Where(t => t.ID == Reader.GetInt64(10)).ToArray();
                                ListBrigades[] Brigade = SystemArgs.Brigades.Where(t => t.ID == Reader.GetInt64(11)).ToArray();
                                DefectProduction[] DefProduction = SystemArgs.DefectLocProduction.Where(t => t.ID == Reader.GetInt64(12)).ToArray();
                                ListSmen[] Smena = SystemArgs.Smeny.Where(t => t.ID == Reader.GetInt64(13)).ToArray();
                                TypesDefect[] Defect = SystemArgs.TypesDefect.Where(t => t.ID == Reader.GetInt64(14)).ToArray();
                                TypesAlloy[] Alloy = SystemArgs.TypesAlloy.Where(t => t.ID == Reader.GetInt64(15)).ToArray();
                                DescriptionDefect[] Description = SystemArgs.Descriptions.Where(t => t.ID == Reader.GetInt64(16)).ToArray();
                                DiameterIngot[] Diameter = SystemArgs.Diameters.Where(t => t.ID == Reader.GetInt64(17)).ToArray();
                                ProgressMark[] ProgressMark = SystemArgs.ProgressMark.Where(t => t.ID == Reader.GetInt64(18)).ToArray();

                                //Добавляем позиция в список
                                SystemArgs.Positions.Add(new Position(Reader.GetInt32(0), Reader.GetDateTime(1), Reader.GetDateTime(2), Reader.GetString(3), Reader.GetInt64(4), Reader.GetDouble(5),
                                                                      Reader.GetString(6), Reader.GetString(7), Reader.GetString(8), Reader.GetString(9), TSN[0], Brigade[0], DefProduction[0], Smena[0], Defect[0], Alloy[0],
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

        public static void  GetArguments()
        {
            if (!SystemArgs.StatusConnect)
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SystemArgs.DefectLocProduction.Clear();
            SystemArgs.TSN.Clear();
            SystemArgs.Brigades.Clear();
            SystemArgs.Descriptions.Clear();
            SystemArgs.Diameters.Clear();
            SystemArgs.ProgressMark.Clear();
            SystemArgs.TypesDefect.Clear();
            SystemArgs.TypesDefect.Clear();
            SystemArgs.Smeny.Clear();
            SystemArgs.TypesAlloy.Clear();

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

                    Connect.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при получении данных с сервера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private static  void SetComboBox(Add_F Dialog)
        {
            Dialog.NumBrigade_CB.DataSource = SystemArgs.Brigades;
            Dialog.NumBrigade_CB.DisplayMember = "Name";
            Dialog.NumBrigade_CB.ValueMember = "ID";

            Dialog.Description_CB.DataSource = SystemArgs.Descriptions;
            Dialog.Description_CB.DisplayMember = "Name";
            Dialog.Description_CB.ValueMember = "ID";

            Dialog.Diameter_CB.DataSource = SystemArgs.Diameters;
            Dialog.Diameter_CB.DisplayMember = $"Name";
            Dialog.Diameter_CB.ValueMember = "ID";

            Dialog.NumSmeny_CB.DataSource = SystemArgs.Smeny;
            Dialog.NumSmeny_CB.DisplayMember = $"Name";
            Dialog.NumSmeny_CB.ValueMember = "ID";

            Dialog.NumTS_CB.DataSource = SystemArgs.TSN;
            Dialog.NumTS_CB.DisplayMember = $"Name";
            Dialog.NumTS_CB.ValueMember = "ID";

            Dialog.TypeDefect_CB.DataSource = SystemArgs.TypesDefect;
            Dialog.TypeDefect_CB.DisplayMember = $"Name";
            Dialog.TypeDefect_CB.ValueMember = "ID";

            Dialog.TypeAlloy_CB.DataSource = SystemArgs.TypesAlloy;
            Dialog.TypeAlloy_CB.DisplayMember = $"Name";
            Dialog.TypeAlloy_CB.ValueMember = "ID";

            Dialog.LocationProduction_CB.DataSource = SystemArgs.DefectLocProduction;
            Dialog.LocationProduction_CB.DisplayMember = $"Name";
            Dialog.LocationProduction_CB.ValueMember = "ID";

            Dialog.ProgressMark_CB.DataSource = SystemArgs.ProgressMark;
            Dialog.ProgressMark_CB.DisplayMember = $"Name";
            Dialog.ProgressMark_CB.ValueMember = "ID";
        }

        private static String SetLocalDefectIngot(Add_F Dialog)
        {
            String LocaDefectIngot = String.Empty;

            foreach (Control TypeControl in Dialog.Controls)
            {
                if (TypeControl is CheckBox)
                {
                    CheckBox Temp = TypeControl as CheckBox;

                    if (Temp.Checked)
                    {
                        LocaDefectIngot += Temp.Text + "_";
                    }
                }
                else
                {
                    continue;
                }
            }

            if (LocaDefectIngot != String.Empty && LocaDefectIngot[LocaDefectIngot.Length - 1] == '_')
            {
                LocaDefectIngot = LocaDefectIngot.Remove(LocaDefectIngot.Length - 1, 1);
            }

            return LocaDefectIngot;
        }

        public static void AddPosition()
        {
            if (!SystemArgs.StatusConnect)
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Add_F Dialog = new Add_F();

                DateTime DateCreate = DateTime.Now;

                Dialog.DateCreate_TB.Text = DateCreate.ToShortDateString();

                SetComboBox(Dialog);

                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    String LocDefIngot = SetLocalDefectIngot(Dialog);

                    Int64 ID = -1;

                    using (var Connect = new NpgsqlConnection(SystemArgs.ConnectString))
                    {
                        Connect.Open();

                        using (var Command = new NpgsqlCommand($"SELECT last_value FROM \"Ingot_ID_seq\"", Connect))
                        {
                            using (var Reader = Command.ExecuteReader())
                            {
                                while (Reader.Read())
                                {
                                    ID = Reader.GetInt64(0);
                                }
                            }
                        }

                        Position Temp = new Position(ID + 1, DateCreate, Dialog.Calendar_MC.SelectionStart, Dialog.NumMelt_TB.Text.Trim(), Convert.ToInt64(Dialog.Count_TB.Text.Trim()),
                                                     Convert.ToDouble(Dialog.Weight_TB.Text.Trim()), LocDefIngot, Dialog.Correction_TB.Text.Trim(), Dialog.Address_TB.Text.Trim(),Dialog.Reason_TB.Text.Trim(), (TSN)Dialog.NumTS_CB.SelectedItem, (ListBrigades)Dialog.NumBrigade_CB.SelectedItem,
                                                     (DefectProduction)Dialog.LocationProduction_CB.SelectedItem, (ListSmen)Dialog.NumSmeny_CB.SelectedItem, (TypesDefect)Dialog.TypeDefect_CB.SelectedItem, (TypesAlloy)Dialog.TypeAlloy_CB.SelectedItem,
                                                     (DescriptionDefect)Dialog.Description_CB.SelectedItem, (DiameterIngot)Dialog.Diameter_CB.SelectedItem, (ProgressMark)Dialog.ProgressMark_CB.SelectedItem);

                        using (var Command = new NpgsqlCommand($"INSERT INTO public.\"Ingot\"(" +
                                                                            "\"SysDateCreate\", \"DateFormation\", \"NumMelt\", \"CountIngot\", \"WeightIngots\", \"DefectLocIngot\", \"Correction\"," +
                                                                            " \"Address\", \"Reason\", \"NumTSN\", \"NumBrigade\", \"DefLocProduction\", \"NumSmen\", \"Defect\", \"TypeAlloy\", \"Description\", \"Diameter\", \"ProgressMark\")" +
                                                                $"VALUES('{Temp.DateCreate}', '{Temp.DateFormation}', '{Temp.NumMelt}', {Temp.Count}, {Temp.WeightDB}, '{Temp.DefectLocIngot}', '{Temp.Correction}', '{Temp.Address}', '{Temp.Reason}' ," +
                                                                            $" {Temp.NumTS.ID}, {Temp.NumBrigade.ID}, {Temp.DefectLocProduction.ID}, {Temp.NumSmeny.ID}, {Temp.Defect.ID}, {Temp.TypeAlloy.ID}, {Temp.Description.ID}, {Temp.Diameter.ID}, {Temp.ProgressMark.ID});", Connect))
                        {
                            Command.ExecuteNonQuery();
                        }

                        SystemArgs.Positions.Add(Temp);

                        Connect.Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при добавлении данных на сервер", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private static void GetLocalDefectIngot(Add_F Dialog, String [] DefectLocIngot)
        {
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

        public static void ChangePosition(Position Position)
        {
            if (!SystemArgs.StatusConnect)
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Add_F Dialog = new Add_F();
            Dialog.Text = "Изменение параметров позиции";

            DateTime DateCreate = Position.DateCreate;

            Dialog.DateCreate_TB.Text = DateCreate.ToShortDateString();

            SetComboBox(Dialog);

            Dialog.NumTS_CB.SelectedIndex = SystemArgs.TSN.FindIndex(p => Position.NumTS.ID == p.ID);
            Dialog.Description_CB.SelectedIndex = SystemArgs.Descriptions.FindIndex(p => Position.Description.ID == p.ID);
            Dialog.NumSmeny_CB.SelectedIndex = SystemArgs.Smeny.FindIndex(p => Position.NumSmeny.ID == p.ID);
            Dialog.NumBrigade_CB.SelectedIndex = SystemArgs.Brigades.FindIndex(p => Position.NumBrigade.ID == p.ID);
            Dialog.Diameter_CB.SelectedIndex = SystemArgs.Diameters.FindIndex(p => Position.Diameter.ID == p.ID);
            Dialog.TypeDefect_CB.SelectedIndex = SystemArgs.TypesDefect.FindIndex(p => Position.Defect.ID == p.ID);
            Dialog.TypeAlloy_CB.SelectedIndex = SystemArgs.TypesAlloy.FindIndex(p => Position.TypeAlloy.ID == p.ID);
            Dialog.LocationProduction_CB.SelectedIndex = SystemArgs.DefectLocProduction.FindIndex(p => Position.DefectLocProduction.ID == p.ID);
            Dialog.ProgressMark_CB.SelectedIndex = SystemArgs.ProgressMark.FindIndex(p => Position.ProgressMark.ID == p.ID);

            Dialog.Calendar_MC.SelectionStart = Position.DateFormation;
            Dialog.Address_TB.Text = Position.Address;
            Dialog.Correction_TB.Text = Position.Correction;
            Dialog.Count_TB.Text = Position.Count.ToString();
            Dialog.NumMelt_TB.Text = Position.NumMelt;
            Dialog.Reason_TB.Text = Position.Reason;
            Dialog.Weight_TB.Text = Position.Weight.ToString();

            if(Position.DefectLocIngot != null)
            {
                String[] DefectLocIngot = Position.DefectLocIngot.Split('_');

                GetLocalDefectIngot(Dialog, DefectLocIngot);
            }

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                String LocDefIngot = SetLocalDefectIngot(Dialog);

                using (var Connect = new NpgsqlConnection(SystemArgs.ConnectString))
                {
                    Connect.Open();

                    Position Temp = new Position(Position.ID, DateCreate, Dialog.Calendar_MC.SelectionStart, Dialog.NumMelt_TB.Text.Trim(), Convert.ToInt64(Dialog.Count_TB.Text.Trim()),
                                                 Convert.ToDouble(Dialog.Weight_TB.Text.Trim()), LocDefIngot, Dialog.Correction_TB.Text.Trim(), Dialog.Address_TB.Text.Trim(), Dialog.Reason_TB.Text.Trim(), (TSN)Dialog.NumTS_CB.SelectedItem, (ListBrigades)Dialog.NumBrigade_CB.SelectedItem,
                                                 (DefectProduction)Dialog.LocationProduction_CB.SelectedItem, (ListSmen)Dialog.NumSmeny_CB.SelectedItem, (TypesDefect)Dialog.TypeDefect_CB.SelectedItem, (TypesAlloy)Dialog.TypeAlloy_CB.SelectedItem,
                                                 (DescriptionDefect)Dialog.Description_CB.SelectedItem, (DiameterIngot)Dialog.Diameter_CB.SelectedItem, (ProgressMark)Dialog.ProgressMark_CB.SelectedItem);

                    using (var Command = new NpgsqlCommand($"UPDATE public.\"Ingot\"" +
                                                            $"SET   \"SysDateCreate\" = '{Temp.DateCreate}', \"DateFormation\" ='{Temp.DateFormation}', \"NumMelt\" = '{Temp.NumMelt}', \"CountIngot\" = {Temp.Count}," +
                                                                $"  \"WeightIngots\" = {Temp.WeightDB}, \"DefectLocIngot\" = '{Temp.DefectLocIngot}', \"Correction\" = '{Temp.Correction}', \"Address\" = '{Temp.Address}'," +
                                                                $"  \"Reason\" ='{Temp.Reason}', \"NumTSN\" = {Temp.NumTS.ID}, \"NumBrigade\" = {Temp.NumBrigade.ID}, \"DefLocProduction\" = {Temp.DefectLocProduction.ID}," +
                                                                $"  \"NumSmen\" = {Temp.NumSmeny.ID}, \"Defect\" = {Temp.Defect.ID}, \"TypeAlloy\" = {Temp.TypeAlloy.ID}, \"Description\" = {Temp.Description.ID}, \"Diameter\" = {Temp.Diameter.ID}," +
                                                                $"  \"ProgressMark\" = {Temp.ProgressMark.ID}" +
                                                            $"WHERE \"ID\" = {Temp.ID};", Connect))
                    {
                        Command.ExecuteNonQuery();
                    }

                    SystemArgs.Positions.Remove(Position);
                    SystemArgs.Positions.Add(Temp);

                    Connect.Close();
                }
            }
        }

        public static void DeletePosition(Position Position)
        {
            if (!SystemArgs.StatusConnect)
            {
                MessageBox.Show("Не удалось полдлючиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var Connect = new NpgsqlConnection(SystemArgs.ConnectString))
            {
                Connect.Open();
             
                using (var Command = new NpgsqlCommand($"DELETE FROM public.\"Ingot\"" +
                                                        $"WHERE \"ID\" = {Position.ID}; ", Connect))
                {
                    Command.ExecuteNonQuery();
                }

                SystemArgs.Positions.Remove(Position);

                Connect.Close();
            }
        }

        public static List<Position> ResultSearch(String TextSearch)
        {
            List<Position> Result = new List<Position>();

            if (!String.IsNullOrEmpty(TextSearch))
            {
                foreach (Position Temp in SystemArgs.Positions)
                {
                    if (Temp.GetSearchString().IndexOf(TextSearch) != -1)
                    {
                        Result.Add(Temp);
                    }
                }
            }

            return Result;
        }

        public static void RequestAdd(String Name, String NameTable, String NameColumn)
        {
            if (!SystemArgs.StatusConnect)
            {
                MessageBox.Show("Не удалось подключиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String ConvertName = $@"'{Name}'";

            if(NameTable == "DiameterIngot")
            {
                ConvertName = $@"{Name}";
            }

            using (var Connect = new NpgsqlConnection(SystemArgs.ConnectString))
            {
                Connect.Open();

                using (var Command = new NpgsqlCommand($"INSERT INTO public.\"{NameTable}\"(\"{NameColumn}\")" +
                                                        $"VALUES({ConvertName});", Connect))
                {
                    Command.ExecuteNonQuery();
                }

                Connect.Close();
            }

            GetArguments();
        }

        public static void RequestChange(Int64 ID, String Name, String NameTable, String NameColumn)
        {
            if (!SystemArgs.StatusConnect)
            {
                MessageBox.Show("Не удалось полдлючиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String ConvertName = $@"'{Name}'";

            if (NameTable == "DiameterIngot")
            {
                ConvertName = $@"{Name}";
            }

            using (var Connect = new NpgsqlConnection(SystemArgs.ConnectString))
            {
                Connect.Open();

                using (var Command = new NpgsqlCommand($"UPDATE public.\"{NameTable}\"" +
                                                       $"SET \"{NameColumn}\" = {ConvertName}" +
                                                       $"WHERE \"ID\" = {ID}; ", Connect))
                {
                    Command.ExecuteNonQuery();
                }

                Connect.Close();
            }

            GetArguments();
        }

        public static void RequestDelete(Int64 ID, String NameTable)
        {
            if (!SystemArgs.StatusConnect)
            {
                MessageBox.Show("Не удалось полдлючиться в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var Connect = new NpgsqlConnection(SystemArgs.ConnectString))
            {
                Connect.Open();

                using (var Command = new NpgsqlCommand($"DELETE FROM public.\"{NameTable}\"" +
                                                       $"WHERE \"ID\" = {ID}; ", Connect))
                {
                    Command.ExecuteNonQuery();
                }

                Connect.Close();
            }

            GetArguments();
        }
    }
}
