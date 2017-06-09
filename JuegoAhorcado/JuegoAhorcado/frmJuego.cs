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
    
    public delegate void send(clsMensaje mensaje);
    public partial class frmJuego : Form
    {      
        clsCliente cliente;
        String nick;
        public event send send;
        public frmJuego(clsCliente cliente,String nick)
        {
            InitializeComponent();
            this.nick=nick;
            this.cliente = cliente;
        }


        private void btnArriesgar_Click(object sender, EventArgs e)
        {
            if (tbPalabra.Text != " " && tbPalabra.Text != "") // Checkear bien que no hayan varios espacios
            {
                tbPalabra.Text.ToUpper();
                //if (!com.enviaPalabra(player, env_palabra))
                //{
                //    pintarTodo();
                //}
            }
        }        
        private void btnLetra_Click(object sender, EventArgs e)
        {
            if (tbLetra.Text != " " && tbLetra.Text != "")
            {
             cliente.Mensaje.LetraPalabra=tbLetra.Text.ToUpper();
             cliente.Mensaje.Accion = Accion.ProbarLetra;
             send(cliente.Mensaje);
                
                //if (!com.enviaLetra(player, env_letra))
                //    pintarUna();
                tbLetra.Clear();
                tbLetra.Focus();
            }
        }
        private void frmJuego_Load(object sender, EventArgs e)
        {
            this.Text = "Juego Ahorcado - PLAYER " + this.nick;

            for (int i = 0; i < cliente.Mensaje.PalabraAhorcado.Length; i++)
            {
                foreach (Control c in pnlPalabra.Controls)
                {
                    if (c is Label && (c as Label).Name.Equals("lblGuion" + i.ToString()))
                    {
                        c.Visible = true;
                    }

                }

            }
        }





        private void habilitaLetra( string pal)
        {

            for (int i = 0; i <= pal.Length - 1; i++)
            {
                
                if (pal[i].ToString().Equals(pal))
                {
                   
                    foreach (Control c in pnlPalabra.Controls)
                    {
                        if (c is Label && !(c as Label).Text.Contains("_")&& (c as Label).Name.Equals("lb"+i.ToString()))
                        {
                            
                            Label l = (Label)c;
                            if (l.Visible == false )
                            {
                              //  l.ForeColor = p.Color;
                                l.Text = pal;
                                l.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        private void habilitaPalabra(Color cp)
        {
            if (cp != Color.Transparent)
             {
                // Habilitar los tb/lbl
                foreach (Control c in pnlPalabra.Controls)
                {
                    if (c is Label && !(c as Label).Text.Contains("_"))
                    {
                        Label l = (Label)c;
                        int posicionLetra = (int.Parse(l.Tag.ToString())) - 1;
                        if (l.Visible == false)
                        {
                            l.ForeColor = cp;
                            //l.Text = com.Palabra[posicionLetra].ToString();
                            l.Visible = true;
                        }
                    }
                }
            }
            else
                MessageBox.Show("Se acabo che...");
        }
        
        public void pintarUna()
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
                ahorcar();
            }
        }

        public void pintarTodo()
        {
            pbPiernaDerPintada.Visible = true;
            pbPiernaIzqPintada.Visible = true;
            pbBrazoDerPintado.Visible = true;
            pbBrazoIzqPintado.Visible = true;
            pbCabezaPintada.Visible = true;
            ahorcar();
        }

        private void ahorcar()
        {
            btnLetra.Enabled = false;
            btnArriesgar.Enabled = false;
            MessageBox.Show("TE RE MIL AHORCASTE");
            //com.recibe -= new ev_recibir(mostrarLetras);
           // com.recibe -= new ev_recibir(habilitaLetra);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
