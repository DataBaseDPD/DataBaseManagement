
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
        public void addTable(string name, Table tabla)
        {
            if (!tables.ContainsKey(name))
            {
                tables.Add(name,tabla);
            }
        }
        public Dictionary<string, Table> getTables()
        {
            return tables;
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
            /**
             Query request = Parser.Parse(query);
             if (true)
             {
                 return Message.WrongSyntax;
             }
             else
             {
                 return request.Run(this);
             }
             **/
            return "Not Implement";
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
                return Message.TableAlreadyExists;
            }


        }
        public string DropTabla(string nameTable)
        {
            if (!tables.ContainsKey(nameTable))
            {
                return Message.TableDoesNotExist;
            }
            else
            {
                tables.Remove(nameTable);
                remove(nameTable+".txt");
                return Message.DeleteTablaSuccess;
            }

           
        }
        //Insert simple
        public string Insert(string nameTable,List<string> values)
        {
            if (!tables.ContainsKey(nameTable))
            {
                Table tab = getTable(nameTable);
                int len = tab.getNumColumn();
                if (values.Count == len)
                {
                    tab.addRow(values);
                    return Message.InsertSuccess;
                }
                else
                {
                    return Message.WrongSyntax;
                }
            }
            else
            {
                return Message.TableDoesNotExist;
            }


               
        }
        //Update some columns
        public string Update(string nameTable, List<string> colNames, List<string> values)
        {
            if (tables.ContainsKey(nameTable) && colNames.Count == values.Count)
            {
                Table tab = getTable(nameTable);
                foreach (TableRow row in tab.getTuples())
                {
                    for (int i=0;i< colNames.Count;i++)
                    {
                        tab.modifyTuple(row,colNames[i],values[i] );
                    }
                   
                }

                return Message.TupleDeleteSuccess;

            }
            else
            {
                return Message.TableDoesNotExist;
            }

        }
        
        
        //Select simple
        public string Select( string nameTable, string column)
        {
            Table tab = getTable(nameTable);
            List<string> columns = tab.getColumn(column);
            string result = "[ "+ column + " ]";
            for (int i = 0; i < columns.Count; i++) result += "{ " + columns[i] + " }";

            result += "";
            return result;
        }
        public string Select(string nameTable, List<string> columns)
        {
            Table tab = getTable(nameTable);
            
            string result = "";

            for(int i=0; i < columns.Count; i++)
            {
                result += Select(nameTable, columns[i]);
                
            }
           
            result += "";
            return result;
        }
        
        public string SelectAll(string nameTabla)
        {
            List<string> tuplas = new List<string>();
            Table tab = getTable(nameTabla);
            tuplas.Add(tab.getHeader().ToString()); //Si se quisiera ver las columnas y su tipo
            foreach (TableRow tupla in tab.getTuples())
            {
                tuplas.Add(tupla.ToString());
            }
            string result = "";

            for(int i= 0; i<tuplas.Count;i++) result += tuplas[i] + "\n";

            result += "\n";
            return result;
        }




        //Select with where
        public string Select(string nameTabla, string columns, string value)
        {
            //TODO
            return "Not implement";
        }
        //Insert with where
        public string Insert(string nameTable, List<string> colNames, string condition)
        {
            //TODO

            return "Not implement";
        }
        //Update with where
        public string Update()
        {
            return "Not implement";
        }


        /**-------------------------------------------------
       Metodos de lectura escritura en archivos
       ---------------------------------------------------**/



        public void remove(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(Path.Combine(sourceDir, filename));
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
