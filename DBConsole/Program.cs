using DataBaseDPD;
using System;
using System.Collections.Generic;
using System.IO;

namespace DBConsole
{
    class Program
    {
        
        //minisql-tester.exe -i input-file.txt -o output-file.txt
        enum Parameter { Unset, InputFile, OutputFile };
        static void Main(string[] args)
        {
            string inputFile = "input-file.txt";
            string outputFile = "output-file.txt";
            Parameter lastParameter = Parameter.Unset;
            foreach (string arg in args)
            {
                if (arg == "-i") lastParameter = Parameter.InputFile;
                else if (arg == "-o") lastParameter = Parameter.OutputFile;
                else if (lastParameter == Parameter.InputFile) inputFile = arg;
                else if (lastParameter == Parameter.OutputFile) outputFile = arg;
            }


            Database db = new Database();
            StreamReader file = new StreamReader(inputFile);
            StreamWriter writer = File.CreateText(outputFile);



            writer.Write("\n");
            string query;
            while ((query = file.ReadLine()) != null)
            {
                DateTime start = DateTime.Now;
                string result = db.RunQuery(query);
                DateTime end = DateTime.Now;

                TimeSpan time = end - start;

                double seconds = time.Milliseconds / 1000.0;

                writer.Write( result + " ( " + seconds+ " )");
                writer.Write("\n");

            }
            writer.Write("\n");
            writer.Close();
            file.Close();
        }
    }
}
