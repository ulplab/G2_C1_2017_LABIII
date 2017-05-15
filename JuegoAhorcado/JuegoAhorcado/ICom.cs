using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace JuegoAhorcado
{
    public delegate void ev_recibir(clsJugador j, string p);
    public delegate void ev_fin(Color c);
    public interface ICom
    {
        string Palabra
        {
            get;
            set;
        }

        bool enviaLetra(clsJugador p, char c);
        bool enviaPalabra(clsJugador p, string s);

        event ev_recibir recibe;
        event ev_fin finJuego;
            
    }
}
