using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDPD
{
    public class Header
    {
        public string name { get; set; }
        public DataType type;
        public int numCol;

        public Header(string name, DataType type, int numColmn)
        {
            this.name = name;
            this.type = type;
            int numCol = numColmn;
        }
       
    }
}
