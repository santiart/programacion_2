using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_09
{
    public class Catedra
    {
        private List<Alumno> alumnos = new List<Alumno>();
        private List<AlumnoCalificado> alumnosCalificados = new List<AlumnoCalificado>();
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
        }

        public List<AlumnoCalificado> AlumnosCalificados
        {
            get { return this.alumnosCalificados; }
        }

        public Catedra()
        {
            this.alumnos = new List<Alumno>();
        }

        public static bool operator ==(Catedra c, Alumno a)
        {
            bool retorno = false;
            if(!object.Equals(c,null) && !object.Equals(a,null))
            {
                if(c.Alumnos.Contains(a))
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Catedra c,Alumno a)
        {
            return !(c == a);
        }

        public static bool operator +(Catedra c, Alumno a)
        {
            bool retorno = false;
            if( !c.Alumnos.Contains(a))
            {
                c.Alumnos.Add(a);//investigar funciones add, insert, etc
                retorno = true;
            }
            return retorno;
        }

        public static int operator |(Alumno a, Catedra c)
        {
            //int index = -1;

            //for (int i = 0; i <c.Alumnos.Count; i++)
            //{
            //    if (c.Alumnos[i] == a)
            //    {
            //        index = i;
            //        break;
            //    }
            //}
            //return index;
            return c.Alumnos.IndexOf(a);
        }

        public static bool operator -(Catedra c, Alumno a)
        {
            bool retorno = false;
            if(c == a)
            {
                c.Alumnos.RemoveAt(a | c);
                retorno = true;
            }
            return retorno;
        }

        public override string ToString()
        {
            string chain = "";
            for(int i = 0; i<this.alumnos.Count; i++)
            {
                chain += this.alumnos[i].ToString();
            }
            return chain;
        }
    }
}
