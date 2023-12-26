using Eduardo_Amorim.Api.Aplicacao.Interfaces;
using Eduardo_Amorim.Api.Dominio;
using Eduardo_Amorim.Api.Infra.Exceptions;

namespace Eduardo_Amorim.Api.Aplicacao
{
    public class ServicoSimulacaoCalculo : ISimulacaoServicoCalculo
    {
        #region Properties
        public readonly TabelaBase _tabelaBase;
        #endregion

        public ServicoSimulacaoCalculo()
        {
            _tabelaBase = new TabelaBase();
        }

        /// </summary>
        /// Método responsável pelo calculo de CDB de acordo com as regras de simulação
        /// <param name="ValorMonetario"> Valor informado pelo usuário</param>
        /// <param name="PrazoEmMeses"> Prazo para o resgate da aplicação</param>
        /// <returns></returns>
        /// <exception cref="InternalServerErrorException">Exceção personalizada do tipoInternalServerErrorException</exception>
        public Task<CalculoCDB> SimulacaoCalculoCDB(decimal valorMonetario, int prazoEmMeses)
        {
            ValidarDadosSimulacao(valorMonetario, prazoEmMeses);

            try
            {
                CalculoCDB retorno = new CalculoCDB();

                retorno.ResultadoBruto = CalculadoraValorBruto(valorMonetario, prazoEmMeses);
                retorno.ResultadoLiquido = CalculadoraValorLiquido(valorMonetario, retorno.ResultadoBruto, prazoEmMeses);

                return Task.FromResult(retorno);
            }
            catch (Exception e)
            {
                throw new InternalServerErrorException("Erro_SimulacaoCalculoCDB", "Ocorreu um erro no Calculo do CDB, tente novamente mais tarde");
            }
        }

        public decimal CalculadoraValorBruto(decimal valorInicial, int prazoEmMeses)
        {
            decimal valorFinal = valorInicial;

            for (int i = 0; i < prazoEmMeses; i++)
                valorFinal *= (1 + (_tabelaBase.ValorDaTaxa * _tabelaBase.ValorPagoSobreCDI));

            return valorFinal;
        }

        public decimal CalculadoraValorLiquido(decimal valorInicial, decimal lucroBruto, int prazoEmMeses)
        {
            var valorDeCalculo = lucroBruto - valorInicial;

            switch (prazoEmMeses)
            {
                case (<= 6):
                    return lucroBruto - (valorDeCalculo * _tabelaBase.SeisMeses / 100);
                case (<= 12):
                    return lucroBruto - (valorDeCalculo * (_tabelaBase.DozeMeses / 100));
                case (<= 24):
                    return lucroBruto - (valorDeCalculo * (_tabelaBase.VinteQuatroMeses / 100));
                default:
                    return lucroBruto - (valorDeCalculo * (_tabelaBase.AcimaVinteQuatroMeses / 100));
            }
        }

        public void ValidarDadosSimulacao(decimal valorMonetario, int prazoEmMeses)
        {
            if (valorMonetario <= 0)
                throw new CustomException("O Valor informado deve ser maior que 0");
            if (prazoEmMeses <= 1)
                throw new CustomException("A quantidades de meses informado deve ser maior que 1");
        }
    }
}
