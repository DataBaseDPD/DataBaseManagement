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
        string name;
        Header head;
        List<TableRow> tuples;

       
       



        //Constructor
        public Table(string tableName, List<TableColumn> tableColumns)
        {
            name = tableName;
            this.addHeader(tableColumns);
            tuples = new List<TableRow>();


            //Console.WriteLine(Message.CreateTableSuccess);
        }
        //C2 Overload
        public Table(string tableName, List<string> colNames, List<string> types)
        {
            name = tableName;
            List<TableColumn> columns = new List<TableColumn>();
            if (colNames.Count == types.Count)
            {
                for (int i = 0; i < colNames.Count; i++)
                {
                    columns.Add(new TableColumn(colNames[i], types[i], i));
                }
            }
            this.addHeader(columns);
            tuples = new List<TableRow>();

            //Console.WriteLine(Message.CreateTableSuccess);
        }
        //Add the firts row, only the first time with the name of the column and the type of the column
        private void addHeader(List<TableColumn> tableColumns)
        {
            head = new Header(tableColumns);

        }
        public Header getHeader()
        {
            return head;
        }



        //Row's methods
        public void addRow(TableRow row)
        {
            tuples.Add(row);
        }
        public void addRow(List<string> values)
        {
            TableRow row = new TableRow(getNumColumn());
            for (int i = 0; i < getNumColumn(); i++)
            {
                row.setItem(i, values[i]);
            }
            tuples.Add(row);

        }
        public void removeRow(TableRow row)
        {
            tuples.Remove(row);

        }
        public TableRow getFirstRow()
        {
            return tuples.First();
        }
        //Return the tuples with the spicify value
        public List<TableRow> getTuples(string nameCol, string value)
        {
            List<TableRow> tuplas = new List<TableRow>();
            int pos = head.index(nameCol);
            foreach (TableRow row in tuples)
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
            int pos = head.index(nameCol);
            if (operation == "=")
            {
                foreach (TableRow row in tuples)
                {
                    if (row.getItem(pos) == value)
                    {
                        tuplas.Add(row);
                    }
                }
            }
            else if (operation == ">")
            {
                foreach (TableRow row in tuples)
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
                foreach (TableRow row in tuples)
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
            int pos = head.index(nameCol);
            tuple.setItem(pos, value);

        }
        public List<TableRow> getTuples()
        {
            return tuples;
        }
        public List<string> getColumn(string colName)
        {
            List<string> column = new List<string>();

            int pos = head.index(colName);

            foreach (TableRow row in tuples)
            {
                column.Add(row.getItem(pos));
            }


            return column;
        }
        public void removeTuple(TableRow row)
        {
            tuples.Remove(row);
        }

        //Not implement
        public TableRow nextRow()
        {
            return null;
        }



        //Info columns
        public List<string> getColNames()
        {
            return head.colNames();
        }
        public int getNumColumn()
        {
            return head.len();
        }
        public int getNumRow()
        {
            return tuples.Count;
        }
        public string getTypeColumn(int posColumn)
        {
            return head.type(posColumn);
        }
        public string getTypeColumn(string nameColumn)
        {
            return head.type(nameColumn);
        }
        public int getIndex(string nameColumn)
        {
            return head.index(nameColumn);
        }


        /**-------------------------------------------------
        Metodos de lectura escritura en archivos
        ---------------------------------------------------**/

        public void save()
        {
            try
            {

                string fileName = name + ".txt";
                StreamWriter writer = File.CreateText(fileName);
                //Write the header
                foreach (string name in getColNames())
                {
                    //Add a space at the end i could control it but i'm too tired
                    writer.Write(name + ";" + getTypeColumn(name) + ";" + getIndex(name) + ";");
                }
                //Only to format the txt if is the last one add \n new line
                writer.Write("\n");
                foreach (TableRow tuple in tuples)
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

        public void save(string sourceDir)
        {
            try
            {

                string fileName = sourceDir + "/" + name + ".txt";
                StreamWriter writer = File.CreateText(fileName);
                //Write the header
                foreach (string name in getColNames())
                {
                    //Add a space at the end i could control it but i'm too tired
                    writer.Write(name + ";" + getTypeColumn(name) + ";" + getIndex(name) + ";");
                }
                //Only to format the txt if is the last one add \n new line
                writer.Write("\n");
                foreach (TableRow tuple in tuples)
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
