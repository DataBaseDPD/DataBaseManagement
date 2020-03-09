using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDPD
{
    public class TableRow
    {
        List<string> tuple;
        public TableRow(string[] items)
        {
            tuple = new List<string>();
            for (int i = 0; 1 < items.Length; i++)
            {
                tuple.Add(items[i]);
            }
        }
        
        public string getItem(int position)
        {
            return tuple[position];
        }
        public string getItem(string columnName)
        {
            return null;
        }
        public List<string> getTuple()
        {
            return tuple;
        }
    }
}
