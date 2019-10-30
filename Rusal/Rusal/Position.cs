using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusal
{
    public class Position
    {
        private Int64 _ID; //ID из БД
        private DateTime _DateCreate; //Дата создания позиции в ПО
        private DateTime _DateFormation; //Дата возникновения
        private String _NumMelt; //Номер плавки
        private Int64 _Count; //Количество
        private Double _Weight; //Вес
        private String _DefectLocIngot; //Место дефекта на слитке
        private String _Correction; // Меры коррекции
        private String _Address; // Адрес слитка
        private String _Reason; //Возможные причины дефекта
        private TSN _NumTS; //Номер технической спецификации
        private ListBrigades _NumBrigade; //Номер бригады
        private DefectProduction _DefectLocProduction; // Место дефекта в производстве
        private ListSmen _NumSmeny; //Номер смены
        private TypesDefect _Defect; //Тип дефекта
        private TypesAlloy _TypeAlloy; //Марка сплава
        private DescriptionDefect _Description; //Описание или вид дефекта
        private DiameterIngot _Diameter; // Даиметр слитка
        private ProgressMark _ProgressMark; //Метка о выполнении

        public Position(Int64 ID, DateTime DateCreate, DateTime DateFormation, String NumMelt, Int64 Count, Double Weight,
                        String DefectLocIngot, String Correction, String Address, String Reason, TSN NumTS, ListBrigades NumBrigade,
                        DefectProduction DefectLocProduction, ListSmen NumSmeny, TypesDefect Defect, TypesAlloy TypeAlloy,
                        DescriptionDefect Description, DiameterIngot Diameter,ProgressMark ProgressMark)
        {
            if(ID >= 0)
            {
                _ID = ID;
            }

            if(DateCreate != null)
            {
                _DateCreate = DateCreate;
            }

            if(DateFormation != null)
            {
                _DateFormation = DateFormation;
            }

            if(!String.IsNullOrEmpty(NumMelt))
            {
                _NumMelt = NumMelt;
            }

            if(Count >= 0)
            {
                _Count = Count;
            }

            if(Weight >= 0)
            {
                _Weight = Weight;
            }

            if (!String.IsNullOrEmpty(DefectLocIngot))
            {
                _DefectLocIngot = DefectLocIngot;
            }

            if (!String.IsNullOrEmpty(Correction))
            {
                _Correction = Correction;
            }

            if (!String.IsNullOrEmpty(Address))
            {
                _Address = Address;
            }

            if (!String.IsNullOrEmpty(Reason))
            {
                _Reason = Reason;
            }

            if (NumTS != null)
            {
                _NumTS = NumTS;
            }

            if (NumBrigade != null)
            {
                _NumBrigade = NumBrigade;
            }

            if (DefectLocProduction != null)
            {
                _DefectLocProduction = DefectLocProduction;
            }

            if (NumSmeny != null)
            {
                _NumSmeny = NumSmeny;
            }

            if (Defect != null)
            {
                _Defect = Defect;
            }

            if (TypeAlloy != null)
            {
                _TypeAlloy = TypeAlloy;
            }

            if (Description != null)
            {
                _Description = Description;
            }

            if(Diameter != null)
            {
                _Diameter = Diameter;
            }

            if (ProgressMark != null)
            {
                _ProgressMark = ProgressMark;
            }
        }

        public Position() : this(0, DateTime.Now, DateTime.Now, "Без номера плавки", 0, 0, "Без места дефекта на слитке", "Без коррекции", "Без адреса","Без возможной причины", null,
                                 null, null, null, null, null, null, null, null) { }

        public Int64 ID
        {
            get
            {
                return _ID;
            }

            set
            {
                if (value >= 0)
                {
                    _ID = value;
                }
            }
        }

        public DateTime DateCreate
        {
            get
            {
                return _DateCreate;
            }

            set
            {
                if (value != null)
                {
                    _DateCreate = value;
                }
            }
        }

        public DateTime DateFormation
        {
            get
            {
                return _DateFormation;
            }

            set
            {
                if (value != null)
                {
                    _DateFormation = value;
                }
            }
        }

        public String NumMelt
        {
            get
            {
                return _NumMelt;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _NumMelt = value;
                }
            }
        }

        public Int64 Count
        {
            get
            {
                return _Count;
            }

            set
            {
                if (value >= 0)
                {
                    _Count = value;
                }
            }
        }

        public Double Weight
        {
            get
            {
                return _Weight;
            }

            set
            {
                if (value >= 0)
                {
                    _Weight = value;
                }
            }
        }

        public String WeightDB
        {
            get
            {
                return _Weight.ToString().Replace(',','.');
            }
        }

        public String DefectLocIngot
        {
            get
            {
                return _DefectLocIngot;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _DefectLocIngot = value;
                }
            }
        }

        public String Correction
        {
            get
            {
                return _Correction;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Correction = value;
                }
            }
        }

        public String Address
        {
            get
            {
                return _Address;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Address = value;
                }
            }
        }

        public String Reason
        {
            get
            {
                return _Reason;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Reason = value;
                }
            }
        }

        public TSN NumTS
        {
            get
            {
                return _NumTS;
            }

            set
            {
                if (value != null)
                {
                    _NumTS = value;
                }
            }
        }

        public ListBrigades NumBrigade
        {
            get
            {
                return _NumBrigade;
            }

            set
            {
                if (value != null)
                {
                    _NumBrigade = value;
                }
            }
        }

        public DefectProduction DefectLocProduction
        {
            get
            {
                return _DefectLocProduction;
            }

            set
            {
                if (value != null)
                {
                    _DefectLocProduction = value;
                }
            }
        }

        public ListSmen NumSmeny
        {
            get
            {
                return _NumSmeny;
            }

            set
            {
                if (value != null)
                {
                    _NumSmeny = value;
                }
            }
        }

        public TypesDefect Defect
        {
            get
            {
                return _Defect;
            }

            set
            {
                if (value != null)
                {
                    _Defect = value;
                }
            }
        }

        public TypesAlloy TypeAlloy
        {
            get
            {
                return _TypeAlloy;
            }

            set
            {
                if (value != null)
                {
                    _TypeAlloy = value;
                }
            }
        }

        public DescriptionDefect Description
        {
            get
            {
                return _Description;
            }

            set
            {
                if (value != null)
                {
                    _Description = value;
                }
            }
        }

        public DiameterIngot Diameter
        {
            get
            {
                return _Diameter;
            }

            set
            {
                if (value != null)
                {
                    _Diameter = value;
                }
            }
        }

        public String DiameterSort
        {
            get
            {
                return _Diameter.ToString();
            }
        }

        public String NumTSSort
        {
            get
            {
                return _NumTS.ToString();
            }
        }

        public ProgressMark ProgressMark
        {
            get
            {
                return _ProgressMark;
            }

            set
            {
                if (value != null)
                {
                    _ProgressMark = value;
                }
            }
        }

        public String GetSearchString()
        {
            return $"{_DateFormation.ToShortDateString()}_{_NumMelt}_{_Count}_{_Weight}_{_DefectLocIngot}_{_Correction}_{_Address}_{_Reason}_{_NumTS.Name}_" +
                   $"{_NumBrigade.Name}_{_DefectLocProduction.Name}_{_NumSmeny}_{_Defect.Name}_{_NumTS.Name}_{_TypeAlloy.Name}_{_Description.Name}_{Diameter.Name}_{_ProgressMark.Name}";
        }
    }
}
