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
        clsJugador player;
        char letra;
        ICom com;

        public frmJuego()
        {
            InitializeComponent();
        }
        public frmJuego(clsJugador p, ICom c)
        {
            InitializeComponent();
            com = c;
            player = p;

        }
        private void btnArriesgar_Click(object sender, EventArgs e)
        {
            if (tbPalabra.Text.ToUpper() == devuelvePalabra())
            {
                MessageBox.Show("CORRECTO");
                habilitaPalabra();
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
        
        private void btnLetra_Click(object sender, EventArgs e)
        {
            /*if(lbPrimera.Text==tbLetra.Text.ToUpper())
            {
                lbPrimera.Visible = true;
            }
            if (lbSegunda.Text == tbLetra.Text.ToUpper())
            {
                lbSegunda.Visible = true;
            }
            if (lbTercera.Text == tbLetra.Text.ToUpper())
            {
                lbTercera.Visible = true;
            }
            if (lbCuarta.Text == tbLetra.Text.ToUpper())
            {
                lbCuarta.Visible = true;
            }
            if (lbQuinta.Text == tbLetra.Text.ToUpper())
            {
                lbQuinta.Visible = true;
            }
            if (lbSexta.Text == tbLetra.Text.ToUpper())
            {
                lbSexta.Visible = true;
            }
            if (lbSeptima.Text == tbLetra.Text.ToUpper())
            {
                lbSeptima.Visible = true;
            }
            if (lbOctava.Text == tbLetra.Text.ToUpper())
            {
                lbOctava.Visible = true;
            }
            if (lbNovena.Text == tbLetra.Text.ToUpper())
            {
                lbNovena.Visible = true;
            }
            if (lbDecima.Text == tbLetra.Text.ToUpper())
            {
                lbDecima.Visible = true;
            }
            if (lbPrimera.Text != tbLetra.Text.ToUpper() && lbSegunda.Text != tbLetra.Text.ToUpper() && lbTercera.Text != tbLetra.Text.ToUpper() && lbCuarta.Text != tbLetra.Text.ToUpper() && lbQuinta.Text != tbLetra.Text.ToUpper() && lbSexta.Text != tbLetra.Text.ToUpper() && lbSeptima.Text != tbLetra.Text.ToUpper() && lbOctava.Text != tbLetra.Text.ToUpper() && lbNovena.Text != tbLetra.Text.ToUpper() && lbDecima.Text != tbLetra.Text.ToUpper())
            {
                if(pbPiernaDerPintada.Visible==false)
                {
                    pbPiernaDerPintada.Visible = true;
                    pbPiernaDer.Visible = false;
                }
                else if(pbPiernaDerPintada.Visible==true && pbPiernaIzqPintada.Visible==false)
                {
                    pbPiernaIzqPintada.Visible = true;
                    pbPiernaIzq.Visible = false;
                }
                else if (pbPiernaDerPintada.Visible == true && pbPiernaIzqPintada.Visible == true && pbBrazoDerPintado.Visible==false)
                {
                    pbBrazoDerPintado.Visible = true;
                    pbBrazoDer.Visible = false;
                }
                else if (pbPiernaDerPintada.Visible == true && pbPiernaIzqPintada.Visible == true && pbBrazoDerPintado.Visible == true && pbBrazoIzqPintado.Visible==false)
                {
                    pbBrazoIzqPintado.Visible = true;
                    pbBrazoIzq.Visible = false;
                }
                else if (pbPiernaDerPintada.Visible == true && pbPiernaIzqPintada.Visible == true && pbBrazoIzqPintado.Visible == true && pbBrazoDerPintado.Visible == true && pbCabezaPintada.Visible==false)
                {
                    pbCabezaPintada.Visible = true;
                    pbCabeza.Visible = false;
                    MessageBox.Show("TE RE MIL AHORCASTE");
                    btnLetra.Enabled = false;
                    btnArriesgar.Enabled = false;
                }
            }
            */
            letra= tbLetra.Text.ToUpper()[0];
            if (!com.enviaLetra(player, letra))
                pintar();
            tbLetra.Clear();
            tbLetra.Focus();
        }
        private void frmJuego_Load(object sender, EventArgs e)
        {
            com.recibe += new ev_recibir(mostrarLetras);
        }



        private void habilitaLetra(Boolean t, int pos)
        {
            if (pos == 1)
            {
                lbPrimera.Visible = t;
            }
            if (pos == 2)
            {
                lbSegunda.Visible = t;
            }
            if (pos == 3)
            {
               
                lbTercera.Visible = t;
            }
            if (pos == 4)
            {
                
                lbCuarta.Visible = t;
            }
            if (pos == 5)
            {
                lbQuinta.Visible = t;
            }
            if (pos == 6)
            {
                lbSexta.Visible = t;
            }
            if (pos == 7)
            {
                lbSeptima.Visible = t;
            }
            if (pos == 8)
            {
                lbOctava.Visible = t;
            }
            if (pos == 9)
            {
                lbNovena.Visible = t;
            }
            if (pos == 10)
            {
                lbDecima.Visible = t;
            }
        }


        public void mostrarLetras(clsJugador p, string l)
        {
            if (lbPrimera.Text == l.ToUpper() && lbPrimera.Visible == false)
            {
                lbPrimera.ForeColor = p.Color;
                lbPrimera.Visible = true;
            }
            if (lbSegunda.Text == l.ToUpper() && lbSegunda.Visible == false)
            {
                lbSegunda.ForeColor = p.Color;
                lbSegunda.Visible = true;
            }
            if (lbTercera.Text == l.ToUpper() && lbTercera.Visible == false)
            {
                lbTercera.ForeColor = p.Color; 
                lbTercera.Visible = true;
            }
            if (lbCuarta.Text == l.ToUpper() && lbCuarta.Visible == false)
            {
                lbCuarta.ForeColor = p.Color;
                lbCuarta.Visible = true;
            }
            if (lbQuinta.Text == l.ToUpper() && lbQuinta.Visible == false)
            {
                lbQuinta.ForeColor = p.Color;
                lbQuinta.Visible = true;
            }
            if (lbSexta.Text == l.ToUpper() && lbSexta.Visible==false)
            {
                lbSexta.ForeColor = p.Color;
                lbSexta.Visible = true;
            }
            if (lbSeptima.Text == l.ToUpper() && lbSeptima.Visible==false)
            {
                lbSeptima.ForeColor = p.Color;
                lbSeptima.Visible = true;
            }
            if (lbOctava.Text == l.ToUpper() && lbOctava.Visible==false)
            {
                lbOctava.ForeColor = p.Color;
                lbOctava.Visible = true;
            }
            if (lbNovena.Text == l.ToUpper() && lbNovena.Visible==false)
            {
                lbNovena.ForeColor = p.Color;
                lbNovena.Visible = true;
            }
            if (lbDecima.Text == l.ToUpper() && lbDecima.Visible==false)
            {
                lbDecima.ForeColor = p.Color;
                lbDecima.Visible = true;
            }
        }

        public void pintar()
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
    }
}
