using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_09
{
    public class Alumno
    {
        protected string apellido;
        protected EtipoExamen examen;
        protected int legajo;
        protected string nombre;

        public string Apellido
        {
            get { return this.apellido; }
        }

        public string Nombre
        {
            get { return this.nombre; }
        }

        public int Legajo
        {
            get { return this.legajo; }
        }

        public EtipoExamen Examen
        {
            get { return this.examen; }
        }

        public Alumno(string name, string surname, int legajo, EtipoExamen test)
        {
            this.nombre = name;
            this.apellido = surname;
            this.legajo = legajo;
            this.examen = test;
        }

        public static string Mostrar(Alumno a)
        {
            return "Apellido: " + a.apellido + "-" + "Nombre: " + a.nombre + "-" + "Legajo: " + a.legajo.ToString() + "-" + "Examen: " + a.examen.ToString() + "\n";
        }

        public static bool operator ==(Alumno a, Alumno b)
        {
            bool retorno = false;
            if(!object.Equals(a,null) && !object.Equals(b,null))
            {
                if(a.legajo == b.legajo)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Alumno a, Alumno b)
        {
            return !(a == b);
        }

        public int OrdenarPorApellidoAsc(Alumno a,Alumno b)
        {
            return String.Compare(a.apellido, b.apellido);
        }

        public int OrdenarPorApellidosDes(Alumno a, Alumno b)
        {
            return -1 * this.OrdenarPorApellidoAsc(a, b);
        }

        public int OrdenarPorLegajoAsc(Alumno a, Alumno b)
        {
            return String.Compare(a.legajo.ToString(), b.legajo.ToString());
        }

        public int OrdenarPorLegajoDes(Alumno a, Alumno b)
        {
            return -1 * this.OrdenarPorLegajoAsc(a, b);
        }


    }
}
