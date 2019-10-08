using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Materia
    {
        private List<Alumno> _alumnos;
        private EMateria _nombre;
        private static Random _notaParaUnAlumno;

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public EMateria Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }

        public void CalificarAlumnos()
        {
            foreach(Alumno a in this.Alumnos)
            {
                a.Nota = Materia._notaParaUnAlumno.Next(1, 10);
            }
        }

        public static explicit operator String(Materia materia)
        {
            return materia.Mostrar();
        }

        public static implicit operator float(Materia m)
        {
            float promedio = 0;
            float acum = 0;
            foreach(Alumno a in m.Alumnos)
            {
                acum += a.Nota;
                promedio = acum / m.Alumnos.Count;
            }
            return promedio;
        }

        public static implicit operator Materia(EMateria nombre)
        {
            Materia m = new Materia();
            if(m.Nombre == nombre)
            {
                return m;
            }
            return null;
        }

        private Materia()
        {
            this._alumnos = new List<Alumno>();
        }

        static Materia()
        {
            _notaParaUnAlumno = new Random();
        }

        private Materia(EMateria nombre):this()
        {
            this._nombre = nombre;
        }

        private string Mostrar()
        {
            return this._alumnos.ToString();
        }

        public static bool operator ==(Materia m, Alumno a)
        {
            bool retorno = false;

            if(!object.Equals(m,null) && !object.Equals(a,null))
            {
                if(m.Alumnos.Contains(a))
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Materia m, Alumno a)
        {
            return !(m == a);
        }

        public static Materia operator +(Materia m, Alumno a)
        {
            if(!object.Equals(m,null) && !object.Equals(a,null))
            {
                if (m != a)
                {
                    m.Alumnos.Add(a);
                }
            }
            return m;
        }

        public static Materia operator -(Materia m, Alumno a)
        {
            if (m == a)
            {
                m.Alumnos.Remove(a);

            }
            return m;
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
