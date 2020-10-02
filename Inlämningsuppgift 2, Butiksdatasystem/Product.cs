using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    class Product
    {
        public string ProductID { get; private set; }
        public int Price { get; private set; }
        public ProductType Type { get; private set; }
        public string ProductName { get; private set; }
        public Product(string productname, string productID, int price, ProductType type)
        {
            ProductName = productname;
            ProductID = productID;
            Price = price;
            Type = type;
        }
    }
}
