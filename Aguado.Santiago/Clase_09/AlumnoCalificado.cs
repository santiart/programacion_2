using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_09
{
    class AlumnoCalificado : Alumno
    {
        protected double nota;

        public double Nota
        {
            get { return this.nota; }
        }

        public AlumnoCalificado(string nombre, string apellido, int legajo, EtipoExamen examen,double nota):base(nombre,apellido,legajo,examen)
        {
            this.nota = nota;
        }

        public AlumnoCalificado(Alumno a, double nota):this(a.Nombre, a.Apellido,a.Legajo,a.Examen,nota)
        {
            
        }

        public string Mostrar()
        {
            return Alumno.Mostrar(this) + "Nota: " + this.nota.ToString();
        }

    }
}
