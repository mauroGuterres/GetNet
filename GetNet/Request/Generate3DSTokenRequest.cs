using Guterres.Payment.GetNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Request
{
        
    public class Generate3DSTokenRequest
    {
        public string version { get; set; }
        public string totalAmount { get; set; }
        public string total_amount { get { return this.totalAmount; } set { this.totalAmount = value; } }
        public ConsumerAuthenticationInformation consumerAuthenticationInformation { get; set; }
        public ConsumerAuthenticationInformation consumer_authentication_information { get { return this.consumerAuthenticationInformation; } set { this.consumerAuthenticationInformation = value; } }
        public List<Item> items { get; set; }
        public string additionalData { get; set; }
        public string additional_data { get { return this.additionalData; } set { this.additionalData = value; } }
        public object additionalObject { get; set; }
        public object additional_object { get { return this.additionalObject; } set { this.additionalObject = value; } }
    }
   
}
