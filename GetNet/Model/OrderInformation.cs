using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Model
{
    public class OrderInformation
    {
        public AmountDetails amountDetails { get; set; }
        public AmountDetails amount_details { get { return amountDetails; } set { this.amountDetails = value; } }
        public ShipTo shipTo { get; set; }
        public ShipTo ship_to { get { return shipTo; } set { shipTo = value; } }
        public BillTo billTo { get; set; }
        public BillTo bill_to { get { return billTo; } set { billTo = value; } }
        public List<Item> items { get; set; }
    }
}
