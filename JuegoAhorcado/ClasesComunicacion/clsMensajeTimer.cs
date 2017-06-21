using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesComunicacion
{
    public class clsMensajeTimer : clsMensajeBase
    {
        int segundero;

        public int Segundero
        {
            get { return segundero; }
            set { segundero = value; }
        }
        public clsMensajeTimer()
        {
            Tipo = "MENSAJE_TIMER";
        }
    }
}
