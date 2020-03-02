using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDPD
{
    class Connection
    {
      
        public string open(){

            string path = "C:/Users/docencia/source/repos/database";
            if (File.Exists(path))
            {
                Console.WriteLine("File Exist");
                File.OpenRead(path);
                return path;
            }
            else
            {
                return Message.DatabaseDoesNotExist;
            }
       

            
        }

        public void closeDB(){

            

  
        }


    }
}
