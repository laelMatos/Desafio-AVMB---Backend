using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace DesafioBackEnvelope.Application.Services
{
    public abstract class ServiceApiAstenBase
    {

        /// <summary>
        /// Classe com a estrutra de retorno 
        /// </summary>
        /// <param name="Envelope"></param>
        protected record ResponseGetEnvelope([property: JsonProperty("response")] object Envelope);
        /// <summary>
        /// Classe com a estrutura de requisição para a API de assinaturas
        /// </summary>
        /// <param name="token">Chave de acesso para a API</param>
        protected record Request(string token)
        {
            private object? @params;
            public void SetPrams(object data) => @params = data;
            public void Dispose() => this.@params = null;
        }
    }
}