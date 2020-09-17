using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    class Produkt
    {
        public int ProduktID { get; private set; }
        public int Pris { get; private set; }
        public PrisTyp Typ { get; private set; }
        public string ProduktNamn { get; private set; }
        public Produkt(string produktNamn, int produktID, int pris, PrisTyp typ)
        {
            ProduktNamn = produktNamn;
            ProduktID = produktID;
            Pris = pris;
            Typ = typ;
        }
    }
}
