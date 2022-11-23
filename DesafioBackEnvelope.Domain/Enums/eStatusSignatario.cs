using System.ComponentModel;

namespace DesafioBackEnvelope.Domain.Enums
{
    public enum eStatusSignatario : byte
    {
        /// <summary>
        /// Pendente
        /// </summary>
        [Description("Pendente")]
        Pendente=1,
        /// <summary>
        /// Visualizado
        /// </summary>
        [Description("Visualizado")]
        Visualizado,
        /// <summary>
        /// Assinado
        /// </summary>
        [Description("Assinado")]
        Assinado,
        /// <summary>
        /// Cancelado
        /// </summary>
        [Description("Cancelado")]
        Cancelado,
        /// <summary>
        /// Ignorado pelo Sistema
        /// </summary>
        [Description("Ignorado pelo Sistema")]
        Ignorado_pelo_Sistema,
        /// <summary>
        /// Delegado
        /// </summary>
        [Description("Delegado")]
        Delegado
    }
}
