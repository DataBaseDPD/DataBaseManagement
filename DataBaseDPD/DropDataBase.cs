using System;
using DataBaseDPD;

namespace DataBaseDPD
{
    public class DropDataBase : Query
    {

        String Base;

        public DropDataBase(String database)
        {

            Base = database;

        }

        public override String Run(Database db)
        {

            return "Not Implement";

        }

        public string getBase()
        {

            return Base;
        }


    }
}