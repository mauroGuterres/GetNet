using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Model
{
    public class BankAccounts
    {

        public string typeAccounts { get; set; }
        public string type_accounts { get { return typeAccounts; } set { typeAccounts = value; } }

        public BankAccount uniqueAccount { get; set; }
        public BankAccount unique_account { get { return uniqueAccount; } set { uniqueAccount = value; } }

        public List<BankAccount> customAccounts { get; set; }
        public List<BankAccount> custom_accounts { get { return customAccounts; } set { customAccounts = value; } }
    }
}
