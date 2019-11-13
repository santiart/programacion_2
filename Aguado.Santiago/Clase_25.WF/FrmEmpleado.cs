using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Clase__25;

namespace Clase_25.WF
{
    public partial class FrmEmpleado : Form
    {
        private Empleado emp;

        public Empleado Emp
        {
            get { return this.emp; }
        }

        public FrmEmpleado()
        {
            InitializeComponent();
            foreach(TipoManejador t in Enum.GetValues(typeof(TipoManejador)))
            {
                this.cmbManejadores.Items.Add(t);
            }
            this.cmbManejadores.SelectedItem = TipoManejador.Todos;
            this.cmbManejadores.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = this.textNombre.Text;
                string apellido = this.textApellido.Text;
                int legajo = int.Parse(this.textLegajo.Text);
                emp = new Empleado(nombre, apellido, legajo);

                switch(this.cmbManejadores.SelectedItem)
                {
                    case TipoManejador.LimiteSueldo:
                        emp.limiteSueldo += new LimiteSueldoDelegado(this.ManejadorLimiteSueldo);
                        break;
                    case TipoManejador.LimiteSueldoMejorado:
                        emp.limiteSueldoMejorado += new SueldoMejoradoDel(this.ManejadorLimiteSueldoAumentado2);
                        break;
                    case TipoManejador.Todos:
                        emp.limiteSueldo += new LimiteSueldoDelegado(this.ManejadorLimiteSueldo);
                        emp.limiteSueldoMejorado += new SueldoMejoradoDel(this.ManejadorLimiteSueldoAumentado2);
                        break;
                }
                this.DialogResult = DialogResult.OK;
                this.emp.Sueldo = double.Parse(this.textSueldo.Text);
            }
            catch(Exception)
            {
                //MessageBox.Show(exc.Message);
            }
        }

        public void ManejadorLimiteSueldo(double value, Empleado emp)
        {
            MessageBox.Show("Empleado con sueldo aumentado, mayor a 19000");
            MessageBox.Show(emp.ToString() + "Sueldo: " + double.Parse(this.textSueldo.Text));
        }

        public static void ManejadorLimiteSueldoAumentado(Empleado emp, EmpleadoEventArgs e)
        {
            MessageBox.Show("Empleado con sueldo aumentado, mayor a 30000");
            MessageBox.Show(emp.ToString() + "Sueldo: " + e.SueldoAsignar.ToString());

        }

        public void ManejadorLimiteSueldoAumentado2(Empleado emp, EmpleadoEventArgs e)
        {
            MessageBox.Show("Empleado con sueldo aumentado, mayor a 30000");
            MessageBox.Show(emp.ToString() + "Sueldo: " + e.SueldoAsignar.ToString());

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.textNombre.Text = "";
            this.textApellido.Text = "";
            this.textLegajo.Text = "";
            this.textSueldo.Text = "";
        }
    }
}
