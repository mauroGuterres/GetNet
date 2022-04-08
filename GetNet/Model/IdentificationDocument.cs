using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Model
{
    public class IdentificationDocument
    {
        public string documentType { get; set; }
        public string document_type { get { return documentType; } set { documentType = value; } }

        public int documentNumber { get; set; }
        public int document_number { get { return documentNumber; } set { documentNumber = value; } }

        public DateTime documentIssueDate { get; set; }
        public DateTime document_issue_date { get { return documentIssueDate; } set { documentIssueDate = value; } }

        public string documentIssuer { get; set; }
        public string document_issuer { get { return documentIssuer; } set { documentIssuer = value; } }

        public string documentIssuerState { get; set; }
        public string document_issuer_state { get { return documentIssuerState; } set { documentIssuerState = value; } }

        public DateTime documentExpirationDate { get; set; }
        public DateTime document_expiration_date { get { return documentExpirationDate; } set { documentExpirationDate = value; } }

        public string documentSerialNumber { get; set; }
        public string document_serial_number { get { return documentSerialNumber; } set { documentSerialNumber = value; } }
    }
}
