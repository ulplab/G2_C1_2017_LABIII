using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            clsMensaje msj = new clsMensaje();
            foreach(clsCliente c in listaCliente)
            {
                c.recMsj += recibe;
                c.MsjPaquete = msjPaquete;
                msj.Accion = Accion.ComienzoPartida;
                msj.Retorno = "START";
                msj.PalabraAhorcado = juego.Palabra;
                c.enviar(msj);
            }
        }
        public void recibe(clsMensaje mensaje, String nombre) //Revisar String nombre que viene JSON completo
        {
            mensaje.PalabraAhorcado = juego.Palabra;
            switch(mensaje.Accion)
            {
                case Accion.ProbarLetra:
                    mensaje = juego.enviaLetra(nombre, mensaje.LetraPalabra); 
                    
                    break;
                case Accion.ProbarPalabra:
                    mensaje = juego.enviaPalabra(nombre, mensaje.LetraPalabra);
                    

                    break;
            }
            if (mensaje.Retorno.Equals("FALLO"))
            {
                EnviarAUno(nombre, mensaje);
            }
            else
            {
                EnviarATodos(mensaje);
            }
        }
        public void EnviarAUno(string nombre,clsMensaje mensaje)
        {
            foreach (clsCliente c in listaCliente)
            {
                if (c.Nick.Equals(nombre))
                {
                    c.enviar(mensaje);
                }
            }

        }
        public void EnviarATodos(clsMensaje mensaje)
        {
            foreach (clsCliente c in listaCliente)
            {
                    c.enviar(mensaje);
            }

        }

    }
}
