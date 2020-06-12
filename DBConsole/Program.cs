using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using DataBaseDPD;

namespace DBConsole
{
    class Program
    {

        class Server
        {
            public static Connection con = new Connection();

            //ParserQuery is a function that treat the answer and query
           
            public static String ParseQuery(String message)
            {

                Match match;
                String response = null;
                //regular expressions
                const string connection = @"<Open\sDatabase(=)([^\)]+)\sUser(=)([^\)]+)\sPassword(=)\s*([^\)]+)/>";
                const string query = @"<Query>(\w+)</Query>";

                match = Regex.Match(message, query);
                if (match.Success)
                {
                    string res = con.RunQuery(match.Groups[1].Value);

                    if (res.StartsWith("ERROR"))
                    {
                        response = string.Format("<Answer><Error>{0}</Error></Answer>", res);
                    }
                    else
                    {
                        response = string.Format("<Answer>{0}</Answer>", res);
                    }
                    return response;
                }
                match = Regex.Match(message, connection);
                if (match.Success)
                {
                    string database = (string)match.Groups[1].Value;
                    string user = (string)match.Groups[2].Value;
                    string password = (string)match.Groups[3].Value;

                    string res = con.Connect(database, user, password);


                    if (con.isConnected())
                    {
                        response = "<Success/>";
                    }
                    else
                    {
                        response = string.Format("<Error>{0}</Error>", res);
                    }
                    return response;
                }

                return response;

            }



            public static void Main(string[] args)
            {
                //Listens for TCP network client connections
                TcpListener server = null;
                try
                {
                   //Set the Tcp Listener on port 13000
                    Int32 port = 13000;
                    string ip = "127.0.0.1";
                    IPAddress localAddr = IPAddress.Parse(ip);

                    //Create a new server and put it on server variable
                    server = new TcpListener(localAddr, port);

                    //star server
                    server.Start();

                    //buffer for reading data, and define response 
                    Byte[] bytes = new Byte[256];
                    String data = null;
                    String response = null;

                    //enter the listening loop
                    while (true)
                    {
                        Console.Write("Waiting for a connection... ");

                        //Perform a blocking call to acept request
                        //You could also use server.AcceptSocket() here.
                        TcpClient client = server.AcceptTcpClient();
                        Console.WriteLine("Connected!");

                        data = null;

                        //Get a stream object for reading and writing
                        NetworkStream stream = client.GetStream();

                        int i;

                        //Loop to recive all the data sent by client
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            //Translate data bytes to a ASCII string
                            data = Encoding.ASCII.GetString(bytes, 0, i);
                            Console.WriteLine("Received: {0}", data);

                            //We call ParserQuery , proccess the data sent by the client
                            response = ParseQuery(data);


                            byte[] msg = Encoding.ASCII.GetBytes(response);

                            //send back a response
                            stream.Write(msg, 0, msg.Length);
                            Console.WriteLine("Sent: {0}", response);
                        }

                        //shutdown and end connections
                        client.Close();
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }
                finally
                {

                    server.Stop();
                }

                Console.WriteLine("\nHit enter to continue...");
                Console.Read();
            }

        }
    }
}
