

using System;
using DataBaseDPD;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DataBaseDPD
{
    public class CreateTable : Query
    {

        string theTable;
        List<string> columnNames = new List<string>();
        List<string> dataType = new List<string>();

        public CreateTable(string table, string data)
        {
            theTable = table;
            

            string[] split = data.Split(' ', ',');
            if (split.Length%2==0)
            {
                for (int i = 0; i < split.Length; i = i + 2)
                {
                    if (split[i] != "")
                    {
                        columnNames.Add(split[i]);
                        dataType.Add(split[i + 1]);
                    }

                }
            }
            else
            {
                columnNames.Add("null");
            }


        }


        public override string Run(Database bd)
        {


            return bd.CreateTable(theTable, columnNames, dataType);

        }

        

    }
}