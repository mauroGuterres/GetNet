using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Model
{
    public class MailingAddress
    {
        public string street { get; set; }
        public int number { get; set; }
        public string district { get; set; }
        public string city { get; set; }
        public string state { get; set; }

        public int postalCode { get; set; }
        public int postal_code { get { return postalCode; } set { postalCode = value; } }
        public string suite { get; set; }
    }
}
