using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using DataBaseDPD;

namespace DBConsole
{
    class Program
    {

        static void Main()
        {
            TcpListener server = null;


            try
            {
               
                Int32 port = 1200;
                string ip = "127.0.0.1";
                IPAddress localAddr = IPAddress.Parse(ip);

                Byte[] bytes = new Byte[256];
                String data = null;
                String input = null;
                bool isCorrectIpAndPort = false;


                server = new TcpListener(localAddr, port);

                //connect to bd storage
                Connection con = new Connection();


                // Start listening for client requests.
                server.Start();


                //TcpClient client = server.AcceptTcpClient();

                TcpClient client = new TcpClient();


                NetworkStream stream = client.GetStream();


                input = null;
                int j;

                // Process the first input of the client to check if all is correct
                while ((j = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    input = Encoding.ASCII.GetString(bytes, 0, j);


                    byte[] msg = Encoding.ASCII.GetBytes(input);



                    if (port == 0 && ip == "") isCorrectIpAndPort = true;

                    //Try to connect to DataBase
                    //Parameter: Database, user, password
                    con.Connect("","","");

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                    
                }



                if (con.isConnected()&& isCorrectIpAndPort)
                {
                    Console.WriteLine("Connected!");
                    // Enter the listening loop.
                    while (true)
                    {
                        Console.Write("Waiting for a response... ");

                        data = null;
                        int i;

                        // Loop to receive all the data sent by the client.
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            // Translate data bytes to a ASCII string.
                            data = Encoding.ASCII.GetString(bytes, 0, i);


                            byte[] msg = Encoding.ASCII.GetBytes(data);

                            //process the queries over database
                            string response = con.RunQuery("");


                            // Send back a response.
                            stream.Write(msg, 0, msg.Length);
                            
                        }

                    }


                }
                else
                {
                    Console.WriteLine("Not connected!");
                    con.Close();
                }

            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
                
            }




        }





    }
}
