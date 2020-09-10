using System;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    class Program
    {
        static void PrintKassaMenu()
        {
            Console.WriteLine("KASSA");
            Console.WriteLine("1. Ny kund");
            Console.WriteLine("0. Avsluta");
        }
        static void Main(string[] args)
        {
            PrintKassaMenu();
        }
    }
}
