using Guterres.Payment.GetNet.Model;
using System.Collections.Generic;


/// <summary>
/// Descrição resumida de Auth3DSRequest
/// </summary>
/// 
namespace Guterres.Payment.GetNet.Request
{
    public class Auth3DSRequest
    {
        public string client_code { get; set; }
        public string currency { get; set; }
        public List<Item> items { get; set; }
        public string js_version { get; set; }
        public string order_number { get; set; }
        public string override_payment_method { get; set; }
        public int total_amount { get; set; }        
    }

    /*public class Item
    {
        public string description { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public int quantity { get; set; }
        public double total_amount { get; set; }
        public double unit_price { get; set; }
    }*/
}
