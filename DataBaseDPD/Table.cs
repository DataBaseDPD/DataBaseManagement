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
        string name;
        List<TableRow> tuples;
        public static int numCol;
        Header head;
        string sourceDir= "";


        private Message m = new Message();
        Dictionary<string, List<string>> columns = new Dictionary<string, List<string>>();


        public Table( string tableName , List<TableColumn> tableColumns )
        {
            name = tableName;
            foreach (TableColumn column in tableColumns){

                string colName = column.name;
                List<string> values = new List<string>();

                if (!(columns.ContainsKey(colName))) 
                {
                    columns.Add(colName, values);
                }
                else
                {
                    m.print( Message.ColumnAlreadyExits);   
                }

            }

            m.print(Message.CreateTableSuccess);
        }


        //Add the firts row, only the first time with the name of the column and the type of the column
        public void addHeader(string[] nameColumns, DataType[] types)
        {
            head = new Header(nameColumns, types);
            numCol = nameColumns.Length;
        }
        //Add the tuple
        public void addRow(TableRow row)
        {
            tuples.Add(row);
        }
        public TableRow getRow()
        {
            return null;
        }
        public TableRow getFirstRow()
        {
            return null;
        }
        public TableRow nextRow()
        {
            return null;
        }
        
        private Boolean close()
        {
            //Before close we have to save the changes
            return false;
        } 
        //Return the amount of attributes
         public int getNumColumn()
        {
            return numCol;
        }
        //Return the amount of tuples
        public int getNumRow()
        {
            return tuples.Count;
        }
        //Return the type of column in the posistion posColumn
        public DataType getTypeColumn(int posColumn)
        {
            return head.getType(posColumn);
        }
        //Save all changes write in a file the data of table
        public void save(string nameFile)
        {
            StreamWriter writer = File.CreateText(nameFile);
            foreach (TableRow tuple in tuples )
            {
                for(int i = 0; i < numCol; i++)
                {
                    //write in each line
                   writer.Write(tuple.getItem(i));
                }
            }
            writer.Close();
        }
        /**
        static public Table load( string filename)
        {
            Table tabla = new Table(filename);
            if (File.Exists(filename))
            {
                foreach (string line in File.ReadAllLines(filename))
                {
                    //Check if string split in comma
                    string[] lineParts = line.Split(',');
                    if (lineParts.Length == numCol)
                    {
                        //how write commas and header?
                        TableRow tuple = new TableRow(lineParts);
                        tabla.addRow(tuple);
                    }
                }
            }
            else
            {
                Console.WriteLine(Message.TableDoesNotExist);
            }
            
            return tabla;
        }
    **/
        public void remove(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(Path.Combine(sourceDir, filename));
            }

        }
        

    }

}
