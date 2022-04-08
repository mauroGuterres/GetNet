using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using Guterres.Payment.GetNet.DTO;
using Guterres.Payment.GetNet.Request;

using System.Net;
using Guterres.Payment.GetNet.Response;


/// <summary>
/// Descrição resumida de GetNetAuth
/// </summary>
/// 
namespace Guterres.Payment.GetNet
{
    public class GetNetAuth
    {
        private string keyBase64;
        private string base_api;
        private string seller_id;
        private GetNetToken token;
        private GetNetToken token3DS;
        public GetNetAuth(string keyBase64, string base_api, string seller_id)
        {
            this.keyBase64 = keyBase64;
            this.base_api = base_api;
            this.seller_id = seller_id;
        }

        /// <summary>
        /// Realiza a autenticação oAuth, capturando o token para uso posterior;        
        /// </summary>
        /// <returns>Objeto contendo token, data de expiração e tipo de autenticação (Ex: Bearer)</returns>
        public GetNetToken Oauth()
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("scope", "oob"));
            parameters.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            FormUrlEncodedContent FormContent = new FormUrlEncodedContent(parameters);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(base_api);
            client.DefaultRequestHeaders.Add("authorization", "Basic " + keyBase64);
            var result = client.PostAsync("/auth/oauth/v2/token", FormContent).Result;
            var token = JsonConvert.DeserializeObject<GetNetToken>(result.Content.ReadAsStringAsync().Result);
            token.dataExpiracao = DateTime.Now.AddSeconds(token.expires_in);
            this.token = token;
            return token;
        }

        /// <summary>
        /// Realiza autenticação 3DS
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Token 3DS para operações futuras</returns>
        public GetNetToken Auth3DS(Auth3DSRequest request)
        {
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            HttpClient client = new HttpClient(clientHandler);
            GetNetToken responseBody;

            var requestObj = new
            {
                client_code = request.client_code,
                currency = request.currency,
                items = request.items?.Select(x => new
                {
                    description = x.description,
                    name = x.name,
                    sku = x.sku,
                    quantity = x.quantity,
                    total_amount = x.total_amount,
                    unit_price = x.unit_price
                }).ToList(),
                js_version = request.js_version,
                order_number = request.order_number,
                override_payment_method = request.override_payment_method,
                total_amount = request.total_amount,
            };

            var requestBody = JsonConvert.SerializeObject(requestObj);

            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(base_api + "/v1/3ds/tokens"),
                Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
            };

            requestMessage.Headers.Add("Authorization", token.token_type + " " + token.access_token);
            requestMessage.Headers.Add("seller_id", seller_id);

            var response = client.SendAsync(requestMessage).Result;
            responseBody = JsonConvert.DeserializeObject<GetNetToken>(response.Content.ReadAsStringAsync().Result);
            this.token3DS = responseBody;

            return responseBody;
        }

        public AuthenticationsResponse SolicitaAutenticacao3DS(AuthenticationsRequest request)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            HttpClient client = new HttpClient(clientHandler);

            #region old
            var requestObj = new
            {
                customer_card_alias = request.paymentInformation.card.holderName,
                request.consumerAuthenticationInformation.override_payment_method,
                alternate_authentication_method = "02",
                authentication = new
                {
                    token = request.token,
                    //npa_code = request.authentication.npa_code,
                    //challenge_code = request.authentication.challenge_code,
                    //installment_total_amount = request.authentication.installment_total_count,
                    //message_category = request.authentication.message_category,
                    //transaction_mode = request.authentication.transaction_mode,
                    //device_channel = request.authentication.device_channel,
                    //acs_windows_size = request.authentication.acs_window_size
                },
                #region device
                /*device = new
                {
                    http_accept_browser_value = request.device.http_accept_browser_value,
                    http_accept_content = request.device.http_accept_content,
                    user_agent_browser_value = request.device.user_agent_browser_value,
                    http_browser_color_depth = request.device.http_browser_color_depth,
                    http_browser_java_enabled = request.device.http_browser_java_enabled,
                    http_browser_java_script_enabled = request.device.http_browser_java_script_enabled,
                    http_browser_language = request.device.http_browser_language,
                    http_browser_screen_height = request.device.http_browser_screen_height,
                    http_browser_screen_width = request.device.http_browser_screen_width,
                    http_browser_time_difference = request.device.http_browser_time_difference,
                    ip_address = request.device.ip_address
                },*/
                #endregion
                //costumer_risk_information = new
                //{
                //    transaction_count_year = request.costumer_risk_information.transaction_count_year,
                //    transaction_count_day = request.costumer_risk_information.transaction_count_day,
                //    add_card_attempts = request.costumer_risk_information.add_card_attempts,
                //    customer_id = request.costumer_risk_information.customer_id,
                //    customer_type_id = request.costumer_risk_information.customer_type_id,
                //    payment_account_history = request.costumer_risk_information.payment_account_history,
                //    payment_account_date = request.costumer_risk_information.payment_account_date,
                //    prior_suspicious_activity = request.costumer_risk_information.prior_suspicious_activity
                //},
                #region recurring
                /* recurring = new
                 {
                     end_date = request.recurring.end_date,
                     frequency = request.recurring.frequency,
                     original_purchase_date = request.recurring.original_purchase_date
                 },*/
                #endregion
                card = new {                    
                    request.payment_information.card.number_token,
                    request.payment_information.card.expiration_year,
                    request.payment_information.card.expiration_month,
                    request.payment_information.card.type_card,
                },
                order = new
                {
                    product_code = "01",
                    request.orderInformation.amountDetails.currency,
                    request.orderInformation.amountDetails.total_amount,
                    bill_to = new{
                        request.orderInformation.bill_to.first_name,
                        request.orderInformation.bill_to.last_name,                        
                        request.orderInformation.bill_to.mobile_phone,
                        request.orderInformation.bill_to.address1,
                        request.orderInformation.bill_to.address2,
                        request.orderInformation.bill_to.administrative_area,
                    },
            
                    items = request.orderInformation.items.Select(x => new
                    {
                        x.description,
                        x.name,
                        x.sku,
                        x.quantity,
                        x.total_amount,
                        x.unit_price
                    }).ToList(),
                    ship_to = new {
                        request.orderInformation.ship_to.address1,
                        request.orderInformation.ship_to.address2,
                        request.orderInformation.ship_to.administrative_area,
                        request.orderInformation.ship_to.country,
                        request.orderInformation.ship_to.destination_code,
                        request.orderInformation.ship_to.first_name,
                        request.orderInformation.ship_to.last_name,
                        request.orderInformation.shipTo.locality,
                        request.orderInformation.shipTo.postal_code
                    }
                }

            };
            #endregion
            var requestBody = JsonConvert.SerializeObject(requestObj);

            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(base_api + "/v1/3ds/authentications"),
                Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
            };

            requestMessage.Headers.Add("Authorization", token.token_type + " " + token.access_token);
            requestMessage.Headers.Add("seller_id", seller_id);
            var responseBody = new AuthenticationsResponse();
            try {
                var response = client.SendAsync(requestMessage).Result;
                responseBody = JsonConvert.DeserializeObject<AuthenticationsResponse>(response.Content.ReadAsStringAsync().Result);

                return responseBody;
            }
            catch (WebException ex) {
                var a = ex;
                var b = a;
            }            

            return responseBody;
            //return new Auth3DSAskedResponse();
        }

        

        public AuthenticationsResultsResponse SolicitaResultadoAutenticacao(AuthenticationsResultsRequest request) {
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            HttpClient client = new HttpClient(clientHandler);
            dynamic responseBody;

            var requestObj = new
            {
                currency = request.orderInformation.amountDetails.currency,
                override_payment_method = request.consumerAuthenticationInformation.override_payment_method.Replace("0",""),
                token = request.token,                
                request.orderInformation.amountDetails.total_amount,
                card = new
                {
                    number_token = request.paymentInformation.card.numberToken,
                    expiration_month = request.paymentInformation.card.expirationMonth,
                    expiration_year = request.paymentInformation.card.expirationYear,
                    type_card = request.paymentInformation.card.type,
                    default_card = request.paymentInformation.card.defaultCard
                },
                //additional_data = request.additionalData,
                //additional_object = request.additional_object

            };

            var requestBody = JsonConvert.SerializeObject(requestObj);

            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(base_api + "/v1/3ds/authentications/results"),
                Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
            };

            requestMessage.Headers.Add("Authorization", token.token_type + " " + token.access_token);
            requestMessage.Headers.Add("seller_id", seller_id);

            var response = client.SendAsync(requestMessage).Result;
            responseBody = JsonConvert.DeserializeObject<AuthenticationsResultsResponse>(response.Content.ReadAsStringAsync().Result);     

            
            return responseBody;
        }

        public PaymentAuthenticatedResponse AuthenticatedPayment(PaymentAuthenticatedRequest request)
        {
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            HttpClient client = new HttpClient(clientHandler);
            dynamic responseBody;

            var requestObj = new
            {
                order_id = "10",
                //currency = request.result.currency,
                payment_method = "CREDIT",
                amount = "100",
                number_installments = "1",
                transaction_type = "FULL",
                xid = request.consumer_authentication_information.xid,
                ucaf = request.consumer_authentication_information.ucaf,
                eci = request.consumer_authentication_information.eci,
                //tdsdsxid = request.consumer_authentication_information.tdsdsxid,
                tdsver = "2.1.0",
                //dynamic_mcc = "1799",
                //soft_descriptor = request.soft_descriptor,
                customer_id = request.client_reference_information.code,
                //credentials_on_file_type = request.credentials_on_file_type,
                //TODO: Confirmar de onde vem as informações abaixo.
                card = new
                {
                    number_token = request.card.number_token ,
                    cardholder_name = "Mauro Guterres",
                    expiration_month = "01",
                    expiration_year = "25",
                    brand = "Mastercard",
                    
                    //security_code = "123",
                    /*expiration_month = request.card.expiration_month,
                    expiration_year = request.card.expiration_year,
                    */
                },                

            };

            var requestBody = JsonConvert.SerializeObject(requestObj);

            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(base_api + "/v1/payments/authenticated"),
                Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
            };

            requestMessage.Headers.Add("Authorization", token.token_type + " " + token.access_token);
            requestMessage.Headers.Add("seller_id", seller_id);

            var response = client.SendAsync(requestMessage).Result;
            responseBody = JsonConvert.DeserializeObject<PaymentAuthenticatedResponse>(response.Content.ReadAsStringAsync().Result);
            
            return responseBody;
        }

    }
}
