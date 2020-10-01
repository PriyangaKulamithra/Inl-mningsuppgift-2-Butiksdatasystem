using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    class Payment
    {
        List<Product> items = new List<Product>();
        List<int> howManyItems = new List<int>();
        string date;
        Calculator calculator = new Calculator();
        public Payment(List<Product> shoppingCart, List<int> howManyItems, string date)
        {
            items = shoppingCart;
            this.howManyItems = howManyItems;
            this.date = date;
        }
        public void SavetoFile()
        {
            var todaysDate = DateTime.Now.ToString("yyyyMMdd");
            var receiptPath = @$"..\..\..\RECEIPT_{todaysDate}.txt";
            using (var sw = File.AppendText(receiptPath))
            {
                sw.WriteLine($"KVITTO   {date}");
                var index = 0;
                var total = 0m;
                foreach (var product in items)
                {
                    var line = @$"{product.ProductName} {howManyItems[index]}*{product.Price} = {howManyItems[index] * product.Price}";
                    sw.WriteLine(line);
                    total += howManyItems[index] * product.Price;
                    index++;
                }
                if (total < 1000) sw.WriteLine($"Total: {total}");
                else if (total >= 1000)
                {
                    var discount = calculator.GetDiscount(total);
                    sw.WriteLine($"Items Totals: {total}");
                    sw.WriteLine($"Rabatt: {discount}");
                    sw.WriteLine($"Total: {total - discount}");
                }
                sw.WriteLine("**********");
            }
        }
    }
}