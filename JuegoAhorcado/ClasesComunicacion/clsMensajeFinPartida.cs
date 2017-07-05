using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesComunicacion
{
    public class clsMensajeFinPartida : clsMensajeBase
    {
        public clsMensajeFinPartida()
        {
            Tipo = "MENSAJE_FIN_PARTIDA";
        }
    }
}