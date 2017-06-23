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
    public partial class frmMensaje : Form
    {
        public frmMensaje(string textoMensaje,string textoFormulario,string textoBoton)
        {
            InitializeComponent();
            btnPrincipal.Text = textoBoton;
            lblMensaje.Text = textoMensaje;
            this.Text = textoFormulario;
        }

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
