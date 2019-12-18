﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClasesSegundoParcial;
using System.Data.SqlClient;
using System.IO;


namespace WindowsForms.SP
{
    public partial class SegundoParcial : Form
    {
        private Lapiz lapiz;
        private Goma  goma;
        private Sacapunta sacapunta;

        private Cartuchera<Utiles> c_utiles;
        private Cartuchera<Lapiz> c_lapices;
        private Cartuchera<Goma> c_gomas;

        private SqlConnection conexion;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public SegundoParcial()
        {
            InitializeComponent();

            this.dataTable = new DataTable("utiles");
            this.dataTable.Columns.Add("id", typeof(int));
            this.dataTable.Columns["id"].AutoIncrement = true;
            this.dataTable.Columns["id"].AutoIncrementSeed = 1;
            this.dataTable.Columns["id"].AutoIncrementStep = 1;

            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AllowUserToAddRows = false;
        }

        private void SegundoParcial_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Suarez Murray, Demian Jose.");
        }

        //Crear la siguiente jerarquía de clases:
        //Utiles-> marca:string y precio:double (publicos); PreciosCuidados:bool (prop. s/l, abstracta);
        //constructor con 2 parametros y UtilesToString():string (protegido y virtual, retorna los valores del útil)
        //ToString():string (polimorfismo; reutilizar código)
        //Lapiz-> color:ConsoleColor(publico); trazo:ETipoTrazo(enum {Fino, Grueso, Medio}; publico); PreciosCuidados->true; 
        //Reutilizar UtilesToString en ToString() (mostrar todos los valores).
        //Goma-> soloLapiz:bool(publico); PreciosCuidados->true; 
        //Reutilizar UtilesToString en ToString() (mostrar todos los valores).
        //Sacapunta-> deMetal:bool(publico); 
        //Reutilizar UtilesToString en ToString() (mostrar todos los valores).
        private void btnPunto1_Click(object sender, EventArgs e)
        {
            //Crear una instancia de cada clase e inicializar los atributos del form lapiz, goma y sacapunta. 
            this.lapiz = new Lapiz(ConsoleColor.Green, ETipoTrazo.Grueso, "Sylvapen", 25.50);
            this.goma = new Goma(true, "Pelican", 30);
            this.sacapunta = new Sacapunta(true, 55.90, "Afiladitos");

            MessageBox.Show(this.lapiz.ToString());
            MessageBox.Show(this.goma.ToString());
            MessageBox.Show(this.sacapunta.ToString());
        }

        //Crear la clase Cartuchera<T> -> restringir para que solo lo pueda usar Utiles o clases que deriven de Utiles
        //atributos: capacidad:int y elementos:List<T> (todos protegidos)        
        //Propiedades
        //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        //PrecioTotal:(sólo lectura) retorna el precio total de la cartuchera (la suma de los precios de sus elementos).
        //Constructor
        //Cartuchera(), Cartuchera(int); 
        //El constructor por default es el único que se encargará de inicializar la lista.
        //Métodos
        //ToString: Mostrará en formato de tipo string: 
        //el tipo de cartuchera, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
        //de todos los elementos contenidos en la misma. Reutilizar código.
        //Sobrecarga de operador
        //(+) Será el encargado de agregar elementos a la cartuchera siempre y cuando no supere la capacidad máxima de la misma.
        private void btnPunto2_Click(object sender, EventArgs e)
        {
            this.c_lapices = new Cartuchera<Lapiz>(3);
            this.c_gomas = new Cartuchera<Goma>(3);
            this.c_utiles = new Cartuchera<Utiles>(2);

            this.c_lapices += new Lapiz(ConsoleColor.Red, ETipoTrazo.Medio, "Faber-Castell", 32.25);
            this.c_lapices += new Lapiz(ConsoleColor.Blue, ETipoTrazo.Fino, "Paper Mate", 30);
            this.c_lapices += this.lapiz;

            this.c_gomas += this.goma;
            this.c_gomas += new Goma(false, "Dos banderas", 25);

            this.c_utiles += this.lapiz;
            this.c_utiles += this.goma;

            MessageBox.Show(this.c_lapices.ToString());
            MessageBox.Show(this.c_gomas.ToString());
            MessageBox.Show(this.c_utiles.ToString());

        }

        //Agregar un elemento a la cartuchera de útiles, al superar la cantidad máxima, lanzará un CartucheraLlenaException (diseñarla), 
        //cuyo mensaje explicará lo sucedido.
        private void btnPunto3_Click(object sender, EventArgs e)
        {
            try
            {
                this.c_utiles += this.lapiz;
            }
            catch (CartucheraLlenaException ex)
            {
                //Agregar, para la clase CartucheraLlenaException, un método de extensión (InformarNovedad():string)
                //que retorne el mensaje de error
                MessageBox.Show(ex.InformarNovedad());
            }            
        }

        //Si el precio total de la cartuchera supera los 85 pesos, se disparará el evento EventoPrecio. 
        //Diseñarlo (de acuerdo a las convenciones vistas) en la clase cartuchera. 
        //Adaptar la sobrecarga del operador +, para que lance el evento, según lo solicitado.
        //Crear el manejador necesario para que, una vez capturado el evento, se imprima en un archivo de texto: 
        //la fecha (con hora, minutos y segundos) y el total de la cartuchera (en un nuevo renglón). 
        //Se deben acumular los mensajes. El archivo se guardará con el nombre tickets.log en la carpeta 'Mis documentos' del cliente.
        //El manejador de eventos (c_gomas_EventoPrecio) invocará al método (de clase) 
        //ImprimirTicket (se alojará en la clase Ticketeadora), que retorna un booleano indicando si se pudo escribir o no
        private void btnPunto4_Click(object sender, EventArgs e)
        {
            //Asociar manejador de eventos (c_gomas_EventoPrecio) aquí  
            this.c_gomas.EventoPrecio -= c_gomas_EventoPrecio;
            this.c_gomas.EventoPrecio += c_gomas_EventoPrecio;
            this.c_gomas += new Goma(false, "Faber-Castell", 31);
        }

        private void c_gomas_EventoPrecio(object sender, EventArgs e)
        {
            //bool todoOK = false;//Reemplazar por la llamada al método de clase ImprimirTicket
            bool todoOK = Ticketeadora<Goma>.ImprimirTicket(this.c_gomas);
            
            if (todoOK)
            {
                MessageBox.Show("Ticket impreso correctamente!!!");
            }
            else
            {
                MessageBox.Show("No se pudo imprimir el ticket!!!");
            }
        }

        //configurar el OpenFileDialog, para poder seleccionar el log de tickets
        private void btnVerLog_Click(object sender, EventArgs e)
        {
            //titulo -> 'Abrir archivo de tickets'
            //directorio por defecto -> Mis documentos
            //tipo de archivo (filtro) -> .log
            //extensión por defecto -> .log
            //nombre de archovo (defecto) -> tickets
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Title = "Abrir archivo de tickets";
            abrir.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //abrir.Filter = ".log";
            abrir.DefaultExt = ".log";
            abrir.FileName = "tickets";
            DialogResult rta = abrir.ShowDialog();
            //DialogResult rta = DialogResult.Cancel;//Reemplazar por la llamada al método correspondiente del OpenFileDialog

            if (rta == System.Windows.Forms.DialogResult.OK)
            {
                //leer el archivo seleccionado por el cliente y mostrarlo en txtVisorTickest
                StreamReader reader = new StreamReader(abrir.OpenFile());
                this.txtVisorTickets.Text = reader.ReadToEnd();
                reader.Close();
            }
        }

        //Crear las interfaces: 
        //#.-ISerializa -> Xml() : bool
        //              -> Path{ get; } : string
        //#.-IDeserializa -> Xml(out Lapiz) : bool
        //Implementar (implícitamente) ISerializa lápiz
        //Implementar (explícitamente) IDeserializa en lápiz
        //El archivo .xml guardarlo en el escritorio del cliente con el nombre formado con su apellido.nombre.lapiz.xml
        //Ejemplo: Alumno Juan Pérez -> perez.juan.lapiz.xml
        private void btnPunto5_Click(object sender, EventArgs e)
        {
            Lapiz aux = null;

            if (this.lapiz.Xml())
            {
                MessageBox.Show("Lápiz serializado OK");
            }
            else
            {
                MessageBox.Show("Lápiz NO serializado");
            }

            if (((IDeserializa)this.lapiz).Xml(out aux))
            {
                MessageBox.Show("Lápiz deserializado OK");
                MessageBox.Show(aux.ToString());
            }
            else
            {
                MessageBox.Show("Lápiz NO deserializado");
            }
        }

        //Obtener de la base de datos (sp_lab_II_utiles) el listado de útiles:
        //Tabla - utiles { id(autoincremental - numérico) - marca(cadena) - precio(numérico) - tipo(cadena) }.
        private void btnPunto6_Click(object sender, EventArgs e)
        {
            //Configurar el SqlConnection
            this.conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            //Configurar el SqlDataAdapter (y su selectCommand)                        
            this.dataAdapter = new SqlDataAdapter("SELECT * FROM utiles", this.conexion);

            this.dataAdapter.Fill(this.dataTable);
            this.dataGridView1.DataSource = this.dataTable;
        }

        //Agregar en el dataTable los útiles del formulario (lapiz, goma y sacapunta).
        private void btnPunto7_Click(object sender, EventArgs e)
        {
            //Configurar el insertCommand del SqlDataAdapter y sus parametros
            this.dataAdapter.InsertCommand = new SqlCommand("INSERT INTO utiles (marca,precio,tipo) values(@marca,@precio,@tipo", this.conexion);
            this.dataAdapter.InsertCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
            this.dataAdapter.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 1000000000, "precio");
            this.dataAdapter.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");

            //Agregar los utiles del formulario al dataTable
            this.SaveRow(this.lapiz, "Lapiz");
            this.SaveRow(this.goma, "Goma");
            this.SaveRow(this.sacapunta, "Sacapunta");
        }
        private void SaveRow(Utiles util, string tipo)
        {
            DataRow fila = dataTable.NewRow();
            DataColumnCollection columnas = dataTable.Columns;
            fila[columnas[1]] = util.marca;
            fila[columnas[2]] = util.precio;
            fila[columnas[3]] = tipo;
            this.dataTable.Rows.Add(fila);
        }


        //Eliminar del dataTable el primer registro
        private void btnPunto8_Click(object sender, EventArgs e)
        {
            //Configurar el deleteCommand del SqlDataAdapter y sus parametros
            this.dataAdapter.DeleteCommand = new SqlCommand("DELETE FROM utiles WHERE id=@id", conexion);
            this.dataAdapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 2, "id");
            //Borrar el primer registro del dataTable            
            this.dataTable.Rows[0].Delete();
        }

        //Modificar del dataTable el ultimo registro, cambiarlo por: marca:barrilito; precio:72
        private void btnPunto9_Click(object sender, EventArgs e)
        {
            //Configurar el updateCommand del SqlDataAdapter y sus parametros
            dataAdapter.UpdateCommand = new SqlCommand("UPDATE utiles SET marca = @marca, precio = @precio" +
                                ", tipo = @tipo WHERE id = @id", this.conexion);
            dataAdapter.UpdateCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
            dataAdapter.UpdateCommand.Parameters.Add("@precio", SqlDbType.Float, 1000000000, "precio");
            dataAdapter.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
            dataAdapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 2, "id");
            //Modificar el ultimo registro del dataTable
            DataColumnCollection columna = this.dataTable.Columns;
            DataRow fila = this.dataTable.Rows[this.dataTable.Rows.Count - 1];
            fila[columna[1]] = "barrilito";
            fila[columna[2]] = 72;
        }

        //Sincronizar los cambios (sufridos en el dataTable) con la base de datos
        private void btnPunto10_Click(object sender, EventArgs e)
        {
            try
            {
                //Sincronizar el SqlDataAdapter con la BD
                this.dataAdapter.Update(this.dataTable);
                MessageBox.Show("Datos sincronizados!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha sincronizado!!!\n" + ex.Message);
            }
        }
    }
}
