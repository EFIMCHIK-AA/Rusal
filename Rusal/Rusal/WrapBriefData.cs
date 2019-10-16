using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusal
{
    public class WrapBriefData
    {
        private string _Name;
        private double _Value;

        public WrapBriefData(string Name,double Value)
        {
            if(Name!=null)
            {
                _Name = Name;
            }
            if(Value>=0)
            {
                _Value = Value;
            }
        }
        public WrapBriefData() : this(null, 0) { }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if(value!=null)
                {
                    _Name = value;
                }
            }
        }
        public double Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if(value>=0)
                {
                    _Value = value;
                }
            }
        }
    }
}
