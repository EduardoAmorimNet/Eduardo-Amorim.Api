using System.Diagnostics.CodeAnalysis;

namespace Eduardo_Amorim.Api.Dominio.Base
{
    [ExcludeFromCodeCoverage]
    public class CalculoCDBBase
    {
        private readonly string _unidadeMonetaria = "R$";
        private readonly string _moedaReal = "Real";

        public string UnidadeMonetaria { get { return _unidadeMonetaria; } }
        public string MoedaReal { get { return _moedaReal; } }
    }
}
