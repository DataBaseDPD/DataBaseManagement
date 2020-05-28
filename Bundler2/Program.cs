using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Diagnostics;


namespace Bundler2
{
    class MainClass
    {
        //To avoid diferent file systems we use methods of the system

        public static string currDirName = Directory.GetCurrentDirectory(); //relative path to the solution root folder from Bundler.exe
        public static string rootDir = Directory.GetParent(currDirName).Parent.Parent.FullName;
        public static string releaseDir = Path.Combine(rootDir, "DBConsole", "bin", "Release");
        public static string RootFolderInZip = "DataBaseDPD"; //name of the folder created inside the zip file

        public static void Main()
        {
            List<string> files = new List<string>();
            string version;


            version = GetVersion(Path.Combine(releaseDir,"DBConsole.exe"));


           
            files.Add(Path.Combine(releaseDir, "DBConsole.exe"));
            files.Add(Path.Combine(releaseDir, "DataBaseDPD.dll"));


            string outputFile = Path.Combine(rootDir, "DataBaseDPD-" + version + ".zip"); //name of the output zip file



            Console.WriteLine("Compressing files");
            Compress(outputFile, files);
            Console.WriteLine("Finished");
           
        }


        public static string GetVersion(string file)
        {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(file);

            return fvi.FileVersion;
        }

        public static void Compress(string outputFilename, List<string> files)
        {
            uint numFilesAdded = 0;
            double totalNumFiles = (double)files.Count;
            using (FileStream zipToOpen = new FileStream(outputFilename, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    foreach (string file in files)
                    {
                        if (System.IO.File.Exists(file))
                        {
                            archive.CreateEntryFromFile(file, RootFolderInZip + file.Substring(currDirName.Length));
                            numFilesAdded++;
                        }
                        else Console.WriteLine("Couldn't find file: {0}", file);

                        Console.Write("\rProgress: {0:F2}%", 100.0 * ((double)numFilesAdded) / totalNumFiles);
                    }
                    Console.WriteLine("\nSaving {0} files in  {1}", numFilesAdded, Path.GetFullPath(outputFilename));
                }
            }
        }


    }
}
