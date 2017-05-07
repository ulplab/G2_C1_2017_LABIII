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
    public partial class frmJuegoJ2 : Form
    {
        String jugador;
        int cuentaPerdidas;
        public static frmJuegoJ2 formJuegoJ2 = new frmJuegoJ2();
        public delegate void adivinaLetra(Boolean t, int Pos);
        public event adivinaLetra habilitaLetraJ2;

        public frmJuegoJ2()
        {
            InitializeComponent();
        }
        public frmJuegoJ2(String jugador)
        {
            InitializeComponent();
            this.jugador = jugador;
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
        private void frmJuegoJ2_Load(object sender, EventArgs e)
        {
            frmJuego.formJuegoJ1.habilitaLetraJ1 += new frmJuego.adivinaLetra(habilitaLetra);
        }
        private void habilitaLetra(Boolean t, int pos)
        {
            if (pos == 1)
            {
                pnJ1P1.Visible = t;
                lbPrimera.Visible = t;
            }
            if (pos == 2)
            {
                pnJ1P2.Visible = t;
                lbSegunda.Visible = t;
            }
            if (pos == 3)
            {
                pnJ1P3.Visible = t;
                lbTercera.Visible = t;
            }
            if (pos == 4)
            {
                pnJ1P4.Visible = t;
                lbCuarta.Visible = t;
            }
            if (pos == 5)
            {
                pnJ1P5.Visible = t;
                lbQuinta.Visible = t;
            }
            if (pos == 6)
            {
                pnJ1P6.Visible = t;
                lbSexta.Visible = t;
            }
            if (pos == 7)
            {
                pnJ1P7.Visible = t;
                lbSeptima.Visible = t;
            }
            if (pos == 8)
            {
                pnJ1P8.Visible = t;
                lbOctava.Visible = t;
            }
            if (pos == 9)
            {
                pnJ1P9.Visible = t;
                lbNovena.Visible = t;
            }
            if (pos == 10)
            {
                pnJ1P10.Visible = t;
                lbDecima.Visible = t;
            }
        }
        private void btnLetra_Click_1(object sender, EventArgs e)
        {
            if (lbPrimera.Text == tbLetra.Text.ToUpper())
            {
                pnJ2P1.Visible = true;
                lbPrimera.Visible = true;
                this.habilitaLetraJ2(true, 1);
            }
            if (lbSegunda.Text == tbLetra.Text.ToUpper())
            {
                pnJ2P2.Visible = true;
                lbSegunda.Visible = true;
                this.habilitaLetraJ2(true, 2);
            }
            if (lbTercera.Text == tbLetra.Text.ToUpper())
            {
                pnJ2P3.Visible = true;
                lbTercera.Visible = true;
                this.habilitaLetraJ2(true, 3);
            }
            if (lbCuarta.Text == tbLetra.Text.ToUpper())
            {
                pnJ2P4.Visible = true;
                lbCuarta.Visible = true;
                this.habilitaLetraJ2(true, 4);
            }
            if (lbQuinta.Text == tbLetra.Text.ToUpper())
            {
                pnJ2P5.Visible = true;
                lbQuinta.Visible = true;
                this.habilitaLetraJ2(true, 5);
            }
            if (lbSexta.Text == tbLetra.Text.ToUpper())
            {
                pnJ2P6.Visible = true;
                lbSexta.Visible = true;
                this.habilitaLetraJ2(true, 6);
            }
            if (lbSeptima.Text == tbLetra.Text.ToUpper())
            {
                pnJ2P7.Visible = true;
                lbSeptima.Visible = true;
                this.habilitaLetraJ2(true, 7);
            }
            if (lbOctava.Text == tbLetra.Text.ToUpper())
            {
                pnJ2P8.Visible = true;
                lbOctava.Visible = true;
                this.habilitaLetraJ2(true, 8);
            }
            if (lbNovena.Text == tbLetra.Text.ToUpper())
            {
                pnJ2P9.Visible = true;
                lbNovena.Visible = true;
                this.habilitaLetraJ2(true, 9);
            }
            if (lbDecima.Text == tbLetra.Text.ToUpper())
            {
                pnJ2P10.Visible = true;
                lbDecima.Visible = true;
                this.habilitaLetraJ2(true, 10);
            }
            if (lbPrimera.Text != tbLetra.Text.ToUpper() && lbSegunda.Text != tbLetra.Text.ToUpper() && lbTercera.Text != tbLetra.Text.ToUpper() && lbCuarta.Text != tbLetra.Text.ToUpper() && lbQuinta.Text != tbLetra.Text.ToUpper() && lbSexta.Text != tbLetra.Text.ToUpper() && lbSeptima.Text != tbLetra.Text.ToUpper() && lbOctava.Text != tbLetra.Text.ToUpper() && lbNovena.Text != tbLetra.Text.ToUpper() && lbDecima.Text != tbLetra.Text.ToUpper())
            {
                if (pbPiernaDerPintada.Visible == false)
                {
                    pbPiernaDerPintada.Visible = true;
                    pbPiernaDer.Visible = false;
                }
                else if (pbPiernaDerPintada.Visible == true && pbPiernaIzqPintada.Visible == false)
                {
                    pbPiernaIzqPintada.Visible = true;
                    pbPiernaIzq.Visible = false;
                }
                else if (pbPiernaDerPintada.Visible == true && pbPiernaIzqPintada.Visible == true && pbBrazoDerPintado.Visible == false)
                {
                    pbBrazoDerPintado.Visible = true;
                    pbBrazoDer.Visible = false;
                }
                else if (pbPiernaDerPintada.Visible == true && pbPiernaIzqPintada.Visible == true && pbBrazoDerPintado.Visible == true && pbBrazoIzqPintado.Visible == false)
                {
                    pbBrazoIzqPintado.Visible = true;
                    pbBrazoIzq.Visible = false;
                }
                else if (pbPiernaDerPintada.Visible == true && pbPiernaIzqPintada.Visible == true && pbBrazoIzqPintado.Visible == true && pbBrazoDerPintado.Visible == true && pbCabezaPintada.Visible == false)
                {
                    pbCabezaPintada.Visible = true;
                    pbCabeza.Visible = false;
                    MessageBox.Show("TE RE MIL AHORCASTE");
                    btnLetra.Enabled = false;
                    btnArriesgar.Enabled = false;
                }
            }
            tbLetra.Clear();
            tbLetra.Focus();
        }
        private void btnArriesgar_Click_1(object sender, EventArgs e)
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
    }
}
