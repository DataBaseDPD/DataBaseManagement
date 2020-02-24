using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDPD
{
    public class Table
    {
        string name;
        int numColumn;
        TableColumn column;

        public Table( string tableName)
        {
            name = tableName;
            
        }
        //Add the firts row, only the first time with the name of the column and the type of the column
        public void addHeader(string nameColumn, DataType type)
        {

        }
        //Add the tuple
        public void addRow(List<string> row)
        {
            //At the same time we have to adding to the column addColumn(string itemColumn)
        }
        public TableRow nextRow()
        {
            return null;
        }
        private void addColumn(string itemColumn)
        {
            column.add(itemColumn);
        }
        public Boolean close()
        {
            //Before close we have to save the changes
            return false;
        }
        //
        public string getItem(int position)
        {
            return null;
        }
        public string getItem(string columnName)
        {
            return null;
        }
        //Return the amount of attributes
         public int getNumColumn()
        {
            return -1;
        }
        //Return the amount of tuples
        public int getNumRow()
        {
            return -1;
        }
        //Return the type of column in the posistion posColumn
        public string getTypeColumn(int posColumn)
        {
            return null;
        }
        //Save all changes
        void save()
        {

        }
        static public Table load( string filename)
        {
            return null;
        } 
        public Table getTable()
        {
            return null;
        }
        public void remove(string tableName)
        {

        }
    }



    
}
