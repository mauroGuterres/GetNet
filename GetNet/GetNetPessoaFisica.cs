
using Guterres.Payment.GetNet.DTO;
using Guterres.Payment.GetNet.Model;
using Guterres.Payment.GetNet.Request;
using Guterres.Payment.GetNet.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Guterres.Payment.GetNet
{
    public class GetNetPessoaFisica
    {

        private string base_api;
        private GetNetToken token;
        public GetNetPessoaFisica(string base_api, GetNetToken token) {
            this.base_api = base_api;
            this.token = token;
        }

        public ConsultaComplementoCadastralCPFResponse ConsultaComplementoCadastral(string merchant_id, string cpf) {
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            HttpClient client = new HttpClient(clientHandler);
            dynamic responseBody;

            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri(base_api + "/v1/mgm/pf/consult/" + merchant_id + "/" + cpf)
            };
            //TODO: Confirmar informação do token.
            requestMessage.Headers.Add("Authorization", token.token_type + " " + token.access_token);            

            var response = client.SendAsync(requestMessage).Result;
            responseBody = JsonConvert.DeserializeObject<ConsultaComplementoCadastralCPFResponse>(response.Content.ReadAsStringAsync().Result);

            return responseBody;
        }

        public ConsultaPlanosPagamentoMarketPlaceResponse ConsultaPlanosPagamentoMarketPlace(string merchant_id)
        {
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            HttpClient client = new HttpClient(clientHandler);
            dynamic responseBody;

            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri(base_api + "/v1/mgm/pf/consult/paymentPlans/" + merchant_id)
            };
            //TODO: Confirmar informação do token.
            requestMessage.Headers.Add("Authorization", token.token_type + " " + token.access_token);

            var response = client.SendAsync(requestMessage).Result;
            responseBody = JsonConvert.DeserializeObject<List<ConsultaPlanosPagamentoMarketPlaceResponse>>(response.Content.ReadAsStringAsync().Result);

            return responseBody;
        }

        public CriarPreCadastroLojaPessoaFisicaResponse CriarPreCadastroLojaPessoaFisica(CriarPreCadastroLojaPessoaFisicaRequest request)
        {
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            HttpClient client = new HttpClient(clientHandler);
            dynamic responseBody;

            var requestObj = new
            {
                request.merchant_id,
                request.legal_document_number,
                request.legal_name,
                request.birth_date,
                request.mothers_name,
                request.occupation,
                request.subsellerid_ext,
                request.monthly_gross_income,
                request.gross_equity,
                business_address = new {
                    request.business_address.mailing_address_equals,
                    request.business_address.street,
                    request.business_address.number,
                    request.business_address.district,
                    request.business_address.city,
                    request.business_address.state,
                    request.business_address.postal_code,
                    request.business_address.suite
                },
                mailling_address = new {
                    request.mailing_address.street,
                    request.mailing_address.number,
                    request.mailing_address.district,
                    request.mailing_address.city,
                    request.mailing_address.state,
                    request.mailing_address.postal_code,
                    request.mailing_address.suite
                },
                phone = new {
                    request.phone.area_code,
                    request.phone.phone_number
                },
                cellphone = new {
                    request.cellphone.area_code,
                    request.cellphone.phone_number,
                },
                bank_accounts = new {
                    request.bank_accounts.type_accounts,
                    request.bank_accounts.unique_account,
                    custom_accounts = request.bank_accounts.custom_accounts.Select(x => new {
                        x.brand,
                        x.account_type,
                        x.bank,
                        x.agency,
                        x.account,
                        x.account_digit
                    }).ToList()
                },
                list_comissions = request.list_commissions.Select(x => new {
                    x.brand,
                    x.product,
                    x.payment_plan,
                    x.commission_percentage,
                    x.commission_value
                }).ToList(),
                request.url_callback,
                request.payment_plan,
                request.accepted_contract,
                request.marketplace_store,
                request.automatic_anticipation
            };

            var requestBody = JsonConvert.SerializeObject(requestObj);

            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(base_api + "/v1/mgm/pf/create-presubseller/"),
                Content = new StringContent(requestBody,Encoding.UTF8,"application/json")
            };
            //TODO: Confirmar informação do token.
            requestMessage.Headers.Add("Authorization", token.token_type + " " + token.access_token);

            var response = client.SendAsync(requestMessage).Result;
            responseBody = JsonConvert.DeserializeObject<CriarPreCadastroLojaPessoaFisicaResponse>(response.Content.ReadAsStringAsync().Result);

            return responseBody;
        }

        public CriarPreCadastroLojaPessoaFisicaResponse ComplementarPreCadastroLojaPessoaFisica(ComplementarPreCadastroLojaPessoaFisicaRequest request)
        {
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            HttpClient client = new HttpClient(clientHandler);
            dynamic responseBody;

            var requestObj = new
            {
                request.merchant_id,
                request.subseller_id,
                request.legal_document_number,
                request.legal_name,
                request.date,
                request.email,                                                            
                business_address = new
                {                    
                    request.business_address.street,
                    request.business_address.number,
                    request.business_address.district,
                    request.business_address.city,
                    request.business_address.state,
                    request.business_address.postal_code,
                    request.business_address.suite
                },
                residential_address = new
                {
                    request.residential_address.street,
                    request.residential_address.number,
                    request.residential_address.district,
                    request.residential_address.city,
                    request.residential_address.state,
                    request.residential_address.postal_code,
                    request.residential_address.suite
                },
                phone = new
                {
                    request.phone.area_code,
                    request.phone.phone_number
                },
                cellphone = new
                {
                    request.cellphone.area_code,
                    request.cellphone.phone_number,
                },
                identification_document = new {
                    request.identification_document.document_type,
                    request.identification_document.document_number,
                    request.identification_document.document_issue_date,
                    request.identification_document.document_issuer,
                    request.identification_document.document_issuer_state,
                    request.identification_document.document_expiration_date,
                    request.identification_document.document_serial_number
                },
                bank_accounts = new
                {
                    request.bank_accounts.type_accounts,
                    request.bank_accounts.unique_account,
                    custom_accounts = request.bank_accounts.custom_accounts.Select(x => new {
                        x.brand,
                        x.account_type,
                        x.bank,
                        x.agency,
                        x.account,
                        x.account_digit
                    }).ToList()
                },
                list_comissions = request.list_commissions.Select(x => new {
                    x.brand,
                    x.product,
                    x.payment_plan,
                    x.commission_percentage,
                    x.commission_value
                }).ToList(),
                request.url_callback,
                request.payment_plan,                
                request.marketplace_store,
                request.sex,
                request.nationality,
                request.mothers_name,
                request.fathers_name,
                request.birth_city,
                request.birth_state,
                request.occupation,
                request.monthly_income,
                request.ppe_indication,
                request.ppe_description,
                request.patrimony

            };

            var requestBody = JsonConvert.SerializeObject(requestObj);

            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("PUT"),
                RequestUri = new Uri(base_api + "/v1/mgm/pf/complement/"),
                Content = new StringContent(requestBody, Encoding.UTF8,"application/json")
            };
            //TODO: Confirmar informação do token.
            requestMessage.Headers.Add("Authorization", token.token_type + " " + token.access_token);

            var response = client.SendAsync(requestMessage).Result;
            responseBody = JsonConvert.DeserializeObject<CriarPreCadastroLojaPessoaFisicaResponse>(response.Content.ReadAsStringAsync().Result);

            return responseBody;
        }

        public dynamic DescredenciarLoja(string merchant_id, string subseller_id)
        {
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            HttpClient client = new HttpClient(clientHandler);
            dynamic responseBody;

            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(base_api + "/v1/mgm/pf/de-accredit/" + merchant_id + "/" + subseller_id)
            };
            //TODO: Confirmar informação do token.
            requestMessage.Headers.Add("Authorization", token.token_type + " " + token.access_token);

            var response = client.SendAsync(requestMessage).Result;
            responseBody = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);

            return responseBody;
        }

        public CriarPreCadastroLojaPessoaFisicaResponse AtualizaCadastroLojaPessoaFisica(AtualizarCadastroLojaPessoaFisicaRequest request)
        {
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            HttpClient client = new HttpClient(clientHandler);
            dynamic responseBody;

            var requestObj = new
            {
                request.merchant_id,
                request.subseller_id,
                request.sex,
                request.legal_document_number,
                request.legal_name,
                request.birth_date,
                request.birth_city,
                request.birthState,
                request.mothers_name,
                request.fathers_name,
                request.occupation,
                request.subsellerid_ext,
                request.monthly_gross_income,
                request.gross_equity,
                request.nationality,
                request.naturalized,
                business_address = new
                {                    
                    request.business_address.street,
                    request.business_address.number,
                    request.business_address.district,
                    request.business_address.city,
                    request.business_address.state,
                    request.business_address.postal_code,
                    request.business_address.suite
                },
                residential_address = new
                {
                    request.residential_address.street,
                    request.residential_address.number,
                    request.residential_address.district,
                    request.residential_address.city,
                    request.residential_address.state,
                    request.residential_address.postal_code,
                    request.residential_address.suite
                },
                identification_document = new
                {
                    request.identification_document.document_type,
                    request.identification_document.document_number,
                    request.identification_document.document_issue_date,
                    request.identification_document.document_issuer,
                    request.identification_document.document_issuer_state,
                    request.identification_document.document_expiration_date,
                    request.identification_document.document_serial_number
                },
                phone = new
                {
                    request.phone.area_code,
                    request.phone.phone_number
                },
                cellphone = new
                {
                    request.cellphone.area_code,
                    request.cellphone.phone_number,
                },
                bank_accounts = new
                {
                    request.bank_accounts.type_accounts,
                    request.bank_accounts.unique_account,
                    custom_accounts = request.bank_accounts.custom_accounts.Select(x => new {
                        x.brand,
                        x.account_type,
                        x.bank,
                        x.agency,
                        x.account,
                        x.account_digit
                    }).ToList()
                },
                list_comissions = request.list_commissions.Select(x => new {
                    x.brand,
                    x.product,
                    x.payment_plan,
                    x.commission_percentage,
                    x.commission_value
                }).ToList(),
                request.url_callback,
                request.payment_plan,                
                request.marketplace_store,
                request.automatic_anticipation
            };

            var requestBody = JsonConvert.SerializeObject(requestObj);

            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("PUT"),
                RequestUri = new Uri(base_api + "/v1/mgm/pf/update-subseller/"),
                Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
            };
            //TODO: Confirmar informação do token.
            requestMessage.Headers.Add("Authorization", token.token_type + " " + token.access_token);

            var response = client.SendAsync(requestMessage).Result;
            responseBody = JsonConvert.DeserializeObject<CriarPreCadastroLojaPessoaFisicaResponse>(response.Content.ReadAsStringAsync().Result);

            return responseBody;
        }

    }
}
