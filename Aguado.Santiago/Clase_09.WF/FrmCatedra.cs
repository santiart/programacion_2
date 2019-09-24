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

            foreach (ETipoOrdenamiento o in Enum.GetValues(typeof(ETipoOrdenamiento)))
            {
                this.comboBox1.Items.Add(o);
            }
            this.comboBox1.SelectedItem = ETipoOrdenamiento.ApellidoAscendente;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            FrmAlumno alumno = new FrmAlumno();
            alumno.ShowDialog();
            bool student = miCatedra + alumno.Alumno; 
            if(alumno.DialogResult == DialogResult.OK )
            {
                this.ActualizarListadoAlumnos();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int order = this.comboBox1.SelectedIndex;

            switch(order)
            {
                case 0:
                    miCatedra.Alumnos.Sort(Alumno.OrdenarPorLegajoAsc);
                    break;
                case 1:
                    miCatedra.Alumnos.Sort(Alumno.OrdenarPorLegajoDes);
                    break;
                case 2:
                    miCatedra.Alumnos.Sort(Alumno.OrdenarPorApellidoAsc);
                    break;
                case 3:
                    miCatedra.Alumnos.Sort(Alumno.OrdenarPorApellidosDes);
                    break;
            }
            ActualizarListadoAlumnos();
        }

        private void ActualizarListadoAlumnos()
        {
            this.listBox1.Items.Clear();
            for (int i = 0; i < miCatedra.Alumnos.Count; i++)
            {
                //this.listBox1.Items.Add(miCatedra.ToString());
                this.listBox1.Items.Add(Alumno.Mostrar(miCatedra.Alumnos[i]));

            }
        }

        private void btnCalificar_Click(object sender, EventArgs e)
        {
            FrmAlumnoCalificado ac = new FrmAlumnoCalificado();
            ac.ShowDialog();
            bool student = miCatedra + ac.AlumnoCalificado;
            if(DialogResult == DialogResult.OK)
            {
                this.listBox2.Items.Clear();
                for(int i = 0; i < miCatedra.AlumnosCalificados.Count; i++)
                {
                    this.listBox2.Items.Add(AlumnoCalificado.Mostrar(miCatedra.AlumnosCalificados[i]));
                    this.listBox1.Items.Clear();
                }
            }

        }
    }
}
