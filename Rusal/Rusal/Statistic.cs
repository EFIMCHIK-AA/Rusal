using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rusal
{
    public static class Statistic
    {
        public static void Ingot(DateTime start,DateTime finish,TextBox North,TextBox South,TextBox West,TextBox East,TextBox TB1,TextBox TB2,TextBox TB3, TextBox TB4, TextBox TB5, TextBox TB6)
        {
            SystemArgs.Result = SystemArgs.Positions.Where(p => (p.DateFormation >= start) && (p.DateFormation <= finish)).ToList();

            int[] SumDefect = new int[10];
            for (int i = 0; i < SystemArgs.Result.Count; i++)
            {
                if (SystemArgs.Result[i].DefectLocIngot != null)
                {
                    String[] DefectLocIngot = SystemArgs.Result[i].DefectLocIngot.Split('_');

                    foreach (String Name in DefectLocIngot)
                    {
                        switch (Name)
                        {
                            case "С":
                                SumDefect[0] += 1;
                                break;
                            case "Ю":
                                SumDefect[1] += 1;
                                break;
                            case "З":
                                SumDefect[2] += 1;
                                break;
                            case "В":
                                SumDefect[3] += 1;
                                break;
                            case "1":
                                SumDefect[4] += 1;
                                break;
                            case "2":
                                SumDefect[5] += 1;
                                break;
                            case "3":
                                SumDefect[6] += 1;
                                break;
                            case "4":
                                SumDefect[7] += 1;
                                break;
                            case "5":
                                SumDefect[8] += 1;
                                break;
                            case "6":
                                SumDefect[9] += 1;
                                break;
                        }
                    }
                }
            }
                North.Text = SumDefect[0].ToString();
                South.Text = SumDefect[1].ToString();
                West.Text = SumDefect[2].ToString();
                East.Text = SumDefect[3].ToString();
                TB1.Text = SumDefect[4].ToString();
                TB2.Text = SumDefect[5].ToString();
                TB3.Text = SumDefect[6].ToString();
                TB4.Text = SumDefect[7].ToString();
                TB5.Text = SumDefect[8].ToString();
                TB6.Text = SumDefect[9].ToString();
        }
        public static void Production(DateTime start,DateTime finish,DataGridView DGV)
        {
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateFormation >= start) && (gp.DateFormation <= finish)
                        group gp by gp.DefectLocProduction.Name into g
                        select new { Name = g.Key, Value = g.Sum(w => 1) };
            foreach(var dp in Group)
            {
                DGV.RowCount++;
                DGV[0, DGV.RowCount - 1].Value = dp.Name;
                DGV[1, DGV.RowCount - 1].Value = dp.Value;
            }
        }
    }
}
