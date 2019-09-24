using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_09.WF
{
    public partial class FrmAlumnoCalificado : FrmAlumno
    {
        private AlumnoCalificado alumnoCaliicado;

        public AlumnoCalificado AlumnoCalificado
        {
            get { return alumnoCaliicado; }
        }

        public FrmAlumnoCalificado()
        {
            InitializeComponent();
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            this.comboBox1.Enabled = false;
            this.button1.Enabled = true;
            this.button2.Enabled = true;
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            //base.btnAceptar_Click(sender, e);

            string nota = this.textBox4.Text;

            alumnoCaliicado = new AlumnoCalificado(this.textBox1.Text, this.textBox2.Text, int.Parse(this.textBox3.Text), (EtipoExamen)this.comboBox1.SelectedItem, double.Parse(nota));
            this.DialogResult = DialogResult.OK;
        }


    }
}
