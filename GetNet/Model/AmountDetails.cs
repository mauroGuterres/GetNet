


namespace Guterres.Payment.GetNet.Model
{
    public class AmountDetails
    {
        public string currency { get; set; }
        public string totalAmount { get; set; }
        public string total_amount { get { return this.totalAmount; } set { this.totalAmount = value; } }
    }
}
