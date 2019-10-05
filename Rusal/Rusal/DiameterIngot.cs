using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusal
{
    public class DiameterIngot : BaseDictionary
    {
        private Double _Name; //Наименование из БД
        private Int32 _ID;

        public DiameterIngot(Int32 ID, Double Name) : base(ID)
        {
            if (Name >= 0)
            {
                _Name = Name;
            }
        }

        public DiameterIngot() : this(0, 0) { }

        public override Int32 ID
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

        public Double Name
        {
            get
            {
                return _Name;
            }

            set
            {
                if (value >= 0)
                {
                    _Name = value;
                }
            }
        }
    }
}
