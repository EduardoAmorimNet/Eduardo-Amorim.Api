using Eduardo_Amorim.Api.Aplicacao;
using Eduardo_Amorim.Api.Aplicacao.Interfaces;
using Eduardo_Amorim.Api.Dominio;
using Eduardo_Amorim.Api.Infra.Exceptions;
using Eduardo_Amorim.Api.Model;
using Moq;
using Xunit;

namespace Eduardo_Amorim.Api.Tests.Aplicacao
{
    [TestClass]
    public class ServicoSimulacaoCalculoTest
    {
        #region Properties
        public readonly TabelaBase _tabelaBase;
        private readonly ServicoSimulacaoCalculo _service;
        protected readonly Mock<ISimulacaoServicoCalculo> _iSimulacaoServico = new();
        private const string spanPadrao = "Erro_SimulacaoCalculoCDB";
        private const string erroPadrao = "Ocorreu um erro no Calculo do CDB, tente novamente mais tarde";
        private const string erroDadosInvalidos = "O Valor ou Prazo em Meses informado é inválido";

        #endregion

        public ServicoSimulacaoCalculoTest()
        {
            _service = new ServicoSimulacaoCalculo();
        }

        [TestMethod]
        [Fact(DisplayName = "O serviço deverá retornar uma exceção quando mês for <1")]
        public async Task SimulacaoCalculoCDB_Retornando_Excecao_Quando_Mes_Invalido()
        {
            decimal valorInicial = 100m;
            int mesInvalido = 0;

            //Arrange
            _iSimulacaoServico.Setup(x => x.SimulacaoCalculoCDB(valorInicial, mesInvalido))
                .ThrowsAsync(new CustomException(erroDadosInvalidos));

            // Act & Assert
            await Xunit.Assert.ThrowsAsync<CustomException>(() => _service.SimulacaoCalculoCDB(valorInicial, mesInvalido));
        }

        [TestMethod]
        [Fact(DisplayName = "O serviço deverá retornar uma exceção quando Valor for <1")]
        public async Task SimulacaoCalculoCDB_Retornando_Excecao_Quando_Valor_Invalido()
        {
            decimal valorInicial = 0m;
            int mesInvalido = 11;

            //Arrange
            _iSimulacaoServico.Setup(x => x.SimulacaoCalculoCDB(valorInicial, mesInvalido))
                .ThrowsAsync(new CustomException(erroDadosInvalidos));

            // Act & Assert
            await Xunit.Assert.ThrowsAsync<CustomException>(() => _service.SimulacaoCalculoCDB(valorInicial, mesInvalido));
        }

        [TestMethod]
        [Fact(DisplayName = "O serviço deverá retornar um calculo quando tudo der certo")]
        public async Task SimulacaoCalculoCDB_Retornando_Ok_6_meses()
        {
            decimal valorMonetario = 1000;
            int prazoEmMeses = 6;

            // Arrange
            var expectedResponseDTO = new CalculoCDB()
            {
                ResultadoBruto = 1059.7556770148984501188388823m,
                ResultadoLiquido = 1046.3106496865462988421001338m

            };
            var expectedResponseModel = new CalculoCDBModel(expectedResponseDTO);

            //Arrange
            _iSimulacaoServico.Setup(x => x.SimulacaoCalculoCDB(It.IsAny<decimal>(), It.IsAny<int>()))
                .ReturnsAsync(expectedResponseDTO);

            // Act
            var result = await _service.SimulacaoCalculoCDB(valorMonetario, prazoEmMeses);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(expectedResponseDTO.ResultadoBruto, result.ResultadoBruto);
            Xunit.Assert.Equal(expectedResponseDTO.ResultadoLiquido, result.ResultadoLiquido);
        }

        [TestMethod]
        [Fact(DisplayName = "O serviço deverá retornar um calculo quando tudo der certo")]
        public async Task SimulacaoCalculoCDB_Retornando_Ok_12_meses()
        {
            decimal valorMonetario = 1000;
            int prazoEmMeses = 12;

            // Arrange
            var expectedResponseDTO = new CalculoCDB()
            {
                ResultadoBruto = 1123.0820949653057631841036240m,
                ResultadoLiquido = 1098.4656759722446105472828992m

            };
            var expectedResponseModel = new CalculoCDBModel(expectedResponseDTO);

            //Arrange
            _iSimulacaoServico.Setup(x => x.SimulacaoCalculoCDB(It.IsAny<decimal>(), It.IsAny<int>()))
                .ReturnsAsync(expectedResponseDTO);

            // Act
            var result = await _service.SimulacaoCalculoCDB(valorMonetario, prazoEmMeses);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(expectedResponseDTO.ResultadoBruto, result.ResultadoBruto);
            Xunit.Assert.Equal(expectedResponseDTO.ResultadoLiquido, result.ResultadoLiquido);
        }

        [TestMethod]
        [Fact(DisplayName = "O serviço deverá retornar um calculo quando tudo der certo")]
        public async Task SimulacaoCalculoCDB_Retornando_Ok_24_meses()
        {
            decimal valorMonetario = 1000;
            int prazoEmMeses = 24;

            // Arrange
            var expectedResponseDTO = new CalculoCDB()
            {
                ResultadoBruto = 1261.3133920316600726659576277m,
                ResultadoLiquido = 1215.5835484261195599494150429m

            };
            var expectedResponseModel = new CalculoCDBModel(expectedResponseDTO);

            //Arrange
            _iSimulacaoServico.Setup(x => x.SimulacaoCalculoCDB(It.IsAny<decimal>(), It.IsAny<int>()))
                .ReturnsAsync(expectedResponseDTO);

            // Act
            var result = await _service.SimulacaoCalculoCDB(valorMonetario, prazoEmMeses);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(expectedResponseDTO.ResultadoBruto, result.ResultadoBruto);
            Xunit.Assert.Equal(expectedResponseDTO.ResultadoLiquido, result.ResultadoLiquido);
        }

        [TestMethod]
        [Fact(DisplayName = "O serviço deverá retornar um calculo quando tudo der certo")]
        public async Task SimulacaoCalculoCDB_Retornando_Ok_25_meses()
        {
            decimal valorMonetario = 1000;
            int prazoEmMeses = 25;

            // Arrange
            var expectedResponseDTO = new CalculoCDB()
            {
                ResultadoBruto = 1273.5733582022078085722707358m,
                ResultadoLiquido = 1232.5373544718766372864301254m

            };
            var expectedResponseModel = new CalculoCDBModel(expectedResponseDTO);

            //Arrange
            _iSimulacaoServico.Setup(x => x.SimulacaoCalculoCDB(It.IsAny<decimal>(), It.IsAny<int>()))
                .ReturnsAsync(expectedResponseDTO);

            // Act
            var result = await _service.SimulacaoCalculoCDB(valorMonetario, prazoEmMeses);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(expectedResponseDTO.ResultadoBruto, result.ResultadoBruto);
            Xunit.Assert.Equal(expectedResponseDTO.ResultadoLiquido, result.ResultadoLiquido);
        }

        [TestMethod]
        [Fact(DisplayName = "O serviço deverá retornar uma exceção quando Ocorrer erro no calculo")]
        public async Task SimulacaoCalculoCDB_Retornando_Excecao_Quando_OcorrerErro_No_Calculo_Invalido()
        {
            decimal valorInicial = Decimal.MaxValue;
            int mesInvalido = 12;

            //Arrange
            _iSimulacaoServico.Setup(x => x.SimulacaoCalculoCDB(valorInicial, mesInvalido))
                .ThrowsAsync(new InternalServerErrorException(spanPadrao, erroPadrao));

            // Act & Assert
            await Xunit.Assert.ThrowsAsync<InternalServerErrorException>(() => _service.SimulacaoCalculoCDB(valorInicial, mesInvalido));
        }
    }
}
