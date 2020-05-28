﻿using System;
using System.Text;
using System.Net.Sockets;
namespace Client
{
    class Program
    {


        public static string Error = "Error";
        public static string userDataBase = "";



        //This method treats passwords
        public static string GetPasswd(string thePasswd)
        {
            //String builder we use because it is mutable
            StringBuilder password = new StringBuilder("");
            bool passwordConfirm = false;


            ConsoleKeyInfo cKey;

            //for security, the password will be represented with crosses

            while (!passwordConfirm)
            {
                Console.WriteLine(thePasswd);

                for (int i = 0; i < password.Length; i++) Console.WriteLine("+");
                cKey = Console.ReadKey(true);
                if (cKey.Key.ToString() == "Enter")
                {
                    if (password.Length < 6 && password.Length > 21)
                    {
                        Console.WriteLine("Password have to between 7 and 20 characters");
                        continue;
                    }
                    passwordConfirm = true;
                    continue;
                }
                else if (cKey.Key.ToString() == "BackSpace" && password.Length > 0)
                {
                    password.Remove(password.Length - 1, 1);
                }

                Console.Clear();
            }

            return password.ToString();

        }

        //This method is about User Login
        public static bool Login(bool nUser)

        {

            string user = "";
            string password = "";
            string confirmP = "";

            bool passwordIsValidated = false;

            //Put your name
            Console.WriteLine("Enter Username:");
            user = Console.ReadLine();

            //Try password two times
            while (!passwordIsValidated)
            {
                password = GetPasswd("Enter your password:");
                Console.WriteLine();
                confirmP = GetPasswd("Please enter again yout password:");

                if (password != confirmP)
                {

                    Console.WriteLine("Please Repeat password because it doesn't match");
                    continue;
                }
                else
                {
                    break;
                }

            }

            //Now we try to send at the server
            Console.WriteLine("Send client information to server for try login");
            return SendLogin(user, password, nUser);
        }

        public static bool dataBase(string message)

        {

            string dataName = "";
            Console.WriteLine("Data Base will be created");
            dataName = Console.ReadLine();
            dataName = "mySQL";

            //Now we try to send at the server
            Console.WriteLine("Data Base created, please wait the system is sending to the server now");

            return SendNewDB(dataName, message);
        }

        //this method is about the sql processing
        public static bool sql(string message)
        {
            string dataName;
            dataName = "";
            Console.WriteLine("Get ready to process file txt");
            dataName = Console.ReadLine();
            dataName = "NoName";


            //Wre create the database name , so therefore , we try to creation this at the server
            Console.WriteLine("Wait a moment please, sending the request to server...");

            return SendNewDB(dataName, message);
        }

        //Now we have 2 methods, one to sending information login to server, and the last one is dbName to Server

        public static bool SendLogin(string username, string password, bool nUser)
        {
            TcpClient tcpClient;
            try
            {
                tcpClient = new TcpClient("127.0.0.1", 0000);// If you need to change ip and port, please change here
                Console.WriteLine("Credentials sent to server");

            }
            catch
            {
                return false;
            }


            //Opening network stream whit server
            NetworkStream netStream = tcpClient.GetStream();
            byte[] byteSend = ASCIIEncoding.ASCII.GetBytes(username + "#.*;#" + password);

            //Send info and wait response
            netStream.Write(byteSend, 0, byteSend.Length);

            //Our server response our petition
            byte[] bytesRead = new byte[tcpClient.ReceiveBufferSize];
            int byteRead = netStream.Read(byteSend, 0, tcpClient.SendBufferSize);
            tcpClient.Close();

            // In conclusion if the client is logged
            if (Encoding.ASCII.GetString(bytesRead, 0, byteRead).Substring(0, 4) == "True")
            {
                userDataBase = username;
                return true;
            }

            return false;
        }


        public static bool SendNewDB(string dataBaseName, string message)
        {
            TcpClient tcpClient;

            //We need try connection whit our server
            try
            {

                tcpClient = new TcpClient("127.0.0.1", 0000); // If you need to change ip and port, please change here
                Console.WriteLine("dataBaseName" + dataBaseName + "send to server");
            }
            catch
            {
                return false;
            }
            // Opening network stream with server
            NetworkStream netStream = tcpClient.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(dataBaseName + "#.*;#" + userDataBase + "#.*;#" + message);

            // Sending credentials and waiting for response.
            netStream.Write(bytesToSend, 0, bytesToSend.Length);

            // Reading response from server
            byte[] bytesToRead = new byte[tcpClient.ReceiveBufferSize];
            int bytesRead = netStream.Read(bytesToRead, 0, tcpClient.ReceiveBufferSize);
            tcpClient.Close();

            // If Server sends "createdDataBase", database is created
            if (Encoding.ASCII.GetString(bytesToRead, 0, bytesRead).Substring(0, 15) == "createdDataBase")
            {
                return true;
            }

            // If Server sends "processSQLOK", processate is done
            if (Encoding.ASCII.GetString(bytesToRead, 0, bytesRead).Substring(0, 12) == "The process SQl its Ok")
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
