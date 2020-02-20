using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDPD
{
     public class Query 
    {
        
        // Constructor that takes one argument:
        public Query (string statement)
        {
            checkValidity(statement);
            
        }
        //Check if the query statment is correct
        private void checkValidity(string statement)
        {
            throw new NotImplementedException();
        }
        public Table executeQuery()
        {
            return null;
        }
        //Return the amount of row it has been modified
        public int executeUpDate()
        {
            return -1;
        }
    }
   
    
    
}
