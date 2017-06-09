using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado
{
    enum Accion
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
        String retorno;
        String palabraAhorcado;
        String puntaje;
        Accion accion;
        // static public event enviaLetra envLetra;



        public string Nick
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

        public string LetraPalabra
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

        public string Retorno
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

        public string PalabraAhorcado
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

        internal Accion Accion
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

        public string Puntaje
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