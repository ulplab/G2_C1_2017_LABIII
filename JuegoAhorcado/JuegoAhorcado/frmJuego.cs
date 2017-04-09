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
    }
}
