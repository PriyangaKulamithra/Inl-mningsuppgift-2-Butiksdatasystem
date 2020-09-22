using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    class ShoppingCart
    {
        private List<Produkt> Shoppingcart = new List<Produkt>();
        public void AddToShoppingCart(Produkt product)
        {
            Shoppingcart.Add(product);
        }
        public IEnumerable<Produkt> GetShoppingCart()
        { 
            return Shoppingcart;
        }
    }
}
