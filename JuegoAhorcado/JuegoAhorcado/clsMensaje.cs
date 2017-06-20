using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado
{
    public enum Accion
    {
        ProbarLetra,
        ProbarPalabra,
        NuevoJugador,
        Baja,
        ComienzoPartida,
    }

    public class clsMensaje
    {
        String nick;
        String letraPalabra;
        List<int> posicionLetra;
        String retorno;
        String palabraAhorcado;
        String puntaje;
        String accion;
        List<clsJugador> listaJugadores = new List<clsJugador>();

        public List<clsJugador> ListaJugadores
        {
            get { return listaJugadores; }
            set { listaJugadores = value; }
        }
        public String Nick
        {
            get
            {
                return nick;
            }

            set
            {
                nick = value;
            }
        }
        public String LetraPalabra
        {
            get
            {
                return letraPalabra;
            }

            set
            {
                letraPalabra = value;
            }
        }
        public List<int> PosicionLetra
        {
            get { return posicionLetra; }
            set { posicionLetra = value; }
        }
        public String Retorno
        {
            get
            {
                return retorno;
            }

            set
            {
                retorno = value;
            }
        }
        public String PalabraAhorcado
        {
            get
            {
                return palabraAhorcado;
            }

            set
            {
                palabraAhorcado = value;
            }
        }
        public String Accion
        {
            get
            {
                return accion;
            }

            set
            {
                accion = value;
            }
        }
        public String Puntaje
        {
            get
            {
                return puntaje;
            }

            set
            {
                puntaje = value;
            }
        }
    }
}
