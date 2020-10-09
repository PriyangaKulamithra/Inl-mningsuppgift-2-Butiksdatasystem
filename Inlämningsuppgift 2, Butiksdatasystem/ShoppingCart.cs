using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    class ShoppingCart
    {
        private List<ReceiptItem> shoppingCart = new List<ReceiptItem>();

        public void AddProduct(Product product, int qty)
        {
            var item = shoppingCart.Find(i => i.ProductID == product.ProductID);
            if (item == null)
            {
                var newItem = new ReceiptItem(product, qty);
                shoppingCart.Add(newItem);
            }
            else
            {
                item.AddQtyToItem(qty);
            }
        }
        public void ReturnProduct(string id)
        {
            foreach (var item in shoppingCart)
            {
                if (item.ProductID == id)
                {
                    item.AddQtyToItem(-1);
                    if (item.Qty == 0)
                    {
                        shoppingCart.Remove(item);
                    }
                }
            }
        }
    }
}
