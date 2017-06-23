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
    public partial class frmGanador : Form
    {
        public frmGanador(String ganador)
        {
            lbGanador.Text = ganador.ToUpper();
            InitializeComponent();
        }
    }
}
