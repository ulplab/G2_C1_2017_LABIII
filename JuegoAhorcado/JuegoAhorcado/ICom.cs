using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado
{
    public delegate void ev_recibir(clsJugador j, string p);
    public delegate void ev_fin();
    public interface ICom
    {
        bool enviaLetra(clsJugador p, char c);
        bool enviaPalabra(clsJugador p, string s);

        event ev_recibir recibe;
        event ev_fin finJuego;
            
    }
}
