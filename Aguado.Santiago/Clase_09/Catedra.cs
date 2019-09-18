using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_09
{
    class Catedra
    {
        private List<Alumno> alumnos = new List<Alumno>();

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
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
            if( c != a)
            {
                c.Alumnos.Add(a);//investigar funciones add, insert, etc
                retorno = true;
            }
            return retorno;
        }

        public static int operator |(Catedra c, Alumno a)
        {
            int index = -1;

            for (int i = 0; i <c.Alumnos.Count; i++)
            {
                if (c.Alumnos[i] == a)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public static bool operator -(Catedra c, Alumno a)
        {
            bool retorno = false;
            if(c.Alumnos.Contains(a))
            {
                c.Alumnos.Remove(a);
                retorno = true;
            }
            return retorno;
        }

    }
}
