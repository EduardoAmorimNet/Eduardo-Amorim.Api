using Eduardo_Amorim.Api.Infra.Log;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime.Serialization;

namespace Eduardo_Amorim.Api.Infra.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class CustomException : Exception
    {
        public CustomException()
        {
        }

        public CustomException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public CustomException(HttpStatusCode statusCode, string mensagemErro, string mensagemLog, NivelLog nivelLog)
            : base(mensagemErro)
        {
            Code = (int)statusCode;
            MensagemLog = mensagemLog;
            NivelLog = nivelLog;
        }

        public CustomException(HttpStatusCode statusCode, string mensagemErro, string mensagemLog, NivelLog nivelLog, Exception innerException)
            : base(mensagemErro, innerException)
        {
            Code = (int)statusCode;
            MensagemLog = mensagemLog;
            NivelLog = nivelLog;
        }

        public CustomException(HttpStatusCode statusCode, string mensagemErro, string mensagemLog, NivelLog nivelLog, string identificador)
            : base(mensagemErro)
        {
            Code = (int)statusCode;
            MensagemLog = mensagemLog;
            NivelLog = nivelLog;
            Identificador = identificador;
        }

        public CustomException(HttpStatusCode statusCode, string mensagemErro, string mensagemLog, NivelLog nivelLog, string identificador, string dados)
            : base(mensagemErro)
        {
            Code = (int)statusCode;
            MensagemLog = mensagemLog;
            NivelLog = nivelLog;
            Identificador = identificador;
            Dados = dados;
        }

        public CustomException(string message)
            : base(message)
        {
            Code = (int)HttpStatusCode.InternalServerError;
        }

        protected CustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        public int Code { get; private set; }
        public string MensagemLog { get; set; }
        public NivelLog NivelLog { get; set; }
        public string Identificador { get; set; }
        public string Dados { get; set; }
    }
}
