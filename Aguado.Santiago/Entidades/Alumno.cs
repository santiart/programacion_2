using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alumno
    {
        private string _apellido;
        private int _legajo;
        private string _nombre;
        private float _nota;

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }

        public int Legajo
        {
            get { return this._legajo; }
            set { this._legajo = value; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }

        public float Nota
        {
            get { return this._nota; }
            set { this._nota = value; }
        }

        public Alumno(int legajo, string nombre, string apellido): this(nombre,apellido)
        {
            this.Legajo = legajo;
        }

        public Alumno(int legajo):this()
        {
            this.Legajo = legajo;
        }

        public Alumno(string nombre, string apellido): this(0)
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
        }

        public Alumno(float nota):this()
        {
            this.Nota = nota;
        }

        public Alumno()
        {
            this.Apellido = "";
            this.Legajo = 0;
            this.Nombre = "";
            this.Nota = 0;
        }

        private string Mostrar()
        {
            return this._nombre + "," + this._apellido + "-" + "Legajo: " + this._legajo.ToString()+ "-" + "Nota: " + this._nota.ToString();
        }

        public static string Mostrar(Alumno alumno)
        {
            return alumno.Mostrar();
        }

        public static bool operator ==(Alumno a1, Alumno a2)
        {
            bool retorno = false;

            if(!object.Equals(a1,null) && !object.Equals(a2,null))
            {
                if(a1.Legajo == a2.Legajo)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Alumno a1, Alumno a2)
        {
            return !(a1 == a2);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
