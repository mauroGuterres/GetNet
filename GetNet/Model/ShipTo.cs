using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Model
{
    public class ShipTo
    {
        public string firstName { get; set; }
        public string first_name { get { return this.firstName; } set { this.firstName = value; } }
        public string lastName { get; set; }

        public string last_name { get { return this.lastName; } set { this.lastName = value; } }
        public string locality { get; set; }
        public string administrativeArea { get; set; }
        public string administrative_area { get { return administrativeArea; } set { administrativeArea = value; } }
        public string country { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string postalCode { get; set; }
        public string postal_code { get { return postalCode; } set { postalCode = value; } }
        public object method { get; set; }
        public string destinationCode { get; set; }
        public string destination_code { get { return destinationCode; } set { destinationCode = value; } }
    }
}
