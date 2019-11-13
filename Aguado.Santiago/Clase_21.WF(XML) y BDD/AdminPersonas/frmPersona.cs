﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace AdminPersonas
{
    public partial class frmPersona : Form
    {
        private Persona miPersona;
        private Persona persona;

        public Persona Persona
        {
            get { return this.miPersona; }    
        }

        public frmPersona()
        {
            InitializeComponent();
        }

        public frmPersona(Persona persona):this()
        {
            this.persona = persona;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            miPersona = new Persona(this.txtNombre.Text, this.txtApellido.Text, int.Parse(this.txtEdad.Text));

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
