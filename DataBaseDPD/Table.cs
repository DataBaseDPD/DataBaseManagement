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

       
        string sourceDir= "";



        //Constructor
        public Table( string tableName , List<TableColumn> tableColumns )
        {
            name = tableName;
            addHeader(tableColumns);
            tuples = new List<TableRow>();

           Console.WriteLine(Message.CreateTableSuccess);
        }
        //Add the firts row, only the first time with the name of the column and the type of the column
        private void addHeader(List<TableColumn> tableColumns)
        {
            head = new Header(tableColumns);
           
        }



        //Row's methods
        public void addRow(TableRow row)
        {
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
        public DataType getTypeColumn(int posColumn)
        {
            return head.type(posColumn);
        }
        public DataType getTypeColumn(string nameColumn)
        {
            return head.type(nameColumn);
        }


        /**-------------------------------------------------
        Metodos de lectura escritura en archivos
        ---------------------------------------------------**/


        
        public void save(string nameFile)
        {
            StreamWriter writer = File.CreateText(nameFile);
            foreach (TableRow tuple in tuples )
            {
                for(int i = 0; i < this.getNumColumn(); i++)
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
        private Boolean close()
        {
            //Before close we have to save the changes
            return false;
        }


    }

}
