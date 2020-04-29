using System;
using System.Collections.Generic;
using DataBaseDPD;

namespace DataBaseDPD
{

    public class Delete : Query
    {

        String Tabla;
        String col;
        String operation;
        String value;

        public Delete(String table, String left, String op, String right)
        {
            Tabla = table;
            col = left;
            operation = op;
            value = right;
        }

        public override string Run(Database database)
        {
            return database.Delete(Tabla, col , operation, value);
        }
    }
}
