using System;
using System.Collections.Generic;
using System.IO;
using DataBaseDPD;

namespace DBConsole
{
    class Program
    {
        
        //minisql-tester.exe -i input-file.txt -o output-file.txt
        enum Parameter { Unset, InputFile, OutputFile };
        static void Main(string[] args)
        {
           
           List<string> columnNames = new List<string>(3);
           List<string> dataType = new List<string>();

          

          
           string query = "CREATE TABLE MyTable (Name TEXT, Age INT, Address TEXT);";
           string query2 = "INSERT INTO MyTable VALUES ('Eva',18,'Calle Los Herran 16 2 Derecha. 01005 Vitoria-Gasteiz');";//V
            string query21 = "INSERT INTO MyTable VALUES ('Eva',19,'Calle Los Herran 16 2 Derecha. 01005 Vitoria-Gasteiz');";
            string query22 = "INSERT INTO MyTable VALUES ('Eva',17,'Calle Los Herran 16 2 Derecha. 01005 Vitoria-Gasteiz');";

            string query3 = "DROP TABLE MyTable;";//V
           string query4 = "SELECT Name,Age FROM MyTable;";//V
            string query5 = "SELECT * FROM MyTable;";//V
            string query6 = "SELECT Name,Age FROM MyTable WHERE Age=18;";//V

            string query7 = "UPDATE MyTable SET Name=Paco WHERE Age=18;";

           Database db = new Database();


           db.RunQuery(query);
           db.RunQuery(query2);
            db.RunQuery(query21);
            db.RunQuery(query22);
            Console.WriteLine(db.RunQuery(query7));
            



            /**
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


          Database db;
          StreamReader file = new StreamReader(inputFile);
          StreamWriter writer = File.CreateText(outputFile);



          writer.Write("\n");
          string line;
           int count = 1;
          while ((line = file.ReadLine()) != null)
          {
               string result;
               double seconds;

               if (line=="" && (line = file.ReadLine()) != null)
               {
                   db = new Database();
                   writer.Write("\n");
                   writer.Write("TEST#" + count++);

                   DateTime start = DateTime.Now;
                   result = db.RunQuery(line);
                   DateTime end = DateTime.Now;

                   TimeSpan time = end - start;

                   seconds = time.Milliseconds / 1000.0;

                   writer.Write(result + " ( " + seconds + " )");
                   writer.Write("\n");

               }
               else
               {
                   db = new Database();
                   writer.Write("\n");
                   writer.Write("TEST#" + count);

                   DateTime start = DateTime.Now;
                   result = db.RunQuery(line);
                   DateTime end = DateTime.Now;

                   TimeSpan time = end - start;

                   seconds = time.Milliseconds / 1000.0;

                   writer.Write(result + " ( " + seconds + " )");
                   writer.Write("\n");

               }
               
               
              

          }
          writer.Write("\n");
          writer.Close();
          file.Close();
            **/
        }
    }
}
