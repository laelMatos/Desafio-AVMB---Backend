using Microsoft.AspNetCore.Mvc;
using DesafioBackEnvelope.Application.Interfaces;
using System.Net;
using System.Text;
using Microsoft.Extensions.Hosting;
using DesafioBackEnvelope.Domain;
using DesafioBackEnvelope.Application.DTOs;
using System.IO;
using Microsoft.AspNetCore.Mvc.Routing;
using DesafioBackEnvelope.Domain.Enums;
using DesafioBackEnvelope.Application.DTOs.Request;
using DesafioBackEnvelope.Application.Services;

namespace DesafioBackEnvelope.API.Controllers
{
    [Produces("application/json")]
    public class EnvelopeController : DesafioBackEnvelopeControllerBase
    {
        private readonly IDomainNotificationHandler _NOTIFICATION;
        private readonly IEnvelopeService _envelopeService;

        public EnvelopeController(IEnvelopeService envelopeService, IDomainNotificationHandler nOTIFICATION)
        {
            _envelopeService = envelopeService;
            _NOTIFICATION = nOTIFICATION;
        }


        /// <summary>
        /// Cria um novo envelope.
        /// </summary>
        /// <param name="envelope">Dados do envelope</param>
        /// <param name="files">Arquivos do envelope</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> NovoEnvelope([FromForm] List<IFormFile> files, [FromQuery] EnvelopeRequestDTO envelope)
        {
            try
            {
                List<DocumentoDTO> documentos = new List<DocumentoDTO>();
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            formFile.OpenReadStream().CopyTo(memoryStream);
                            documentos.Add(new DocumentoDTO()
                            {
                                nomeArquivo = formFile.FileName,
                                mimeType = formFile.ContentType,
                                conteudo = Convert.ToBase64String(memoryStream.ToArray())
                            });
                        }
                    }
                }

                var envelopeNovo = new EnvelopeDTO()
                {
                    descricao = envelope.descricao,
                    Repositorio = new RepositorioDTO { id = envelope.idRepositorio, nome = envelope.nomeRepositorio },
                    listaDocumentos = documentos,
                };
                
                return await _envelopeService.NovoEnvelope(envelopeNovo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Inserir um novo signatario ao envelope
        /// </summary>
        /// <param name="IdEnvelope">Codigo de identificação do envelope</param>
        /// <param name="signatario">Dados Do signatario</param>
        /// <returns></returns>
        [HttpPost("{IdEnvelope}/signatario")]
        public async Task<object> NovoSignatario(int IdEnvelope, [FromBody]SignatarioRequestDTO signatario)
        {
            return await _envelopeService.InserirSignatario( IdEnvelope, signatario);
        }

        /// <summary>
        /// Encaminhar envelope para assinatura
        /// </summary>
        /// <param name="idEnvelope">Codigo de identificação do envelope</param>
        /// <param name="dataHoraEnvioAgendado">Data e horario do agendamento caso precise agendar o envio (yyyy-mm-dd hh:mm:ss)</param>
        /// <returns></returns>
        [HttpPost("{idEnvelope}/Encaminhar")]
        public async Task<object> EncaminharParaAssinatura(int idEnvelope, DateTime? dataHoraEnvioAgendado)
        {
            return await _envelopeService.EncaminharEnvelopeParaAssinatura(idEnvelope, dataHoraEnvioAgendado);
        }

        /// <summary>
        /// Consultar status do envelope
        /// </summary>
        /// <param name="idEnvelope">Codigo de identificação do envelope</param>
        /// <returns></returns>
        [HttpGet("{idEnvelope}")]
        public async Task<object> ConsultarStatus(int idEnvelope)
        {
            try
            {
                return await _envelopeService.ConsultarStatus(idEnvelope);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
