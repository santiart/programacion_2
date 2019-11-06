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

namespace AdminPersonas
{
    public partial class FrmPrincipal : Form
    {
        SqlConnection sql;

        DataTable dt ;

        private List<Persona> lista;

        public FrmPrincipal()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            this.lista = new List<Persona>();

            this.dt = new DataTable("Personas");
            CrearDataTable();

            SqlConnection sql = new SqlConnection(Properties.Settings.Default.conexion);
            sql.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sql;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT TOP 1000[id] ,[nombre] ,[apellido] ,[edad] FROM[personas_bd].[dbo].[personas]";

            SqlDataAdapter dataA = new SqlDataAdapter(cmd.CommandText, sql);
            dataA.Fill(dt);
            dataA.InsertCommand = new SqlCommand("insert into Personas values(@p1,@p2,@p3)");//faltan parametros
            dataA.InsertCommand = new SqlCommand("update Personas set nombre = '{0}',apellido = '{1}',edad = {2} where id = {3}");//faltan parametros
            dataA.InsertCommand = new SqlCommand("delete from Personas where id = {0}");//faltan parametros

            //dataA.UpdateCommand = something;
            //dataA.DeleteCommand = something;
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

                lista =(List<Persona>)xml.Deserialize(tr);

                tr.Close();
            }
            catch(Exception exc)
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
            catch(Exception exc)
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
            this.Close();
        }

        private void crearBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlConnection sql = new SqlConnection(Properties.Settings.Default.conexion);

            //    sql.Open();
            //    //MessageBox.Show("Se Conecto");

            //    SqlCommand sqlcomm = new SqlCommand();

            //    sqlcomm.Connection = sql;

            //    sqlcomm.CommandType = CommandType.Text;

            //    sqlcomm.CommandText =
            //        "SELECT TOP 1000 [id] ,[nombre] ,[apellido] ,[edad] FROM[personas_bd].[dbo].[personas]";

            //    SqlDataReader dataReader = sqlcomm.ExecuteReader();

            //    //while (dataReader.Read() != false)
            //    //{
            //    //    object o = dataReader[0].ToString();
            //    //    object n = dataReader["nombre"].ToString();
            //    //    object a = dataReader["apellido"].ToString();
            //    //    MessageBox.Show("ID: " + o.ToString(),n.ToString() +" " + a.ToString());
            //    //}

            //    dataReader.Close();
            //    sql.Close();
            //}
            //catch(Exception exc)
            //{
            //    MessageBox.Show(exc.Message);
            //}
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
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void visualizarTablasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVisorDataTable frm = new FrmVisorDataTable();

            frm.StartPosition = FormStartPosition.CenterScreen;

            frm.Show();

            this.lista = frm.ListaPersonas;
        }
    }
}
