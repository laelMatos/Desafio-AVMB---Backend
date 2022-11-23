using DesafioBackEnvelope.Application.DTOs;
using DesafioBackEnvelope.Application.Interfaces;
using DesafioBackEnvelope.Domain;
using DesafioBackEnvelope.Domain.Enums;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace DesafioBackEnvelope.Application.Services
{
    public class EnvelopeService : IEnvelopeService
    {
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _client;
        private readonly string _token;
        private readonly IConfiguration _config;

        public EnvelopeService(IConfiguration config)
        {
            _config = config;
            _client = new HttpClient() { BaseAddress = new Uri(_config["urlAPI"]) };
            _token = _config["token"];

            _options = new()
            {
                PropertyNameCaseInsensitive = false
            };
        }

        public async Task<object> NovoEnvelope(EnvelopeDTO envelope)
        {
            //var v = Newtonsoft.Json.JsonConvert.DeserializeObject("");

            var req = new
            {
                token = _token,
                @params = new
                {
                    Envelope = new
                    {
                        descricao = envelope.descricao,
                        Repositorio = new { id = envelope.Repositorio.id },
                        usarOrdem = "S",
                        ConfigAuxiliar = new
                        {
                            documentosComXMLs = "N"
                        },
                        listaDocumentos = new
                        {
                            Documento = envelope.listaDocumentos
                        },
                        incluirHashTodasPaginas = "S",
                        permitirDespachos = "S",
                        ignorarNotificacoes = "N",
                        ignorarNotificacoesPendentes = "N"
                    }
                }
            };

            //HttpResponseMessage response = await _client.PostAsJsonAsync("inserirEnvelope", req, _options);

            //response.EnsureSuccessStatusCode();

            //var result = await response.Content.ReadFromJsonAsync<EnvelopeDTO>();

            return await Post_API_Asten(req, "inserirEnvelope").Result.Content.ReadAsStreamAsync();
        }

        public async Task<object> InserirSignatario(int IdEnvelope, SignatarioRequestDTO signatario)
        {
            var req = new
            {
                token = _token,
                @params = new{
                    SignatarioEnvelop = new{
                        Envelope = new{
                            id = IdEnvelope,
                        },
                        ordem = 1,
                        ConfigAssinatura = new{
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
                }
            };

            //HttpResponseMessage response = await _client.PostAsJsonAsync(
            //    "inserirSignatarioEnvelope", req, _options);

            //response.EnsureSuccessStatusCode();

            return await Post_API_Asten(req, "inserirSignatarioEnvelope").Result.Content.ReadAsStreamAsync();
        }
            
        public async Task<object> EncaminharEnvelopeParaAssinatura(int idEnvelope,DateTime? dataHorarioEnvioAgendado)
        {
            object req;
            if (dataHorarioEnvioAgendado == null || dataHorarioEnvioAgendado == DateTime.MinValue)
            {
                req = new
                {
                    token = _token,
                    @params = new
                    {
                        Envelope = new { id = idEnvelope },
                        agendarEnvio = "N",
                        detectarCampos = "N",
                    }
                };
            }
            else
            {
                req = new
                {
                    token = _token,
                    @params = new
                    {
                        Envelope = new { id = idEnvelope },
                        agendarEnvio = "S",
                        detectarCampos = "N",
                        dataEnvioAgendado = dataHorarioEnvioAgendado?.Date.ToString("yyyy-MM-dd"),
                        horaEnvioAgendado = dataHorarioEnvioAgendado?.Date.ToString(@"hh\:mm\:ss")
                    }
                };
            }

            //HttpResponseMessage response = await _client.PostAsJsonAsync(
            //    "encaminharEnvelopeParaAssinaturas", req, _options);

            //response.EnsureSuccessStatusCode();

            return await Post_API_Asten(req,"encaminharEnvelopeParaAssinaturas").Result.Content.ReadAsStreamAsync();
        }

        public async Task<object> ConsultarStatus(int idEnvelope)
        {
            var req = new
            {
                token = _token,
                @params = new{
                    idEnvelope = idEnvelope,
                    getLobs= "N"
                }
            };

            var result = await Post_API_Asten(req, "getDadosEnvelope").Result.Content.ReadFromJsonAsync<DadosEnvelope>();

            return result;
        }


        #region Private Functions
        private async Task<HttpResponseMessage> Get_API_Asten(string path)
        {
            HttpResponseMessage response = await _client.GetAsync(path);

            response.EnsureSuccessStatusCode();

            return response;
        }

        private async Task<HttpResponseMessage> Post_API_Asten(object req, string path)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(path, req, _options);

            response.EnsureSuccessStatusCode();

            return response;
        }
        #endregion
    }
}
