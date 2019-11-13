using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_20.Entidades
{
    public class Alumno : Persona
    {
        public double nota;

        public Alumno() : base()
        {
            this.nota = 0;
        }

        public Alumno(string nombre, string apellido, int edad, double nota) : base(nombre,apellido,edad)
        {
            this.nota = nota;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(base.ToString() + "Nota: " + this.nota);

            return sb.ToString();
        }
    }
}
