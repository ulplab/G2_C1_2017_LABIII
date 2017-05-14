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
        Color color;


        public frmSala(String jugador)
        {
            InitializeComponent();
            this.jugador = jugador.ToUpper();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(lbJ1S1.Text!=String.Empty ||lbJ2S1.Text!=String.Empty ||lbJ3S1.Text!=String.Empty ||lbJ4S1.Text!=String.Empty ||lbJ1S2.Text!=String.Empty ||lbJ2S2.Text!=String.Empty ||lbJ3S2.Text!=String.Empty ||lbJ4S2.Text!=String.Empty)
            {
                clsControlador control = new clsControlador("laberintos");
                
                clsJugador p1 = new clsJugador(jugador, color);
                clsJugador p2 = new clsJugador("maria", Color.Black);

                frmJuego frmP1 = new frmJuego(p1, control);
                frmP1.Show();
                frmJuego frmP2 = new frmJuego(p2, control);
                frmP2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Seleccione sala y color");
            }
        }

        private void btnP1S1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            lbJ1S1.Text = jugador;
            btnP2S1.Enabled = false;
            btnP3S1.Enabled = false;
            btnP4S1.Enabled = false;
            btnP1S2.Enabled = false;
            btnP2S2.Enabled = false;
            btnP3S2.Enabled = false;
            btnP4S2.Enabled = false;
            color = b.BackColor;
        }

        private void btnP2S1_Click(object sender, EventArgs e)
        {
            lbJ2S1.Text = jugador;
            btnP1S1.Enabled = false;
            btnP3S1.Enabled = false;
            btnP4S1.Enabled = false;
            btnP1S2.Enabled = false;
            btnP2S2.Enabled = false;
            btnP3S2.Enabled = false;
            btnP4S2.Enabled = false;
            //color = this.BackColor.Name;
        }

        private void btnP3S1_Click(object sender, EventArgs e)
        {
            lbJ3S1.Text = jugador;
            btnP1S1.Enabled = false;
            btnP2S1.Enabled = false;
            btnP4S1.Enabled = false;
            btnP1S2.Enabled = false;
            btnP2S2.Enabled = false;
            btnP3S2.Enabled = false;
            btnP4S2.Enabled = false;
            //color = this.BackColor.Name;
        }

        private void btnP4S1_Click(object sender, EventArgs e)
        {
            lbJ4S1.Text = jugador;
            btnP1S1.Enabled = false;
            btnP2S1.Enabled = false;
            btnP3S1.Enabled = false;
            btnP1S2.Enabled = false;
            btnP2S2.Enabled = false;
            btnP3S2.Enabled = false;
            btnP4S2.Enabled = false;
            //color = this.BackColor.Name;
        }

        private void btnP1S2_Click(object sender, EventArgs e)
        {
            lbJ1S2.Text = jugador;
            btnP1S1.Enabled = false;
            btnP2S1.Enabled = false;
            btnP3S1.Enabled = false;
            btnP4S1.Enabled = false;
            btnP2S2.Enabled = false;
            btnP3S2.Enabled = false;
            btnP4S2.Enabled = false;
            //color = this.BackColor.Name;
        }

        private void btnP2S2_Click(object sender, EventArgs e)
        {
            lbJ2S2.Text = jugador;
            btnP1S1.Enabled = false;
            btnP2S1.Enabled = false;
            btnP3S1.Enabled = false;
            btnP4S1.Enabled = false;
            btnP1S2.Enabled = false;
            btnP3S2.Enabled = false;
            btnP4S2.Enabled = false;
            //color = this.BackColor.Name;
        }

        private void btnP3S2_Click(object sender, EventArgs e)
        {
            lbJ3S2.Text = jugador;
            btnP1S1.Enabled = false;
            btnP2S1.Enabled = false;
            btnP3S1.Enabled = false;
            btnP4S1.Enabled = false;
            btnP1S2.Enabled = false;
            btnP2S2.Enabled = false;
            btnP4S2.Enabled = false;
            //color = this.BackColor.Name;
        }

        private void btnP4S2_Click(object sender, EventArgs e)
        {
            lbJ4S2.Text = jugador;
            btnP1S1.Enabled = false;
            btnP2S1.Enabled = false;
            btnP3S1.Enabled = false;
            btnP4S1.Enabled = false;
            btnP1S2.Enabled = false;
            btnP2S2.Enabled = false;
            btnP3S2.Enabled = false;
            //color = this.BackColor.Name;
        }
    }
}
