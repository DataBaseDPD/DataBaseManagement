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

        public override string Run(Database database)
        {
            return database.Select(Table,Columns);
        }
    }
}