using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDPD
{
    public class TableRow
    {
        //Atributes
        List<string> tuple;

        //Constructor 
        public TableRow(string[] items)
        {
            tuple = new List<string>();
            for (int i = 0; i < items.Length; i++)
            {
                tuple.Add(items[i]);
            }
        }

        //Pos start at 0 
        public string getItem(int position)
        {
            string result = "";
            try
            {
                result = tuple[position];
            }
            catch(Exception e)
            {
                Console.WriteLine("Error. Remenber the position start at 0 index.");
                Console.WriteLine(e.StackTrace);
            }
            return result;
            
        }
        public void setItem(int position , string value)
        {
            tuple[position] = value;

        }
        //Not implement
        public void getItem(string columnName)
        {
            
            
        }

        public override string ToString()
        {
            string result = "{";
            
            for (int i = 0; i < tuple.Count; i++) result += " " + tuple[i]+ " ";
            result += "}";
            
            return result;
        }

            public List<string> getTuple()
        {
            return tuple;
        }
    }
}
