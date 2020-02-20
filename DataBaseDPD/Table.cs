using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDPD
{
    class Table
    {
        string name;
        Table()
        {
            TableColumn column = new TableColumn();
            TableRow row = new TableRow();
        }
        //Add the tuple
        void addRow(List<string> row)
        {

        }
        TableRow nextRow()
        {
            return null;
        }
        //Before close we have to save the changes
        Boolean close()
        {
            return false;
        }
        //
        string getItem(int position)
        {
            return null;
        }
        string getItem(string columnName)
        {
            return null;
        }
        //Return the amount of attributes
        int getNumColumn()
        {
            return -1;
        }
        //Return the amount of tuples
        int getNumRow()
        {
            return -1;
        }
        //Return the type of column in the posistion posColumn
        string getTypeColumn(int posColumn)
        {
            return null;
        }
        //Save all changes
        void save()
        {

        }
    }



    
}
