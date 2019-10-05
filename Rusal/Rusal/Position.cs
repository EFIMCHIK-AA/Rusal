using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusal
{
    public class Position
    {
        private DateTime _DateCreate; //Дата создания позиции в ПО
        private DateTime _DateFormation; //Дата возникновения
        private String _NumMelt; //Номер плавки
        private Int32 _Count; //Количество
        private Double _Weight; //Вес
        private String _DefectLocIngot; //Место дефекта на слитке
        private String _Correction; // Меры коррекции
        private String _Address; // Адрес слитка
        private String _NumTS; //Номер технической спецификации
        private String _NumBrigade; //Номер бригады
        private String _DefectLocProduction; // Место дефекта в производстве
        private String _NumSmeny; //Номер смены
        private String _Defect; //Тип дефекта
        private String _TypeAlloy; //Марка сплава
        private String _Description; //Описание или вид дефекта
        private Double _Diameter; // Даиметр слитка
        private String _ProgressMark; //Метка о выполнении

        public Position(DateTime DateCreate, DateTime DateFormation, String NumMelt, Int32 Count, Double Weight,
                        String DefectLocIngot, String Correction, String Address, String NumTS, String NumBrigade,
                        String DefectLocProduction, String NumSmeny, String Defect, String TypeAlloy, String Description, Double Diameter,
                        String ProgressMark)
        {
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

            if (!String.IsNullOrEmpty(NumTS))
            {
                _NumTS = NumTS;
            }

            if (!String.IsNullOrEmpty(NumBrigade))
            {
                _NumBrigade = NumBrigade;
            }

            if (!String.IsNullOrEmpty(DefectLocProduction))
            {
                _DefectLocProduction = DefectLocProduction;
            }

            if (!String.IsNullOrEmpty(NumSmeny))
            {
                _NumSmeny = NumSmeny;
            }

            if (!String.IsNullOrEmpty(Defect))
            {
                _Defect = Defect;
            }

            if (!String.IsNullOrEmpty(TypeAlloy))
            {
                _TypeAlloy = TypeAlloy;
            }

            if (!String.IsNullOrEmpty(Description))
            {
                _Description = Description;
            }

            if(Diameter >= 0)
            {
                _Diameter = Diameter;
            }

            if (!String.IsNullOrEmpty(ProgressMark))
            {
                _ProgressMark = ProgressMark;
            }
        }

        public Position() : this(DateTime.Now, DateTime.Now, "Без номера плавки", 0, 0, "Без места дефекта на слитке", "Без коррекции", "Без адреса", "Без номера ТС",
                                 "Без номера бригады","Без места дефекта в производстве", "Без номера смены", "Без типа дефекта", "Без марки сплава", "Без описания", 0, "Без маркера выполнения") { }

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

        public Int32 Count
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

        public String NumTS
        {
            get
            {
                return _NumTS;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _NumTS = value;
                }
            }
        }

        public String NumBrigade
        {
            get
            {
                return _NumBrigade;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _NumBrigade = value;
                }
            }
        }

        public String DefectLocProduction
        {
            get
            {
                return _DefectLocProduction;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _DefectLocProduction = value;
                }
            }
        }

        public String NumSmeny
        {
            get
            {
                return _NumSmeny;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _NumSmeny = value;
                }
            }
        }

        public String Defect
        {
            get
            {
                return _Defect;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Defect = value;
                }
            }
        }

        public String TypeAlloy
        {
            get
            {
                return _TypeAlloy;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _TypeAlloy = value;
                }
            }
        }

        public String Description
        {
            get
            {
                return _Description;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Description = value;
                }
            }
        }

        public Double Diameter
        {
            get
            {
                return _Diameter;
            }

            set
            {
                if (value >= 0)
                {
                    _Diameter = value;
                }
            }
        }

        public String ProgressMark
        {
            get
            {
                return _ProgressMark;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _ProgressMark = value;
                }
            }
        }
    }
}
