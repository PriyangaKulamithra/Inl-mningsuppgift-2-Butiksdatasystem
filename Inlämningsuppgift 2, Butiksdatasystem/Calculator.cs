using System;
using System.Collections.Generic;
using System.Text;

namespace MALL_inlupp_2
{
    class Calculator
    {
        public decimal GetPrice(decimal price, int howMany)
        {
            return price * howMany;
        }
        public decimal GetDiscountAndPrint(decimal total)
        {
            var discount = 0m;
            if (total < 2000)
            {
                discount = total * 0.02m;
                Console.WriteLine($"Items total: {total}");
                Console.WriteLine($"Rabatt: {discount}");
                Console.WriteLine($"Total: {total - discount}");
                return total - discount;
            }
            discount = total * 0.03m;
            Console.WriteLine($"Items total: {total}");
            Console.WriteLine($"Rabatt: {discount}");
            Console.WriteLine($"Total: {total - discount}");
            return total - discount;
        }
        public decimal GetDiscount(decimal total)
        {
            if (total < 2000) return total * 0.02m;
            return total * 0.03m;
        }
    }
}
