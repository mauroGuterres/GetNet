using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Model
{
    public class Commission
    {
        public string brand { get; set; }
        public string brandId { get; set; }
        public string brand_id { get { return brandId; } set { brandId = value; } }

        public string product { get; set; }

        public string productId { get; set; }
        public string product_id { get { return productId; } set { productId = value; } }
        public int percent { get; set; }

        [JsonProperty("value")]
        public int valor { get; set; }

        public int paymentPlan { get; set; }
        public int payment_plan { get { return paymentPlan; } set { paymentPlan = value; } }

        public int commissionPercentage { get; set; }
        public int commission_percentage { get { return commissionPercentage; } set { commissionPercentage = value; } }

        public int commissionValue { get; set; }
        public int commission_value { get { return commissionValue; } set { commissionValue = value; } }
    }
}
