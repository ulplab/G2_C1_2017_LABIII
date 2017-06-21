using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesComunicacion
{
    public class clsMensajeTimer:clsMensajeBase
    {
        int timeSeg;
        public int TimeSeg
        {
            get { return timeSeg; }
            set { timeSeg = value; }
        }
        public clsMensajeTimer()
        {
            Tipo = "MENSAJE_TIMER";
        }
    }
}
