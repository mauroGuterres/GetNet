using Guterres.Payment.GetNet.Model;
using System;
using System.Collections.Generic;


namespace Guterres.Payment.GetNet.Response
{
    public class ConsultaComplementoCadastralCPFResponse
    {
        public int subsellerId { get; set; }
        public int subseller_id { get { return subsellerId; } set { subsellerId = value; } }

        public string subselleridExt { get; set; }
        public string subsellerid_ext { get { return subselleridExt; } set { subselleridExt = value; } }
        public int legalDocumentNumber { get; set; }
        public int legal_document_number { get { return legalDocumentNumber; } set { legalDocumentNumber = value; } }
        public string fiscalType { get; set; }
        public string fiscal_type { get { return fiscalType; } set { fiscalType = value; } }
        public string enabled { get; set; }
        public string status { get; set; }
        public int paymentPlan { get; set; }
        public int payment_plan { get { return paymentPlan; } set { paymentPlan = value; } }

        public string capturePaymentsEnabled { get; set; }
        public string capture_payments_enabled { get { return capturePaymentsEnabled; } set { capturePaymentsEnabled = value; } }
        public string anticipationEnabled { get; set; }
        public string anticipation_enabled { get { return anticipationEnabled; } set { anticipationEnabled = value; } }

        public string automaticAnticipation { get; set; }
        public string automatic_anticipation { get { return automaticAnticipation; } set { automaticAnticipation = value; } }

        public string acceptedContract { get; set; }
        public string accepted_contract { get { return acceptedContract; } set { acceptedContract = value; } }

        public List<BankAccount> bankAccounts { get; set; }
        public List<BankAccount> bank_accounts { get { return bankAccounts; } set { bankAccounts = value; } }

        public List<Commission> listCommissions { get; set; }
        public List<Commission> list_commissions { get { return listCommissions; } set { listCommissions = value; } }

        public DateTime lockSchedule { get; set; }
        public DateTime lock_schedule { get { return lockSchedule; } set { lockSchedule = value; } }

        public DateTime lockCapturePayments { get; set; }
        public DateTime lock_capture_payments { get { return lockCapturePayments; } set { lockCapturePayments = value; } }

        public DateTime createDate { get; set; }
        public DateTime create_date { get { return createDate; } set { createDate = value; } }
    }
}
