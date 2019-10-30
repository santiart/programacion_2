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

        private List<Persona> lista;

        public FrmPrincipal()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            this.lista = new List<Persona>();
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

            this.lista = frm.ListaPersonas;

            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void crearBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sql = new SqlConnection(Properties.Settings.Default.conexion);

                sql.Open();
                //MessageBox.Show("Se Conecto");

                SqlCommand sqlcomm = new SqlCommand();

                sqlcomm.Connection = sql;

                sqlcomm.CommandType = CommandType.Text;

                sqlcomm.CommandText =
                    "SELECT TOP 1000 [id] ,[nombre] ,[apellido] ,[edad] FROM[personas_bd].[dbo].[personas]";

                SqlDataReader dataReader = sqlcomm.ExecuteReader();

                while (dataReader.Read() != false)
                {
                    object o = dataReader[0].ToString();
                    object n = dataReader["nombre"].ToString();
                    MessageBox.Show(o.ToString(),n.ToString());
                }

                dataReader.Close();
                sql.Close();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
