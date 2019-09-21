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
    public partial class FrmAlumno : Form
    {
        Clase_09.Alumno alumno;

        public Alumno Alumno
        {
            get { return this.alumno; }
        }

        public FrmAlumno()
        {
            InitializeComponent();
            foreach(EtipoExamen t in Enum.GetValues(typeof(EtipoExamen)))
            {
                this.comboBox1.Items.Add(t);
            }
            this.comboBox1.SelectedItem = EtipoExamen.Final;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string name;
            string surname;
            string legajo;
            EtipoExamen test;

            name = this.textBox1.Text;
            surname = this.textBox2.Text;
            legajo = this.textBox3.Text;
            test =(EtipoExamen) this.comboBox1.SelectedItem;

            this.alumno = new Alumno(name, surname,int.Parse(legajo), test);
            //MessageBox.Show(this.alumno.ToString());
            this.DialogResult = DialogResult.OK;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
