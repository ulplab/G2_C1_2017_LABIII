using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesComunicacion
{
    public class clsMensajeSigRonda : clsMensajeBase
    {
        public clsMensajeSigRonda()
        {
            Tipo = "MENSAJE_SIGUIENTE_RONDA";
        }
    }
}
