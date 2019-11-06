using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AdminPersonas
{
    public partial class FrmVisorDataTable : frmVisorPersona
    {
        DataTable dt;
        public FrmVisorDataTable():base()
        {
            dt = new DataTable("Personas");
        }

        public FrmVisorDataTable(DataTable dat):this()
        {
            try
            {
                DataRow dr;

                for(int  i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    this.lstVisor.Items.Add(dr["id"].ToString() + "-" + dr["name"].ToString() + "-" + dr["apellido"].ToString() + "-" + dr["edad"].ToString());
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public DataTable Dt
        {
            get { return this.dt; }
        }

        public void ActualizarLista()
        {
            this.lstVisor.Items.Clear();
            foreach(DataRow d in dt.Rows)
            {
                MessageBox.Show(d.RowState.ToString());
                if(d.RowState != DataRowState.Deleted)
                {
                    this.lstVisor.Items.Add($"{d[0]} - {d[1]} - {d[2]} - {d[3]}");
                }
            }
        }

        protected override void btnAgregar_Click(object sender, EventArgs e)
        {
            frmPersona frm = new frmPersona();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {

            }
        }

        protected override void btnModificar_Click(object sender, EventArgs e)
        {
            DataRow dr = this.dt.Rows[this.lstVisor.SelectedIndex];
            frmPersona frm = new frmPersona(new Entidades.Persona(dr["nombre"].ToString(), dr["apellido"].ToString(),int.Parse(dr["edad"].ToString())));
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK)
            {
                dr["nombre"] = frm.Persona.nombre;
                dr["apellido"] = frm.Persona.apellido;
                dr["edad"] = frm.Persona.edad;
            }
            this.ActualizarLista();
        }

        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            if(lstVisor.SelectedIndex >= 0)
            {
                DataRow fila = this.dt.Rows[this.lstVisor.SelectedIndex];
                fila.Delete();
                this.ActualizarLista();
            }
        }

        //private void CrearDataTable()
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = new SqlConnection(Properties.Settings.Default.conexion);
        //        cmd.Connection.Open();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "SELECT * FROM Personas";
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        this.dt.Load(dr);
        //        dr.Close();
        //        cmd.Connection.Close();
        //    }
        //    catch (Exception exc)
        //    {
        //        MessageBox.Show(exc.Message);
        //    }
        //}
    }
}
