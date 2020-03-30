﻿using System;
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

       //PUT FILES IN A DIRECTORY OF DATABASE MISSING
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
        public List<TableRow> getTuples()
        {
            return tuples;
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
                //NOSE DONDE PONER LOS ARCHIVOS DEBERIAN ESTAR DENTRO DE DB
                string fileName =  name + ".txt";
                Console.WriteLine(fileName);
                StreamWriter writer = File.CreateText(fileName);
                //Write the header
                foreach (string name in getColNames())
                {
                    //Add a space at the end i could control it but i'm too tired
                    writer.Write(name + ";" + getTypeColumn(name) + ";" + getIndex(name)+";");
                }
                //Only to format the txt if is the last one add \n new line
                writer.Write("\n");
                foreach (TableRow tuple in tuples)
                {
                    for (int i = 0; i < this.getNumColumn(); i++)
                    {
                       
                        if(i != this.getNumColumn() - 1)
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
                Console.WriteLine("Saved ...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Not Saved ...");
                Console.WriteLine(e.StackTrace);
            }

            
        }
    
        public Table load( string fileName)
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
                string[] header = head.Split(new Char[] {';'});

                //Le quito uno por el espacio al final
                int numCol = ((header.Length-1)/3);
                for (int i=0; i<numCol;i=i+3)
                {
                    columns.Add(new TableColumn(header[i],header[i+1],Convert.ToInt32(header[i+2])));
                }
               



                //Para no guarde el nombre de la tabla con la extencion quito el -> ".txt"
                tabla = new Table(fileName.Substring(0, fileName.Length - 4), columns);//Mejorable
                //Read the tuples
                string line;
                while ((line = file.ReadLine()) != null)
                {

                    string[] lineParts = line.Split(',');
                    if (lineParts.Length == getNumColumn())
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
   
        
        private Boolean close()
        {
            //Before close we have to save the changes
            return false;
        }


    }

}
