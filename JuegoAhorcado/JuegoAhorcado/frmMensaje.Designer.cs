namespace JuegoAhorcado
{
    partial class frmMensaje
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
            this.btnPrincipal = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPrincipal
            // 
            this.btnPrincipal.Location = new System.Drawing.Point(136, 122);
            this.btnPrincipal.Name = "btnPrincipal";
            this.btnPrincipal.Size = new System.Drawing.Size(91, 34);
            this.btnPrincipal.TabIndex = 0;
            this.btnPrincipal.Text = "button1";
            this.btnPrincipal.UseVisualStyleBackColor = true;
            this.btnPrincipal.Click += new System.EventHandler(this.btnPrincipal_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.Font = new System.Drawing.Font("MineCrafter 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(12, 38);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(352, 81);
            this.lblMensaje.TabIndex = 1;
            this.lblMensaje.Text = "label1";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmMensaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 186);
            this.ControlBox = false;
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnPrincipal);
            this.Name = "frmMensaje";
            this.Text = "frmMensaje";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrincipal;
        private System.Windows.Forms.Label lblMensaje;
    }
}