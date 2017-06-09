using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace JuegoAhorcado
{
    public delegate void enviar(string Json);
    public delegate void recibir();
    public delegate void Comienzo(clsMensaje cl);


    public class clsCliente
    {
        String nick;

        public String Nick
        {
            get { return nick; }
            set { nick = value; }
        }
        //clsJugador player;
        TcpClient client;
        static int port = 8000;
        clsMensaje mensaje;

        public clsMensaje Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }
        clsManejoPaquetes serializador = new clsManejoPaquetes();
        static private NetworkStream stream;
        static private StreamWriter streamw;
        static private StreamReader streamr;
        public event Comienzo start;

        //public event ev_recibir recibe;
        //public event ev_fin finJuego;
        //public event Action ev_palabra;
        //public event ev_enviar ev_send;
        public clsCliente()
        {
            //manda = new ev_enviar(frmJuego.enviarp);
            //manda = new ev_enviar(enviar);
            //manda = j.en;
            //serializador.Enviar += enviar;
            
        }
        public void leer()
        {
            bool control=true;
            while(control)
            {
                string aux = streamr.ReadLine();
                mensaje = serializador.recibirMensaje(aux);
               
                streamw.Flush();
                if (control)
                {
                    start(mensaje);
                    control = false;
                }
                    
            }
            
        }
        public void Start()
        {
            try
            {
                client = new TcpClient("10.62.233.21", port);
                Console.WriteLine("Client conectado.");
                stream = client.GetStream();
                streamw = new StreamWriter(stream);
                streamr = new StreamReader(stream);
                streamw.WriteLine(nick);
                streamw.Flush();
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Client Disconnected.");
            }
            leer();
        }


        public void DataIn()
        {
            try
            {
                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream);
                while (true) //client.Connected
                {
                    //string recibe = reader.ReadLine();
                    //clsMensaje mAux = serializador.recibirMensaje(recibe);
                    //switch (mAux.Tipo)
                    //{
                    //    case TipoMsj.palabraJuego:
                    //        j.Palabra = mAux.Msj;
                    //        j.Invoke((Action)j.CargarForm);
                    //        break;
                    //    case TipoMsj.env_letra:
                    //        break;
                    //}
                }
                reader.Close();
                stream.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void enviar(string dato)
        {
            NetworkStream stream;
            StreamWriter sw;
            try
            {
                stream = client.GetStream();
                sw = new StreamWriter(stream);
                if (client.Connected)
                {
                    clsMensaje msj = new clsMensaje();
                    //string output = serializador.enviarMensaje(msj);
                    //sw.WriteLine(output);
                    sw.Flush();
                }
                sw.Close();
                stream.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

    }
}
