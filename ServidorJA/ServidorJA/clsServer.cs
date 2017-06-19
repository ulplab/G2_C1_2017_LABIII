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
        private String cantJugadores;
        private TcpListener server;
        private TcpClient client = new TcpClient();
        private IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, 8000);
        private List<Connection> list = new List<Connection>();
        //clsMensaje Mensaje = new clsMensaje();
        clsManejoPaquetes paquete = new clsManejoPaquetes();
        static clsJuego juego = new clsJuego();
        clsRouter router = new clsRouter(juego);
        clsCliente cliente;
        private bool controlInicio = false;

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
            controlInicio = true;
            //paquete.Recibir += recibe;
            //paquete.Enviar += Envia;
            Inicio();
        }

        public void Inicio()
        {
 
            Console.WriteLine("Servidor escuchando en puerto 8000");
            server = new TcpListener(ipendpoint);
            server.Start();
            Console.WriteLine("INGRESE CANTIDAD DE JUGADORES QUE DESEA TENER EN LA PARTIDA");
            cantJugadores = Console.ReadLine();

            while (true)
            {
                if (juego.Jugadores.Count < Convert.ToInt32(cantJugadores)) 
                {
                    client = server.AcceptTcpClient();
                    con = new Connection();
                    con.stream = client.GetStream();
                    con.streamr = new StreamReader(con.stream);
                    con.streamw = new StreamWriter(con.stream);
                    con.recibe = con.streamr.ReadLine();
                    clsMensaje msjLee = new clsMensaje();
                    msjLee = paquete.recibirMensaje(con.recibe);
                    Console.WriteLine("Jugador " + msjLee.Nick + " ya se unio a la partida");
                    clsJugador jugador = new clsJugador(msjLee.Nick);
                    juego.agregarJugador(jugador);
                    if((Convert.ToInt32(cantJugadores) - juego.Jugadores.Count)!=0)
                    {
                        Console.WriteLine("Jugador: " + msjLee.Nick + " espere que faltan " + (Convert.ToInt32(cantJugadores) - juego.Jugadores.Count) + " jugadores para comenzar el juego");
                        cliente = new clsCliente(con.stream, con.streamw, con.streamr, msjLee.Nick, "WAIT");
                        router.ListaCliente.Add(cliente);
                    }   
                    else
                    {
                        cliente = new clsCliente(con.stream, con.streamw, con.streamr, msjLee.Nick, "START");
                        router.ListaCliente.Add(cliente);
                        router.comienzaPartida();
                    }
                    Thread t = new Thread(cliente.DataIn);
                    t.Start();
                }                
            }
        }

        //public void recibe(clsMensaje msje)
        //{
        //    switch (msje.Accion)
        //    {  
        //        case Accion.ProbarLetra:
        //            msje.Retorno = juego.enviaLetra(msje.Nick, msje.LetraPalabra);
        //            break;

        //        case Accion.ProbarPalabra:
        //            msje.Retorno = juego.enviaPalabra(msje.Nick, msje.LetraPalabra);
        //            break;
        //        case Accion.ComienzoPartida:
        //            msje.Retorno = "START";
        //            msje.PalabraAhorcado = juego.Palabra;
        //                break;
                
        //        default: break;
        //    }


        //}
        //public void Envia(string mensaje, clsMensaje Mensaje)
        //{
        //    switch(Mensaje.Retorno){

        //    case "FALLO":

        //         foreach (Connection c in list)
        //        {
        //            if (c.nick.Equals(Mensaje.Nick))
        //            {
        //                c.streamw.WriteLine(mensaje);
        //                c.streamw.Flush();
        //                break;
        //            }
        //         }
        //         break;
        //        case "EXITO":
        //            foreach (Connection c in list)
        //            {
        //                try
        //                {   
        //                    c.streamw.WriteLine(mensaje);
        //                    c.streamw.Flush();
        //                }
        //                catch
        //                {
        //                }
        //            }
        //            break;

        //        default: break;
        //    }
        //    if (Mensaje.Retorno.Equals("FALLO"))
        //    {
               
        //    }
        //    else
        //    {
 
        //    }
        //}
    }
}
        


