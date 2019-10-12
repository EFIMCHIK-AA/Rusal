﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusal
{
    public class ProgressMark : BaseDictionary
    {
        private String _Name; //Наименование из БД
        private Int32 _ID;

        public ProgressMark(Int32 ID, String Name) : base(ID)
        {
            if (!String.IsNullOrEmpty(Name))
            {
                _Name = Name;
            }
        }

        public ProgressMark() : this(0, "Без наименования") { }

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

        public String Name
        {
            get
            {
                return _Name;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Name = value;
                }
            }
        }

        public override String ToString()
        {
            return _Name;
        }
    }
}
