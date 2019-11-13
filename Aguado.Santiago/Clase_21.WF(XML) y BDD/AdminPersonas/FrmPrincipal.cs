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
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using System.Threading;

namespace AdminPersonas
{
    public partial class FrmPrincipal : Form
    {
        SqlConnection sql;
        DataTable dt;
        private SqlDataAdapter adapter;
        private List<Persona> lista;

        public FrmPrincipal()
        {
            InitializeComponent();
            MessageBox.Show("cerra el form con Salir\nSALAME");
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
            this.lista = new List<Persona>();
            this.dt = new DataTable("Personas");
            CrearDataTable();

            sql = new SqlConnection(Properties.Settings.Default.conexion);
            sql.Open();
            SqlCommand cmd = new SqlCommand();

            this.adapter = new SqlDataAdapter(cmd.CommandText, sql);
            adapter.InsertCommand = new SqlCommand("insert into Personas(nombre,apellido,edad) values(@p1,@p2,@p3)", sql);
            adapter.UpdateCommand = new SqlCommand("update Personas set nombre = @p1,apellido = @p2,edad = @p3 where id = @p4", sql);
            adapter.DeleteCommand = new SqlCommand("delete from Personas where id = @p4", sql);

            adapter.InsertCommand.Parameters.Add("@p1", SqlDbType.VarChar, 50, "nombre");
            adapter.InsertCommand.Parameters.Add("@p2", SqlDbType.VarChar, 50, "apellido");
            adapter.InsertCommand.Parameters.Add("@p3", SqlDbType.Int, 1, "edad");

            adapter.InsertCommand.Parameters.Add("@p4", SqlDbType.Int, 1, "id");
            adapter.UpdateCommand.Parameters.Add("@p1", SqlDbType.VarChar, 50, "nombre");
            adapter.UpdateCommand.Parameters.Add("@p2", SqlDbType.VarChar, 50, "apellido");
            adapter.UpdateCommand.Parameters.Add("@p3", SqlDbType.Int, 1, "edad");

            adapter.UpdateCommand.Parameters.Add("@p4", SqlDbType.Int, 1, "id");
            adapter.DeleteCommand.Parameters.Add("@p4", SqlDbType.Int, 1, "id");
        }

        private void cargarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Persona>));

                OpenFileDialog file = new OpenFileDialog();

                file.ShowDialog();

                file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                TextReader tr = new StreamReader(file.FileName);

                lista = (List<Persona>)xml.Deserialize(tr);

                tr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void guardarEnArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Persona>));

                SaveFileDialog file = new SaveFileDialog();

                file.ShowDialog();

                file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                TextWriter tw = new StreamWriter(file.FileName);

                xml.Serialize(tw, lista);

                tw.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisorPersona frm = new frmVisorPersona(this.lista);

            frm.StartPosition = FormStartPosition.CenterScreen;

            frm.Show();

            this.lista = frm.ListaPersonas;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(this.AdapterUpdate);

            hilo.Start();

            this.Close();
        }

        private void crearBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void traerTodosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            sql = new SqlConnection(Properties.Settings.Default.conexion);
            sql.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = sql;

            command.CommandType = CommandType.Text;

            command.CommandText = "SELECT * FROM Personas";

            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read() != false)
            {
                this.lista.Add(new Persona(dataReader["nombre"].ToString(), dataReader["apellido"].ToString(), int.Parse(dataReader["edad"].ToString())));
            }

            dataReader.Close();
            sql.Close();
        }

        private void ConectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                sql = new SqlConnection(Properties.Settings.Default.conexion);
                sql.Open();
                sql.Close();
                MessageBox.Show("se conecto y se fue");
            }
            catch
            {
                MessageBox.Show("juiste");
            }
        }

        private void CrearDataTable()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = new SqlConnection(Properties.Settings.Default.conexion);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Personas";
                SqlDataReader dr = cmd.ExecuteReader();
                this.dt.Load(dr);
                dr.Close();
                cmd.Connection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void visualizarTablasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVisorDataTable frm = new FrmVisorDataTable(dt);

            frm.StartPosition = FormStartPosition.CenterScreen;

            frm.ShowDialog();

            //this.lista = frm.ListaPersonas;
        }

        private void AdapterUpdate()
        {
            Thread.Sleep(300);
            try
            {
                adapter.Update(dt);
            }
            catch(Exception)
            {
                MessageBox.Show("problema en el update");
            }
        }
    }
}
