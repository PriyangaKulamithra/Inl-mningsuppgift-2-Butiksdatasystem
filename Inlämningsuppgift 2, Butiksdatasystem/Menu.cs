using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    class Menu
    {
        public void PrintKassaMeny()
        {
            Console.WriteLine("KASSA");
            Console.WriteLine("1. Ny kund");
            Console.WriteLine("0. Avsluta");
            Console.Write("Menyval: ");
        }
        public int KorrektMenyval()
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
        public void NyKund()
        {
            Console.Clear();
            //NYTT KÖP OCH KVITTO STARTAS
        }
        public void AvslutaKassaSystem()
        {
            Console.Clear();
            Console.WriteLine("Tack för idag!");
            System.Threading.Thread.Sleep(1000);

        }
    }
}
