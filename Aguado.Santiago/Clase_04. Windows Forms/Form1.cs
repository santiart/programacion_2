using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase_04.Entidades;

namespace Clase_04.Windows_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            int entero = int.Parse(this.textBox1.Text);
            string cadena = this.textBox2.Text;
            DateTime fecha = Convert.ToDateTime(this.textBox3.Text);

            Cosa thing = new Cosa(cadena, fecha, entero);
            MessageBox.Show(thing.Mostrar());

            
            
        }

        //backcolor




    }
}
