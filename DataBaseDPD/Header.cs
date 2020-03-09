using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDPD
{
    public class Header
    {
        public string atributes;
        public DataType [] type;
        public int numCol;

        public Header(string[] nameColumns, DataType [] types)
        {
            
            for (int i = 0; 1 < nameColumns.Length; i++)
            {
                
            }
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
