

using System;
using DataBaseDPD;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DataBaseDPD
{
    public class CreateTable : Query
    {

        string Table;
        List<string> columnNames = new List<string>();
        List<string> dataType = new List<string>();

        public CreateTable(string table, string data)
        {
            Table = table;

           
            String[] splitParameters = data.Split(',');
            foreach (String toSplit in splitParameters)
            {
                string trimmedToSplit = toSplit.Trim(' ');
                columnNames.Add(trimmedToSplit.Split(' ')[0]);
                dataType.Add(trimmedToSplit.Split(' ')[1]);
            }

        }

        public override PrivilegeType getType()
        {
            return PrivilegeType.ADMIN;
        }

        public override string Run(Database bd)
        {


            return bd.CreateTable(Table, columnNames, dataType);

        }
        public override string getTableName()
        {
            return Table;
        }

        public override string Run(Connection connection)
        {
            throw new NotImplementedException();
        }
    }
}