using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDPD
{
     class Query 
    {
        
        // Constructor that takes one argument:
        Query (string statement)
        {
            checkValidity(statement);
            
        }
        //Check if the query statment is correct
        private void checkValidity(string statement)
        {
            throw new NotImplementedException();
        }
        Table executeQuery()
        {
            return new Table();
        }
        //Return the amount of row it has been modified
        int executeUpDate()
        {
            return -1;
        }
    }
   
    
    
}
