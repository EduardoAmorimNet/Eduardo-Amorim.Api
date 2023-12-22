using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime.Serialization;
using Eduardo_Amorim.Api.Infra.Log;

namespace Eduardo_Amorim.Api.Infra.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class InternalServerErrorException : CustomException
    {
        public InternalServerErrorException(string mensagemErro, string mensagemLog)
           : base(HttpStatusCode.InternalServerError, mensagemErro, mensagemLog, NivelLog.Fatal)
        {
        }

        public InternalServerErrorException(string mensagemErro, string mensagemLog, Exception innerException)
           : base(HttpStatusCode.InternalServerError, mensagemErro, mensagemLog, NivelLog.Fatal, innerException)
        {
        }

        public InternalServerErrorException(string mensagemErro, string mensagemLog, string identificador)
           : base(HttpStatusCode.InternalServerError, mensagemErro, mensagemLog, NivelLog.Fatal, identificador)
        {
        }

        protected InternalServerErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
