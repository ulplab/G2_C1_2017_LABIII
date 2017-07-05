using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace JuegoAhorcado
{
    public partial class frmFinJuego : Form
    {
        public frmFinJuego()
        {
            InitializeComponent();
            Thread t = new Thread(redireccionar);
            t.Start();
        }

        public void redireccionar()
        {
            for (int i = 5; i >= 0; i--)
            {
                this.Invoke(new Action(() =>
                {
                    lbTime.Text = i.ToString();
                }));
                Thread.Sleep(1000);
            }
            this.Invoke(new Action(() =>
            {
                frmPrincipal frmPrincipal = new frmPrincipal();
                frmPrincipal.ShowDialog();
                this.Close();
            }));

        }
    }
}
