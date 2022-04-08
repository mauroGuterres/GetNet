using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Model
{
    public class BillTo
    {
        public string firstName { get; set; }
        public string first_name { get { return this.firstName; } set { this.firstName = value; } }
        public string lastName { get; set; }
        public string last_name { get { return this.lastName; } set { this.lastName = value; } }
        public string email { get; set; }
        public string locality { get; set; }
        public string administrativeArea { get; set; }
        public string administrative_area { get { return administrativeArea; } set { administrativeArea = value; } }
        public string country { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string postalCode { get; set; }
        public string homePhone { get; set; }
        public string home_phone { get { return homePhone; } set { homePhone = value; } }
        public string mobilePhone { get; set; }
        public string mobile_phone { get { return mobilePhone; } set { mobilePhone = value; } }
    }
}
