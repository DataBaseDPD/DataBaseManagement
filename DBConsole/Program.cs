using DataBaseDPD;
using System;
using System.Collections.Generic;

namespace DBConsole
{
    class Program
    {
        static void Main(string[] args)
        {


            TableColumn col1 = new TableColumn("id", DataType.Int, 1);
            TableColumn col2 = new TableColumn("nombre", DataType.String, 2);
            TableColumn col3 = new TableColumn("email", DataType.String, 3);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Table tabla = new Table("tablaTest", columns);

            tabla.addRow(new TableRow(new string[3] { "01","david","david@email.com" }));
            tabla.addRow(new TableRow(new string[3] { "02", "domenico", "domenico@email.com" }));



            Console.WriteLine(tabla.getFirstRow().getItem(1));

        }
    }
}
