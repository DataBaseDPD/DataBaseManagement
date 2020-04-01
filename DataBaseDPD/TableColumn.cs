using System;
namespace DataBaseDPD
{
    public class TableColumn
    { 
        //Atributes
        public string name { get; set; }
        public int index { get; set; }
        public string type { get; set; }

        //Constructor
        public TableColumn(string pName, string pType, int index)
        {
            //Check if the column name is not null
            if (!(pName is null) )
            {
                name = pName;
            }
            else
            {
                Console.WriteLine(Message.ColumnNameIsNull);
            }
            type = pType;
            this.index = index;//MUST START BY 0

        }
        
    }
}
