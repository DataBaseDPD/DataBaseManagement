
using System;
using System.IO;
namespace DataBaseDPD
{
    public class Database
    {
        public string createDB()
        {
            
            string path = "C:/Users/docencia/source/repos/DataBaseDPD/DataBaseManagement/Data.txt";

 
            if (File.Exists(path))
            {
                Console.WriteLine("File Exist");
                File.OpenRead(path);
                return path;
            }
            else
            {
                
                File.Create(path);
                return path;

            }
        }
        
      


    }
}
