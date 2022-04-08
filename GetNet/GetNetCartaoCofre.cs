using Guterres.Payment.GetNet.Request;
using Guterres.Payment.GetNet.Response;
using Guterres.Payment.GetNet.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

/// <summary>
/// Descrição resumida de GetNetCartaoCofre
/// </summary>
/// 
namespace Guterres.Payment.GetNet
{
    public class GetNetCartaoCofre
    {
        private string seller_id;
        private string base_api;
        private GetNetToken token;

        public GetNetCartaoCofre(string base_api, string seller_id, GetNetToken token)
        {
            this.base_api = base_api;
            this.seller_id = seller_id;
            this.token = token;
        }

        /// <summary>
        /// Faz a tokenização do cartão para uso em transações
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="customerId"></param>
        /// <returns>cartão tokenizado</returns>
        public string TransformaCartaoEmToken(TokenizeCardRequest request)
        {

            string cardTokenized;
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            HttpClient client = new HttpClient(clientHandler);

                var requestObj = new
                {
                    card_number = request.Card_Number,
                    customer_id = request.Customer_Id
                };

                var requestBody = JsonConvert.SerializeObject(requestObj);

                var requestMessage = new HttpRequestMessage()
                {
                    Method = new HttpMethod("POST"),
                    RequestUri = new Uri(base_api + "/v1/tokens/card"),
                    Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
                };

                requestMessage.Headers.Add("Authorization", token.token_type + " " + token.access_token);
                requestMessage.Headers.Add("seller_id", seller_id);

                var response = client.SendAsync(requestMessage).Result;

                var responseBody = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);

                cardTokenized = responseBody.number_token;                                                        
            

            return cardTokenized;

        }


        /// <summary>
        /// Insere cartão no cofre GetNet
        /// </summary>
        /// <param name="request"></param>
        /// <returns>card_id do cartão inserido</returns>
        public CardInVaultResponse InsereCartaoNoCofre(InsertCardInVaultRequest request)
        {
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            HttpClient client = new HttpClient(clientHandler);
            dynamic responseBody;
            
                var requestObj = new
                {
                    number_token = request.Number_Token,
                    brand = request.Brand,
                    cardholder_name = request.CardHolder_Name,
                    expiration_month = request.Expiration_Month,
                    expiration_year = request.Expiration_Year,
                    cardholder_identification = request.CardHolder_Identification,
                    security_code = request.Security_Code,
                    customer_id = request.Customer_Id
                };

                var requestBody = JsonConvert.SerializeObject(requestObj);

                var requestMessage = new HttpRequestMessage()
                {
                    Method = new HttpMethod("POST"),
                    RequestUri = new Uri(base_api + "/v1/cards"),
                    Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
                };

                requestMessage.Headers.Add("Authorization", token.token_type + " " + token.access_token);
                requestMessage.Headers.Add("seller_id", seller_id);

                var response = client.SendAsync(requestMessage).Result;
                responseBody = JsonConvert.DeserializeObject<CardInVaultResponse>(response.Content.ReadAsStringAsync().Result);
            
            
            return responseBody;
        }

        /// <summary>
        /// Lista cartões existentes no cofre GetNet
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="customerId"></param>
        /// <returns>Lista de cartões</returns>
        public List<CardInVaultResponse> ListaCartoesDoCofre(string Customer_Id, StatusCartao status) {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            HttpClient client = new HttpClient(clientHandler);
            List<CardInVaultResponse> responseBody;
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("customer_id", Customer_Id));
            parameters.Add(new KeyValuePair<string, string>("status", status.GetStringValue()));
            FormUrlEncodedContent FormContent = new FormUrlEncodedContent(parameters);
            var requestObj = new
            {
                customer_id = Customer_Id,
                status = status.GetStringValue()
            };            

            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri(base_api + "/v1/cards?customer_id=" + Customer_Id),
                //Content = FormContent
            };

            requestMessage.Headers.Add("Authorization", token.token_type + " " + token.access_token);
            requestMessage.Headers.Add("seller_id", seller_id);

           /* client.DefaultRequestHeaders.Add("Authorization", token.Token_Type + " " + token.Access_Token);
            client.DefaultRequestHeaders.Add("seller_id", seller_id);*/
            var response = client.SendAsync(requestMessage).Result;
            responseBody = JsonConvert.DeserializeObject<List<CardInVaultResponse>>(response.Content.ReadAsStringAsync().Result);

            return responseBody;
        }

        /// <summary>
        /// Recupera cartão existente no cofre GetNet
        /// </summary>
        /// <param name="card_id"></param>
        /// <returns>Cartão encontrado no cofre com o card_id informado</returns>
        public CardInVaultResponse RecuperaCartaoDoCofre(string card_id)
        {
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            HttpClient client = new HttpClient(clientHandler);
            dynamic responseBody;
                        
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri(base_api + "/v1/cards/" + card_id)                
            };

            requestMessage.Headers.Add("Authorization", token.token_type + " " + token.access_token);
            requestMessage.Headers.Add("seller_id", seller_id);

            var response = client.SendAsync(requestMessage).Result;
            responseBody = JsonConvert.DeserializeObject<CardInVaultResponse>(response.Content.ReadAsStringAsync().Result);

            return responseBody;
        }

        /// <summary>
        /// Exclui cartão existente no cofre
        /// </summary>
        /// <param name="card_id"></param>        
        public void ExcluiCartaoDoCofre(string card_id)
        {
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            HttpClient client = new HttpClient(clientHandler);
            dynamic responseBody;

            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("DELETE"),
                RequestUri = new Uri(base_api + "/v1/cards/" + card_id)
            };

            requestMessage.Headers.Add("Authorization", token.token_type + " " + token.access_token);
            requestMessage.Headers.Add("seller_id", seller_id);

            var response = client.SendAsync(requestMessage).Result;
            responseBody = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);            
        }
    }
}
