using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServidorJA
{
    public delegate void delRec(clsMensaje msg);
    public delegate void delEnv(string strJSON,clsMensaje a);
    
    public class clsManejoPaquetes
    {



        string msje;
        clsMensaje mensajedeserializado = new clsMensaje();

        public clsMensaje Mensajedeserializado
        {
            get
            {
                return mensajedeserializado;
            }

            set
            {
                mensajedeserializado = value;
            }
        }

        public clsManejoPaquetes()
        {

        }

        //una cola de string para deserializar
        public event delEnv Enviar;
        public event delRec Recibir;
        public void recibirMensaje(string mensaje)
        {
            this.msje = mensaje;
            Mensajedeserializado = JsonConvert.DeserializeObject<clsMensaje>(this.msje);
            if (Recibir != null)
                Recibir(Mensajedeserializado);

            enviarMensaje();
        }

        public void enviarMensaje()
        {
            string mensajeserializado = JsonConvert.SerializeObject(this.mensajedeserializado);
            if (Enviar != null)
            {
                Enviar(mensajeserializado,Mensajedeserializado);
            }
        }
           }
}