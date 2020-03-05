using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDPD
{
    public class Header
    {
        public string[] nameColumns;
        public DataType [] type;
        public int numCol;

        public Header(string[] nameColumns, DataType [] types)
        {
            this.nameColumns = nameColumns;
            this.type = types;
            numCol = nameColumns.Length;
        }
        public int getNumCol()
        {
            return numCol;
        }
       public DataType getType(int pos)
        {
            return type[pos];
        }
    }
}
