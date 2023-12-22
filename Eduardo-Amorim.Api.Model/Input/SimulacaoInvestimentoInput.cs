using System.Diagnostics.CodeAnalysis;

namespace Eduardo_Amorim.Api.Model.Input
{
    [ExcludeFromCodeCoverage]
    public class SimulacaoInvestimentoInput
    {
        public decimal ValorMonetario { get; set; }
        public int PrazoEmMeses { get; set; }
    }
}
