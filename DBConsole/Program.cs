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

            Connection con = new Connection();
            StreamReader file = new StreamReader(inputFile);
            StreamWriter writer = File.CreateText(outputFile);

            
            string line;
            string head;
            int count = 1;
            double totalTime = 0;



            writer.Write("# TEST " + count++);
            writer.Write("\n");

            head = file.ReadLine();
            string[] header = head.Split(new Char[] { ',' });

            //Le quito uno por el espacio al final


            writer.Write(con.Connect(header[0], header[1], header[2])); //Puede dar exeption nullpointer
            writer.Write("\n");

            while ((line = file.ReadLine()) != null)
            {
                string result;
                double seconds;


                if (line == "")
                {
                    
                    writer.Write("TOTAL TIME: " + totalTime + "s");
                    writer.Write("\n");
                    writer.Write("\n");
                    writer.Write("# TEST "+ count++);
                    writer.Write("\n");
                    totalTime = 0;

                    con.Close();

                    line = file.ReadLine();
                    header = line.Split(new Char[] { ',' });

                    //Le quito uno por el espacio al final


                    writer.Write(con.Connect(header[0], header[1], header[2]));
                    writer.Write("\n");


                }
                else if(con.isConnected())
                {
                    DateTime start = DateTime.Now;
                    result = con.RunQuery(line);
                    DateTime end = DateTime.Now;

                    TimeSpan time = end - start;

                    seconds = time.Milliseconds / 1000.0;

                    writer.Write(result + " ( " + seconds + "s )");
                    totalTime += seconds;
                    writer.Write("\n");
                }

                

            }
            writer.Write("TOTAL TIME: " + totalTime + "s");
            writer.Write("\n");

            con.Close();
            writer.Close();
            file.Close();
        }


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

            Console.WriteLine("Input file: " + inputFile);
            Console.WriteLine("Output file: " + outputFile);



            process(inputFile, outputFile);


           
        }

    }
}
