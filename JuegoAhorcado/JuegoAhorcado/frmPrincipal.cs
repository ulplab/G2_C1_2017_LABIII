using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoAhorcado
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            if(tbJugador.Text!=String.Empty || tbJugador.Text.Length>4)
            {
                clsJuego sala = new clsJuego();
                clsJugador p1 = new clsJugador(tbJugador.Text, Color.Orange);
                clsJugador p2 = new clsJugador("maria", Color.Green);
                sala.GeneraPalabra();//genero palabra para probar
                sala.agregarJugador(p1);
                sala.agregarJugador(p2);

                frmJuego frmP1 = new frmJuego(p1, sala);
                frmP1.Show();
                frmJuego frmP2 = new frmJuego(p2, sala);
                frmP2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ingrese usuario para poder jugar", "CAMPOS OBLIGATORIOS", MessageBoxButtons.OKCancel);
            }
        }
    }
}
