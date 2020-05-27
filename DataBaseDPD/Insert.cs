using System;
using System.Collections.Generic;
using DataBaseDPD;

namespace DataBaseDPD
{

    public class Insert : Query
    {

        public List<string> Values = new List<string>();
        public string Tabla { get; }


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

        public override PrivilegeType getType()
        {
            return PrivilegeType.INSERT;
        }
        public override string getTableName()
        {
            return Tabla;
        }

        public override string Run(Connection connection)
        {
            throw new NotImplementedException();
        }
    }

}
