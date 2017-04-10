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
    public partial class frmJuego : Form
    {
        String jugador;
        public frmJuego(String jugador)
        {
            InitializeComponent();
            this.jugador = jugador;
        }

        private void btnArriesgar_Click(object sender, EventArgs e)
        {
            if (tbPalabra.Text.ToUpper() == devuelvePalabra())
            {
                MessageBox.Show("CORRECTO");
                habilitaPalabra();
                habilitaCompletaPlayer1();
            }
            else
                MessageBox.Show("TE RE MIL AHORCASTE");
        }

        private string devuelvePalabra()
        {
            return lbPrimera.Text + lbSegunda.Text + lbTercera.Text + lbCuarta.Text + lbQuinta.Text + lbSexta.Text + lbSeptima.Text + lbOctava.Text + lbNovena.Text + lbDecima.Text;
        }

        private void habilitaPalabra()
        {
            lbPrimera.Visible = true;
            lbSegunda.Visible = true;
            lbTercera.Visible = true;
            lbCuarta.Visible = true;
            lbQuinta.Visible = true;
            lbSexta.Visible = true;
            lbSeptima.Visible = true;
            lbOctava.Visible = true;
            lbNovena.Visible = true;
            lbDecima.Visible = true;
        }

        private void habilitaCompletaPlayer1()
        {
            pnJ1P1.Visible = true;
            pnJ1P2.Visible = true;
            pnJ1P3.Visible = true;
            pnJ1P4.Visible = true;
            pnJ1P5.Visible = true;
            pnJ1P6.Visible = true;
            pnJ1P7.Visible = true;
            pnJ1P8.Visible = true;
            pnJ1P9.Visible = true;
            pnJ1P10.Visible = true;
        }
        private void habilitaCompletaPlayer2()
        {
            pnJ2P1.Visible = true;
            pnJ2P2.Visible = true;
            pnJ2P3.Visible = true;
            pnJ2P4.Visible = true;
            pnJ2P5.Visible = true;
            pnJ2P6.Visible = true;
            pnJ2P7.Visible = true;
            pnJ2P8.Visible = true;
            pnJ2P9.Visible = true;
            pnJ2P10.Visible = true;
        }
        private void habilitaCompletaPlayer3()
        {
            pnJ3P1.Visible = true;
            pnJ3P2.Visible = true;
            pnJ3P3.Visible = true;
            pnJ3P4.Visible = true;
            pnJ3P5.Visible = true;
            pnJ3P6.Visible = true;
            pnJ3P7.Visible = true;
            pnJ3P8.Visible = true;
            pnJ3P9.Visible = true;
            pnJ3P10.Visible = true;
        }
        private void habilitaCompletaPlayer4()
        {
            pnJ4P1.Visible = true;
            pnJ4P2.Visible = true;
            pnJ4P3.Visible = true;
            pnJ4P4.Visible = true;
            pnJ4P5.Visible = true;
            pnJ4P6.Visible = true;
            pnJ4P7.Visible = true;
            pnJ4P8.Visible = true;
            pnJ4P9.Visible = true;
            pnJ4P10.Visible = true;
        }

        private void btnLetra_Click(object sender, EventArgs e)
        {
            if(lbPrimera.Text==tbLetra.Text.ToUpper())
            {
                pnJ1P1.Visible = true;
                lbPrimera.Visible = true;
            }
            if (lbSegunda.Text == tbLetra.Text.ToUpper())
            {
                pnJ1P2.Visible = true;
                lbSegunda.Visible = true;
            }
            if (lbTercera.Text == tbLetra.Text.ToUpper())
            {
                pnJ1P3.Visible = true;
                lbTercera.Visible = true;
            }
            if (lbCuarta.Text == tbLetra.Text.ToUpper())
            {
                pnJ1P4.Visible = true;
                lbCuarta.Visible = true;
            }
            if (lbQuinta.Text == tbLetra.Text.ToUpper())
            {
                pnJ1P5.Visible = true;
                lbQuinta.Visible = true;
            }
            if (lbSexta.Text == tbLetra.Text.ToUpper())
            {
                pnJ1P6.Visible = true;
                lbSexta.Visible = true;
            }
            if (lbSeptima.Text == tbLetra.Text.ToUpper())
            {
                pnJ1P7.Visible = true;
                lbSeptima.Visible = true;
            }
            if (lbOctava.Text == tbLetra.Text.ToUpper())
            {
                pnJ1P8.Visible = true;
                lbOctava.Visible = true;
            }
            if (lbNovena.Text == tbLetra.Text.ToUpper())
            {
                pnJ1P9.Visible = true;
                lbNovena.Visible = true;
            }
            if (lbDecima.Text == tbLetra.Text.ToUpper())
            {
                pnJ1P10.Visible = true;
                lbDecima.Visible = true;
            }
            tbLetra.Clear();
            tbLetra.Focus();
        }
    }
}
