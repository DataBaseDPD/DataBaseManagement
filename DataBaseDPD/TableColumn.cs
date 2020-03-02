

using System.Collections.Generic;

namespace DataBaseDPD
{
    public class TableColumn

    {
        List<string> column;
        public TableColumn()
        {
            column = new List<string>();
        }
        public void add(string item)
        {
            column.Add(item);
        }
    }
}
