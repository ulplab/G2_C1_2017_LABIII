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
    public delegate void enviaLetra(clsMensaje mensaje);
    public partial class frmJuego : Form
    {      
        clsCliente cliente;
        String nick;

        public frmJuego(clsCliente cliente,String nick)
        {
            InitializeComponent();
            this.nick=nick;
            this.cliente = cliente;
            cliente.acertoLetra += habilitaLetra;
            cliente.falloLetra += fallaLetra;
            cliente.acertoPalabra += habilitaPalabra;
            cliente.falloPalabra += fallaPalabra;
            string palabra = cliente.Mensaje.PalabraAhorcado;
            Char[] palabraIndice = palabra.ToCharArray();
            foreach(clsJugador c in cliente.Mensaje.ListaJugadores)
            {
                lbJugadores.Items.Add(c.Nick);
            }
        }
        private void btnArriesgar_Click(object sender, EventArgs e)
        {
            if (tbPalabra.Text != " " && tbPalabra.Text != "") // Checkear bien que no hayan varios espacios
            {
                clsMensaje msj = new clsMensaje();
                msj.LetraPalabra = tbPalabra.Text.ToUpper();
                msj.Accion = "PROBAR_PALABRA";
                msj.Nick = cliente.Nick;
                cliente.enviar(msj);
            }
        }        
        private void btnLetra_Click(object sender, EventArgs e)
        {
            if (tbLetra.Text != " " && tbLetra.Text != "")
            {
                clsMensaje msj = new clsMensaje();
                 msj.LetraPalabra=tbLetra.Text.ToUpper();
                 msj.Accion = "PROBAR_LETRA";
                 msj.Nick = cliente.Nick;
                 cliente.enviar(msj);
                
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
        private void habilitaLetra(clsMensaje msj) 
        {
            List<int> posiciones = msj.PosicionLetra;
            for(int i=0;i<posiciones.Count;i++)
            {
                if (posiciones[i] == 0)
                    this.Invoke(new Action(() =>
                    {
                        lb0.Text = msj.LetraPalabra;
                    }));
                else if (posiciones[i] == 1)
                    this.Invoke(new Action(() =>
                    {
                        lb1.Text = msj.LetraPalabra;
                    }));
                else if (posiciones[i] == 2)
                    this.Invoke(new Action(() =>
                    {
                        lb2.Text = msj.LetraPalabra;
                    }));
                else if (posiciones[i] == 3)
                    this.Invoke(new Action(() =>
                    {
                        lb3.Text = msj.LetraPalabra;
                    }));
                else if (posiciones[i] == 4)
                    this.Invoke(new Action(() =>
                    {
                        lb4.Text = msj.LetraPalabra;
                    }));
                else if (posiciones[i] == 5)
                    this.Invoke(new Action(() =>
                    {
                        lb5.Text = msj.LetraPalabra;
                    }));
                else if (posiciones[i] == 6)
                    this.Invoke(new Action(() =>
                    {
                        lb6.Text = msj.LetraPalabra;
                    }));
                else if (posiciones[i] == 7)
                    this.Invoke(new Action(() =>
                    {
                        lb7.Text = msj.LetraPalabra;
                    }));
                else if (posiciones[i] == 8)
                    this.Invoke(new Action(() =>
                    {
                        lb8.Text = msj.LetraPalabra;
                    }));
                else if (posiciones[i] == 9)
                    this.Invoke(new Action(() =>
                    {
                        lb9.Text = msj.LetraPalabra;
                    }));
                else if (posiciones[i] == 10)
                    this.Invoke(new Action(() =>
                    {
                        lb10.Text = msj.LetraPalabra;
                    }));
                else if (posiciones[i] == 11)
                    this.Invoke(new Action(() =>
                    {
                        lb11.Text = msj.LetraPalabra;
                    }));
                else if (posiciones[i] == 12)
                    this.Invoke(new Action(() =>
                    {
                        lb12.Text = msj.LetraPalabra;
                    }));
                else if (posiciones[i] == 13)
                    this.Invoke(new Action(() =>
                    {
                        lb13.Text = msj.LetraPalabra;
                    }));
            }

        }
        private void fallaLetra(clsMensaje msj)
        {
            MessageBox.Show("FALLASTE, TENE CUIDADO QUE LA SOGA APRETA");
            pintarUna();
        }

        //private void habilitaLetra( string pal)
        //{
        //    for (int i = 0; i <= pal.Length - 1; i++)
        //    {

        //        if (pal[i].ToString().Equals(pal))
        //        {

        //            foreach (Control c in pnlPalabra.Controls)
        //            {
        //                if (c is Label && !(c as Label).Text.Contains("_") && (c as Label).Name.Equals("lb" + i.ToString()))
        //                {

        //                    Label l = (Label)c;
        //                    if (l.Visible == false) 
        //                    {
        //                        this.Invoke(new Action(() =>
        //                        {
        //                            l.Text = pal;
        //                            l.Visible = true;
        //                        }));
        //                        //  l.ForeColor = p.Color;
                                
        //                    }
        //                }
        //            }
        //        }
        //    }
            
        //}
        //private void habilitaPalabra(Color cp)
        //{
        //    if (cp != Color.Transparent)
        //     {
        //        // Habilitar los tb/lbl
        //        foreach (Control c in pnlPalabra.Controls)
        //        {
        //            if (c is Label && !(c as Label).Text.Contains("_"))
        //            {
        //                Label l = (Label)c;
        //                int posicionLetra = (int.Parse(l.Tag.ToString())) - 1;
        //                if (l.Visible == false)
        //                {
        //                    l.ForeColor = cp;
        //                    //l.Text = com.Palabra[posicionLetra].ToString();
        //                    l.Visible = true;
        //                }
        //            }
        //        }
        //    }
        //    else
        //        MessageBox.Show("Se acabo che...");
        //}
        private void habilitaPalabra(clsMensaje msj)
        {
            int cant=msj.PalabraAhorcado.Length;
            for (int i = 0; i < cant; i++)
            {
                if (i == 0)
                    this.Invoke(new Action(() =>
                    {
                        lb0.Text = msj.LetraPalabra;
                    }));
                else if (i == 1)
                    this.Invoke(new Action(() =>
                    {
                        lb1.Text = msj.LetraPalabra;
                    }));
                else if (i == 2)
                    this.Invoke(new Action(() =>
                    {
                        lb2.Text = msj.LetraPalabra;
                    }));
                else if (i == 3)
                    this.Invoke(new Action(() =>
                    {
                        lb3.Text = msj.LetraPalabra;
                    }));
                else if (i == 4)
                    this.Invoke(new Action(() =>
                    {
                        lb4.Text = msj.LetraPalabra;
                    }));
                else if (i == 5)
                    this.Invoke(new Action(() =>
                    {
                        lb5.Text = msj.LetraPalabra;
                    }));
                else if (i == 6)
                    this.Invoke(new Action(() =>
                    {
                        lb6.Text = msj.LetraPalabra;
                    }));
                else if (i == 7)
                    this.Invoke(new Action(() =>
                    {
                        lb7.Text = msj.LetraPalabra;
                    }));
                else if (i == 8)
                    this.Invoke(new Action(() =>
                    {
                        lb8.Text = msj.LetraPalabra;
                    }));
                else if (i == 9)
                    this.Invoke(new Action(() =>
                    {
                        lb9.Text = msj.LetraPalabra;
                    }));
                else if (i == 10)
                    this.Invoke(new Action(() =>
                    {
                        lb10.Text = msj.LetraPalabra;
                    }));
                else if (i == 11)
                    this.Invoke(new Action(() =>
                    {
                        lb11.Text = msj.LetraPalabra;
                    }));
                else if (i == 12)
                    this.Invoke(new Action(() =>
                    {
                        lb12.Text = msj.LetraPalabra;
                    }));
                else if (i == 13)
                    this.Invoke(new Action(() =>
                    {
                        lb13.Text = msj.LetraPalabra;
                    }));
            }
        }
        private void fallaPalabra(clsMensaje msj)
        {
            pintarTodo();
        }
        public void pintarUna()
        {
            if (pbPiernaDerPintada.Visible == false)
            {
                this.Invoke(new Action(() =>
                {
                    pbPiernaDerPintada.Visible = true;
                    pbPiernaDer.Visible = false;
                }));  
            }
            else if (pbPiernaDerPintada.Visible == true && pbPiernaIzqPintada.Visible == false)
            {
                this.Invoke(new Action(() =>
                {
                    pbPiernaIzqPintada.Visible = true;
                    pbPiernaIzq.Visible = false;
                }));
            }
            else if (pbPiernaDerPintada.Visible == true && pbPiernaIzqPintada.Visible == true && pbBrazoDerPintado.Visible == false)
            {
                this.Invoke(new Action(() =>
                {
                    pbBrazoDerPintado.Visible = true;
                    pbBrazoDer.Visible = false;
                }));
            }
            else if (pbPiernaDerPintada.Visible == true && pbPiernaIzqPintada.Visible == true && pbBrazoDerPintado.Visible == true && pbBrazoIzqPintado.Visible == false)
            {
                this.Invoke(new Action(() =>
                {
                    pbBrazoIzqPintado.Visible = true;
                    pbBrazoIzq.Visible = false;
                }));
            }
            else if (pbPiernaDerPintada.Visible == true && pbPiernaIzqPintada.Visible == true && pbBrazoIzqPintado.Visible == true && pbBrazoDerPintado.Visible == true && pbCabezaPintada.Visible == false)
            {
                this.Invoke(new Action(() =>
                {
                    pbCabezaPintada.Visible = true;
                    pbCabeza.Visible = false;
                    ahorcar();
                }));
            }
        }
        public void pintarTodo()
        {
            this.Invoke(new Action(() =>
            {
                pbPiernaDerPintada.Visible = true;
                pbPiernaIzqPintada.Visible = true;
                pbBrazoDerPintado.Visible = true;
                pbBrazoIzqPintado.Visible = true;
                pbCabezaPintada.Visible = true;
                ahorcar();
            }));  
        }
        private void ahorcar()
        {
            btnLetra.Enabled = false;
            btnArriesgar.Enabled = false;
            MessageBox.Show("TE RE MIL AHORCASTE");
            //com.recibe -= new ev_recibir(mostrarLetras);
           // com.recibe -= new ev_recibir(habilitaLetra);
        }

    }
}
