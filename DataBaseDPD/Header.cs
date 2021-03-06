﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDPD
{
    public class Header
    {
        //As key the name of the column and value the info of the column -->type, name, and pos
        Dictionary<string, TableColumn> columns = new Dictionary<string, TableColumn>();


        public Header(List<TableColumn> tableColumns)
        {

            foreach (TableColumn column in tableColumns)
            {

                string colName = column.name;

                if (!(columns.ContainsKey(colName)))
                {
                    columns.Add(colName, column);
                }
                else
                {
                    Console.WriteLine(Message.ColumnAlreadyExits);
                }

            }
        }

        //return the amount of columns/atributes of the table
        public int len()
        {
            return columns.Count;
        }

        public string type(int pos)
        {
            string type = "";

            foreach (KeyValuePair<string, TableColumn> column in columns)
            {
                int current = column.Value.index;
                if (current == pos)
                {
                    type = column.Value.type;
               
                }
            }
            return type;
        }
        public string type(string colName)
        {
         
            TableColumn col;
            columns.TryGetValue(colName, out col);
            return col.type;

        }
        public List<string> colNames()
        {
            List<string> colNames = new List<string>();
            foreach (KeyValuePair<string, TableColumn> column in columns)
            {
                colNames.Add(column.Key);
            }
            return colNames;
        }
        public int index(string colName)
        {
            TableColumn col;
            columns.TryGetValue(colName, out col);
            return col.index;

        }
        public override string ToString()
        {
            string result = "[";
            foreach (KeyValuePair<string, TableColumn>  col in columns)
            {
                result += string.Format( "{0} of type {1}",col.Key, col.Value.type);
            }

            result += "]";
            return result;
        }
    }
}
