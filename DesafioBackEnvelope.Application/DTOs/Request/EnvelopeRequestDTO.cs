using System.ComponentModel.DataAnnotations;


namespace DesafioBackEnvelope.Application.DTOs.Request
{
    public class EnvelopeRequestDTO
    {
        /// <summary>
        /// Descrição do envelope
        /// </summary>
        [Required(ErrorMessage ="Informe a descrição do envelope")]
        [MaxLength(100, ErrorMessage ="Tamanho maximo de 100 caracteres")]
        public string descricao { get; set; }
        /// <summary>
        /// Codigo de identificação do repositorio
        /// </summary>
        public int idRepositorio { get; set; }
        /// <summary>
        /// Nome do repositorio (Caso não exista sera criado)
        /// </summary>
        public string? nomeRepositorio { get; set; }
    }
}
