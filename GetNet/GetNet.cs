using System;
using System.Collections.Generic;
using System.Text;
using Guterres.Payment.GetNet.Request;
using Guterres.Payment.GetNet.Response;
using Guterres.Payment.GetNet.DTO;


/// <summary>
/// Descrição resumida de GetNetAuth
/// </summary>
/// 
namespace Guterres.Payment.GetNet
{
    public class GetNet
    {
        private const string client_id = "";
        private const string client_secret = "";
        private const string seller_id = "";
        private string keyBase64 = "";
        private const string base_api = "https://api-sandbox.getnet.com.br";
        private GetNetToken token;
        private GetNetAuth auth;
        private GetNetCartaoCofre cofre;
        

        /// <summary>
        /// Instancia um objeto autenticado para operações financeiras  com a GetNet
        /// </summary>
        public GetNet()
        {            
            keyBase64 = GetAuthStringBase64();
            auth = new GetNetAuth(keyBase64, base_api, seller_id);
            RenewSession();
            cofre = new GetNetCartaoCofre(base_api, seller_id, token);
            
        }


        public static GetNet getInstance() {
            return new GetNet();
        }

        public string TokenizeCard(TokenizeCardRequest request)
        {
            return cofre.TransformaCartaoEmToken(request);
        }

        /// <summary>
        /// Insere cartão no cofre GetNet
        /// </summary>
        /// <param name="request"></param>
        /// <returns>card_id do cartão inserido</returns>
        public CardInVaultResponse InsereCartaoNoCofre(InsertCardInVaultRequest request)
        {
            if (!isTokenValid())
            {
                RenewSession();
            }

            var result = cofre.InsereCartaoNoCofre(request);
            return result;
        }


        /// <summary>
        /// Lista cartões existentes no cofre GetNet
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="customerId"></param>
        /// <returns>Lista de cartões</returns>
        public List<CardInVaultResponse> ListaCartoesNoCofre(string CustomerId, StatusCartao status)
        {
            if (!isTokenValid())
            {
                RenewSession();
            }

            var result = cofre.ListaCartoesDoCofre(CustomerId, status);

            return result;
        }

     
        public CardInVaultResponse RecuperaCartao(string card_id)
        {
            if (!isTokenValid())
            {
                RenewSession();
            }
            return cofre.RecuperaCartaoDoCofre(card_id);
        }

        public GetNetToken Auth3DS(Auth3DSRequest auth3DSRequest)
        {           
            var result = auth.Auth3DS(auth3DSRequest);
            return result;
        }

        public AuthenticationsResponse AskAuth3DS(AuthenticationsRequest request) {
            var tokenizeRequest = new TokenizeCardRequest();
            tokenizeRequest.Card_Number = request.paymentInformation.card.number;
            tokenizeRequest.Customer_Id = request.additionalData.ToString();
            request.paymentInformation.card.number_token = cofre.TransformaCartaoEmToken(tokenizeRequest);
            var result = auth.SolicitaAutenticacao3DS(request);
            return result;
        }

        public AuthenticationsResultsResponse AskAuth3DSResults(AuthenticationsResultsRequest request) {
            var tokenizeRequest = new TokenizeCardRequest();
            tokenizeRequest.Card_Number = request.paymentInformation.card.number;
            tokenizeRequest.Customer_Id = request.additionalData.ToString();
            request.paymentInformation.card.numberToken = cofre.TransformaCartaoEmToken(tokenizeRequest);
            return auth.SolicitaResultadoAutenticacao(request);
        }

        public PaymentAuthenticatedResponse AuthenticatedPayment(PaymentAuthenticatedRequest request) {
           return auth.AuthenticatedPayment(request);
        }


        /// <summary>
        /// Renova a sessão com a GetNet
        /// </summary>
        private void RenewSession()
        {
            this.token = auth.Oauth();
        }

        /// <summary>
        /// Verifica se é necessário renovar a sessão com a GetNet
        /// </summary>
        /// <returns></returns>
        private bool isTokenValid()
        {
            bool isAcessTokenEmpty = string.IsNullOrEmpty(token.access_token);
            bool isExpired = DateTime.Now > token.dataExpiracao;
            return !isAcessTokenEmpty && !isExpired;
        }

        /// <summary>
        /// Gera o AuthStringBase64 utilizando client_id e client_secret
        /// </summary>
        /// <returns></returns>
        private string GetAuthStringBase64()
        {
            var result = client_id + ":" + client_secret;
            byte[] bytes = Encoding.ASCII.GetBytes(result);
            var resultBase64 = Convert.ToBase64String(bytes);
            return resultBase64;
        }
    }


}
