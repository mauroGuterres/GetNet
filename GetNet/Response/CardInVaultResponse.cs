using System;

/// <summary>
/// Descrição resumida de CardInVaultResponse
/// </summary>
/// 
namespace Guterres.Payment.GetNet.Response
{
    public class CardInVaultResponse
    {
        public string card_id { get; set; }
        public string last_four_digits { get; set; }
        public string expiration_month { get; set; }
        public string expiration_year { get; set; }
        public string brand { get; set; }
        public string cardholder_name { get; set; }
        public string customer_id { get; set; }
        public string number_token { get; set; }
        public DateTime used_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string status { get; set; }
    }
}
