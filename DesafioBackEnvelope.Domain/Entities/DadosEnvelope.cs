using DesafioBackEnvelope.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DesafioBackEnvelope.Domain
{
    public sealed class DadosEnvelope
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Required]
        public int RepositorioId { get; set; }
        [Required]
        public int UsiarioId { get; set; }
        [Required]
        public string descricao { get; set; }
        public string? conteudo { get; set; }
        [Column(TypeName = "char(1)")]
        public string incluirHashTodasPaginas { get; set; }
        [Column(TypeName = "char(1)")]
        public string permitirDespachos { get; set; }
        [Column(TypeName = "char(1)")]
        public string usarOrdem { get; set; }
        [Required]
        public string hashSHA256 { get; set; }
        [Required]
        public string hashSHA512 { get; set; }
        public string? mensagem { get; set; }
        public string? mensagemObservadores { get; set; }
        public string? motivoCancelamento { get; set; }
        [Required]
        public int numeroPaginas { get; set; }
        public eStatusEnvelope status { get; set; }
        public DateTime dataHoraCriacao { get; set; }
        public DateTime dataHoraAlteracao { get; set; }
        public string objetoContrato { get; set; }
        public eStatusContrato statusContrato { get; set; }
        public int? numContrato { get; set; }
        public string? descricaoContratante { get; set; }
        public string? descricaoContratado { get; set; }
        public string? Envelope { get; set; }
    }
}
