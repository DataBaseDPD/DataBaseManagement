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
        public TableRow()
        {
            tuple = new List<string>();
        }
        public void add(string[] items)
        {
            for (int i=0;1<items.Length;i++)
            {
                string item = items[i];
                tuple.Add(item);
            }
            
        }
        public string getItem(int position)
        {
            return null;
        }
        public string getItem(string columnName)
        {
            return null;
        }
    }
}
