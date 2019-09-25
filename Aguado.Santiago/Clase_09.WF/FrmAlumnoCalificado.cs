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
        private AlumnoCalificado alumnoCalificado;

        public AlumnoCalificado AlumnoCalificado
        {
            get { return alumnoCalificado; }
        }

        public FrmAlumnoCalificado()
        {
            InitializeComponent();
        }

        public FrmAlumnoCalificado(Alumno a):this()
        {
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            this.comboBox1.Enabled = false;

            this.textBox1.Text = a.Nombre;
            this.textBox2.Text = a.Apellido;
            this.textBox3.Text = a.Legajo.ToString();
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            

            string nota = this.textBox4.Text;

            alumnoCalificado = new AlumnoCalificado(this.textBox1.Text, this.textBox2.Text, int.Parse(this.textBox3.Text), (EtipoExamen)this.comboBox1.SelectedItem, double.Parse(nota));
            this.DialogResult = DialogResult.OK;
        }


    }
}
