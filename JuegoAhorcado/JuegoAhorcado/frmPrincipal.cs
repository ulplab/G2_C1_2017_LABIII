using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace JuegoAhorcado
{
    public partial class frmPrincipal : Form
    {
        static clsCliente cliente = new clsCliente();
        public frmPrincipal()
        {
            InitializeComponent();
            cliente.start += comenzar;
        }
        private void btnJugar_Click(object sender, EventArgs e)
        {
            if(tbJugador.Text!=String.Empty || tbJugador.Text.Length>4)
            {
                cliente.Nick = tbJugador.Text;
                Thread comienzo = new Thread(cliente.Iniciar);
                comienzo.Start();
                tbJugador.Enabled = false;
                btnJugar.Enabled = false;
                btnInstrucciones.Enabled = false;
                btnExit.Enabled = false;
            }
            else
            {
                MessageBox.Show("Ingrese usuario para poder jugar", "CAMPOS OBLIGATORIOS", MessageBoxButtons.OKCancel);
            }
        }

        public void comenzar(clsMensaje msg)
        {
            if (msg.Retorno != "WAIT")
            {
                frmJuego frmP1 = new frmJuego(cliente, tbJugador.Text);
                this.Invoke(new Action(() =>
                {
                    frmP1.Show();
                    this.Hide();
                    cliente.Mensaje = msg;
                }));
            }
            else
                MessageBox.Show("ESPERA DEMAS JUGADORES");
        }

    }
}
