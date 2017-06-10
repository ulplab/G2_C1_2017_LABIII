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
        clsJuego juego = new clsJuego();
        clsRouter router = new clsRouter();
        private bool controlInicio = false;

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
            Console.WriteLine("Palabra a adivinar: " + juego.Palabra);
            Console.WriteLine("INGRESE CANTIDAD DE JUGADORES QUE DESEA TENER EN LA PARTIDA");
            cantJugadores = Console.ReadLine();
            bool control = false;

            while (true)
            {
                if (juego.Jugadores.Count < Convert.ToInt32(cantJugadores)) 
                {
                    client = server.AcceptTcpClient();
                    con = new Connection();
                    con.stream = client.GetStream();
                    con.streamr = new StreamReader(con.stream);
                    con.streamw = new StreamWriter(con.stream);
                    con.nick = con.streamr.ReadLine();
                    clsJugador jugador = new clsJugador(con.nick);
                    juego.agregarJugador(jugador);
                    //list.Add(con);
                    clsCliente cliente = new clsCliente(con.stream,con.streamw,con.streamr,con.nick);
                    router.ListaCliente.Add(cliente);
                    Console.WriteLine("Jugador " + con.nick + " ya se unio a la partida");
                    if((Convert.ToInt32(cantJugadores) - juego.Jugadores.Count)!=0)
                        Console.WriteLine(con.nick + "Espere que faltan: " + (Convert.ToInt32(cantJugadores) - juego.Jugadores.Count) + " jugadores para comenzar");
                    else
                    {

                    //    if(control==false)
                    //    {
                    //        //Console.WriteLine("Juego listo para comenzar");
                    //        //paquete.Mensajedeserializado.PalabraAhorcado = juego.Palabra;
                    //        //paquete.Mensajedeserializado.Retorno = "EXITO";
                    //        //paquete.enviarMensaje();
                    //        //control = true;
                    //    }  
                    }
                    Thread t = new Thread(cliente.DataIn);
                    t.Start();
                }                
            }
        }
        public void DataIn()
        {
            bool control=false;
            Connection hcon = con;
            try
            {
                while (true) //client.Connected
                {

                    if (control==false && Convert.ToInt32(cantJugadores)>1)
                    {
                        hcon.streamw.WriteLine("WAIT");
                        hcon.streamw.Flush();
                        control = true;
                    }
                    else if(list.Count== Convert.ToInt32(cantJugadores))
                    {
                        //paquete.Mensajedeserializado.PalabraAhorcado = juego.Palabra;
                        //paquete.Mensajedeserializado.Retorno = "EXITO";
                        //paquete.enviarMensaje();
                    }
                    //foreach (Connection c in list)
                    //{
                   
                    //}
                    ////    string recibe = reader.ReadLine();
                    ////    //clsMensaje mAux =
                    ////    paquete.recibirMensaje(recibe);
                    //paquete.enviarMensaje();

                }
                //reader.Close();
                //stream.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void recibe(clsMensaje msje)
        {
            switch (msje.Accion)
            {  
                case Accion.ProbarLetra:
                    msje.Retorno = juego.enviaLetra(msje.Nick, msje.LetraPalabra);
                    break;

                case Accion.ProbarPalabra:
                    msje.Retorno = juego.enviaPalabra(msje.Nick, msje.LetraPalabra);
                    break;
                case Accion.ComienzoPartida:
                    msje.Retorno = "START";
                    msje.PalabraAhorcado = juego.Palabra;
                        break;
                
                default: break;
            }


        }
        public void Envia(string mensaje, clsMensaje Mensaje)
        {
            switch(Mensaje.Retorno){

            case "FALLO":

                 foreach (Connection c in list)
                {
                    if (c.nick.Equals(Mensaje.Nick))
                    {
                        c.streamw.WriteLine(mensaje);
                        c.streamw.Flush();
                        break;
                    }
                 }
                 break;
                case "EXITO":
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
                    break;

                default: break;
            }
            if (Mensaje.Retorno.Equals("FALLO"))
            {
               
            }
            else
            {
 
            }
        }
    }
}
        


