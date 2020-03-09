using DataBaseDPD;
using System;

namespace DBConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Table tabla = new Table("tabla.txt");
            tabla.save("tabla.txt");
            Console.ReadKey();

        }
    }
}
