using Eduardo_Amorim.Api.Aplicacao.Interfaces;
using Eduardo_Amorim.Api.Dominio;
using Eduardo_Amorim.Api.Model;
using Eduardo_Amorim.Api.Model.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Eduardo_Amorim.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalcularCDBController : ControllerBase
    {
        private readonly ILogger<CalcularCDBController> _logger;
        protected readonly ISimulacaoServicoCalculo _simulacaoServico;
        public CalcularCDBController(ILogger<CalcularCDBController> logger, ISimulacaoServicoCalculo simulacaoServico)
        {
            _logger = logger;
            _simulacaoServico = simulacaoServico;
        }

        /// <summary>
        /// Criar uma simulação de calculo CDB
        /// </summary>
        /// <param name="input">Dados para simulação</param>
        /// <returns>Informações da simulação criada</returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CalculoCDBModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(RetornoRequisicao), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(RetornoRequisicao), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RetornoRequisicao), (int)HttpStatusCode.NotFound)]
        [Route("")]
        public async Task<ActionResult> SimularInvestimento([FromBody] SimulacaoInvestimentoInput input)
        {
            var resultadoSimulacao = await _simulacaoServico.SimulacaoCalculoCDB(input.ValorMonetario, input.PrazoEmMeses);
            var resultadoModel = new CalculoCDBModel(resultadoSimulacao);

            return Ok(resultadoModel);
        }
    }
}
