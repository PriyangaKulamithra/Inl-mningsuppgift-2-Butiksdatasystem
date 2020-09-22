using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    class Produkt
    {
        public string ProduktID { get; private set; }
        public decimal Pris { get; private set; }
        public PrisTyp Typ { get; private set; }
        public string ProduktNamn { get; private set; }
        public Produkt(string produktNamn, string produktID, decimal pris, PrisTyp typ)
        {
            ProduktNamn = produktNamn;
            ProduktID = produktID;
            Pris = pris;
            Typ = typ;
        }
        public string GetProductIDFromInput(string input)
        {
            string productid = input.Substring(0, 3);
            return productid;
        }
    }
}
