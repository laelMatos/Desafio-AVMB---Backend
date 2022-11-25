using DesafioBackEnvelope.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DesafioBackEnvelope.Domain
{
    [Table("Envelope")]
    public sealed class DadosEnvelope
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Required]
        public Repositorio Repositorio { get; set; }
        [Required]
        public Usuario Usuario { get; set; }
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

        [NotMapped]
        [JsonIgnore] 
        int _numeroPaginas;

        [Required]
        public string numeroPaginas { get { return _numeroPaginas.ToString(); } set { _numeroPaginas = int.Parse(value); } }

        [Required]
        public eStatusEnvelope status { get; set; }
        public DateTime? dataEnvioAgendado { get; set; }
        public DateTime? horaEnvioAgendado { get; set; }
        [Required]
        public DateTime dataHoraCriacao { get; set; }
        [Required]
        public DateTime dataHoraAlteracao { get; set; }
        public string? objetoContrato { get; set; }
        public eStatusContrato? statusContrato { get; set; }

        [NotMapped]
        [JsonIgnore] 
        int _numContrato;

        public string? numContrato { get { return _numContrato > 0 ? _numContrato.ToString() : null; } set { _numContrato = ConvertStringForInt(value); } }

        public string? descricaoContratante { get; set; }
        public string? descricaoContratado { get; set; }
        public string? Envelope { get; set; }

        private int ConvertStringForInt(string? val)
        {
            int r;
            return (int.TryParse(val, out r)? r:0);

        }
    }
}
