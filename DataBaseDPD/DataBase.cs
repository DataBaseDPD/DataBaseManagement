
using System;
using System.Collections.Generic;
using System.IO;
namespace DataBaseDPD
{
    public class Database

    {

        //Atributes
        public Dictionary<string, Table> tables;
        string Name;


        string sourceDir = "";


        //Constructor
        public Database()
        {
            sourceDir = PATH.GetPath();
            tables = new Dictionary<string, Table>();
        }
        //C2 Overload
        public Database(string name)
        {
            sourceDir = PATH.GetPath();

            Name = name;
            tables = new Dictionary<string, Table>();
            sourceDir = Path.Combine(sourceDir, Name);
            try
            {
                DirectoryInfo di;
                // Determine whether the directory exists.
                if (Directory.Exists(sourceDir))
                {
                    //Console.WriteLine("That DataBase exists already.");
                    loadTables();
                    return;
                }

                // Try to create the directory.
                di = Directory.CreateDirectory(sourceDir);
                //Console.WriteLine("The DataBase was created successfully at {0}.", Directory.GetCreationTime(sourceDir));

                //Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
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
            // Process the list of files found in the directory.
            string[] files = Directory.GetFiles(sourceDir, "*.txt");
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileName(files[i]);
                load(files[i]);
            }
               
           
        }
        /**-------------------------------------------------
      Metodos de respuesta a las queries
      ---------------------------------------------------**/
        public string RunQuery(string query)
        {
             Query request = Parser.Parse(query);
             if (request == null) return Message.WrongSyntax;
             else return request.Run(this);
        }

        public string CreateTable(string tableName, List<string> colNames, List<string> types)
        {
            if (!tables.ContainsKey(tableName))
            {
                if (colNames.Count==types.Count)
                {
                    Table table = new Table(tableName, colNames, types);
                    table.save(sourceDir);
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
                    tab.save(sourceDir);
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
                        if (tab.getColNames().Contains(colNames[i]))
                            tab.modifyTuple(row, colNames[i], values[i]);
                        else return Message.WrongSyntax;
                    }
                   
                }
                tab.save(sourceDir);

                return Message.TupleUpdateSuccess;

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
            if (tables.ContainsKey(nameTable))
            {
                Table tab = getTable(nameTable);
                List<string> colName = tab.getColNames();

                string result = "[ ";
                for(int i = 0; i < columns.Count; i++)
                {
                    if (i == columns.Count - 1 && colName.Contains(columns[i]))
                    {
                        result += columns[i];
                    }
                    else if (colName.Contains(columns[i]))
                    {
                        result += columns[i] + ", ";
                    }
                    else if (!colName.Contains(columns[i])) result += "NOT EXIST, ";

                }
                result += " ] ";
                foreach(string col in columns)
                {
                    result += "{ ";
                    if (colName.Contains(col))
                    {
                        List<string> column = tab.getColumn(col);
                        
                        for (int i=0; i< column.Count;i++ )
                        {
                            if (i == column.Count - 1) result += column[i] + " }";
                            else result += column[i] + ", ";
                           
                        }
                    }
                    else result += "NULL }";
                }
                

                 return result;
            }
            else return Message.TableDoesNotExist;
        }
        
        public string Select(string nameTabla)
        {

            if (tables.ContainsKey(nameTabla))
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
            else return Message.TableDoesNotExist;
                
        }




        //Select with where
        public string Select(string nameTable, List<string> columns, string col, string operation, string value)
        {
            //Format is not correct 
            if (tables.ContainsKey(nameTable))
            {
                Table tab = getTable(nameTable);
                List<string> colNames = tab.getColNames(); 
                List<TableRow> tuplas;

                if (colNames.Contains(col))
                {
                    string type = tab.getTypeColumn(col);

                    if (type == "TEXT" && operation == "=")
                    {
                        tuplas = tab.getTuples(col, operation, value);
                        int tuplasLenght = tuplas.Count;
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
                        int position;
                        foreach(TableRow row in tuplas)
                        {
                            result += "{ ";

                            for (int i = 0; i < columns.Count; i++)
                            {
                                if (colNames.Contains(columns[i]))
                                {
                                    position = tab.getIndex(columns[i]);

                                    result += row.getItem(position);

                                    result += " }";
                                }
                                else result += "NULL }";
                            }
                        }
                        return result;
                    }
                    else if (type == "TEXT" && operation != "=") return Message.WrongSyntax;
                    else
                    {
                        tuplas = tab.getTuples(col, operation, value);
                        int tuplasLenght = tuplas.Count;
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
                        result += " ] ";
                        int position;
                        for (int i = 0; i < columns.Count; i++)
                        {
                            result += "{ ";
                            if (colNames.Contains(columns[i]))
                            {
                                position = tab.getIndex(columns[i]);

                                for (int j = 0; j < tuplasLenght; j++)
                                {
                                    if (j == tuplasLenght - 1) result += tuplas[j].getItem(position);
                                    else result += tuplas[j].getItem(position) + ", ";
                                }

                                result += " }";
                            }
                            else result += "NULL }";
                        }
                        return result;

                    }
                
                
                   
                }
                else return Message.WrongSyntax;


            }
            else return Message.TableDoesNotExist;
          

        }

        //Update with where
        public string Update(string nameTable, string col, string val, string colCondition, string operation, string value)
        {
           
            if (tables.ContainsKey(nameTable))
            {
                Table tab = getTable(nameTable);
                List<TableRow> tuplas;

                if (tab.getColNames().Contains(col) && tab.getColNames().Contains(colCondition))
                {
                    tuplas = tab.getTuples(colCondition, operation, value);
                    string type = tab.getTypeColumn(colCondition);

                   
                    if (type == "TEXT" && operation == "=")//text could be only equals
                    {
                        foreach (TableRow row in tuplas) tab.modifyTuple(row, col, val);
                    }
                    else
                    { 
                        foreach (TableRow row in tuplas) tab.modifyTuple(row, col, val);

                    }
                    tab.save(sourceDir);
                    return Message.TupleUpdateSuccess;
                }

                else return Message.WrongSyntax;
            }
            else return Message.WrongSyntax;
           
        }


        //Insert with where
        public string Insert(string nameTable, List<string> colNames, string condition)
        {
            //TODO

            return "Not implement";
        }

        public string Delete(string nameTable, string col, string operation, string value)
        {
            if (tables.ContainsKey(nameTable))
            {
                Table tab = getTable(nameTable);
                List<TableRow> tuplas;


                if (tab.getColNames().Contains(col))
                {
                    int count = 0;
                    string type = tab.getTypeColumn(col);

                    if (type == "TEXT" && operation == "=")
                    {
                        tuplas = tab.getTuples(col, operation, value);
                        foreach (TableRow row in tuplas) tab.removeRow(row); count++;
                    }
                    else if (type == "TEXT" && operation != "=") return Message.WrongSyntax;
                    else
                    {
                        tuplas = tab.getTuples(col, operation, value);
                        foreach (TableRow row in tuplas) tab.removeRow(row); count++;
                    }
                    tab.save(sourceDir);
                }
                return Message.TupleDeleteSuccess;

            }
            else return Message.WrongSyntax;
        }
        


        /**-------------------------------------------------
       Metodos de lectura escritura en archivos
       ---------------------------------------------------**/



        public void remove(string filename)
        {
            string path = Path.Combine(sourceDir, filename);
            if (File.Exists(path))
            {
                File.Delete(path);
            }

        }
       


        public Table load(string fileName)
        {
            List<TableColumn> columns;
            Table tabla = null;

            string filename = fileName;
            string path = Path.Combine(sourceDir, filename);

            if (File.Exists(path))
            {
                columns = new List<TableColumn>();


                //Read first line with the information of columns
                StreamReader file = new StreamReader(path);
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

                tables.Add(fileName.Substring(0, fileName.Length - 4), tabla);
                file.Close();
            }
            else
            {
                Console.WriteLine(Message.TableDoesNotExist);
            }

            return tabla;
        }




    }
}
