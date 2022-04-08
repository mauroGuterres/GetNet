

/// <summary>
/// Descrição resumida de TipoTransacao
/// </summary>

namespace Guterres.Payment.GetNet.DTO
{
    public enum TipoTransacao
    {
        Credito = 02,
        Debito = 03
    }

    public static class GetNetTipoTransacaoExtension
    {

        public const string Credito = "02";
        private const string Debito = "03";
        public static string GetStringValue(this TipoTransacao me)
        {
            switch (me)
            {
                case TipoTransacao.Credito:
                    return Credito;
                case TipoTransacao.Debito:
                    return Debito;
                default:
                    return "INVALIDO";
            }
        }
    }
}
