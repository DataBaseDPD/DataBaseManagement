using System;
using System.Collections.Generic;

namespace DataBaseDPD
{
    public class SelectAll : Query

    {
        string Table;
        List<string> Columns;

        public SelectAll(string nameTable)
        {
            Table = nameTable;
        }

        public override string Run(Database database)
        {
            return database.SelectAll(Table);
        }
    }
}
