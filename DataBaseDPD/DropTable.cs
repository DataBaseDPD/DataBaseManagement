using System;
using DataBaseDPD;


namespace DataBaseDPD
{
	
	public class DropTable : Query
    {
       
        string Table;

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
            return PrivilegeType.ADMIN;
        }

        public override String Run(Database database)
        {

            
           return database.DropTabla(Table);


        }

        

    }

}