using System;
using DataBaseDPD;

namespace DataBaseDPD
{

    public class Insert : Query
    {

        List<string> columNames = new List<string>();
        string[] valuesSeparated;
        string tabName { get; }


        //Sin columna
        public Insert(string table, string values)
        {

            tabName = table;
            valuesSeparated = values.Split(',');
            for (int a=0;a<valuesSeparated.Length;a++)
            {
                valuesSeparated[a] = valuesSeparated[i].Trim(' ');    
            }
        }

        //Con columna
        public Insert (string table, string columns , string values)
        {

            string[] listColumns = columns.Split(',');
            foreach (string col in listColumns)
            {

                columNames.Add(col);

            }

            tabName = table;
            valuesSeparated = values.Split(',');
            for (int a = 0; a < valuesSeparated.Length; a++)
            {
                valuesSeparated[a] = valuesSeparated[i].Trim(' ');
            }

        }

        public override string Run(DataBase db)
        {

            if (columNames.Count ==0)
            {

                db.Insert(tabName,valuesSeparated);


            }
            else
            {


                db.Insert(tabName,columNames,valuesSeparated);


            }

            return null;

        }


    }





}
