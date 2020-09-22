using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    class Store
    {
        private List<Produkt> AllProductsInStore = new List<Produkt>();

        public void AddProductToStore(Produkt product)
        {
            AllProductsInStore.Add(product);
        }
        public bool IsAProduct(string productid)
        {
            foreach (var product in AllProductsInStore)
            {
                if (productid == product.ProduktID)
                    return true;
            }
            return false;
        }
        //public IEnumerable<Produkt> GetAllProductsInStore()
        //{
        //    return AllProductsInStore;
        //}
        public Produkt GetProductInfo(string kommandoinput)
        {
            string productid = kommandoinput.Substring(0, 3);
            int amount = Convert.ToInt32(kommandoinput.Substring(4));
            bool isAProduct = IsAProduct(productid);
            if (isAProduct == true)
            {
                foreach (var product in AllProductsInStore)
                    return product;
            }
            Console.WriteLine("Produktid finns ej.");
            return null;
        }
        public decimal CalculatePrice(string productID, int amount)
        {
            decimal price = 0;
            foreach (var product in AllProductsInStore)
            {
                if (productID == product.ProduktID)
                {
                    price += product.Pris * amount;
                }
            }
            return price;
        }
       
    }
}
