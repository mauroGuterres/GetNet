

/// <summary>
/// Descrição resumida de TipoTransacao
/// </summary>

namespace Guterres.Payment.GetNet.DTO
{
    public enum StatusCartao
    {
        Todos = 01,
        Ativo = 02,
        Renovado = 03
    }

    public static class GetNetStatusCartaoExtension
    {

        public const string Todos = "all";
        public const string Ativos = "active";
        public const string Renovados = "renewed";        
        public static string GetStringValue(this StatusCartao me)
        {
            switch (me)
            {
                case StatusCartao.Todos:
                    return Todos;
                case StatusCartao.Ativo:
                    return Ativos;
                case StatusCartao.Renovado:
                    return Renovados;
                default:
                    return "INVALIDO";
            }
        }
    }
}
