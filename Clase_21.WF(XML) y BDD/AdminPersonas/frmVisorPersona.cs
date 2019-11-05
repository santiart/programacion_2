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
using System.Data.SqlClient;

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
            foreach(Persona per in this.listaPersonas)
            {
                this.lstVisor.Items.Add(per);
            }
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

            //this.lstVisor.Items.Clear();
            if (frm.DialogResult == DialogResult.OK)
            {
                this.ListaPersonas.Add(frm.Persona);
                this.lstVisor.Items.Add(frm.Persona);
                StringBuilder sb = new StringBuilder();
                SqlCommand sqlC = new SqlCommand();
                sqlC.Connection = new SqlConnection(Properties.Settings.Default.conexion);
                sqlC.Connection.Open();
                sqlC.CommandType = CommandType.Text;
                sb.AppendFormat("insert into Personas(nombre,apellido,edad) values('{0}','{1}',{2})", frm.Persona.nombre, frm.Persona.apellido, frm.Persona.edad);
                sqlC.CommandText = sb.ToString();
                sqlC.ExecuteNonQuery();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmPersona frm = new frmPersona();
            frm.StartPosition = FormStartPosition.CenterScreen;

            frm.ShowDialog();

            if(frm.DialogResult == DialogResult.OK)
            {
                try
                {
                    this.lstVisor.SelectedItem = frm.Persona;
                    this.lstVisor.Items.Add(frm.Persona);
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("update Personas set nombre = '{0}',apellido = '{1}',edad = {2} where id = {3}", frm.Persona.nombre, frm.Persona.apellido, frm.Persona.edad, this.lstVisor.SelectedIndex + 1);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = new SqlConnection(Properties.Settings.Default.conexion);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();
                    cmd.ExecuteNonQuery();
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmPersona frm = new frmPersona();
            frm.StartPosition = FormStartPosition.CenterScreen;

            frm.ShowDialog();

            if(frm.DialogResult == DialogResult.OK)
            {
                this.lstVisor.SelectedItem = frm.Persona;
                this.lstVisor.Items.Remove(frm.Persona);

                try
                {
                    StringBuilder sb = new StringBuilder();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = new SqlConnection(Properties.Settings.Default.conexion);
                    cmd.Connection.Open();
                    sb.AppendFormat("delete from Personas where id = {3}", this.lstVisor.SelectedIndex + 1);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();
                    cmd.ExecuteNonQuery();
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }
    }
}
