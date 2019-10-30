using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Clase_20.Entidades
{
    [XmlInclude(typeof(Empleado))]
    [XmlInclude(typeof(Alumno))]
    public class Persona
    {
        public string nombre;
        public string apellido;
        private int edad;
        private List<string> apodos;

        public int Edad
        {
            get { return this.edad; }
            set { this.edad = value; }
        }

        public List<string> Apodos
        {
            get { return this.apodos; }
            set { this.apodos = value; }
        }

        public Persona()
        {
            this.apellido = "";
            this.nombre = "";
            this.Edad = 0;
            this.apodos = new List<string>();
        }

        public Persona(string nombre, string apellido, int edad)//, List<string> apodos
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.Edad = edad;
            this.Apodos = apodos;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Nombre y Apellido:  " + this.nombre +" " + this.apellido);
            sb.AppendFormat("Edad: " + this.Edad.ToString());

            return sb.ToString();
        }


    }
}
