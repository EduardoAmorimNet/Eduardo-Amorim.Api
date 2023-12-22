using Eduardo_Amorim.Api.Aplicacao.Interfaces;
using Eduardo_Amorim.Api.Controllers;
using Eduardo_Amorim.Api.Dominio;
using Eduardo_Amorim.Api.Model.Input;
using Eduardo_Amorim.Api.Tests.Service;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Eduardo_Amorim.Api.Model;

namespace Eduardo_Amorim.Api.Tests.UI
{
    public class CalcularCDBControllerFixture
    {
        private readonly Mock<ISimulacaoServicoCalculo> _simulacaoServico;
        private readonly Mock<ILogger<CalcularCDBController>> _logger;

        private readonly SimulacaoInvestimentoInput _simulacaoInvestimentoInput;
        private readonly CalculoCDB _simulacaoResultado;
        private readonly CalcularCDBController _calcularCDBController;


        public CalcularCDBControllerFixture()
        {
            _simulacaoServico = new Mock<ISimulacaoServicoCalculo>();
            _simulacaoInvestimentoInput = ServicoSimulacaoCalculoFixture.ObterSimulacaoInvestientoInput();
            _simulacaoResultado = ServicoSimulacaoCalculoFixture.ObterSimulacaoCDB();
            _calcularCDBController = new CalcularCDBController(_logger.Object, _simulacaoServico.Object);
        }

        [Fact]
        public async Task SimularInvestimento_Sucesso()
        {
            ServicoSimulacaoCalculoFixture.SetupSimulacaoCalculoCDB(_simulacaoServico, _simulacaoResultado);

            var resultado = await _calcularCDBController.SimularInvestimento(_simulacaoInvestimentoInput);

            resultado.Should().BeOfType<OkObjectResult>().Which.Value.Should().BeAssignableTo<CalculoCDBModel>();
        }
    }
}
