using System.Diagnostics.CodeAnalysis;

namespace Eduardo_Amorim.Api.Dominio
{
    [ExcludeFromCodeCoverage]
    public class CalculoCDB
    {
        public decimal ResultadoBruto { get; set; }
        public decimal ResultadoLiquido { get; set; }
    }
}
