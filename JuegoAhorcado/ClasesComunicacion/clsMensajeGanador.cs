using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesComunicacion
{
    public class clsMensajeGanador : clsMensajeBase
    {
        List<clsJugador> listaJugadores = new List<clsJugador>();
        int indice_ganador;
        string adivinador;

        public string Adivinador
        {
            get { return adivinador; }
            set { adivinador = value; }
        }
        public int Indice_ganador
        {
            get { return indice_ganador; }
            set { indice_ganador = value; }
        }
        public List<clsJugador> ListaJugadores
        {
            get { return listaJugadores; }
            set { listaJugadores = value; }
        }
        public clsMensajeGanador()
        {
            Tipo = "MENSAJE_GANADOR";
        }
    }
}
