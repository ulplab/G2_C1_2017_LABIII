using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesComunicacion
{
    public class clsMensajePartida : clsMensajeBase
    {
        List<clsJugador> listaJugadores;

        public List<clsJugador> ListaJugadores
        {
            get { return listaJugadores; }
            set { listaJugadores = value; }

        }
        public clsMensajePartida()
        {
            Tipo = "MENSAJE_PARTIDA";
        }
    }
}
