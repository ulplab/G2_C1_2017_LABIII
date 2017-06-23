using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;
using ClasesComunicacion;


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
        //clsMensaje Mensaje = new clsMensaje();
        clsManejoPaquetes paquete = new clsManejoPaquetes();
        static clsJuego juego = new clsJuego();
        clsRouter router = new clsRouter(juego);
        clsCliente cliente;

        Connection con;
        private struct Connection
        {
            public NetworkStream stream;
            public StreamWriter streamw;
            public StreamReader streamr;
            public string recibe;
        }

        public clsServer()
        {
            Inicio();
        }

        public void Inicio()
        {
            Console.WriteLine("Servidor escuchando en puerto 8000");
            server = new TcpListener(ipendpoint);
            server.Start();

            while (true)
            {
                if (juego.Jugadores.Count < 2) 
                {
                    client = server.AcceptTcpClient();
                    con = new Connection();
                    con.stream = client.GetStream();
                    con.streamr = new StreamReader(con.stream);
                    con.streamw = new StreamWriter(con.stream);
                    con.recibe = con.streamr.ReadLine();
                    clsMensajeBase msjLee = paquete.recibirMensaje(con.recibe);
                    Console.WriteLine("Jugador " + msjLee.Nick + "  se unio a la partida");
                    clsJugador jugador = new clsJugador(msjLee.Nick);
                    juego.agregarJugador(jugador);
                    cliente = new clsCliente(con.stream, con.streamw, con.streamr, msjLee.Nick);
                    router.ListaCliente.Add(cliente);
                    if((2 - juego.Jugadores.Count)==0)
                    {
                        router.comienzaPartida();
                    }
                    Thread t = new Thread(cliente.DataIn);
                    t.Start();
                }
            }
        }

  
    }
}
        


