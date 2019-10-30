using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace AdminPersonas
{
    public partial class frmVisorPersona : Form
    {
        private List<Persona> listaPersonas = new List<Persona>();

        public frmVisorPersona()
        {
            InitializeComponent();
        }

        public frmVisorPersona(List<Persona> p) : this()
        {
            this.listaPersonas = p;
        }

        public List<Persona> ListaPersonas
        {
            get { return this.listaPersonas; }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmPersona frm = new frmPersona();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            this.lstVisor.Items.Clear();
            if (frm.DialogResult == DialogResult.OK)
            {
                this.ListaPersonas.Add(frm.Persona);
                this.lstVisor.Items.Add(frm.Persona);
            }
            foreach(Persona p in this.ListaPersonas)
            {
                this.lstVisor.Items.Add(p);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmPersona frm = new frmPersona();
            frm.StartPosition = FormStartPosition.CenterScreen;

            //implementar
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmPersona frm = new frmPersona();
            frm.StartPosition = FormStartPosition.CenterScreen;

            //implementar
        }
    }
}
