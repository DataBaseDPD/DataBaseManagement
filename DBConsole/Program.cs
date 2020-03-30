using DataBaseDPD;
using System;
using System.Collections.Generic;
using System.IO;

namespace DBConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            
            TableColumn col1 = new TableColumn("id", "int", 1);
            TableColumn col2 = new TableColumn("nombre", "string", 2);
            TableColumn col3 = new TableColumn("email", "string", 3);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Table tabla = new Table("tablaTest", columns);

            tabla.addRow(new TableRow(new string[3] { "01","david","david@email.com" }));
            tabla.addRow(new TableRow(new string[3] { "02", "domenico", "domenico@email.com" }));

            string[] hola = new string[]{"1","2","3","4","5","6" };

            Console.WriteLine((hola.Length/3).GetType());

            Table tab = tabla.load("tablaTest.txt");



        }
    }
}
