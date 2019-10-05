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
    public partial class LlamadaProvincial : Llamada
    {

        private Provincial newProvintialCall;

        public Provincial provincial
        {
          get { return this.newProvintialCall; }
        }

        public LlamadaProvincial()
        {
            InitializeComponent();
            foreach(Franja f in Enum.GetValues(typeof(Franja)))
            {
                this.comboBox1.Items.Add(f);
            }
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            string nroOrigen = this.textBox1.Text;
            string nroDestino = this.textBox2.Text;
            string duracion = this.txtDuracion.Text;
            Franja miFranja = (Franja)this.comboBox1.SelectedItem;

            newProvintialCall = new Provincial(nroOrigen, miFranja,float.Parse(duracion), nroDestino);
            this.DialogResult = DialogResult.OK;
            base.btnAceptar_Click(sender, e);
        }

        protected override void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  }
}
