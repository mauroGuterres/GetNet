using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de InsertCardInVaultRequest
/// </summary>
/// 
namespace Guterres.Payment.GetNet.Request
{    
    public class InsertCardInVaultRequest
    {
        public InsertCardInVaultRequest()
        {
            
        }

        public string Number_Token { get; set; }
        public string Brand { get; set; }
        public string CardHolder_Name { get; set; }
        public string Expiration_Month { get; set; }
        public string Expiration_Year { get; set; }
        public string CardHolder_Identification { get; set; }
        public string Security_Code { get; set; }
        public string Customer_Id { get; set; }
    }
}
