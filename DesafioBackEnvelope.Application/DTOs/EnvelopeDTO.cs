using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DesafioBackEnvelope.Application.DTOs
{
    public class EnvelopeDTO
    {

        public string descricao { get; set; }
        public RepositorioDTO Repositorio { get; set; }
        public string? mensagem { get; set; }
        public string? mensagemObservadores { get; set; }
        public string? mensagemNotificacaoSMS { get; set; }
        public string? dataExpiracao { get; set; }
        public string? horaExpiracao { get; set; }
        public string usarOrdem { get; set; }
        public object ConfigAuxiliar { get; set; }
        public List<DocumentoDTO> listaDocumentos { get; set; }
        public IEnumerable<object> listaSignatariosEnvelope { get; set; }
        public IEnumerable<object> listaObservadores { get; set; }
        public IEnumerable<object> listaTags { get; set; }
        public IEnumerable<object> listaInfoAdicional { get; set; }
        public string incluirHashTodasPaginas { get; set; }
        public string permitirDespachos { get; set; }
        public string ignorarNotificacoes { get; set; }
        public string ignorarNotificacoesPendentes { get; set; }
        public string? qrCodePosLeft { get; set; }
        public string? qrCodePosTop { get; set; }
        public DateTime? dataIniContrato { get; set; }
        public DateTime? dataFimContrato { get; set; }
        public object objetoContrato { get; set; }
        public string? numContrato { get; set; }
        public string? valorContrato { get; set; }
        public string? descricaoContratante { get; set; }
        public string? descricaoContratado { get; set; }
    }


}
