using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    class Store
    {
        private List<Product> allProductsInStore = new List<Product>();

        public List<Product> AddToStoreFromFile()
        {
            string productFilePath = @"..\..\..\Products.txt";
            if (File.Exists(productFilePath))
            {
                using (var sr = File.OpenText(productFilePath))
                {
                    while (true)
                    {
                        var line = sr.ReadLine();
                        if (String.IsNullOrEmpty(line)) break;
                        var splitLine = line.Split('_');
                        ProductType type;
                        if (splitLine[3] == "Styck") type = ProductType.Styck;
                        else type = ProductType.Kilo;
                        Product newProduct = new Product(splitLine[0], splitLine[1], Convert.ToInt32(splitLine[2]), type);
                        allProductsInStore.Add(newProduct);
                    }
                }
                return allProductsInStore;
            }
            else return null;
        }
        internal Product DoesProductExistInStore(string id)
        {
            foreach (var product in allProductsInStore)
            {
                if (id == product.ProductID) return product;
            }
            return null;
        }
        public void SaveProductsInStoreToFile()
        {
            string productFilePath = @"..\..\..\Products.txt";
            if (File.Exists(productFilePath)) File.Delete(productFilePath);
            using (var sw = File.AppendText(productFilePath))
            {
                foreach (var product in allProductsInStore)
                {
                    var line = $"{product.ProductName}_{product.ProductID}_{product.Price}_{product.Type}";
                    sw.WriteLine(line);
                }
            }
        }
        public IEnumerable<Product> GetAllProductsInStore()
        {
            AddToStoreFromFile();
            return allProductsInStore;
        }
        public Product GetProduct(string id)
        {
            var allProduct = GetAllProductsInStore();
            foreach (var product in allProduct)
            {
                if (id == product.ProductID) return product;
            }
            return null;
        }
    }
}