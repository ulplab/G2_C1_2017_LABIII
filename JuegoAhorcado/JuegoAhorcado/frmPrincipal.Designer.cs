namespace JuegoAhorcado
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.btnJugar = new System.Windows.Forms.Button();
            this.btnInstrucciones = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tbJugador = new System.Windows.Forms.TextBox();
            this.lbNombre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnJugar
            // 
            this.btnJugar.BackColor = System.Drawing.Color.Transparent;
            this.btnJugar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnJugar.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnJugar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnJugar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnJugar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJugar.Font = new System.Drawing.Font("MineCrafter 3", 27.75F);
            this.btnJugar.Location = new System.Drawing.Point(283, 201);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(308, 46);
            this.btnJugar.TabIndex = 0;
            this.btnJugar.Text = "JUGAR";
            this.btnJugar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnJugar.UseVisualStyleBackColor = false;
            this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            // 
            // btnInstrucciones
            // 
            this.btnInstrucciones.BackColor = System.Drawing.Color.Transparent;
            this.btnInstrucciones.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnInstrucciones.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnInstrucciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnInstrucciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnInstrucciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstrucciones.Font = new System.Drawing.Font("MineCrafter 3", 15.75F);
            this.btnInstrucciones.ForeColor = System.Drawing.Color.Black;
            this.btnInstrucciones.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInstrucciones.Location = new System.Drawing.Point(283, 158);
            this.btnInstrucciones.Name = "btnInstrucciones";
            this.btnInstrucciones.Size = new System.Drawing.Size(309, 37);
            this.btnInstrucciones.TabIndex = 1;
            this.btnInstrucciones.Text = "INSTRUCCIONES";
            this.btnInstrucciones.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExit.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("MineCrafter 3", 18F);
            this.btnExit.Location = new System.Drawing.Point(678, 18);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(147, 39);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "SALIR";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // tbJugador
            // 
            this.tbJugador.Font = new System.Drawing.Font("MineCrafter 3", 24F);
            this.tbJugador.Location = new System.Drawing.Point(295, 15);
            this.tbJugador.Multiline = true;
            this.tbJugador.Name = "tbJugador";
            this.tbJugador.Size = new System.Drawing.Size(308, 42);
            this.tbJugador.TabIndex = 3;
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.BackColor = System.Drawing.Color.Transparent;
            this.lbNombre.Font = new System.Drawing.Font("MineCrafter 3", 24F);
            this.lbNombre.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbNombre.Location = new System.Drawing.Point(166, 18);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(123, 52);
            this.lbNombre.TabIndex = 4;
            this.lbNombre.Text = "NICK";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JuegoAhorcado.Properties.Resources.portada;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(837, 439);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.tbJugador);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnInstrucciones);
            this.Controls.Add(this.btnJugar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.Text = "Juego Ahorcado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJugar;
        private System.Windows.Forms.Button btnInstrucciones;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox tbJugador;
        private System.Windows.Forms.Label lbNombre;
    }
}

