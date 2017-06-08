using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorJA
{
    public class clsMensaje
    {
        String accion;
        String nick;
        String letraPalabra;
        String retorno;
        String palabraAhorcado;

        // static public event enviaLetra envLetra;

        public string Accion
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
    }
}
