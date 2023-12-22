using Eduardo_Amorim.Api.Dominio;

namespace Eduardo_Amorim.Api.Aplicacao.Interfaces
{
    public interface ISimulacaoServicoCalculo
    {
        Task<CalculoCDB> SimulacaoCalculoCDB(decimal ValorMonetario, int PrazoEmMeses);
        bool ValidarDadosSimulacao(decimal ValorMonetario, int PrazoEmMeses);
        decimal CalculadoraValorBruto(decimal valorInicial, int prazoEmMeses);
        decimal CalculadoraValorLiquido(decimal valorInicial, decimal lucroBruto, int prazoEmMeses);
    }
}
