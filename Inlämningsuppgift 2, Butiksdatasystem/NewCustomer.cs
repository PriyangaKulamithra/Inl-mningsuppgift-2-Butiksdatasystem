using System;
using System.Collections.Generic;
using System.IO;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    internal class NewCustomer
    {
        public void StartNewPurchase()
        {
            Store store = new Store();
            var shoppingCartItems = new List<Product>();
            var howManyItems = new List<int>();
            var thisDateAndTime = DateTime.Now.ToString();
            while (true)
            {
                PrintShoppingCart(thisDateAndTime, shoppingCartItems, howManyItems);
                PrintOption();
                var input = CorrectInput();
                if (input == "PAY")
                {
                    Pay(shoppingCartItems, howManyItems, thisDateAndTime);
                    break;
                }
                else if (input == "RETURN")
                {
                    Console.Write("<productid> ");
                    var id = Console.ReadLine();
                    Return(id, shoppingCartItems, howManyItems);
                }
                else
                {
                    var id = GetIDFromInput(input);
                    var qty = GetQtyFromInput(input);
                    var product = store.GetProduct(id);
                    if (product != null && !shoppingCartItems.Contains(product) && qty > 0)
                    {
                        shoppingCartItems.Add(product);
                        howManyItems.Add(qty);
                    }
                    else if (product == null)
                    {
                        Console.WriteLine("ProduktID hittades ej");
                        System.Threading.Thread.Sleep(1000);
                    }
                    else if (qty < 1)
                    {
                        Console.WriteLine("För lågt antal.");
                        System.Threading.Thread.Sleep(1000);
                    }
                    else
                    {
                        var indexOfProductInToBuy = shoppingCartItems.IndexOf(product);
                        howManyItems[indexOfProductInToBuy] += qty;
                    }
                }
            }
        }

        private void PrintShoppingCart(string thisDateAndTime, List<Product> shoppingCartItems, List<int> howManyItems)
        {
            var calculator = new Calculator();
            Console.Clear();
            Console.WriteLine("KASSA");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"KVITTO   {thisDateAndTime}");
            var total = 0m;
            var index = 0;
            foreach (var eachProduct in shoppingCartItems)
            {
                var price = calculator.GetPrice(eachProduct.Price, howManyItems[index]);
                Console.WriteLine($"{eachProduct.ProductName} {howManyItems[index]}*{eachProduct.Price} = {price}");
                total += price;
                index++;
            }
            if (total < 1000) Console.WriteLine($"Total: {total}");
            else if (total >= 1000) calculator.GetDiscountAndPrint(total);
        }

        private void Return(string id, List<Product> shoppingCartItems, List<int> howManyItems)
        {
            foreach (var item in shoppingCartItems)
            {
                if (item.ProductID == id)
                {
                    var index = shoppingCartItems.IndexOf(item);
                    if (howManyItems[index] == 0)
                    {
                        shoppingCartItems.Remove(shoppingCartItems[index]);
                        howManyItems.Remove(howManyItems[index]);
                        break;
                    }
                    howManyItems[index]--;
                }
            }
        }

        private void Pay(List<Product> ProductsToBuy, List<int> qty, string date)
        {
            var newPayment = new Payment(ProductsToBuy, qty, date);
            newPayment.SavetoFile();
            Console.WriteLine("Avslutar köp...");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }

        private string GetIDFromInput(string input)
        {
            var splittedInput = input.Split(' ');
            if (splittedInput[0].Length == 3)
                return splittedInput[0];
            else return "Felaktigt ID";
        }
        private int GetQtyFromInput(string input)
        {
            int qty;
            int.TryParse(input.Substring(4), out qty);
            return qty;
        }
        private Product GetProduct(string id, IEnumerable<Product> allProducts)
        {
            var existing = DoesProductExistInStore(id, allProducts);
            if (existing == null) return null;
            else return existing;
        }
        private Product DoesProductExistInStore(string id, IEnumerable<Product> allProductsInStore)
        {
            foreach (var product in allProductsInStore)
            {
                if (id == product.ProductID)
                    return product;
            }
            return null;
        }
        private void PrintOption()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Kommandon:");
            Console.WriteLine("<productid> <antal>");
            Console.WriteLine("RETURN");
            Console.WriteLine("PAY");
            Console.Write("Kommando: ");
        }
        private string CorrectInput()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Length < 5 && input != "PAY" && input != "RETURN")
                {
                    Console.Write("Ogiltig input. Var god ange 3-siffrigt produkt-id och antal: ");
                }
                else return input;
            }
        }
    }
}