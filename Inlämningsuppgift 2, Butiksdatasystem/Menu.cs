using System;
using System.Collections.Generic;
using System.Drawing;
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
            //ÖPPNA TEXTFIL OCH LÄS IN SPARADE PRODUKTER TILL LISTA
            //NYTT KÖP OCH KVITTO SPARAS TILL LISTA VID "PAY"
            var thisDateAndTime = DateTime.Now.ToString();
            Console.WriteLine("KASSA");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"KVITTO   {thisDateAndTime}");
            Console.BackgroundColor = ConsoleColor.Black;
            while (true)
            {
                Receipt newReceipt = new Receipt();
                ShoppingCart shoppingcart = new ShoppingCart();
                var Cart = shoppingcart.GetShoppingCart();
                foreach (var product in Cart)
                {
                    Console.WriteLine($"{product.ProduktNamn} ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("kommandon: ");
                Console.WriteLine("<productid> <antal>");
                Console.WriteLine("PAY");
                Console.Write("Kommando: ");
                var kommandoInput = Console.ReadLine();

                if (kommandoInput == "PAY")
                {
                    //newReceipt.AddReceiptToTodaysList(newReceipt);
                    break;
                }
                else
                {
                    string productid = kommandoInput.Substring(0, 3);
                    int amount = Convert.ToInt32(kommandoInput.Substring(4));
                    Store newStore = new Store();
                    var thisProduct = newStore.GetProductInfo(kommandoInput);
                    shoppingcart.AddToShoppingCart(thisProduct);
                }
            }
        }

        //FORTSÄTT MED NEDAN KOD IMORGON FÖR ATT HANTERA KOMMANDOINPUT, FÖLJD AV OVAN METOD
        //TA IN STRÄNGEN, DELA VID SPACE OCH LÄGG I OLIKA VARIABLER
        public string KommandoInput()
        {
            var input = Console.ReadLine();
            return input;
        }
        public void AvslutaKassaSystem()
        {
            Console.Clear();
            Receipt AllReceiptsFromToday = new Receipt();
            //AllReceiptsFromToday.SaveReceiptsToFile();
            Console.WriteLine("Tack för idag!");
            System.Threading.Thread.Sleep(1000);
            //SPARA ALLA KVITTON TILL FIL
        }
    }
}
