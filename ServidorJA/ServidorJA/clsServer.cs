using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;


namespace ServidorJA
{
    class clsServer
    {
        /*        
            TcpListener--------> Espera la conexion del Cliente.        
            TcpClient----------> Proporciona la Conexion entre el Servidor y el Cliente.        
            NetworkStream------> Se encarga de enviar mensajes atravez de los sockets.        
        */

        private TcpListener server;
        private TcpClient client = new TcpClient();
        private IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, 8000);
        private List<Connection> list = new List<Connection>();
        clsMensaje Mensaje = new clsMensaje();
        clsManejoPaquetes paquete = new clsManejoPaquetes();
        clsJuego juego = new clsJuego();

        Connection con;
        private struct Connection
        {
            public NetworkStream stream;
            public StreamWriter streamw;
            public StreamReader streamr;
            public string nick;
        }

        public clsServer()
        {
            Inicio();
            paquete.Recibir += recibe;
            paquete.Enviar += Envia;
        }

        public void Inicio()
        {
            Console.WriteLine("Servidor escuchando en puerto 8000");
            server = new TcpListener(ipendpoint);
            server.Start();

            if (juego.Jugadores.Count < 4)
            {
                while (true)
                {
                    client = server.AcceptTcpClient();
                    con = new Connection();
                    con.stream = client.GetStream();
                    con.streamr = new StreamReader(con.stream);
                    con.streamw = new StreamWriter(con.stream);
                    con.nick = con.streamr.ReadLine();
                    clsJugador jugador = new clsJugador(con.nick);
                    juego.agregarJugador(jugador);
                    list.Add(con);
                    Console.WriteLine("jugador " + con.nick + " se a conectado.");
                    Thread t = new Thread(Escuchar_conexion);

                    t.Start();
                }
            }
            else
            {
                ///mandarle al loco que quiere jugar que ya estan los cuatro jugadores 
            }
        }

        public void recibe(clsMensaje msje)
        {
            switch (msje.Accion)
            {
                case "PROBAR_LETRA":
                    msje.Retorno = juego.enviaLetra(msje.Nick, msje.LetraPalabra);
                    break;

                case "PROBAR_PALABRA":
                    msje.Retorno = juego.enviaPalabra(msje.Nick, msje.LetraPalabra);
                    break;

                default: break;
            }

        }
        public void Envia(string mensaje)
        {
            if (Mensaje.Retorno.Equals("FALLO"))
            {
                foreach (Connection c in list)
                {
                    if (c.nick.Equals(Mensaje.Nick))
                    {
                        c.streamw.WriteLine(mensaje);
                        c.streamw.Flush();
                        break;
                    }
                }
            }
            else
            {
                foreach (Connection c in list)
                {
                    try
                    {
                        c.streamw.WriteLine(mensaje);
                        c.streamw.Flush();
                    }
                    catch
                    {
                    }
                }
            }
        }
        void Escuchar_conexion()
        {
            Connection hcon = con;
            do
            {
                try
                {
                    string tmp = hcon.streamr.ReadLine();
                    paquete.recibirMensaje(tmp);//RECIBE EL JSON LO CONVIERTE EN OBJETO DE TIPO JSON Y JUEGA
                    paquete.enviarMensaje(Mensaje);//ESTA FUNCION DECIDE QUE SI FALLA AL JUGADOR QUE FALLO SE LE REPORTA EL FALLO DE LO CONTRARIO AVISARA A TODOS QUE HACERTO LETRA/PALABRA

                    // Console.WriteLine(hcon.nick + ": " + tmp);

                }
                catch
                {
                    list.Remove(con);
                    // Console.WriteLine(con.nick + " se a desconectado.");
                    break;
                }
            } while (true);
        }


    }
}

