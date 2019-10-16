using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusal
{
    public class WrapFullData
    {
        private DateTime _DateFormation;
        private double _SumWeight;
        private double _AccumulationWeight;
        private double _DiameterWeight;
        private double _AccumulationDiameter;

        public WrapFullData(DateTime DateFormation,double SumWeight,double AccumulationWeight,double DiameterWeight,double AccumulationDiameter)
        {
            if(DateFormation!=null)
            {
                _DateFormation = DateFormation;
            }
            if (SumWeight >= 0)
            {
                _SumWeight = SumWeight;
            }
            if (AccumulationWeight >= 0)
            {
                _AccumulationWeight = AccumulationWeight;
            }
            if (DiameterWeight >= 0)
            {
                _DiameterWeight = DiameterWeight;
            }
            if (AccumulationDiameter >= 0)
            {
                _AccumulationDiameter = AccumulationDiameter;
            }
        }
        public WrapFullData() : this(DateTime.Now, 1, 1, 1, 1) { }
        public DateTime DateFormation
        {
            get
            {
                return _DateFormation;
            }
            set
            {
                if(value!=null)
                {
                    _DateFormation = value;
                }
            }
        }
        public double SumWeight
        {
            get
            {
                return _SumWeight;
            }
            set
            {
                if (value >= 0)
                {
                    _SumWeight = value;
                }
            }
        }
        public double AccumulationWeight
        {
            get
            {
                return _AccumulationWeight;
            }
            set
            {
                if (value >= 0)
                {
                    _AccumulationWeight = value;
                }
            }
        }
        public double DiameterWeight
        {
            get
            {
                return _DiameterWeight;
            }
            set
            {
                if (value >= 0)
                {
                    _DiameterWeight = value;
                }
            }
        }
        public double AccumulationDiameter
        {
            get
            {
                return _AccumulationDiameter;
            }
            set
            {
                if (value >= 0)
                {
                    _AccumulationDiameter = value;
                }
            }
        }

    }
}
