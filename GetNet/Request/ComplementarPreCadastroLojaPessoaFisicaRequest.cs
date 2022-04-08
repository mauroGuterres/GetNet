using Guterres.Payment.GetNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Request
{
    public class ComplementarPreCadastroLojaPessoaFisicaRequest
    {

        public string merchantId { get; set; }
        public string merchant_id { get { return merchantId; } set { merchantId = value; } }

        public int subsellerId { get; set; }
        public int subseller_id { get { return subsellerId; } set { subsellerId = value; } }

        public int legalDocumentNumber { get; set; }
        public int legal_document_number { get { return legalDocumentNumber; } set { legalDocumentNumber = value; } }

        public string legalName { get; set; }
        public string legal_name { get { return legalName; } set { legalName = value; } }
        public DateTime date { get; set; }
        public string email { get; set; }
        public Phone phone { get; set; }
        public Phone cellphone { get; set; }

        public BusinessAddress businessAddress { get; set; }
        public BusinessAddress business_address { get { return businessAddress; } set { businessAddress = value; } }

        public MailingAddress residentialAddress { get; set; }
        public MailingAddress residential_address { get { return residentialAddress; } set { residentialAddress = value; } }

        public IdentificationDocument identificationDocument { get; set; }
        public IdentificationDocument identification_document { get { return identificationDocument; } set { identificationDocument = value; } }

        public BankAccounts bankAccounts { get; set; }
        public BankAccounts bank_accounts { get { return bankAccounts; } set { bankAccounts = value; } }

        public List<Commission> listCommissions { get; set; }
        public List<Commission> list_commissions { get { return listCommissions; } set { listCommissions = value; } }

        public string urlCallback { get; set; }
        public string url_callback { get { return urlCallback; } set { urlCallback = value; } }

        public int paymentPlan { get; set; }
        public int payment_plan { get { return paymentPlan; } set { paymentPlan = value; } }

        public string marketplaceStore { get; set; }
        public string marketplace_store { get { return marketplaceStore; } set { marketplaceStore = value; } }
        public string sex { get; set; }
        public string nationality { get; set; }

        public string mothersName { get; set; }
        public string mothers_name { get { return mothersName; } set { mothersName = value; } }

        public string fathersName { get; set; }
        public string fathers_name { get { return fathersName; } set { fathersName = value; } }

        public string birthCity { get; set; }
        public string birth_city { get { return birthCity; } set { birthCity = value; } }

        public string birthState { get; set; }
        public string birth_state { get { return birthState; } set { birthState = value; } }
        public string occupation { get; set; }

        public int monthlyIncome { get; set; }
        public int monthly_income { get { return monthlyIncome; } set { monthlyIncome = value; } }

        public string ppeIndication { get; set; }
        public string ppe_indication { get { return ppeIndication; } set { ppeIndication = value; } }

        public string ppeDescription { get; set; }
        public string ppe_description { get { return ppeDescription; } set { ppeDescription = value; } }
        public int patrimony { get; set; }
    }
}
