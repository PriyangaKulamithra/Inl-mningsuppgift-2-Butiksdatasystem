using System;
using System.Collections.Generic;
using System.Text;

namespace MALL_inlupp_2
{
    class Product
    {
        private List<Product> AllProducts = new List<Product>();
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
        public void AddtoAllProductList(Product newProduct)
        {
            AllProducts.Add(newProduct);
        }
    }
}
