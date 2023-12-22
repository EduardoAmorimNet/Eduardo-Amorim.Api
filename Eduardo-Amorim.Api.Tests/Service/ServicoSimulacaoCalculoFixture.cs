using Eduardo_Amorim.Api.Aplicacao.Interfaces;
using Eduardo_Amorim.Api.Dominio;
using Eduardo_Amorim.Api.Model.Input;
using Moq;

namespace Eduardo_Amorim.Api.Tests.Service
{
    public class ServicoSimulacaoCalculoFixture
    {
        private readonly Mock<ISimulacaoServicoCalculo> _simulacaoServico;

        public ServicoSimulacaoCalculoFixture () 
        {
            _simulacaoServico = new Mock<ISimulacaoServicoCalculo>();
        }

        public static void SetupSimulacaoCalculoCDB(Mock<ISimulacaoServicoCalculo> _servicoSimulacaoCalculo, CalculoCDB _resultadoCalculo)
        {
            _servicoSimulacaoCalculo.Setup(x => x.SimulacaoCalculoCDB(It.IsAny<Decimal>(), It.IsAny<int>())).ReturnsAsync(_resultadoCalculo);
        }

        public static CalculoCDB ObterSimulacaoCDB()
        {
            return new CalculoCDB
            {
                ResultadoBruto = 100,
                ResultadoLiquido = 80
            };
        }

        public static SimulacaoInvestimentoInput ObterSimulacaoInvestientoInput()
        {
            return new SimulacaoInvestimentoInput
            {
                ValorMonetario = 100,
                PrazoEmMeses = 5
            };
        }

    }
}
