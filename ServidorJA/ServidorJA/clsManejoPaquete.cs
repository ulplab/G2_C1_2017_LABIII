using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServidorJA
{
    public delegate void delRec(clsMensaje msg);
    public delegate void delEnv(string strJSON);
    public class clsManejoPaquetes
    {
        public clsManejoPaquetes()
        {

        }

        //una cola de string para deserializar
        public event delEnv Enviar;
        public event delRec Recibir;
        public void recibirMensaje(string mensaje)
        {
            clsMensaje mensajedeserializado = JsonConvert.DeserializeObject<clsMensaje>(mensaje);
            if (Recibir != null)
                Recibir(mensajedeserializado);
        }

        public void enviarMensaje(clsMensaje msg)
        {
            string mensajeserializado = JsonConvert.SerializeObject(msg);
            if (Enviar != null)
            {
                Enviar(mensajeserializado);
            }
        }

    }
}