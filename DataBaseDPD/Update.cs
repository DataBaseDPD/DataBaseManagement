using System;
using System.Collections.Generic;
using DataBaseDPD;

namespace DataBaseDPD
{


    public class Update : Query

    {
        public string Tabla;
        public List<string> Values = new List<string>();
        public List<string> ColNames = new List<string>();
        public string Val;
        public string ColName;
        public string ColCondition;
        public string Value;
        public string Operation;


        public Update(string tabla, string col, string val)
        {
            Tabla = tabla;
            ColNames.Add(col);
            Values.Add(val);
            Operation = "";
        }
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
            Operation = "";

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

        public override PrivilegeType getType()
        {
            return PrivilegeType.UPDATE;
        }
        public override string getTableName()
        {
            return Tabla;
        }

        public override string Run(Connection connection)
        {
            throw new NotImplementedException();
        }
    }
}