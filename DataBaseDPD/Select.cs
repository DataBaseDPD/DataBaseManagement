﻿using System;
using System.Collections.Generic;
using DataBaseDPD;

namespace DataBaseDPD
{
    public class Select : Query

    {
        string Table;
        List<string> Columns = new List<string>();
        string Col;
        string Operation;
        string Value ="";

        public Select(string nameTable, List<string> column) {
            Table = nameTable;
            Columns = column;
        }
        public Select(string nameTable)
        {
            Table = nameTable;
        }
        public Select(string nameTable, List<string> column, string col, string operation, string value)
        {
            Table = nameTable;
            Columns = column;
            Col = col;
            Operation = operation;
            Value = value;
        }



        public override string Run(Database database)
        {
            if (Columns.Count==0 && Value=="")
            {
                return database.Select(Table);
            }
            else if(Columns.Count != 0 && Value=="")
            {
                return database.Select(Table, Columns);
            }
            else if(Columns.Count != 0 && Value != "")
            {
                return database.Select(Table, Columns, Col, Operation, Value);
            }
            else
            {
                return Message.WrongSyntax;
            }
            
        }

        public override PrivilegeType getType()
        {
            return PrivilegeType.SELECT;
        }
        

        public override string getTableName()
        {
            return Table;
        }
    }
}