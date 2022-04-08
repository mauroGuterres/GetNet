using Guterres.Payment.GetNet.Model;
using System;


namespace Guterres.Payment.GetNet.Request
{
    public class AuthenticationsResponse
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

        public ErrorInformation errorInformation { get; set; }
        public ErrorInformation error_information { get { return errorInformation; } set { errorInformation = value; } }

        public string referenceId { get; set; }
        public string reference_id { get { return referenceId; } set { referenceId = value; } }

        public string orgUnitId { get;  set; }
        public string org_unit_id { get { return orgUnitId; } set { orgUnitId = value; } }
        public long sendDsDate { get; set; }
        public long send_ds_date { get { return sendDsDate; } set { sendDsDate = value; } }
        public long recDsDate { get; set; }
        public long rec_ds_date { get { return recDsDate; } set { recDsDate = value; } }
    }
}
