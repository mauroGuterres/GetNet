using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Model
{
    public class Phone
    {
        public int areaCode { get; set; }
        public int area_code { get { return areaCode; } set { areaCode = value; } }

        public int phoneNumber { get; set; }
        public int phone_number { get { return phoneNumber; } set { phoneNumber = value; } }
    }
}
