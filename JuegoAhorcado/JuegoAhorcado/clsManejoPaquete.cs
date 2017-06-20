using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClasesComunicacion;

namespace JuegoAhorcado
{
   public class clsManejoPaquetes
    {
        public clsMensajeBase recibirMensaje(string mensaje)
        {
            

                clsMensajeBase convertido=JsonConvert.DeserializeObject<clsMensajeBase>(mensaje);
                switch (convertido.Tipo)
                {
                    case "MENSAJE_PARTIDA":
                        clsMensajePartida retorno1 = JsonConvert.DeserializeObject<clsMensajePartida>(mensaje);
                        return retorno1;
                        
                    case "MENSAJE_JUEGO":
                        clsMensajeJuego retorno2 = JsonConvert.DeserializeObject<clsMensajeJuego>(mensaje);
                        return retorno2;

                    default: return null;
                    
                        
                }

            


           
        }

        public string enviarMensaje(clsMensajeBase msj)
        {
            return JsonConvert.SerializeObject(msj);
        }
     }
}