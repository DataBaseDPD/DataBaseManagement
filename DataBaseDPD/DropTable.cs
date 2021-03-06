﻿using System;
using DataBaseDPD;


namespace DataBaseDPD
{
	
	public class DropTable : Query
    {

        public string Table;

        public DropTable(string table)
        {

            Table = table;


        }

        public override string getTableName()
        {
            return Table;
        }

        public override PrivilegeType getType()
        {
            return PrivilegeType.OTHER;
        }

        public override String Run(Database database)
        {

            
           return database.DropTabla(Table);


        }

        public override string Run(Connection connection)
        {
            throw new NotImplementedException();
        }
    }

}