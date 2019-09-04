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

        private Paleta():this(5)
        {
            //this.colores = new Tempera[5];
            //this.cantidadMaximaColores = 5; 
        }

        private Paleta(int cantMax)
        {
            this.cantidadMaximaColores = cantMax;
            this.colores = new Tempera[cantMax];
        }

        public static implicit operator Paleta(int cantidadMaxima)
        {
            Paleta a = new Paleta(cantidadMaxima);
            return a;
        }

        private string Mostrar()
        {
            string retorno = " ";
            retorno = " cantidad maxima de colores: " + this.cantidadMaximaColores.ToString();
            for(int i = 0; i < this.colores.Length;i++)
            {
                retorno += "\n";
                if(!this.colores[i].Equals(null))
                {
                    retorno += "\n" + this.colores[i];
                }
            }
            return retorno;
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
            if(!object.Equals(p,null) && !object.Equals(t,null))
            {
                for(int i = 0; i < p.cantidadMaximaColores; i++)
                {
                    if(p.colores[i] == t)
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
            int index = -1;
            if(!object.Equals(p,null) && !object.Equals(t,null))
            {
                for(int i = 0; i < p.colores.Length; i++)
                {
                    if(p.colores[i] != t)
                    {
                        index = p.obtenerLugarLibre();
                        if(index != -1)
                        {
                            p.colores[index] = t;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("no hay lugar disponible en el array");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        p.colores[i]+= t;
                    }
                }
            }
            return p;
        }

        private  int obtenerLugarLibre()
        {
            int index = -1;
            Paleta p = new Paleta();
            if(!object.Equals(p,null))
            {
                for(int i = 0; i < p.colores.Length; i++)
                {
                    if(!object.Equals(p.colores[i],null))// if(vec[i].estado == 0)
                    {
                        index = i;
                        break;
                    }
                }
            }
                return index;
        }

        public static int ObtenerIndiceTempera()
        {
            int index = -1;

            return 0;
        }



    }
}