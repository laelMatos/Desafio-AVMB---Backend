using System.ComponentModel;

namespace DesafioBackEnvelope.Domain.Enums
{
    public enum eTipoAssinatura : byte
    {
        /// <summary>
        /// Assinar
        /// </summary>
        [Description("Assinar")]
        Assinar =1,
        /// <summary>
        /// Aprovar
        /// </summary>
        [Description("Aprovar")]
        Aprovar,
        /// <summary>
        /// Reconhecer
        /// </summary>
        [Description("Reconhecer")]
        Reconhecer,
        /// <summary>
        /// Acusar Recebimento
        /// </summary>
        [Description("Acusar Recebimento")]
        AcusarRecebimento,
        /// <summary>
        /// PendeAssinar como Partente
        /// </summary>
        [Description("Assinar como Parte")]
        AssinarComoParte,
        /// <summary>
        /// Assinar como Testemunha
        /// </summary>
        [Description("Assinar como Testemunha")]
        AssinarComoTestemunha,
        /// <summary>
        /// Assinar como Interveniente
        /// </summary>
        [Description("Assinar como Interveniente")]
        AssinarComoInterveniente,
        /// <summary>
        /// Assinar como Emissor
        /// </summary>
        [Description("Assinar como Emissor")]
        AssinarComoEmissor,
        /// <summary>
        /// Assinar como Avalista
        /// </summary>
        [Description("Assinar como Avalista")]
        AssinarComoAvalista,
        /// <summary>
        /// Assinar como Credor
        /// </summary>
        [Description("Assinar como Credor")]
        AssinarComoCredor,
        /// <summary>
        /// Assinar como Devedor
        /// </summary>
        [Description("Assinar como Devedor")]
        AssinarComoDevedor,
        /// <summary>
        /// Assinar como Declarante
        /// </summary>
        [Description("Assinar como Declarante")]
        AssinarComoDeclarante,
        /// <summary>
        /// Assinar como Outorgante
        /// </summary>
        [Description("Assinar como Outorgante")]
        AssinarComoOutorgante,
        /// <summary>
        /// Assinar como Outorgado
        /// </summary>
        [Description("Assinar como Outorgado")]
        AssinarComoOutorgado,
        /// <summary>
        /// Assinar como Contratante
        /// </summary>
        [Description("Assinar como Contratante")]
        AssinarComoContratante,
        /// <summary>
        /// Assinar como Contratado
        /// </summary>
        [Description("Assinar como Contratado")]
        AssinarComoContratado,
        /// <summary>
        /// Assinar como Advogado
        /// </summary>
        [Description("Assinar como Advogado")]
        AssinarComoAdvogado,
        /// <summary>
        /// Chancela Jurídica
        /// </summary>
        [Description("Chancela Jurídica")]
        ChancelaJuridica,
        /// <summary>
        /// Dar Ciência
        /// </summary>
        [Description("Dar Ciência")]
        DarCiencia
    }
}
