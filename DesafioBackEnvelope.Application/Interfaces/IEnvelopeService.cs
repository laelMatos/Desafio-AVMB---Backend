using DesafioBackEnvelope.Application.DTOs;
using DesafioBackEnvelope.Domain;
using DesafioBackEnvelope.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEnvelope.Application.Interfaces
{
    public interface IEnvelopeService
    {
        /// <summary>
        /// Cria um novo envelope
        /// </summary>
        /// <param name="envelope">Dados do envelope</param>
        /// <returns></returns>
        Task<object> NovoEnvelope(EnvelopeDTO envelope);
        /// <summary>
        /// Insere um novo signatario para um envelope especificado
        /// </summary>
        /// <param name="IdEnvelope">Codigo de identificação do emvelope</param>
        /// <param name="signatario">Dados do signatario</param>
        /// <returns></returns>
        Task<object> InserirSignatario(int IdEnvelope,SignatarioRequestDTO signatario);
        /// <summary>
        /// Encaminha o envelope para ser assinado
        /// </summary>
        /// <param name="idEnvelope">Codigo de identificação do envelope</param>
        /// <param name="dataHorarioEnvioAgendado">Data e horario do agendamento caso precise agendar o envio (yyyy-mm-dd hh:mm:ss)</param>
        /// <returns></returns>
        Task<object> EncaminharEnvelopeParaAssinatura(int idEnvelope, DateTime? dataHorarioEnvioAgendado);
        /// <summary>
        /// Consultar o status do envelope
        /// </summary>
        /// <param name="idEnvelope">Codigo de identificação do envelope</param>
        /// <returns></returns>
        Task<DadosEnvelope> ConsultarStatus(int idEnvelope);
    }
}
