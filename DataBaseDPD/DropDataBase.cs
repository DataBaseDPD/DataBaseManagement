using System;
using DataBaseDPD;


public class DropDataBase : Query
{

    String Base;

    public DropDataBase(String database)
    {

        Base = database;

    }

    public override String Run()
    {

        throw new NotImplementedException();

    }

    public string getBase()
    {

        return Base;
    }


}
