
using System;
using System.Collections.Generic;
using System.IO;
namespace DataBaseDPD
{
    public class Database

    {

        //Atributes
        public Dictionary<string, Table> tables;
        

        string sourceDir = "";


        //Constructor
        public Database()
        {
            tables = new Dictionary<string, Table>();
           
        }


        //Methods to manipulate class

        public Table getTable(string nameTable)
        {
            Table tabla;
            if (!tables.ContainsKey(nameTable))
            {
                Console.WriteLine(Message.TableDoesNotExist);
            }
            tables.TryGetValue(nameTable, out tabla);
            return tabla;
        }
        public void deleteTable(string nameTable)
        {
            if (!tables.ContainsKey(nameTable))
            {
                Console.WriteLine(Message.TableDoesNotExist);
            }
            else
            {
                tables.Remove(nameTable);
            }
        }
        
        public void loadTables()
        {
            //TODO
            /**Si se puede recorrer el directoria cargando todas las tablas
             * pero no estoy seguro de que en el directorio actual sola haya
             * tablas.txt
             *
             * Se cargarian todas al cargar la base de datos
             * */
        }
        /**-------------------------------------------------
      Metodos de respuesta a las queries
      ---------------------------------------------------**/
        public string RunQuery(string query)
        {
            Query request = null; //= Parser.Parse(query);
            if (request==null)
            {
                return Message.WrongSyntax;
            }
            else
            {
                return request.Run(this);
            }
            
        }

        public string CreateTable(string tableName, List<string> colNames, List<string> types)
        {
            if (!tables.ContainsKey(tableName))
            {
                Table table = new Table(tableName, colNames,types);
                table.save();
                tables.Add(tableName, table);
                Console.WriteLine(Message.CreateTableSuccess);
                return Message.CreateTableSuccess;
            }
            else
            {
                Table table;
                Console.WriteLine(Message.TableAlreadyExists);
                tables.TryGetValue(tableName, out table);
                return Message.TableAlreadyExists;
            }


        }
        public string Update(String columns, String tableName, String left, String op, String right)
        {
            //TODO

            return "";
        }
        
        /**-------------------------------------------------
       Metodos de lectura escritura en archivos
       ---------------------------------------------------**/



        public void remove(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(Path.Combine(sourceDir, filename));
                tables.Remove(filename.Substring(0, filename.Length - 4));
            }

        }
       


        public Table load(string fileName)
        {
            List<TableColumn> columns;
            Table tabla = null;

            string filename = sourceDir + fileName;
            if (File.Exists(filename))
            {
                columns = new List<TableColumn>();


                //Read first line with the information of columns
                StreamReader file = new StreamReader(filename);
                string head;
                head = file.ReadLine();
                string[] header = head.Split(new Char[] { ';' });

                //Le quito uno por el espacio al final
                int numCol = ((header.Length - 1) / 3);
                for (int i = 0; i < numCol; i = i + 3)
                {
                    columns.Add(new TableColumn(header[i], header[i + 1], Convert.ToInt32(header[i + 2])));
                }




                //Para no guarde el nombre de la tabla con la extencion quito el -> ".txt"
                tabla = new Table(fileName.Substring(0, fileName.Length - 4), columns);//Mejorable
                //Read the tuples
                string line;
                while ((line = file.ReadLine()) != null)
                {

                    string[] lineParts = line.Split(',');
                    if (lineParts.Length == numCol)
                    {
                        tabla.addRow(new TableRow(lineParts));
                    }

                }


                file.Close();
                Console.WriteLine(Message.TableLoadSuccess);
            }
            else
            {
                Console.WriteLine(Message.TableDoesNotExist);
            }

            return tabla;
        }




    }
}
