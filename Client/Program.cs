using System;
using System.Net.Sockets;
using System.Collections.Generic;

namespace Client
{
    class MainClass
    {


        static String Connect(String message)
        {
            try
            {

                Int32 port = 13000;
                String server = "127.0.0.1";
                TcpClient client = new TcpClient(server, port);


                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                NetworkStream stream = client.GetStream();


                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);


                data = new Byte[256];


                String responseData = String.Empty;


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
        public static List<string> ReadConnection()
        {

            Console.Write("Connect: ");
            string connection = Console.ReadLine();

            List<string> result = new List<string>();
            string[] separate = connection.Split(',');
            for (int i = 0; i < separate.Length; i++)
            {
                result.Add(separate[i].Trim(' '));
            }
            return result;
        }
        public static void ProcessQuery(List<string> connection_data)
        {
            string message = string.Format("<Open Database={0} User={1} Password={2}/>", connection_data[0], connection_data[1], connection_data[2]);

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


        public static void Main(string[] args)
        {

            List<string> connection_data = ReadConnection();

            if (connection_data.Count > 1) ProcessQuery(connection_data);
            else Console.WriteLine("Please introduce the correct format {database},{user},{password}");



        }
    }
}