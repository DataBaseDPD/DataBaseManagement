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
            string[] splitParameters = data.Split(',');

            foreach (string toSplit in splitParameters)
            {

                string trimmedToSplit = toSplit.Trim(' ');
                dataType.Add(trimmedToSplit.Split(' ')[1]);
                columnNames.Add(trimmedToSplit.Split(' ')[0]);

            }



        }


        public override string Run(DataBase bd)
        {
            


        }

        public string getTable()
        {
            return theTable;
        }


    }
}