using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDPD
{
    public class Table
    {
        //Atributes
        string TableName;
        Header Head;
        List<TableRow> Tuples;

       
        //Constructor
        public Table(string tableName, List<TableColumn> tableColumns)
        {
            TableName = tableName;
            this.addHeader(tableColumns);
            Tuples = new List<TableRow>();


            //Console.WriteLine(Message.CreateTableSuccess);
        }
        //C2 Overload
        public Table(string tableName, List<string> colNames, List<string> types)
        {
            TableName = tableName;
            List<TableColumn> columns = new List<TableColumn>();
            if (colNames.Count == types.Count)
            {
                for (int i = 0; i < colNames.Count; i++)
                {
                    columns.Add(new TableColumn(colNames[i], types[i], i));
                }
            }
            this.addHeader(columns);
            Tuples = new List<TableRow>();

            //Console.WriteLine(Message.CreateTableSuccess);
        }
        //Add the firts row, only the first time with the name of the column and the type of the column
        private void addHeader(List<TableColumn> tableColumns)
        {
            Head = new Header(tableColumns);

        }
        public Header getHeader()
        {
            return Head;
        }



        //Row's methods
        public void addRow(TableRow row)
        {
            Tuples.Add(row);
        }
        public void addRow(List<string> values)
        {
            TableRow row = new TableRow(getNumColumn());
            for (int i = 0; i < getNumColumn(); i++)
            {
                row.setItem(i, values[i]);
            }
            Tuples.Add(row);

        }
        public void removeRow(TableRow row)
        {
            Tuples.Remove(row);

        }
        public TableRow getFirstRow()
        {
            return Tuples.First();
        }
        //Return the tuples with the spicify value
        public List<TableRow> getTuples(string nameCol, string value)
        {
            List<TableRow> tuplas = new List<TableRow>();
            int pos = Head.index(nameCol);
            foreach (TableRow row in Tuples)
            {
                if (row.getItem(pos) == value)
                {
                    tuplas.Add(row);
                }
            }
            return tuplas;
        }
        public List<TableRow> getTuples(string nameCol, string operation, string value)
        {
            List<TableRow> tuplas = new List<TableRow>();
            int pos = Head.index(nameCol);
            if (operation == "=")
            {
                foreach (TableRow row in Tuples)
                {
                    if (row.getItem(pos) == value)
                    {
                        tuplas.Add(row);
                    }
                }
            }
            else if (operation == ">")
            {
                foreach (TableRow row in Tuples)
                {
                    //Lo convierto a entero para que ocupe mucho
                    if (Convert.ToInt32(row.getItem(pos)) > Convert.ToInt32(value))
                    {
                        tuplas.Add(row);
                    }
                }
            }
            else if (operation == "<")
            {
                foreach (TableRow row in Tuples)
                {
                    //Lo convierto a entero para que ocupe mucho
                    if (Convert.ToInt32(row.getItem(pos)) < Convert.ToInt32(value))
                    {
                        tuplas.Add(row);
                    }
                }
            }


            return tuplas;
        }
        //Modify the column of the tuple spicify with the value specify
        public void modifyTuple(TableRow tuple, string nameCol, string value)
        {
            int pos = Head.index(nameCol);
            tuple.setItem(pos, value);

        }
        public List<TableRow> getTuples()
        {
            return Tuples;
        }
        public List<string> getColumn(string colName)
        {
            List<string> column = new List<string>();

            int pos = Head.index(colName);

            foreach (TableRow row in Tuples)
            {
                column.Add(row.getItem(pos));
            }


            return column;
        }
        public void removeTuple(TableRow row)
        {
            Tuples.Remove(row);
        }

        //Not implement
        public TableRow nextRow()
        {
            return null;
        }



        //Info columns
        public List<string> getColNames()
        {
            return Head.colNames();
        }
        public int getNumColumn()
        {
            return Head.len();
        }
        public int getNumRow()
        {
            return Tuples.Count;
        }
        public string getTypeColumn(int posColumn)
        {
            return Head.type(posColumn);
        }
        public string getTypeColumn(string nameColumn)
        {
            return Head.type(nameColumn);
        }
        public int getIndex(string nameColumn)
        {
            return Head.index(nameColumn);
        }


        /**-------------------------------------------------
        Metodos de lectura escritura en archivos
        ---------------------------------------------------**/


        public void save(string sourceDir)
        {
            try
            {
                string path = Path.Combine(sourceDir, TableName + ".txt");
                StreamWriter writer = File.CreateText(path);
                //Write the header
                foreach (string name in getColNames())
                {
                    //Add a space at the end i could control it but i'm too tired
                    writer.Write(name + ";" + getTypeColumn(name) + ";" + getIndex(name) + ";");
                }
                //Only to format the txt if is the last one add \n new line
                writer.Write("\n");
                foreach (TableRow tuple in Tuples)
                {
                    for (int i = 0; i < this.getNumColumn(); i++)
                    {

                        if (i != this.getNumColumn() - 1)
                        {
                            writer.Write(tuple.getItem(i) + ",");
                        }
                        else
                        {
                            writer.Write(tuple.getItem(i) + "\n");
                        }

                    }
                }
                writer.Close();
                //Console.WriteLine("Saved ...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Not Saved ...");
                Console.WriteLine(e.StackTrace);
            }


        }


    }

}
