using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Model
{
    public class Card
    {
        public string numberToken { get; set; }
        public string number_token { get { return numberToken; } set { numberToken = value; } }
        public string number { get; set; }
        public string expirationMonth { get; set; }
        public string expiration_month { get { return expirationMonth; } set { this.expirationMonth = value; } }
        public string expirationYear { get; set; }
        public string expiration_year { get { return expirationYear; } set { expirationYear = value; } }
        public string holderName { get; set; }
        public string holder_name { get { return holderName; } set { holderName = value; } }
        public string type { get; set; }
        public string type_card { get { return type; } set { type = value; } }
        public bool defaultCard { get; set; }
        public bool default_card { get { return defaultCard; } set { defaultCard = value; } }
    }
}
