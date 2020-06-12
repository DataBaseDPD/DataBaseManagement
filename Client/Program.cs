using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
namespace Client
{
    class Program
    {
        static String Connect(String message)
        {
            try
            {
                //Create a TCP Client
                //Note , for this client to work you need to haave a TcpServer
                //connected to same address as specified by the server, port
                //combination
                Int32 port = 13000;
                String server = "127.0.0.1";
                TcpClient client = new TcpClient(server, port);

                //Translate the passed message into ASCII and store it as a Byte arry
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                //Get a client stream for reading and writing 
                NetworkStream stream = client.GetStream();

                //send the message to the conected Tcp server
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                //Recive the TcpServer.response.

                //Buffer to store the response bytes
                data = new Byte[256];

                //String to store the response ASCII representation
                String responseData = String.Empty;

                //Read the first Batch of the TcpServer response bytes
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);


                // Close everything.
                stream.Close();
                client.Close();
                return responseData;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);

            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);

            }

            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
            return null;
        }


        public static void Main(string[] args)
        {

            
            Console.Write("Connect: ");
            string connection = Console.ReadLine();
            //We need put data information whit comas
            List<string> result = new List<string>();
            string[] separate = connection.Split(',');
            for (int i = 0; i < separate.Length; i++)
            {
                result.Add(separate[i].Trim(' '));
            }
            string message = string.Format("<Open Database={0} User={1} Password={2}/>", result[0], result[1], result[2]);
            //start connection TcpClient
            String res = Connect(message);

            if (res.Equals("<Success/>"))
            {
                bool continu = true;
                while (continu)
                {
                    Console.Write("Write a query: ");
                    string query = Console.ReadLine();

                    message = string.Format("<Query>{0}</Query>", query);

                    res = Connect(message);

                    if (res.Equals("<Close/>")) continu = false;
                }

            }



        }
    }

}
