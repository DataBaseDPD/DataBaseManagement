
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
            tables.TryGetValue(nameTable, out Table tabla);
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
            
             Query request = Parser.Parse(query);
             if (request == null)
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
                if (colNames.Count==types.Count)
                {
                    Table table = new Table(tableName, colNames, types);
                    table.save();
                    tables.Add(tableName, table);

                    return Message.CreateTableSuccess;
                }
                else
                {
                    return Message.WrongSyntax;
                }
                
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
            if (tables.ContainsKey(nameTable))
            {
                Table tab = getTable(nameTable);
                int len = tab.getNumColumn();
                if (values.Count == len)
                {
                    tab.addRow(values);
                    tab.save();
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
        
        
        //Select simple <Format>
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
        
        public string Select(string nameTabla)
        {

            Table tab = getTable(nameTabla);
            List<string> columns = tab.getColNames();
            string result = "[ ";
            for (int i = 0; i < columns.Count; i++)
            {
                if (i == columns.Count - 1)
                {
                    result += columns[i];
                }
                else
                {
                    result += columns[i] + ", ";
                }

            }
            result += " ]";
            foreach (TableRow row in tab.getTuples()) result += row.ToString();
            result += "\n";
            return result;
        }




        //Select with where
        public string Select(string nameTable, List<string> columns, string col, string operation, string value)
        {
            Table tab = getTable(nameTable);
            string type = tab.getTypeColumn(col);
            if (type =="TEXT")
            {
                return Message.WrongSyntax;
            }
            else
            {
                List<TableRow> tuplas = tab.getTuples(col,operation,value);
                string result = "[ ";
                for (int i=0; i < columns.Count; i++)
                {
                    if (i ==columns.Count-1 )
                    {
                        result += columns[i];
                    }
                    else
                    {
                        result += columns[i] + ", ";
                    }
                    
                }
                result += "]";
                foreach(TableRow row in tuplas) result += row.ToString();
                return result;
            }

            
        }

        //Update with where
        public string Update(string nameTable, string col, string val, string colCondition, string operation, string value)
        {
            Table tab = getTable(nameTable);
            string type = tab.getTypeColumn(colCondition);
            if (type == "TEXT")
            {
                return Message.WrongSyntax;
            }
            else
            {
                List<TableRow> tuplas = tab.getTuples(colCondition, operation, value);
                
                foreach (TableRow row in tuplas)  tab.modifyTuple(row,col,val);
               
                return Message.TupleUpdateSuccess;
            }
           
        }


        //Insert with where
        public string Insert(string nameTable, List<string> colNames, string condition)
        {
            //TODO

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
