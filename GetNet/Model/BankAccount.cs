using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Model
{
    public class BankAccount
    {
        public string brand { get; set; }
        public int bank { get; set; }
        public int agency { get; set; }
        public string agencyDigit { get; set; }
        public string agency_digit { get { return agencyDigit; } set { agencyDigit = value; } }
        public int account { get; set; }

        public string accountType { get; set; }
        public string account_type { get { return accountType; } set { accountType = value; } }
        public string accountDigit { get; set; }
        public string account_digit { get { return accountDigit; } set { accountDigit = value; } }
    }
}
