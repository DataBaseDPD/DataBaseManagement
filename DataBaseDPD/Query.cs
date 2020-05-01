using System;


namespace DataBaseDPD
{
     public abstract class Query 


    {

        public abstract String Run(Database database);
        public abstract PrivilegeType getType();
        public abstract string getTableName();

    }
   
    
    
}
