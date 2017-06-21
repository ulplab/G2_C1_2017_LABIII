using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClasesComunicacion;

namespace ServidorJA
{
    public class clsManejoPaquetes
    {
        public clsMensajeBase recibirMensaje(string mensaje)
        {
            clsMensajeBase convertido = JsonConvert.DeserializeObject<clsMensajeBase>(mensaje);
            switch (convertido.Tipo)
            {
                case "MENSAJE_PARTIDA":
                    clsMensajePartida retorno1 = JsonConvert.DeserializeObject<clsMensajePartida>(mensaje);
                    return retorno1;

                case "MENSAJE_JUEGO":
                    clsMensajeJuego retorno2 = JsonConvert.DeserializeObject<clsMensajeJuego>(mensaje);
                    return retorno2;

                case "MENSAJE_PERDEDOR":
                    clsMensajePerdedor retorno3 = JsonConvert.DeserializeObject<clsMensajePerdedor>(mensaje);
                    return retorno3;

                case "MENSAJE_GANADOR":
                    clsMensajeGanador retorno4 = JsonConvert.DeserializeObject<clsMensajeGanador>(mensaje);
                    return retorno4;

                case "MENSAJE_TIMER":
                    clsMensajeTimer retorno5 = JsonConvert.DeserializeObject<clsMensajeTimer>(mensaje);
                    return retorno5;

                default: return convertido;

            }
        }

        public string enviarMensaje(clsMensajeBase msj)
        {
            return JsonConvert.SerializeObject(msj);
        }
    }
}