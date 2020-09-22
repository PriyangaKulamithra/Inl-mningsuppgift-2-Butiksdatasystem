using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Inlämningsuppgift_2__Butiksdatasystem
{
    class Payment
    {
        private void SaveAllReceiptsToFile()
        {
            var todaysDate = DateTime.Now.ToString("yyyyMMdd");
            string filePathReceipts = $@"../../Receipts_{todaysDate}";
            Receipt AllReceiptsFromToday = new Receipt();
            using (StreamWriter sw = File.AppendText(filePathReceipts))
            {
                foreach (var line in AllReceiptsFromToday.GetAllReceiptsFromToday())
                {
                    sw.WriteLine(line);
                }
                sw.WriteLine("\n*****\n");
            }
        }
    }
}
