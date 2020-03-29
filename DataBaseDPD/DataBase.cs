
using System;
using System.IO;
namespace DataBaseDPD
{
    public class Database

    {
        string sourceDir = "../../SGBD/";
       

        public void remove(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(Path.Combine(sourceDir, filename));
            }

        }




    }
}
