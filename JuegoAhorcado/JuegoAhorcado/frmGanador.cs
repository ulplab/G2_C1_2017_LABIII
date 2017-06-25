using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasesComunicacion;
using System.Threading;

namespace JuegoAhorcado
{
    public partial class frmGanador : Form
    {
        clsCliente cliente;
        public frmGanador(String ganador,clsCliente cliente)
        {
            InitializeComponent();
            lbGanador.Text = ganador.ToUpper();
            //this.cliente = cliente;
            //Thread t = new Thread(sigRonda);
            //t.Start();
        }
        //public void sigRonda()
        //{
        //    for (int i = 5; i >= 0;i-- )
        //    {
        //        this.Invoke(new Action(() =>
        //            {
        //                lbTimeSigRonda.Text = i.ToString();
        //            }));
        //        Thread.Sleep(1000);
        //        this.Invoke(new Action(() =>
        //        {
        //            this.Close();
        //        }));
                
        //        //clsMensajeSigRonda msjSigRonda = new clsMensajeSigRonda();
        //        //msjSigRonda.Accion = "SIGUIENTE_RONDA";
        //        //frmJuego frmJuego = new frmJuego(null, null, null);
        //        //frmJuego.limpiarForm();
        //        //cliente.enviar((clsMensajeBase)msjSigRonda);
        //    }
            

        //}
    }
}
