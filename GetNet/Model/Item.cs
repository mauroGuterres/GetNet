using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Model
{
    public class Item
    {
        public string name { get; set; }
        public string description { get; set; }
        public string sku { get; set; }
        public string quantity { get; set; }
        public string unitPrice { get; set; }
        public string unit_price { get { return this.unitPrice; } set { this.unitPrice = value; } }
        public string totalAmount { get; set; }
        public string total_amount { get { return this.totalAmount; } set { this.totalAmount = value; } }
    }
}
