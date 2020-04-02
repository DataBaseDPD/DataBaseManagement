using System;
using System.Collections.Generic;
using DataBaseDPD;

namespace DataBaseDPD
{
    public class Select : Query

    {
        string Table;
        List<string> Columns = new List<string>();

        public Select(string nameTable, List<string> column) {
            Table = nameTable;
            Columns = column;
        }
        public Select(string nameTable)
        {
            Table = nameTable;
        }

        public override string Run(Database database)
        {
            if (Columns.Count==0)
            {
                return database.Select(Table);
            }
            else
            {
                return database.Select(Table, Columns);
            }
            
        }
    }
}