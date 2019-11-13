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

        protected virtual void btnAgregar_Click(object sender, EventArgs e)
        {
            frmPersona frm = new frmPersona();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            //this.lstVisor.Items.Clear();
            if (frm.DialogResult == DialogResult.OK)
            {
                try
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
                    sqlC.Connection.Close();
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        protected virtual void btnModificar_Click(object sender, EventArgs e)
        {
            if(!object.Equals(this.lstVisor.SelectedItem,null))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = new SqlConnection(Properties.Settings.Default.conexion);
                cmd.Connection.Open();
                StringBuilder sb = new StringBuilder();
                frmPersona frm = new frmPersona();//(Persona)this.lstVisor.SelectedItem
                frm.StartPosition = FormStartPosition.CenterScreen;

                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    //int i = this.lstVisor.SelectedIndex;
                    //this.listaPersonas[i] = frm.Persona;
                    this.lstVisor.SelectedItem = frm.Persona;

                    try
                    {
                        sb.AppendFormat("update Personas set nombre = '{0}',apellido = '{1}',edad = {2} where id = {3}", frm.Persona.nombre, frm.Persona.apellido, frm.Persona.edad, this.lstVisor.SelectedIndex + 1);
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sb.ToString();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    catch (Exception exc)
                    {
                        cmd.Connection.Close();
                        MessageBox.Show(exc.Message);
                    }
                    this.lstVisor.Items.Clear();
                    foreach (Persona p in this.listaPersonas)
                    {
                        this.lstVisor.Items.Add(p);
                    }
                }
            }
        }

        protected virtual void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(Properties.Settings.Default.conexion);
            cmd.Connection.Open();
            frmPersona frm = new frmPersona();
            frm.StartPosition = FormStartPosition.CenterScreen;

            this.listaPersonas.RemoveAt(this.lstVisor.SelectedIndex);

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("delete from Personas where id = {0}", this.lstVisor.SelectedIndex + 1);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sb.ToString();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch(Exception exc)
            {
                cmd.Connection.Close();
                MessageBox.Show(exc.Message);
            }

            this.lstVisor.Items.Clear();
            foreach(Persona p in this.listaPersonas)
            {

                this.lstVisor.Items.Add(p);
            }
        }

        private void frmVisorPersona_Load_1(object sender, EventArgs e)
        {
            this.btnAgregar.Click += new EventHandler(this.btnAgregar_Click);
        }

        private void lstVisor_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.btnAgregar.Click -= new EventHandler(this.btnAgregar_Click);
            this.btnModificar.Click += new EventHandler(this.btnModificar_Click);
            this.btnEliminar.Click += new EventHandler(this.btnEliminar_Click);
        }
    }
}
