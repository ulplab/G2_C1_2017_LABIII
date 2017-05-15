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
        //int vidas;
        //int sala;

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

        /*public int Vidas
        {
            get
            {
                return vidas;
            }

            set
            {
                vidas = value;
            }
        }*/


        public clsJugador(string s, Color c)
        {
            Nick = s;
            Color = c;
            Puntaje = 0;
            //Vidas = 5;
        }

    }


    public class clsJuego : ICom
    {
        private List<clsJugador> jugadores = new List<clsJugador>();
        private string palabra;

        public string Palabra
        {
            get
            {
                return palabra;
            }

            set
            {
                palabra = value;
            }
        }

        public clsJuego(string p)
        {
            palabra = p.ToUpper();
        }

        public void agregarJugador(clsJugador j)
        {
            jugadores.Add(j);
        }

        public void quitarJugador(clsJugador j)
        {
            if(jugadores.Exists(x=>x.Nick==j.Nick))
            {
                jugadores.Remove(j);
            }
            if (jugadores.Count() == 0)
                finJuego(Color.Transparent);
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
                finJuego(p.Color);
                return true;
            }
            else
            {
                quitarJugador(p);
                return false;
            }
        }
    }
}
