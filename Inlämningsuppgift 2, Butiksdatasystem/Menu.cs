using System;
using System.Collections.Generic;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    internal class Menu
    {
        public void PrintMenu()
        {
            Console.WriteLine("KASSA");
            Console.WriteLine("1. Ny kund");
            Console.WriteLine("0. Avsluta");
            Console.Write("Menyval: ");
        }
        public int SafeMenuInput()
        {
            int nummer;
            while (true)
            {
                string menyval = Console.ReadLine();
                if (int.TryParse(menyval, out nummer) == true && nummer >= 0 && nummer < 2)
                    break;
                Console.WriteLine("Ogiltigt val... Vänligen ange 1 för Ny Kund eller 0 för att avsluta, tack!");
            }
            return nummer;
        }
        internal void Quit(Store store)
        {
            store.SaveProductsInStoreToFile();
            Console.Clear();
            Console.WriteLine("Tack för idag!");
            System.Threading.Thread.Sleep(1000);
        }
    }
}