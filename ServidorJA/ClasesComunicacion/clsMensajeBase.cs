using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesComunicacion
{
    public class clsMensajeBase
    {
        String tipo;

        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        String accion;
        String retorno;
        String nick;
        String palabraAhorcado;

        public String PalabraAhorcado
        {
            get { return palabraAhorcado; }
            set { palabraAhorcado = value; }
        }

        public String Nick
        {
            get { return nick; }
            set { nick = value; }
        }
        public String Accion
        {
            get { return accion; }
            set { accion = value; }
        }
        public String Retorno
        {
            get { return retorno; }
            set { retorno = value; }
        }

    }
}
