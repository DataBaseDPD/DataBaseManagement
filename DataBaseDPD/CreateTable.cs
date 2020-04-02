

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
            

            string[] split = data.Split(' ');
            for (int i = 0; i < split.Length; i = i + 2)
            {
                columnNames.Add(split[i]);
                dataType.Add(split[i + 1].Trim(','));
            }



        }


        public override string Run(Database bd)
        {


            return bd.CreateTable(theTable, columnNames, dataType);

        }

        

    }
}