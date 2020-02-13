using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDPD
{
     class Query 
    {
        // Constructor that takes no arguments:
        private Query()
        {
            string statement = "unknown";
        }
        // Constructor that takes one argument:
        private Query (string statement)
        {
            checkValidity(statement);
            
        }

        private void checkValidity(string statement)
        {
            throw new NotImplementedException();
        }
        Table executeQuery()
        {
            return new Table();
        }
        int executeUpDate()
        {
            return -1;
        }
    }
   
    
    
}
