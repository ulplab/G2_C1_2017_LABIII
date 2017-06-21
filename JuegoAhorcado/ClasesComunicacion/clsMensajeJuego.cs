using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesComunicacion
{
    public class clsMensajeJuego : clsMensajeBase
    {
        String letraPalabra;
        List<int> posicionLetra;
        String palabraAhorcado;


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
        public clsMensajeJuego()
        {
            Tipo = "MENSAJE_JUEGO";
        }
    }
}
