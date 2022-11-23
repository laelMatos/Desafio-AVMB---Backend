using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEnvelope.Domain.Enums
{
    public enum eStatusEnvelope : byte
    {
        /// <summary>
        /// Em construção
        /// </summary>
        [Description("Em construção")]
        EmConstrução=1,
        /// <summary>
        /// Aguardando Assinaturas
        /// </summary>
        [Description("Aguardando Assinaturas")]
        AguardandoAssinaturas,
        /// <summary>
        /// Concluído
        /// </summary>
        [Description("Concluído")]
        Concluído,
        /// <summary>
        /// Arquivado
        /// </summary>
        [Description("Arquivado")]
        Arquivado,
        /// <summary>
        /// Cancelado
        /// </summary>
        [Description("Cancelado")]
        Cancelado,
        /// <summary>
        /// Expirado
        /// </summary>
        [Description("Expirado")]
        Expirado
    }
}
