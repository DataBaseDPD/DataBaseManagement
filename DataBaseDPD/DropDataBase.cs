using System;
using DataBaseDPD;


public class DropDataBase : Query
{

    String dBase;

    public DropDataBase(String database)
    {

        Base = database;

    }

    public override String Run(DataBase db)
    {

        throw new NotImplementedException();

    }

    public string getBase()
    {

        return dBase;
    }


}
