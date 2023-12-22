using System.Diagnostics.CodeAnalysis;

namespace Eduardo_Amorim.Api.Dominio
{
    [ExcludeFromCodeCoverage]
    public class RetornoRequisicao
    {
        public int Codigo { get; set; }
        public int Mensagem { get; set; }
        public string Identificador { get; set; }
    }
}
