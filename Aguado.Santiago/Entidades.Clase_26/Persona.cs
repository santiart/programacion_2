using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clase_26
{
    public class Persona
    {
        protected string nombre;
        protected string apellido;
        protected int dni;

        #region Constructor

        public Persona(string nombre, string apellido, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
        }

        #endregion

        #region Properties

        public string Nombre
        {
            get { return this.nombre; }
        }

        public string Apellido
        {
            get { return this.apellido; }
        }

        public int Dni
        {
            get { return this.dni; }
        }

        #endregion

        #region Getters

        public string ObtenerNombre()
        {
            return this.Nombre;
        }

        public string ObtenerApellido()
        {
            return this.Apellido;
        }

        public int ObtenerDni()
        {
            return this.Dni;
        }

        #endregion

        public string MostrarDatos()
        {
            return "Nombre: " + this.Nombre + ", Apellido: " + this.Apellido + ", Dni: " + this.Dni + "\n";
        }


    }
}
