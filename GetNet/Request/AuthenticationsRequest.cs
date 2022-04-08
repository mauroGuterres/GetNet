using Guterres.Payment.GetNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Request
{
    public class AuthenticationsRequest
    {
        public string token { get; set; }
        public OrderInformation orderInformation { get; set; }
        public OrderInformation order_information { get { return orderInformation; } set { this.orderInformation = value; } }
        public PaymentInformation paymentInformation { get; set; }
        public PaymentInformation payment_information { get { return paymentInformation; } set { this.paymentInformation = value; } }
        public PersonalIdentification personalIdentification { get; set; }
        public PersonalIdentification personal_identification { get { return personalIdentification; } set { personalIdentification = value; } }
        public ConsumerAuthenticationInformation consumerAuthenticationInformation { get; set; }
        public ConsumerAuthenticationInformation consumer_authentication_information { get { return consumerAuthenticationInformation; } set { this.consumerAuthenticationInformation = value; } }
        public string additionalData { get; set; }
        public string additional_data { get { return additionalData; } set { additionalData = value; } }
        public object additionalObject { get; set; }
        public object additional_object { get { return additionalObject; } set { additionalObject = value; } }
    }
}
