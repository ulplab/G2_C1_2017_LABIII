namespace JuegoAhorcado
{
    partial class frmGanador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbGanador = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbGanador
            // 
            this.lbGanador.BackColor = System.Drawing.Color.Transparent;
            this.lbGanador.Font = new System.Drawing.Font("MineCrafter 3", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGanador.ForeColor = System.Drawing.Color.White;
            this.lbGanador.Location = new System.Drawing.Point(39, 39);
            this.lbGanador.Name = "lbGanador";
            this.lbGanador.Size = new System.Drawing.Size(198, 64);
            this.lbGanador.TabIndex = 0;
            // 
            // frmGanador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JuegoAhorcado.Properties.Resources.ganador;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(261, 261);
            this.Controls.Add(this.lbGanador);
            this.Name = "frmGanador";
            this.Text = "frmGanador";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbGanador;
    }
}