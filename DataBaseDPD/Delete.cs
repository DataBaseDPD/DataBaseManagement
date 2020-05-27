using System;
using System.Collections.Generic;
using DataBaseDPD;

namespace DataBaseDPD
{

    public class Delete : Query
    {

        String Tabla;
        String colCondition;
        String Operation;
        String Value;

        public Delete(String table, String left, String op, String right)
        {
            Tabla = table;
            colCondition = left;
            Operation = op;
            Value = right;
        }

        public override PrivilegeType getType()
        {
            return PrivilegeType.DELETE;
        }

        public override string Run(Database database)
        {
            return database.Delete(Tabla, colCondition , Operation, Value);
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
