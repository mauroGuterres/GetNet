using Guterres.Payment.GetNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Request
{
    public class CriarPreCadastroLojaPessoaFisicaRequest
    {
        public string merchantId { get; set; }
        public string merchant_id { get { return merchantId; } set { merchantId = value; } }

        public int legalDocumentNumber { get; set; }
        public int legal_document_number { get { return legalDocumentNumber; } set { legalDocumentNumber = value; } }

        public string legalName { get; set; }
        public string legal_name { get { return legalName; } set { legalName = value; } }

        public DateTime birthDate { get; set; }
        public DateTime birth_date { get { return birthDate; } set { birthDate = value; } }

        public string mothersName { get; set; }
        public string mothers_name { get { return mothersName; } set { mothersName = value; } }
        public string occupation { get; set; }

        public string subselleridExt { get; set; }
        public string subsellerid_ext { get { return subselleridExt; } set { subselleridExt = value; } }

        public int monthlyGrossIncome { get; set; }
        public int monthly_gross_income { get { return monthlyGrossIncome; } set { monthlyGrossIncome = value; } }

        public int grossEquity { get; set; }
        public int gross_equity { get { return grossEquity; } set { grossEquity = value; } }

        public BusinessAddress businessAddress { get; set; }
        public BusinessAddress business_address { get { return businessAddress; } set { businessAddress = value; } }

        public MailingAddress mailingAddress { get; set; }
        public MailingAddress mailing_address { get { return mailingAddress; } set { mailingAddress = value; } }
        public Phone phone { get; set; }
        public Phone cellphone { get; set; }
        public string email { get; set; }
        public BankAccounts bankAccounts { get; set; }
        public BankAccounts bank_accounts { get { return bankAccounts; } set { bankAccounts = value; } }

        public List<Commission> listCommissions { get; set; }
        public List<Commission> list_commissions { get { return listCommissions; } set { listCommissions = value; } }

        public string urlCallback { get; set; }
        public string url_callback { get { return urlCallback; } set { urlCallback = value; } }

        public int paymentPlan { get; set; }
        public int payment_plan { get { return paymentPlan; } set { paymentPlan = value; } }

        public string acceptedContract { get; set; }
        public string accepted_contract { get { return acceptedContract; } set { acceptedContract = value; } }

        public string marketplaceStore { get; set; }
        public string marketplace_store { get { return marketplaceStore; } set { marketplaceStore = value; } }

        public string automaticAnticipation { get; set; }
        public string automatic_anticipation { get { return automaticAnticipation; } set { automaticAnticipation = value; } }
    }
}
