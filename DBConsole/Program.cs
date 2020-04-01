﻿using DataBaseDPD;
using System;
using System.Collections.Generic;
using System.IO;

namespace DBConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            
            TableColumn col1 = new TableColumn("id", "int", 0);
            TableColumn col2 = new TableColumn("nombre", "string", 1);
            TableColumn col3 = new TableColumn("email", "string", 2);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Table tabla = new Table("tablaTest", columns);

            tabla.addRow(new TableRow(new string[3] { "01","'david'","david@email.com" }));
            tabla.addRow(new TableRow(new string[3] { "02", "'domenico'", "domenico@email.com" }));
            tabla.addRow(new TableRow(new string[] { "03", "'percy'", "percy@email.com" }));

            tabla.save();


            Database db = new Database();
            db.addTable("tablaTest", tabla);

           
                Console.WriteLine(db.SelectAll("tablaTest"));
            
            

        }
    }
}
