using System;
using System.IO;


namespace DataBaseDPD
{
    public class PATH
    {
        public static string GetPath()
        {

            string currentDirName = Directory.GetCurrentDirectory();
            string sourceDir = Path.Combine(currentDirName, "DataBase");

            try
            {
                DirectoryInfo di;

                if (Directory.Exists(sourceDir))
                {
                    return sourceDir;
                }
                else
                {
                    di = Directory.CreateDirectory(sourceDir);
                    return sourceDir;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                return "The DataBase could not be created";
            }

            
           
        }


    }
}
