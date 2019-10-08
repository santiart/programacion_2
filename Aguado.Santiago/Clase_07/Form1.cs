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
            this.groupBox1.Visible = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void administracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.miPaleta = 5;
        }

        private void paletaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.paletaToolStripMenuItem.Enabled = true;
            this.groupBox1.Visible = true;
        }

        private void temperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTemperas frm = new FrmTemperas();

            //frm.MdiParent = this;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                this.listBox1.Items.Clear();
                this.miPaleta += frm.MiTempera;
                for(int i = 0; i < 5; i++)
                {
                    this.listBox1.Items.Add((string)this.miPaleta[i]);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            temperaToolStripMenuItem_Click(sender,e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index;
            index = listBox1.SelectedIndex;
            if(index != -1 && !object.Equals(this.miPaleta[index],null))
            {
                //frmT = new FrmTemperas(miPaleta[index]);
                //soy una empanada que baila y nadie lo sabe
            }

        }

    }
}
