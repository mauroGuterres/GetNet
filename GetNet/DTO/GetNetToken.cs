using System;


/// <summary>
/// Descrição resumida de GetNetToken
/// </summary>
/// 
namespace Guterres.Payment.GetNet.DTO
{
    public class GetNetToken
    {

        public string accessToken { get; set; }
        public string access_token { get { return this.accessToken; } set { this.accessToken = value; } }
        public string tokenType { get; set; }
        public string token_type { get { return this.tokenType; } set { this.tokenType = value; } }
        public string scope { get; set; }
        public int expires_in { get { return this.expiresIn; } set { this.expiresIn = value; } }
        public int expiresIn { get; set; }
        public DateTime dataExpiracao { get; set; }
        public DateTime data_expiracao { get { return dataExpiracao; } set { this.dataExpiracao = value; } }

        public DateTime expirationDate { get; set; }
        public DateTime expiration_date { get { return this.expirationDate; } set { this.expirationDate = value; } }
    }
}
