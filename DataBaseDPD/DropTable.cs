using System;
using DataBaseDPD;


namespace DataBaseDPD
{
	
	public class DropTable : Query
    {
        string theColumns;
        string theTable;

        public DropTable(string table)
        {

            theTable = table;


        }



        public override String Run(DataBase database)
        {

            


        }


    }

}