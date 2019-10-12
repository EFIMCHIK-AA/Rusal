using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using System.Drawing;
using System.Windows.Forms;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using OxyPlot.Series;

namespace Rusal
{
    public static class Analysis
    {
        private static List<int> vs = new List<int>();
        public static void BriefDiametrWeight(DateTime datestart, DateTime datefinish)
        {
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.Diameter.Name into g
                        select new { Name = g.Key, Value = g.Sum(w => w.Weight) };
            Analysis_F Dialog = new Analysis_F();
            ColumnSeries histogramm = new ColumnSeries();
            CategoryAxis xaxis = new CategoryAxis();
            xaxis.Position = AxisPosition.Bottom;
            xaxis.MajorGridlineStyle = LineStyle.Solid;
            xaxis.MinorGridlineStyle = LineStyle.Dot;
            histogramm.IsStacked = true;
            foreach (var item in Group)
            {
                Dialog.listBox1.Items.Add(item.Name);
                Dialog.listBox2.Items.Add(item.Value);
                histogramm.Items.Add(new ColumnItem(item.Value));
                xaxis.Labels.Add(item.Name.ToString());
            }
            Dialog.pv.Model = new PlotModel { Title = "Анализ" };
            Dialog.pv.Model.Axes.Add(xaxis);
            Dialog.pv.Model.Series.Add(histogramm);

            Dialog.ShowDialog();
            
        }
        public static void BriefBrigadeWeight(DateTime datestart, DateTime datefinish)
        {
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.NumBrigade.Name into g
                        select new { Name = g.Key, Value = g.Sum(w => w.Weight) };
        }
        public static void BriefNumTSWeight(DateTime datestart, DateTime datefinish)
        {
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.NumTS.Name into g
                        select new { Name = g.Key, Value = g.Sum(w => w.Weight) };
        }
        public static void BriefDescriptionWeight(DateTime datestart, DateTime datefinish)
        {
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.Description.Name into g
                        select new { Name = g.Key, Value = g.Sum(w => w.Weight) };
        }
        public static void BriefBrigadeCount(DateTime datestart, DateTime datefinish)
        {
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.NumBrigade.Name into g
                        select new { Name = g.Key, Value = g.Count() };
        }
        public static void BriefNumTSCount(DateTime datestart, DateTime datefinish)
        {
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.NumBrigade.Name into g
                        select new { Name = g.Key, Value = g.Count() };
        }
        public static void BriefDescriptionCount(DateTime datestart, DateTime datefinish)
        {
            var Group = from gp in SystemArgs.Positions
                        where (gp.DateCreate >= datestart) && (gp.DateCreate <= datefinish)
                        group gp by gp.Description.Name into g
                        select new { Name = g.Key, Value = g.Count() };
        }

    }
}
