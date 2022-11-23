using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesafioBackEnvelope.Application.DTOs
{
    public class RepositorioDTO
    {
        /// <summary>
        /// Identificador do repositório onde o envelope será criado
        /// </summary>
        [Key]
        public int id { get; set; }
        public UsuarioDTO Usuario { get; set; }
        /// <summary>
        /// Descrição do repositório. Quando não informado um identificador de repositório, o sistema tentará utilizar um repositório de mesmo nome. Não existindo, o mesmo será criado.
        /// </summary>
        [Required]
        public string nome { get; set; }
        [Required]
        public string compartilharCriacaoDocs { get; set; }
        [Required]
        public string compartilharVisualizacaoDocs { get; set; }
        [Required]
        public string ocultarEmailSignatarios { get; set; }
        [Required]
        public string nomeRemetente { get; set; }
        [Required]
        public string opcaoValidCodigo { get; set; }
        [Required]
        public string opcaoValidCertICP { get; set; }
        [Required]
        public string opcaoValidDocFoto { get; set; }
        [Required]
        public string opcaoValidDocSelfie { get; set; }
        [Required]
        public string opcaoValidTokenSMS { get; set; }
        [Required]
        public string opcaoValidLogin { get; set; }
        [Required]
        public string opcaoValidReconhecFacial { get; set; }
        [Required]
        public string opcaoValidPix { get; set; }
        [Required]
        public string lembrarAssinPendentes { get; set; }
        [Required]
        public DateTime dataHoraCriacao { get; set; }
    }
}