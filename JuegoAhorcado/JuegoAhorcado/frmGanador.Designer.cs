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
            this.lbTimeSigRonda = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbGanador
            // 
            this.lbGanador.BackColor = System.Drawing.Color.Transparent;
            this.lbGanador.Font = new System.Drawing.Font("MineCrafter 3", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGanador.ForeColor = System.Drawing.Color.White;
            this.lbGanador.Location = new System.Drawing.Point(30, 33);
            this.lbGanador.Name = "lbGanador";
            this.lbGanador.Size = new System.Drawing.Size(198, 64);
            this.lbGanador.TabIndex = 0;
            this.lbGanador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTimeSigRonda
            // 
            this.lbTimeSigRonda.BackColor = System.Drawing.Color.Transparent;
            this.lbTimeSigRonda.Font = new System.Drawing.Font("MineCrafter 3", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeSigRonda.ForeColor = System.Drawing.Color.White;
            this.lbTimeSigRonda.Location = new System.Drawing.Point(92, 195);
            this.lbTimeSigRonda.Name = "lbTimeSigRonda";
            this.lbTimeSigRonda.Size = new System.Drawing.Size(81, 56);
            this.lbTimeSigRonda.TabIndex = 2;
            this.lbTimeSigRonda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // frmGanador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JuegoAhorcado.Properties.Resources.ganador;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(261, 260);
            this.Controls.Add(this.lbTimeSigRonda);
            this.Controls.Add(this.lbGanador);
            this.Name = "frmGanador";
            this.Text = "frmGanador";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbGanador;
        private System.Windows.Forms.Label lbTimeSigRonda;
    }
}