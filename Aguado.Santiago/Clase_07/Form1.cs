using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase_06.Entidades;

namespace Clase_07
{
    public partial class Form1 : Form
    {
        
        Paleta miPaleta;

        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
           // this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void paletaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.miPaleta = 5;
        }

        private void temperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmTemperas();

            //frm.MdiParent = this;

            frm.ShowDialog();

            if()

        }
    }
}
