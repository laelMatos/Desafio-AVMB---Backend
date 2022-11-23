using DesafioBackEnvelope.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioBackEnvelope.Domain
{
    [Table("Signatarios")]
    public class Signatario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id { get; set; }
        [Required]
        [Column(TypeName = "tinyint")]
        public eStatusSignatario status { get; set; }
        [Required]
        public string emailSignatario { get; set; }
        [Required]
        public string nomeSignatario { get; set; }
        [Required]
        public string celularSignatario { get; set; }
        [Column(TypeName = "char(1)")]
        public string ordem { get; set; }
        [Required]
        public DateTime dataHoraEnvio { get; set; }
        [Required]
        public DateTime dataHoraVisualizacao { get; set; }
        [Required]
        public DateTime dataHoraAssinatura { get; set; }
        [Required]
        public DateTime? dataHoraCancelamento { get; set; }
        public string? motivoCancelamento { get; set; }
        [Required]
        public string linkAcessoConclusao { get; set; }
        public Assinatura Assinatura { get; set; }
    }
}