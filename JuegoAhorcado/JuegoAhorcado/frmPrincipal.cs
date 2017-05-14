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
                frmSala frmS = new frmSala(tbJugador.Text);
                this.Hide();
                frmS.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ingrese usuario para poder jugar", "CAMPOS OBLIGATORIOS", MessageBoxButtons.OKCancel);
            }
        }
    }
}
