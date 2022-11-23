using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEnvelope.Domain.Enums
{
    public enum eStatusContrato : byte
    {
        Pendente = 1, 
        Vigente, 
        Encerrado
    }
}
