using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet.Model
{
    public class ConsumerAuthenticationInformation
    {

        public string acsUrl { get; set; }
        public string acs_url { get { return acsUrl; } set { this.acsUrl = value; } }

        public string authenticationPath { get; set; }
        public string authentication_path { get { return this.authenticationPath; } set { this.authenticationPath = value; } }
        public string authenticationTransactionId { get; set; }
        public string authentication_transaction_id { get { return this.authenticationTransactionId; } set { this.authenticationTransactionId = value; } }
        public string pareq { get; set; }
        public string overridePaymentMethod { get; set; }
        public string override_payment_method { get { return this.overridePaymentMethod; } set { this.overridePaymentMethod = value; } }

        public string proofXml { get; set; }
        public string proof_xml { get { return this.proofXml; } set { this.proofXml = value; } }
        public int proxyPan { get; set; }
        public int proxy_pan { get { return this.proxyPan; } set { this.proxyPan = value; } }

        public string specificationVersion { get; set; }
        public string specification_version { get { return this.specificationVersion; } set { this.specificationVersion = value; } }
        public string veresEnrolled { get; set; }
        public string veres_enrolled { get { return this.veresEnrolled; } set { this.veresEnrolled = value; } }
        public string installmentTotalCount { get; set; }
        public string installment_total_count { get { return this.installmentTotalCount; } set { this.installmentTotalCount = value; } }
        public string xid { get; set; }
        public string token { get; set; }


        public string authenticationResult { get; set; }
        public string authentication_result { get { return authenticationResult; } set { this.authenticationResult = value; } }

        public string authenticationStatusMsg { get; set; }
        public string authentication_status_msg { get { return authenticationStatusMsg; } set { authenticationStatusMsg = value; } }
        public string indicator { get; set; }
        public string eci { get; set; }

        public string paresStatus { get; set; }
        public string pares_status { get { return paresStatus; } set { paresStatus = value; } }

        public string cavvAlgorithm { get; set; }
        public string cavv_algorithm { get { return cavvAlgorithm; } set { cavvAlgorithm = value; } }
        public string ucaf { get; set; }
        public string ucafAuthenticationData { get; set; }
        public string ucaf_authentication_data { get { return ucafAuthenticationData; } set { ucafAuthenticationData = value; } }

        public string ucafCollectionIndicator { get; set; }
        public string ucaf_collection_indicator { get { return ucafCollectionIndicator; } set { ucafCollectionIndicator = value; } }
        public string cavv { get; set; }
    }
}
