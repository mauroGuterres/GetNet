using Guterres.Payment.GetNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Request
{
    public class PaymentAuthenticatedRequest
    {
        public Card card { get; set; }
        public ClientReferenceInformation clientReferenceInformation { get; set; }
        public ClientReferenceInformation client_reference_information { get { return clientReferenceInformation; } set { clientReferenceInformation = value; } }
        public ConsumerAuthenticationInformation consumerAuthenticationInformation { get; set; }
        public ConsumerAuthenticationInformation consumer_authentication_information { get { return consumerAuthenticationInformation; } set { consumerAuthenticationInformation = value; } }
        public string id { get; set; }
        public long recDsDate { get; set; }
        public long rec_ds_date { get { return recDsDate; } set { recDsDate = value; } }
        public long send_ds_date { get { return sendDsDate; } set { sendDsDate = value; } }
        public long sendDsDate { get; set; }
        public DateTime submitTimeUtc { get; set; }
        public DateTime submit_time_utc { get { return submitTimeUtc; } set { submitTimeUtc = value; } }
        public string status { get; set; }

        

    }
}
