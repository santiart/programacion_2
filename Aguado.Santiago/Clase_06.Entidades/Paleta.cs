using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_06.Entidades
{
    public class Paleta
    {
        private Tempera[] colores;
        private int cantidadMaximaColores;

        private Paleta() : this(5)
        {
            //this.colores = new Tempera[5];
            //this.cantidadMaximaColores = 5; 
        }

        private Paleta(int cantMax)
        {
            this.colores = new Tempera[cantMax];
            this.cantidadMaximaColores = cantMax;
        }

        public static implicit operator Paleta(int cantidadMaxima)
        {
            Paleta a = new Paleta();
            return a;
        }

        private string Mostrar()
        {
            string retorno;
            retorno = " cantidad maxima de colores: " + this.cantidadMaximaColores.ToString();
            for (int i = 0; i < this.cantidadMaximaColores; i++)
            {
                //retorno += "\n";
                //if(!this.colores[i].Equals(null))
                //{
                retorno += "\n" + (string)this.colores[i];
                // }
            }
            return retorno;
        }

        public static implicit operator string(Paleta p)
        {
            return p.Mostrar();
        }

        //public static string Mostrar(Paleta a)
        //{
        //    string retorno = " ";
        //    if(!object.Equals(a,null))
        //    {
        //        retorno = a.Mostrar();
        //    }
        //    return retorno;
        //}

        public static bool operator ==(Paleta p, Tempera t)
        {
            bool retorno = false;
            if (!object.Equals(p, null) && !object.Equals(t, null))
            {
                for (int i = 0; i < p.colores.Length; i++)
                {
                    if (p.colores[i] == t)
                    {
                        retorno = true;
                    }
                }
            }
            else
            {
                retorno = object.Equals(p, t);
            }
            return retorno;
        }

        public static bool operator !=(Paleta p, Tempera t)
        {
            return !(p == t);
        }

        public static Paleta operator +(Paleta p, Tempera t)
        {
            //int index = -1;
            if (p == t)
            {
                if ((p | t) != -1)
                {
                    p.colores[p | t] += t;
                }
            }
            else
            {
                if (p.obtenerLugarLibre() != -1)
                    p.colores[p.obtenerLugarLibre()] = t;
            }
            return p;
        }

        private int obtenerLugarLibre()
        {
            int index = -1;
            for (int i = 0; i < this.cantidadMaximaColores; i++)
            {
                if (this.colores[i] == null)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public static int operator |(Paleta p, Tempera t)
        {
            int index = -1;

            for (int i = 0; i < p.cantidadMaximaColores; i++)
            {
                if (p.colores[i] == t)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public Tempera this[int index]
        {
            get { return this.colores[index]; }

        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}