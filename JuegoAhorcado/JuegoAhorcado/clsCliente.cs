﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using ClasesComunicacion;

namespace JuegoAhorcado
{
    public delegate void enviar(string Json);
    public delegate void enviaFrmJuego(clsMensajeBase msj);
    public delegate void comienzo(clsMensajeBase msj);


    public class clsCliente
    {
        //clsJugador player;
        TcpClient client;
        static int port = 8000;
        clsMensajeBase mensaje;
        private String nick;
        public String Nick
        {
            get { return nick; }
            set { nick = value; }
        }
        public clsMensajeBase Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        clsManejoPaquetes serializador = new clsManejoPaquetes();
        static private NetworkStream stream;
        static private StreamWriter streamw;
        static private StreamReader streamr;
        public event comienzo start;
        public event enviaFrmJuego acertoLetra;
        public event enviaFrmJuego falloLetra;
        public event enviaFrmJuego acertoPalabra;
        public event enviaFrmJuego falloPalabra;
        public void leer()
        {
            while (true)
            {
                string aux = streamr.ReadLine();
                mensaje = serializador.recibirMensaje(aux);  //pto de corte sab 17
                if (mensaje.Retorno != "FALLO" && mensaje.Accion =="PROBAR_LETRA")
                    acertoLetra(mensaje);
                else if (mensaje.Retorno == "FALLO" && mensaje.Accion == "PROBAR_LETRA")
                    falloLetra(mensaje);
                if (mensaje.Retorno != "FALLO" && mensaje.Accion == "PROBAR_PALABRA")
                    acertoPalabra(mensaje);
                else if (mensaje.Retorno == "FALLO" && mensaje.Accion == "PROBAR_PALABRA")
                    falloPalabra(mensaje);
            }
        }            
        public void Iniciar()
        {
            try
            {
                client = new TcpClient("127.0.0.1", port);
                Console.WriteLine("Client conectado.");
                stream = client.GetStream();
                streamw = new StreamWriter(stream);
                streamr = new StreamReader(stream);
                clsMensajeBase msjNick = new clsMensajeBase();
                msjNick.Nick = nick;
                streamw.WriteLine(serializador.enviarMensaje(msjNick)); 
                streamw.Flush();


                string aux = streamr.ReadLine();
                mensaje = serializador.recibirMensaje(aux);
                start(mensaje);
                Thread t = new Thread(leer);
                t.Start();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex+"Client Disconnected.");
            }
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
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        public void enviar(clsMensajeBase msj)
        {
            try
            {
                string aux = serializador.enviarMensaje(msj);
                streamw.WriteLine(aux);
                streamw.Flush();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

    }
}
