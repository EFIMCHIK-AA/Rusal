using System;
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
    public partial class ParamSearch_F : Form
    {
        public ParamSearch_F()
        {
            InitializeComponent();
        }

        private static List<DefectProduction> DefectLocProduction; //Список мест дефектов в производственном процессе
        private static List<TypesDefect> TypesDefect;//Типы дефектов (устранимый или брак)
        private static List<TypesAlloy> TypesAlloy;//Марки сплавов
        private static List<ProgressMark> ProgressMark; //Отметка о выполнении
        private static List<TSN> TSN; //Номера технических спецификаций
        private static List<ListBrigades> Brigades; //Список бригад
        private static List<ListSmen> Smeny; //Список смен
        private static List<DescriptionDefect> Descriptions; //Список описаний дефекта
        private static List<DiameterIngot> Diameters; // Диаметры слитков

        private void ParamSearch_F_Load(object sender, EventArgs e)
        {
            DefectLocProduction = new List<DefectProduction>();
            TypesDefect = new List<TypesDefect>();
            TypesAlloy = new List<TypesAlloy>();
            ProgressMark = new List<ProgressMark>();
            TSN = new List<TSN>();
            Brigades = new List<ListBrigades>();
            Smeny = new List<ListSmen>();
            Descriptions = new List<DescriptionDefect>();
            Diameters = new List<DiameterIngot>();

            DefectLocProduction.Add(new DefectProduction(-1, "Не задано"));
            DefectLocProduction.AddRange(SystemArgs.DefectLocProduction);
            LocationProduction_CB.DataSource = DefectLocProduction;

            Descriptions.Add(new DescriptionDefect(-1, "Не задано"));
            Descriptions.AddRange(SystemArgs.Descriptions);
            Description_CB.DataSource = Descriptions;

            Diameters.Add(new DiameterIngot(-1, -1));
            Diameters.AddRange(SystemArgs.Diameters);
            Diameter_CB.DataSource = Diameters;

            Brigades.Add(new ListBrigades(-1, "Не задано"));
            Brigades.AddRange(SystemArgs.Brigades);
            NumBrigade_CB.DataSource = Brigades;

            Smeny.Add(new ListSmen(-1, "Не задано"));
            Smeny.AddRange(SystemArgs.Smeny);
            NumSmeny_CB.DataSource = Smeny;

            TSN.Add(new TSN(-1, "Не задано"));
            TSN.AddRange(SystemArgs.TSN);
            NumTS_CB.DataSource = TSN;

            ProgressMark.Add(new ProgressMark(-1, "Не задано"));
            ProgressMark.AddRange(SystemArgs.ProgressMark);
            ProgressMark_CB.DataSource = ProgressMark;

            TypesAlloy.Add(new TypesAlloy(-1, "Не задано"));
            TypesAlloy.AddRange(SystemArgs.TypesAlloy);
            TypeAlloy_CB.DataSource = TypesAlloy;

            TypesDefect.Add(new TypesDefect(-1, "Не задано"));
            TypesDefect.AddRange(SystemArgs.TypesDefect);
            TypeDefect_CB.DataSource = TypesDefect;
        }
    }
}
