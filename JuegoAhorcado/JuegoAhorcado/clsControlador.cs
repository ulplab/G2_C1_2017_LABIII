using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace JuegoAhorcado
{
    public class clsJugador
    {
        string nick;
        int puntaje;
        Color color;
        int vidas;

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

        public int Puntaje
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

        public Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        public int Vidas
        {
            get
            {
                return vidas;
            }

            set
            {
                vidas = value;
            }
        }

        //int sala;

        public clsJugador(string s, Color c)
        {
            Nick = s;
            Color = c;
            Puntaje = 0;
            Vidas = 5;
        }

        public void PierdeVida()
        {
            Vidas--;
        }

    }


    public class clsControlador : ICom
    {
        public string palabra;

        public clsControlador(string p)
        {
            palabra = p.ToUpper();
        }

        public event ev_fin finJuego;
        public event ev_recibir recibe;
        

        public bool enviaLetra(clsJugador p, char l)
        {
            if (palabra.IndexOf(l) != -1)
            {
                recibe(p, l.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool enviaPalabra(clsJugador p, string s)
        {
            if (palabra == s)
            {
                finJuego();
                return true;
            }
            else
                return false;
        }
    }
}
