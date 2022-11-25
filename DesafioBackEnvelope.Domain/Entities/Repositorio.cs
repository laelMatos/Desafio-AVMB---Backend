using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEnvelope.Domain
{
    public sealed class Repositorio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public Usuario Usuario { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        public string compartilharCriacaoDocs { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        public string compartilharVisualizacaoDocs { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        public string ocultarEmailSignatarios { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        public string nomeRemetente { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        public string opcaoValidCodigo { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        public string opcaoValidCertICP { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        public string opcaoValidDocFoto { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        public string opcaoValidDocSelfie { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        public string opcaoValidTokenSMS { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        public string opcaoValidLogin { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        public string opcaoValidReconhecFacial { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        public string opcaoValidPix { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        public string lembrarAssinPendentes { get; set; }
        [Required]
        public DateTime dataHoraCriacao { get; set; }
    }
}
