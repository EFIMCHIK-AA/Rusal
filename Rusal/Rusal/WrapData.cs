using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusal
{
    public class WrapData
    {
        private DateTime _DateCreate;
        private double _SumWeight;
        private double _AccumulationWeight;
        private double _DiameterWeight;
        private double _AccumulationDiameter;

        public WrapData(DateTime DateCreate,double SumWeight,double AccumulationWeight,double DiameterWeight,double AccumulationDiameter)
        {
            if(DateCreate!=null)
            {
                _DateCreate = DateCreate;
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
        public WrapData() : this(DateTime.Now, 1, 1, 1, 1) { }
        public DateTime DateCreate
        {
            get
            {
                return _DateCreate;
            }
            set
            {
                if(value!=null)
                {
                    _DateCreate = value;
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
