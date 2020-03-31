using System;
using DataBaseDPD;

public class CreateDataBase : Query
{

    String dBase;

    public CreateDataBase(String database)
    {

        dBase = database;


    }

    public override String Run(DataBase db)
    {
        DataBase database = new DataBase(db);
       
        return dBase+"Database created";

    }

    public string getBase()
    {

        return dBase;
    }


}
