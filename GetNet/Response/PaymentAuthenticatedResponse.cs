using Guterres.Payment.GetNet.Model;
using System;


namespace Guterres.Payment.GetNet.Request
{
    public class PaymentAuthenticatedResponse
    {
        public Card card { get; set; }
        public string id { get; set; }

        public DateTime submitTimeUtc { get; set; }
        public DateTime submit_time_utc { get { return submitTimeUtc; } set { submitTimeUtc = value; } }
        public string status { get; set; }

        public ClientReferenceInformation clientReferenceInformation { get; set; }
        public ClientReferenceInformation client_reference_information { get { return clientReferenceInformation; } set { clientReferenceInformation = value; } }

        public ConsumerAuthenticationInformation consumerAuthenticationInformation { get; set; }
        public ConsumerAuthenticationInformation consumer_authentication_information { get { return consumerAuthenticationInformation; } set { consumerAuthenticationInformation = value; } }

        public long sendDsDate { get; set; }
        public long send_ds_date { get { return sendDsDate; } set { sendDsDate = value; } }
        public long recDsDate { get; set; }
        public long rec_ds_date { get { return recDsDate; } set { recDsDate = value; } }
    }
}
