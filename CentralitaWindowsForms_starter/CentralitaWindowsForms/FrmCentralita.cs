using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CentralitaPolimorfismo;

namespace CentralitaWindowsForms
{
    public partial class FrmCentralita : Form
    {
        public FrmCentralita()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LlamadaLocal llamadaLocal = new LlamadaLocal();
            llamadaLocal.Show();
            if(DialogResult == DialogResult.OK)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LlamadaProvincial llamadaProvincial = new LlamadaProvincial();
            llamadaProvincial.Show();
        }
    }
}
