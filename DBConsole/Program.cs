using System;
using System.Collections.Generic;
using System.IO;
using DataBaseDPD;

namespace DBConsole
{
    class Program
    {


        public static void process(string inputFile, string outputFile)
        {
           
            Database db = new Database();
            StreamReader file = new StreamReader(inputFile);
            StreamWriter writer = File.CreateText(outputFile);

            writer.Write("\n");
            string line;

            while ((line = file.ReadLine()) != null)
            {
                string result;
                double seconds;

                writer.Write("\n");


                DateTime start = DateTime.Now;
                result = db.RunQuery(line);
                DateTime end = DateTime.Now;

                TimeSpan time = end - start;

                seconds = time.Milliseconds / 1000.0;

                writer.Write(result + " ( " + seconds + " )");
                writer.Write("\n");

                

            }
            writer.Write("\n");
            writer.Close();
            file.Close();
        }


        //minisql-tester.exe -i input-file.txt -o output-file.txt
        enum Parameter { Unset, InputFile, OutputFile };
        static void Main(string[] args)
        {
            /***
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

            Console.WriteLine("Input file: " + inputFile);
            Console.WriteLine("Output file: " + outputFile);



            process(inputFile, outputFile);

            **/


            Database db = new Database();

            string query = "CREATE TABLE MyTable (Name TEXT, Age INT, Address TEXT);";
           
            string q1 = "INSERT INTO MyTable VALUES ('Eva',18,'Calle Los Herran 16 2 Derecha. 01005 Vitoria-Gasteiz');";
            string q2 = "INSERT INTO MyTable VALUES ('Ramon',26,'Larratxo kalea 23 2. Ezk. 20012 Donostia');";
            string q3 = "INSERT INTO MyTable VALUES ('Miren',26,'Larratxo kalea 23 2. Ezk. 20012 Donostia');";

            db.RunQuery(query);
           
            db.RunQuery(q1);
            db.RunQuery(q2);
            db.RunQuery(q3);





            db.RunQuery("UPDATE MyTable SET Age=16 WHERE Name='Miren';");



        }

    }
}
