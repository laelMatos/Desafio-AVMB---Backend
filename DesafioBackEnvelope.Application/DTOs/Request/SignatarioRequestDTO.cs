using DesafioBackEnvelope.Domain.Enums;
using DesafioBackEnvelope.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace DesafioBackEnvelope.Application.DTOs
{
    public class SignatarioRequestDTO
    {
        /// <summary>
        /// Email do signatário
        /// </summary>
        [Required(ErrorMessage = "Informe o email do destinatario")]
        [EmailAddress(ErrorMessage ="Email do destinatario é invalido")]
        [MaxLength(100, ErrorMessage ="Tamanho maximo de 100 caracteres")]
        public string Email { get; set; }
        /// <summary>
        /// Nome do signatário
        /// </summary>
        [Required(ErrorMessage ="Informe o nome")]
        [MaxLength(140, ErrorMessage ="Tamanho maximo de 140 caracteres")]
        [MinLength(2, ErrorMessage ="Tamanho minimo para o nome é de 3 caracteres")]
        public string Nome { get; set; }
        /// <summary>
        /// Tipo de ação efetuada pela signatário
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o tipo de assinatura")]
        [CustomValidationEnums(typeof(eTipoAssinatura), ErrorMessage = "O tipo de assinatura é inválido")]
        public eTipoAssinatura TipoAssinatura { get; set; }
    }
}
