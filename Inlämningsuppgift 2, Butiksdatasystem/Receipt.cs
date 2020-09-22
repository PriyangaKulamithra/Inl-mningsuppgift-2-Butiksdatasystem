using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    public class Receipt
    {
        
        private List<string> AllReceipts = new List<string>();
        
        public void AddReceiptToTodaysList(string newReceipt)
        {
            this.AllReceipts.Add(newReceipt);
        }
        public IEnumerable<string> GetAllReceiptsFromToday()
        {
            return this.AllReceipts;
        }

    }
}
