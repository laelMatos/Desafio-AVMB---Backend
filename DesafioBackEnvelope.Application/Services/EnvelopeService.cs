using DesafioBackEnvelope.Application.DTOs;
using DesafioBackEnvelope.Application.Interfaces;
using DesafioBackEnvelope.Domain;
using DesafioBackEnvelope.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text.Json;


namespace DesafioBackEnvelope.Application.Services
{
    public class EnvelopeService : IEnvelopeService
    {
        private readonly DataContractJsonSerializerSettings _settingsJson;
        private readonly IEnvelopeRepository _ENVELOPE_REPOS;
        private readonly JsonSerializerOptions _options;
        private readonly IConfiguration _config;
        private readonly HttpClient _client;
        private readonly string _token;
        private object? _dataRequest;

        public EnvelopeService(IConfiguration config, IEnvelopeRepository envelopeRepository)
        {
            _ENVELOPE_REPOS = envelopeRepository;
            _config = config;

            string? url = _config["urlAPI"];
            string? tk = _config["token"];

            if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(url))
                throw new Exception("O token ou a URL estão são dados");

            _client = new HttpClient() { BaseAddress = new Uri(url) };
            _token = tk;

            _settingsJson = new() { DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss") };
            _options = new() { PropertyNameCaseInsensitive = false };
        }

        public async Task<object> NovoEnvelope(EnvelopeDTO envelope)
        {
            //var v = Newtonsoft.Json.JsonConvert.DeserializeObject("");

            _dataRequest = SetParamsRequest(new {
                Envelope = new
                {
                    descricao = envelope.descricao,
                    Repositorio = new { id = envelope.Repositorio.id },
                    usarOrdem = "S",
                    ConfigAuxiliar = new {
                        documentosComXMLs = "N"
                    },
                    listaDocumentos = new {
                        Documento = envelope.listaDocumentos
                    },
                    incluirHashTodasPaginas = "S",
                    permitirDespachos = "S",
                    ignorarNotificacoes = "N",
                    ignorarNotificacoesPendentes = "N"
                }
            });

            return await Post_API_Asten(_dataRequest, "inserirEnvelope").Result.Content.ReadAsStreamAsync();
        }

        public async Task<object> InserirSignatario(int IdEnvelope, SignatarioRequestDTO signatario)
        {
            _dataRequest = SetParamsRequest(new {
                SignatarioEnvelop = new {
                    Envelope = new {
                        id = IdEnvelope,
                    },
                    ordem = 1,
                    ConfigAssinatura = new {
                        emailSignatario = signatario.Email,
                        nomeSignatario = signatario.Nome,
                        tipoAssinatura = (int)signatario.TipoAssinatura,
                        permitirDelegar = "N",
                        apenasCelular = "N",
                        exigirLogin = "N",
                        exigirCodigo = "N",
                        exigirDadosIdentif = "N",
                        assinaturaPresencial = "N",
                        ignorarRecusa = "N",
                        incluirImagensAutentEnvelope = "N",
                        analisarFaceImagem = "N",
                        percentualPrecisaoFace = 0
                    }
                }
            });

            return await Post_API_Asten(_dataRequest, "inserirSignatarioEnvelope").Result.Content.ReadAsStreamAsync();
        }

        public async Task<object> EncaminharEnvelopeParaAssinatura(int idEnvelope, DateTime? dataHorarioEnvioAgendado)
        {
            if (dataHorarioEnvioAgendado == null || dataHorarioEnvioAgendado == DateTime.MinValue)
            {
                _dataRequest = SetParamsRequest(new {
                    Envelope = new { id = idEnvelope },
                    agendarEnvio = "N",
                    detectarCampos = "N",
                });

            }
            else
            {
                _dataRequest = SetParamsRequest(new {
                    Envelope = new { id = idEnvelope },
                    agendarEnvio = "S",
                    detectarCampos = "N",
                    dataEnvioAgendado = dataHorarioEnvioAgendado?.Date.ToString("yyyy-MM-dd"),
                    horaEnvioAgendado = dataHorarioEnvioAgendado?.Date.ToString(@"hh\:mm\:ss")
                });

            }

            return await Post_API_Asten(_dataRequest, "encaminharEnvelopeParaAssinaturas").Result.Content.ReadAsStreamAsync();
        }

        public async Task<DadosEnvelope?> ConsultarStatus(int idEnvelope)
        {
            try
            {
                _dataRequest = SetParamsRequest(new
                {
                    idEnvelope = idEnvelope,
                    getLobs = "N"
                });

                var result = (ResponseGetEvelope?)new DataContractJsonSerializer(typeof(ResponseGetEvelope), _settingsJson)
                    .ReadObject(Post_API_Asten(_dataRequest, "getDadosEnvelope").Result.Content.ReadAsStream());

                if(result?.response != null && result?.response.status == Domain.Enums.eStatusEnvelope.Concluído)
                    await _ENVELOPE_REPOS.InsertAsync(result?.response);

                return result?.response;
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        #region Private Functions and Class

        /// <summary>
        /// Classe com a estrutra de retorno 
        /// </summary>
        public record ResponseGetEvelope
        {
            [JsonProperty("response")]
            public DadosEnvelope? response { get; set; }
        }

        private object SetParamsRequest(object value)
        {
            return new
            {
                token = _token,
                @params = value
            };
        }

        private async Task<HttpResponseMessage> Post_API_Asten(object req, string path)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(path, req, _options);

            response.EnsureSuccessStatusCode();

            //req.Dispose();

            return response;
        }
        #endregion
    }
}
