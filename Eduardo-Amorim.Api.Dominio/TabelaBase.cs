using System.Diagnostics.CodeAnalysis;

namespace Eduardo_Amorim.Api.Dominio
{
    [ExcludeFromCodeCoverage]
    public class TabelaBase
    {
        private readonly decimal _valorPagoSobreCDI = 1.08m;
        private readonly decimal _valorDaTaxa = 0.009m;

        private readonly decimal _seisMeses = 22.5m;
        private readonly decimal _dozeMeses = 20m;
        private readonly decimal _vinteQuatroMeses = 17.5m;
        private readonly decimal _acimaVinteQuatroMeses = 15m;

        public decimal ValorPagoSobreCDI { get { return _valorPagoSobreCDI; } }
        public decimal ValorDaTaxa { get { return _valorDaTaxa; } }

        public decimal SeisMeses { get { return _seisMeses; } }
        public decimal DozeMeses { get { return _dozeMeses; } }
        public decimal VinteQuatroMeses { get { return _vinteQuatroMeses; } }
        public decimal AcimaVinteQuatroMeses { get { return _acimaVinteQuatroMeses; } }
    }
}
