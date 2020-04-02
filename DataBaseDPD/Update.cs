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
        string Val;
        string ColName;
        string ColCondition;
        string Value;
        string Operation;
       


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
        public Update(string tabla, string col, string val, string colCondition, string operacion, string value)
        {
            Tabla = tabla;
            Val = val;
            ColName = col;
            ColCondition = colCondition;
            Operation = operacion;
            Value = value;
        }


        public override string Run(Database database)
        {
            if (Operation == "")
            {
                return database.Update(Tabla, ColNames, Values);
            }
            else if(Operation != "")
            {
                return database.Update(Tabla,ColName,Val,ColCondition,Operation,Value);
            }
            else
            {
                return Message.WrongSyntax;
            }
            
        }


     }
}