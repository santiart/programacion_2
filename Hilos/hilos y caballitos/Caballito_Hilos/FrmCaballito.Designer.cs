﻿namespace Caballito_Hilos
{
    partial class FrmCaballito
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
            this.caballito1 = new Caballo.Caballito();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // caballito1
            // 
            this.caballito1.Location = new System.Drawing.Point(38, 32);
            this.caballito1.Name = "caballito1";
            this.caballito1.Size = new System.Drawing.Size(208, 129);
            this.caballito1.TabIndex = 0;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(83, 184);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(118, 30);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "&Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // FrmCaballito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 312);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.caballito1);
            this.Name = "FrmCaballito";
            this.Text = "FrmCaballito";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrueba_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        protected Caballo.Caballito caballito1;
        private System.Windows.Forms.Button btnIniciar;
    }
}

