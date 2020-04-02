using System;
using System.Collections.Generic;
using DataBaseDPD;

namespace DataBaseDPD
{

    public class Insert : Query
    {

        List<string> Values = new List<string>();
        string Tabla { get; }


        //Todas las columnnas
        public Insert(string table, List<string> values)
        {

            Tabla = table;
            Values = values;
        }

        public override string Run(Database db)
        {

            
            return db.Insert(Tabla,Values);

        }


    }





}
