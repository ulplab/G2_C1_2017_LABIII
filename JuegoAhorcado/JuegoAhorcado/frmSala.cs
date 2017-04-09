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
    public partial class frmSala : Form
    {
        String jugador;
        public frmSala(String jugador)
        {
            InitializeComponent();
            this.jugador = jugador;
        }

        private void frmSala_Load(object sender, EventArgs e)
        {
            lbJ1S1.Text = jugador.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmPrincipal frmPrincipal = new frmPrincipal();
            frmPrincipal.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            frmJuego frmJuego = new frmJuego(jugador);
            frmJuego.ShowDialog();
            this.Hide();
        }
    }
}
