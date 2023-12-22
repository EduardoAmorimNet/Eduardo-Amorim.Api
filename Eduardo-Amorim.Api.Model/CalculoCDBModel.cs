using Eduardo_Amorim.Api.Dominio;
using Eduardo_Amorim.Api.Dominio.Base;
using System.Diagnostics.CodeAnalysis;

namespace Eduardo_Amorim.Api.Model
{
    [ExcludeFromCodeCoverage]
    public class CalculoCDBModel : CalculoCDBBase
    {
        public CalculoCDBModel(CalculoCDB resultadocalculoCDB)
            : base()
        {
            ResultadoBruto = resultadocalculoCDB.ResultadoBruto;
            ResultadoLiquido = resultadocalculoCDB.ResultadoLiquido;
        }

        public decimal ResultadoBruto { get; set; }
        public decimal ResultadoLiquido { get; set; }
    }
}
