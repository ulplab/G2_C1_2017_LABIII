using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesComunicacion;

namespace ServidorJA
{
    class clsRouter
    {
        clsJuego juego;
        clsManejoPaquetes msjPaquete;
        List<clsCliente> listaCliente;
        internal List<clsCliente> ListaCliente
        {
            get { return listaCliente; }
            set { listaCliente = value; }
        }

        public clsRouter(clsJuego juego)
        {
            this.juego = juego;
            msjPaquete = new clsManejoPaquetes();
            listaCliente = new List<clsCliente>();
        }
        public void comienzaPartida()
        {
            juego.GeneraPalabra();
            Console.WriteLine("Palabra a adivinar: " + juego.Palabra);
            clsMensajePartida msjP = new clsMensajePartida();
            foreach(clsCliente c in listaCliente)
            {
                c.recMsj += recibe;
                c.MsjPaquete = msjPaquete;
                msjP.Accion = "COMIENZA_PARTIDA";
                msjP.ListaJugadores = juego.Jugadores;
                msjP.Retorno = "START";
                msjP.PalabraAhorcado = juego.Palabra;
                c.enviar(msjP);
            }
        }
        public void recibe(clsMensajeBase m, String nombre) //Revisar String nombre que viene JSON completo
        {

            clsMensajeJuego mensaje =(clsMensajeJuego)m;

            mensaje.PalabraAhorcado = juego.Palabra;
            switch(m.Accion)
            {
                case "PROBAR_LETRA":
                    mensaje = juego.enviaLetra(nombre, mensaje.LetraPalabra);
                    controlaFallo(mensaje, nombre);

                    break;
                case "PROBAR_PALABRA":
                    mensaje = juego.enviaPalabra(nombre, mensaje.LetraPalabra);
                    controlaFallo(mensaje, nombre);
                    break;
            }
        }

        private void controlaFallo(clsMensajeJuego mensaje, String nombre)
        {
            if (juego.Jugadores.ElementAt(juego.BuscaIndiceJugador(nombre)).FueraDeJuego)
            {
                clsMensajePerdedor msjPerdedor = new clsMensajePerdedor();
                EnviarAUno(nombre, msjPerdedor);
            }
            else
            {
                if (mensaje.Retorno.Equals("FALLO"))
                {
                    EnviarAUno(nombre, mensaje);
                }
                else
                {
                    if (juego.Ganador != null)
                        EnviarATodos(juego.Ganador);//ojo con este cambio !!! penvia clase ganador
                    else
                        EnviarATodos(mensaje);
                }
            }
       
        }
        public void EnviarAUno(string nombre,clsMensajeBase mensaje)
        {
            foreach (clsCliente c in listaCliente)
            {
                if (c.Nick.Equals(nombre))
                {
                    c.enviar(mensaje);
                }
            }

        }
        public void EnviarATodos(clsMensajeBase mensaje)
        {
            foreach (clsCliente c in listaCliente)
            {
                    c.enviar(mensaje);
            }

        }

    }
}
