using System;
using System.Collections.Generic;
using DataBaseDPD;

namespace DataBaseDPD
{


    public class Update : Query

    {
        string Tabla;
        List<string> ColNames = new List<string>();
        List<string> Values = new List<string>();


        public Update(string nameTable, List<string> colNames, List<string> values)
        {
            Tabla = nameTable;
            ColNames = colNames;
            Values = values;
        }


        public override string Run(Database database)
        {
            return database.Update(Tabla, ColNames, Values);
        }


     }
}