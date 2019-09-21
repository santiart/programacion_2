using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase_09;

namespace Clase_09.WF
{
    public partial class FrmCatedra : Form
    {
        Catedra miCatedra;
        private List<AlumnoCalificado> alumnoCalificados;

        public FrmCatedra()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.miCatedra = new Catedra();
            this.alumnoCalificados = new List<AlumnoCalificado>();
            //this.groupBox1.Visible = false;
            //this.groupBox2.Visible = false;
        }



        private void FrmCatedra_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAlumno alumno = new FrmAlumno();
            alumno.ShowDialog();
          //this.miCatedra += alumno.Alumno;
            if(alumno.DialogResult == DialogResult.OK )
            {
                this.listBox1.Items.Clear();
                this.listBox1.Items.Add(alumno);
            }
        }
    }
}
