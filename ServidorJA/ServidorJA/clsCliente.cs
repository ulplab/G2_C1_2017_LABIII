using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesComunicacion;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace ServidorJA
{

    public delegate void recibir(clsMensajeBase mensaje, String nombre);
    class clsCliente
    {
        #region Atributos, Set y Get
        private NetworkStream stream;
        public NetworkStream Stream
        {
            get { return stream; }
            set { stream = value; }
        }

        private StreamWriter streamw;
        public StreamWriter Streamw
        {
            get { return streamw; }
            set { streamw = value; }
        }

        private StreamReader streamr;
        public StreamReader Streamr
        {
            get { return streamr; }
            set { streamr = value; }
        }
      
        private string nick;
        public string Nick
        {
            get { return nick; }
            set { nick = value; }
        }

        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        #endregion

        public event recibir recMsj;
        private clsManejoPaquetes msjPaquete;

        public clsManejoPaquetes MsjPaquete
        {
            get { return msjPaquete; }
            set { msjPaquete = value; }
        }
        public clsCliente(NetworkStream ntStream, StreamWriter sw, StreamReader sr, String nick)
        {
            stream = ntStream;
            streamw = sw;
            streamr = sr;
            this.nick = nick; 
            msjPaquete = new clsManejoPaquetes();
           clsMensajeBase m= new clsMensajeBase();
        }

        public void DataIn()
        {
            try
            {
                while (true) 
                {
                    String aux=streamr.ReadLine();
                    recMsj(msjPaquete.recibirMensaje(aux), nick);
                }
            }
            catch (Exception ex)
            {
                Console.ReadLine();
            }
        }

        public void enviar(clsMensajeBase msj)
        {
            try
            {
                streamw.WriteLine(msjPaquete.enviarMensaje(msj));
                streamw.Flush();
            }
            catch (System.IO.IOException e)
            {
                Console.ReadLine();
            }
            catch(System.Net.Sockets.SocketException e)
            {
                Console.ReadLine();
            }
        }


    }
}
