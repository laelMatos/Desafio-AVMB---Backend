using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioBackEnvelope.Domain
{
    [Table("Assinaturas")]
    public sealed class Assinatura
    {
        [Key]
        public string hashAssinatura { get; set; }

        //[Column(TypeName = "geography (point)")]
        //private Point GeoLocalizate;
        [Required]
        public string infoGeoLat { get; set; }
        [Required]
        public string infoGeoLong { get; set; }
        [Required]
        public string infoBrowser { get; set; }
        [Required]
        public string infoSistemaOperacional { get; set; }
        [Required]
        [Column(TypeName = "varchar(15)")]
        public string infoEnderecoIP { get; set; }
    }
}