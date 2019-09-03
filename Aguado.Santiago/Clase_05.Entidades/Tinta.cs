using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_05.Entidades
{
    public class tinta
    {
        private ConsoleColor _color;
        private ETipoTinta _tipo;


        //CONSTRUCTORES
        /// <summary>
        /// Constructor original 
        /// </summary>
        public tinta()
        {
            this._color = ConsoleColor.Blue;
            this._tipo = ETipoTinta.comun;
            
        }

        /// <summary>
        /// </summary>
        /// <param name="colour">sera el que se ingrese</param>
        public tinta(ConsoleColor colour)
        {
            this._color = colour;
        }

        public tinta(ETipoTinta type)
        {
            this._tipo = type;
        }

        //METHODS
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string Mostrar()
        {
            return "color:" + this._color.ToString() + "-" + "Tipo:" + this._tipo.ToString() + "\n";
        }

        public static string Mostrar(tinta t)
        {
            return t.Mostrar();
        }

        public static bool operator == (tinta a, tinta b)
        {
            bool retorno = false;
            //if(a._color == b._color && a._tipo == b._tipo)
            //{
            //    retorno = true;
            //}
            if(!object.Equals(a,null) && !object.Equals(b,null))
            {
                retorno = (a._color == b._color && a._tipo == b._tipo);
            }

            return retorno;
        }

        public static bool operator != (tinta a, tinta b)
        {
            //if(a == b)
            //{
            //    return false;
            //}
            //return true;

            return !(a == b);
        }

        public static bool operator == (tinta a, ConsoleColor colour)
        {
            bool retorno = false;
            if (a._color == colour)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator != (tinta a, ConsoleColor colour)
        {
            return !(a == colour);
        }

        public static explicit operator string (tinta ink)
        {
            return ink.Mostrar();
        }
    }


    //----------------------------------------------------------------------------------------------------------------------


    public class Pluma
    {
        private string _marca;
        private tinta tinta;
        private int cantidad;


        public Pluma()
        {
            this._marca = " ";
            this.tinta = null;
            this.cantidad = 0;
        }

        public Pluma(string marca):this()
        {
            this._marca = marca;
        }

        public Pluma(string marca, tinta ink):this(marca)
        {
            this.tinta = ink;
        }

        public Pluma(string marca, tinta ink, int cant):this(marca,ink)
        {
            this.cantidad = cant;
        }

        private string Mostrar()
        {
            return "marca: " + this._marca + "-" + tinta.Mostrar(this.tinta) + "-" + this.cantidad.ToString() + "\n"; 
        }

        public static implicit operator string (Pluma p)
        {
            return p.Mostrar();
        }

        public static bool operator ==(Pluma p, tinta t)
        {
            return (p.tinta == t);
        }

        public static bool operator !=(Pluma p, tinta t)
        {
            return !(p == t);
        }

        public static Pluma operator +(Pluma p, tinta t)
        {
            if(p.tinta == t)
            {
                if(p.cantidad <=100)
                {
                    p.cantidad++;
                }
            }
            return p;
        }

    }
}