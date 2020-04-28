using System;
using DataBaseDPD;


namespace DataBaseDPD
{
	
	public class DropTable : Query
    {
       
        string theTable;

        public DropTable(string table)
        {

            theTable = table;


        }



        public override String Run(Database database)
        {

            
           return database.DropTabla(theTable);


        }

        

    }

}