using Guterres.Payment.GetNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Request
{
    public class AuthenticationsResultsRequest
    {
        public string token { get; set; }
        public OrderInformation orderInformation { get; set; }
        public ConsumerAuthenticationInformation consumerAuthenticationInformation { get; set; }
        public PaymentInformation paymentInformation { get; set; }
        public string additionalData { get; set; }
        public object additionalObject { get; set; }
    }
}
