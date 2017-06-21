using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasesComunicacion;

namespace JuegoAhorcado
{
    public partial class frmJuego : Form
    {      
        clsCliente cliente;
        String nick;
        clsMensajeJuego msjJuego;
        string palabra;
        clsMensajeGanador ganador;
        clsMensajePartida msjPartida;

        public frmJuego(clsCliente cliente,String nick,clsMensajeBase msjBase)
        {
            InitializeComponent();
            this.nick=nick;
            this.cliente = cliente;
            ///this.msjJuego = (clsMensajeJuego)msjBase;
            msjPartida = (clsMensajePartida)msjBase;
            start(msjPartida);
            cliente.acertoLetra += habilitaLetra;
            cliente.falloLetra += fallaLetra;
            cliente.acertoPalabra += habilitaPalabra;
            cliente.falloPalabra += fallaPalabra;
            cliente.timeForm += tiempo;
            palabra = cliente.Mensaje.PalabraAhorcado;
            Char[] palabraIndice = palabra.ToCharArray();
           
        }

        private void start(clsMensajePartida msjPartida)
        {
            this.Text = "Juego Ahorcado - PLAYER " + this.nick;

            for (int i = 0; i < msjPartida.PalabraAhorcado.Length; i++)
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
        private void btnArriesgar_Click(object sender, EventArgs e)
        {
            if (tbPalabra.Text != " " && tbPalabra.Text != "") // Checkear bien que no hayan varios espacios
            {
                clsMensajeJuego msj = new clsMensajeJuego();
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
                clsMensajeJuego msj = new clsMensajeJuego();
                 msj.LetraPalabra=tbLetra.Text.ToUpper();
                 msj.Accion = "PROBAR_LETRA";
                 msj.Nick = cliente.Nick;
                 cliente.enviar(msj);
                
                tbLetra.Clear();
                tbLetra.Focus();
            }
        }
        private void habilitaLetra(clsMensajeBase m) 
        {


            clsMensajeJuego msj = (clsMensajeJuego)m;
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
        private void fallaLetra()
        {
            MessageBox.Show("FALLASTE, TENE CUIDADO QUE LA SOGA APRETA");
            pintarUna();
        }
        private void habilitaPalabra(clsMensajeBase m)
        {
            
                        ganador = (clsMensajeGanador)m;
                        int cant = ganador.PalabraAhorcado.Length;
                        for (int i = 0; i < cant; i++)
                        {
                            if (i == 0)
                                this.Invoke(new Action(() =>
                                {
                                    lb0.Text = ganador.PalabraAhorcado[i].ToString();
                                }));
                            else if (i == 1)
                                this.Invoke(new Action(() =>
                                {
                                    lb1.Text = ganador.PalabraAhorcado[i].ToString();
                                }));
                            else if (i == 2)
                                this.Invoke(new Action(() =>
                                {
                                    lb2.Text = ganador.PalabraAhorcado[i].ToString();
                                }));
                            else if (i == 3)
                                this.Invoke(new Action(() =>
                                {
                                    lb3.Text = ganador.PalabraAhorcado[i].ToString();
                                }));
                            else if (i == 4)
                                this.Invoke(new Action(() =>
                                {
                                    lb4.Text = ganador.PalabraAhorcado[i].ToString();
                                }));
                            else if (i == 5)
                                this.Invoke(new Action(() =>
                                {
                                    lb5.Text = ganador.PalabraAhorcado[i].ToString();
                                }));
                            else if (i == 6)
                                this.Invoke(new Action(() =>
                                {
                                    lb6.Text = ganador.PalabraAhorcado[i].ToString();
                                }));
                            else if (i == 7)
                                this.Invoke(new Action(() =>
                                {
                                    lb7.Text = ganador.PalabraAhorcado[i].ToString();
                                }));
                            else if (i == 8)
                                this.Invoke(new Action(() =>
                                {
                                    lb8.Text = ganador.PalabraAhorcado[i].ToString();
                                }));
                            else if (i == 9)
                                this.Invoke(new Action(() =>
                                {
                                    lb9.Text = ganador.PalabraAhorcado[i].ToString();
                                }));
                            else if (i == 10)
                                this.Invoke(new Action(() =>
                                {
                                    lb10.Text = ganador.PalabraAhorcado[i].ToString();
                                }));
                            else if (i == 11)
                                this.Invoke(new Action(() =>
                                {
                                    lb11.Text = ganador.PalabraAhorcado[i].ToString();
                                }));
                            else if (i == 12)
                                this.Invoke(new Action(() =>
                                {
                                    lb12.Text = ganador.PalabraAhorcado[i].ToString();
                                }));
                            else if (i == 13)
                                this.Invoke(new Action(() =>
                                {
                                    lb13.Text = ganador.PalabraAhorcado[i].ToString();
                                }));
                        }

                        MessageBox.Show("GANADOR:" + ganador.ListaJugadores[ganador.Indice_ganador].Nick);
            
            
        }
        private void fallaPalabra()
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
        private void tiempo(clsMensajeBase m)
        {
            clsMensajeTimer msjTime = (clsMensajeTimer)m;
            lbTime.Invoke((Action)(() => lbTime.Text = msjTime.Segundero.ToString()));
        }

        private void frmJuego_Load(object sender, EventArgs e)
        {int cont=0;
        
        lvJugadores.Font = new Font(lvJugadores.Font,lvJugadores.Font.Style | FontStyle.Bold);
       
            lvJugadores.View = View.Details;
            lvJugadores.BackColor= Color.PaleGoldenrod;

           
            foreach (clsJugador j in msjPartida.ListaJugadores)
            {
                lvJugadores.Items.Add(j.Nick);

                lvJugadores.Items[cont].ForeColor = j.Color;
                cont++;
   
            }
        }

        private void lvJugadores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
