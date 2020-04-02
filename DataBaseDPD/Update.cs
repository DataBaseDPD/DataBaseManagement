using System;
using System.Collections.Generic;
using DataBaseDPD;

namespace DataBaseDPD
{


    public class Update : Query

    {
        string Tabla;
        List<string> Values = new List<string>();
        List<string> ColNames = new List<string>();
       


        public Update(string nameTable, List<string> datas)
        {
            Tabla = nameTable;
            foreach (string data in datas )
            {
                string[] split = data.Split('=');
                for (int i = 0; i < split.Length; i = i + 2)
                {
                    ColNames.Add(split[i]);
                    Values.Add(split[i + 1].Trim(','));
                }

            }


        }


        public override string Run(Database database)
        {
            return database.Update(Tabla, ColNames, Values);
        }


     }
}