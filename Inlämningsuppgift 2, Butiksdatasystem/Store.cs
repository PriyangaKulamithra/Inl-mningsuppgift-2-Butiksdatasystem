using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MALL_inlupp_2
{
    class Store
    {
        private List<Product> AllProductsInStore = new List<Product>();

        private List<Product> AddToStoreFromFile()
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
                        AllProductsInStore.Add(newProduct);
                    }
                }
                return AllProductsInStore;
            }
            else return null;
        }
        internal Product DoesProductExistInStore(string id)
        {
            foreach (var product in AllProductsInStore)
            {
                if (id == product.ProductID)
                    return product;
            }
            return null;
        }
        public void SaveProductsToFile(IEnumerable<Product> AllProductsInStore)
        {
            string productFilePath = @"..\..\..\Products.txt";
            if (File.Exists(productFilePath)) File.Delete(productFilePath);
            using (var sw = File.AppendText(productFilePath))
            {
                foreach (var product in AllProductsInStore)
                {
                    var line = $"{product.ProductName}_{product.ProductID}_{product.Price}_{product.Type}";
                    sw.WriteLine(line);
                }
            }
        }
        public IEnumerable<Product> GetAllProductsInStore()
        {
            AddToStoreFromFile();
            return AllProductsInStore;
        }
    }
}
