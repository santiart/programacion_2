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
    public partial class LlamadaLocal : Llamada
    {
        private Local newLocalCall;

        public Local local
        {
          get { return this.newLocalCall; }
        }

        public LlamadaLocal()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            string nroOrigen = this.textBox1.Text;
            string nroDestino = this.textBox2.Text;
            string duracion = this.txtDuracion.Text;
            string costo = this.textBox3.Text;

            this.newLocalCall = new Local(nroOrigen, nroDestino, float.Parse(duracion), float.Parse(costo));

            this.DialogResult = DialogResult.OK;

            base.btnAceptar_Click(sender, e);
        }

        protected override void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

  }
}
