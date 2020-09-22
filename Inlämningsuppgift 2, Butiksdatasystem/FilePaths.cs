using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    class FilePaths
    {
        public void SaveReceiptsToFile()
        {
            Receipt AllReceipts = new Receipt();
            //var allReceipts= AllReceipts.GetAllReceiptsFromToday();
            var todaysDate = DateTime.Now.ToString("yyyyMMdd");
            string filePathReceipts = $"Receipts_{todaysDate}.txt";
            //USING SW skicka AllReceipts-listan till filen, APPENDALLLINES  
            using (var sw = File.AppendText(filePathReceipts))
            {
                foreach (var line in AllReceipts.GetAllReceiptsFromToday())
                {
                    sw.WriteLine(line);
                }
                sw.WriteLine("\n*****\n");
            }
        }
        //public void CreateTextFileForProducts()
        //{
        //    string filePathProducts = "Products.txt";
        //    File.Create(filePathProducts);
        //}
        public void GetAllProductsFromFile()
        {
            string filePathProducts = "Products.txt";
            if (File.Exists(filePathProducts))
            {
                Store store = new Store();
                using (var sr = new StreamReader(filePathProducts))
                {
                    while (true)
                    {
                        string line;
                        line = sr.ReadLine();
                        if (line == null)
                            break;
                        string[] separateInfo = line.Split(' ');
                        string productName = separateInfo[0];
                        string produktID = separateInfo[1];
                        decimal pris = Convert.ToDecimal(separateInfo[2]);
                        PrisTyp pristyp;
                        if (separateInfo[3] == "Styck")
                            pristyp = PrisTyp.Styck;
                        else pristyp = PrisTyp.Kilo;
                        Produkt product = new Produkt(productName, produktID, pris, pristyp);
                        store.AddProductToStore(product);
                    }
                }
            }
        }

    }
}
