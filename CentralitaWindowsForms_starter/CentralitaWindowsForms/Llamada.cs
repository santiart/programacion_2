using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CentralitaPolimorfismo;

namespace CentralitaWindowsForms
{
    public partial class Llamada : Form
    {
        //private CentralitaPolimorfismo.Llamada unaLlamada;
        //private Llamada llamada;

        //public Llamada Call
        //{
        //    get { return this.llamada; }
        //}

        public Llamada()
        {
            InitializeComponent();
        }

        protected virtual void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        protected virtual void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
