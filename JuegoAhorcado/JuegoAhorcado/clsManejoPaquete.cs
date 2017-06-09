using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JuegoAhorcado
{
    public delegate void delRec(clsMensaje msg);
    public delegate void delEnv(string strJSON);
    public class clsManejoPaquetes
    {
        clsMensaje mensaje = new clsMensaje();
        public clsManejoPaquetes()
        {

        }

        //una cola de string para deserializar
        public event delEnv Enviar;
        public event delRec Recibir;
        public clsMensaje recibirMensaje(string m)
        {
            try
            {
                mensaje = JsonConvert.DeserializeObject<clsMensaje>(m);
            }
            catch(Exception e)
            {
                mensaje = null;
            }
            return mensaje;
            //if (Recibir != null)
            //    Recibir(mensajedeserializado);
        }

        public void enviarMensaje(clsMensaje msg)
        {
            string mensajeserializado = JsonConvert.SerializeObject(msg);
            //if (Enviar != null)
            //{
            //    Enviar(mensajeserializado);
            //}
        }

    }
}