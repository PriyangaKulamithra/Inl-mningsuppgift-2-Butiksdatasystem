using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    class ReceiptItem
    {
        public string Name { get; private set; }
        public string ProductID { get; private set; }
        public decimal Price { get; private set; }
        public int Qty { get; private set; }
        public ReceiptItem(Product product, int qty)
        {
            Name = product.ProductName;
            ProductID = product.ProductID;
            Price = product.Price;
            Qty = qty;
        }
        public void AddQtyToItem(int qty)
        {
            Qty += qty;
        }
    }
}
