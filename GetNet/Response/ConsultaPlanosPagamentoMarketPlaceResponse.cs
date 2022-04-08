

namespace Guterres.Payment.GetNet.Response
{
    public class ConsultaPlanosPagamentoMarketPlaceResponse
    {

        public int paymentplanId { get; set; }
        public int paymentplan_id { get { return paymentplanId; } set { paymentplanId = value; } }
        public string name { get; set; }
        public string anticipation { get; set; }
    }
}
