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
    public partial class FrmPrincipal : Form
    {
        //Alumno alumno;

        public FrmPrincipal()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void catedraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCatedra catedra = new FrmCatedra();
            catedra.MdiParent = this;
            catedra.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
