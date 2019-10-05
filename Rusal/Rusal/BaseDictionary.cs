using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusal
{
    abstract public class BaseDictionary
    {
        abstract public Int32 ID { get; set;} //ID из БД

        public BaseDictionary (Int32 ID)
        {
            if(ID >= 0)
            {
                this.ID = ID;
            }
        }

        public BaseDictionary() : this(0) { }
    }
}
