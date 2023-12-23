using Eduardo_Amorim.Api.Aplicacao.Interfaces;
using Eduardo_Amorim.Api.Controllers;
using Eduardo_Amorim.Api.Dominio;
using Eduardo_Amorim.Api.Model;
using Eduardo_Amorim.Api.Model.Input;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using Xunit;

namespace Eduardo_Amorim.Api.Tests.UI
{
    [TestClass]
    public class CalcularCDBControllerTests
    {
        private readonly CalcularCDBController controller;
        private readonly Mock<ILogger<CalcularCDBController>> _logger = new();
        protected readonly Mock<ISimulacaoServicoCalculo> _simulacaoServico = new();

        public CalcularCDBControllerTests()
        {
            controller = new CalcularCDBController(_logger.Object, _simulacaoServico.Object);
        }

        [TestMethod]
        [Fact(DisplayName = "Criar uma simulação de calculo CDB")]
        public async Task SimularInvestimento_ReturnsExpectedResponse()
        {
            // Arrange
            var expectedResponseDTO = new CalculoCDB();
            var expectedResponseModel = new CalculoCDBModel(expectedResponseDTO);

            _simulacaoServico.Setup(x => x.SimulacaoCalculoCDB(It.IsAny<decimal>(), It.IsAny<int>()))
                .ReturnsAsync(expectedResponseDTO);

            // Act
            var result = await controller.SimularInvestimento(new SimulacaoInvestimentoInput());

            var okObjectResult = result as OkObjectResult;

            // Assert
            Xunit.Assert.IsType<OkObjectResult>(result);
            Xunit.Assert.NotNull(okObjectResult);
            Xunit.Assert.Equal((int)HttpStatusCode.OK, okObjectResult.StatusCode);
        }
    }
}
