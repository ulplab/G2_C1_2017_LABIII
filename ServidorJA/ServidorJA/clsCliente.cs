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

    public delegate void recibir(clsMensaje mensaje, String nombre);
    class clsCliente
    {
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
            sw = streamw;
            sr = streamr;
            this.nick = nick;
            msjPaquete = new clsManejoPaquetes();
           clsMensaje m= new clsMensaje();
            m.Retorno="WAIT";

            enviar(m);
            
        }

        public void DataIn()
        {
            
            bool control = false;
            try
            {
                while (true) //client.Connected
                {
                    if (control == false)
                    {
                        recMsj(msjPaquete.recibirMensaje(streamr.ReadLine()),nick);
                        //streamw.WriteLine("WAIT");
                        //streamw.Flush();
                        //control = true;
                    }
                }
                //reader.Close();
                //stream.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void enviar(clsMensaje msj)
        {
            
            streamw.WriteLine(msjPaquete.enviarMensaje(msj));
            streamw.Flush();
        }

    }
}
