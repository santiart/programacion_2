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
        private Catedra miCatedra;
        private List<AlumnoCalificado> alumnoCalificado;

        public FrmCatedra()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.miCatedra = new Catedra();
            this.alumnoCalificado = new List<AlumnoCalificado>();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FrmAlumno alumno = new FrmAlumno();
            alumno.ShowDialog();
            bool student = miCatedra + alumno.Alumno; 
            if(alumno.DialogResult == DialogResult.OK )
            {
                this.listBox1.Items.Clear();
                for(int i = 0; i < miCatedra.Alumnos.Count; i++)
                {
                    this.listBox1.Items.Add(Alumno.Mostrar(miCatedra.Alumnos[i]));
                    
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int order = this.comboBox1.SelectedIndex;
        }
    }
}
