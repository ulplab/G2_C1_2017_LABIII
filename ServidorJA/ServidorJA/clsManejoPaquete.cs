using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServidorJA
{
    public delegate void delRec(clsMensaje msg);
    //public delegate void delEnv(string strJSON,clsMensaje a);
    public class clsManejoPaquetes
    {

        delRec Recibe;
        string msje;
        clsMensaje msjPaquete = new clsMensaje();

        public clsMensaje MsjPaquete
        {
            get
            {
                return msjPaquete;
            }

            set
            {
                msjPaquete = value;
            }
        }

        public clsMensaje recibirMensaje(string mensaje)
        {
            this.msje = mensaje;
            return JsonConvert.DeserializeObject<clsMensaje>(this.msje);

        }

        public string enviarMensaje(clsMensaje msj)
        {
            return JsonConvert.SerializeObject(msj);
        }
     }
}