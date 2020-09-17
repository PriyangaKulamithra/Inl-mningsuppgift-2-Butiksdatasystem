using System;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Menu meny = new Menu();
            meny.PrintKassaMeny();
            var menyVal = meny.KorrektMenyval();

            switch (menyVal)
            {
                case 1:
                    meny.NyKund();
                    break;
                case 0:
                    meny.AvslutaKassaSystem();
                    break;
            }

            //ANVÄND DENNA KOD för att skriva belopp: Console.WriteLine(5000.ToString("C",null)); "5 000,00 kr"
        }
    }
}
