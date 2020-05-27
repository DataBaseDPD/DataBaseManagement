using System;
using System.IO;


namespace DataBaseDPD
{
    public class PATH
    {
        //Here we gonna create the FileSystem where we save our DataBase
        public static string GetPath()
        {
            //First we get the current application directory
            string currentDirName = Directory.GetCurrentDirectory();
            string sourceDir = Path.Combine(currentDirName, "DataBase");


            //Then check if the file already exist if not we'll create it
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
