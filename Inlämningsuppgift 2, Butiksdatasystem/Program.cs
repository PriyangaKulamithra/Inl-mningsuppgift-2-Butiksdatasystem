using System;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Store store = new Store();
            //Produkt apples = new Produkt("Äpple", "100", 5, PrisTyp.Kilo);
            //Produkt bananas = new Produkt("Banan", "200", 3, PrisTyp.Kilo);
            //Produkt kaffe = new Produkt("Kaffe", "300", 35, PrisTyp.Styck);
            //store.AddProductToStore(apples);
            //store.AddProductToStore(bananas);
            //store.AddProductToStore(kaffe);

            FilePaths filepaths = new FilePaths();
            filepaths.GetAllProductsFromFile();
            Menu meny = new Menu();
            bool isRunning = true;
            while (isRunning)
            {
                meny.PrintKassaMeny();
                var menyVal = meny.KorrektMenyval();
                switch (menyVal)
                {
                    case 1:
                        Console.Clear();
                        meny.NyKund();
                        break;
                    case 0:
                        meny.AvslutaKassaSystem();
                        filepaths.SaveReceiptsToFile();
                        isRunning = false;
                        break;
                }
            }
            


        }
    }
}
