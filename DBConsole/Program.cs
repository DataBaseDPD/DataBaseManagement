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
            /**
           List<string> columnNames = new List<string>(3);
           List<string> dataType = new List<string>();

          

           string data = "Name TEXT, Age INT, Address TEXT";
           string query = "CREATE TABLE MyTable (Name TEXT, Age INT, Address TEXT);";
           string query2 = "INSERT INTO MyTable VALUES ('Eva',18,'Calle Los Herran 16 2 Derecha. 01005 Vitoria-Gasteiz');";
           string query3 = "DROP TABLE MyTable;"

           Database db = new Database();


           db.RunQuery(query);
           Console.WriteLine(db.RunQuery(query2));
    **/




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
                string result;
                double seconds;

                
                    DateTime start = DateTime.Now;
                    result = db.RunQuery(query);
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
    }
}
