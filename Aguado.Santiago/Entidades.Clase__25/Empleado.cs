using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clase__25
{
    public class Empleado
    {
        private string nombre;
        private string apellido;
        private int legajo;
        private double sueldo;
        public event LimiteSueldoDelegado limiteSueldo;
        public event SueldoMejoradoDel limiteSueldoMejorado;

        #region Constructor

        public Empleado(string nombre, string apellido, int legajo)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Legajo = legajo;
        }

        #endregion

        #region Properties

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        public int Legajo
        {
            get { return this.legajo; }
            set { this.legajo = value; }
        }

        public double Sueldo
        {
            get { return this.sueldo; }
            set
            {             
                if(value > 18000 && value < 30000)
                {
                    this.limiteSueldo(value,this);
                }
                else if(value >= 30000)
                {
                    EmpleadoEventArgs emp = new EmpleadoEventArgs();
                    emp.SueldoAsignar = value;
                    this.limiteSueldoMejorado(this,emp);
                }
                else
                {
                this.sueldo = value;
                }
             }
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return string.Format("Nombre y Apellido: " + this.Nombre + " " + this.apellido + " - " +
                "Legajo: " + this.Legajo.ToString() + " - " + "Sueldo: " + this.Sueldo.ToString() + "\n");
        }

        #endregion
    }
}
