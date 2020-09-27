using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;

namespace MALL_inlupp_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            var store = new Store();
            var allProductsInStore = store.GetAllProductsInStore();

            bool isRunning = true;
            while (isRunning)
            {
                menu.PrintMenu();
                var menuChoice = menu.SafeMenuInput();
                switch (menuChoice)
                {
                    case 1:
                        var newCustomer = new NewCustomer();
                        newCustomer.StartNewPurchase();
                        break;
                    case 0:
                        menu.Quit(allProductsInStore, store);
                        isRunning = !isRunning;
                        break;
                }
            }
        }
    }
}
