using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_06.Entidades
{
    public class Tempera
    {
        private ConsoleColor color;
        private string marca;
        private int cantidad;

        public Tempera(ConsoleColor colour, string mark, int cant)
        {
            this.color = colour;
            this.marca = mark;
            this.cantidad = cant;
        }

        private string Mostrar()
        {
            return "color: " + this.color.ToString() + "-" + "Marca: " + this.marca + "-" + "Cantidad: " + this.cantidad.ToString() + "\n";
        }

        public static implicit operator string(Tempera t)
        {
            string ret = " ";
            if(t != null)
            {
                ret = t.Mostrar();
            }
            return ret;
        }

        public static bool operator ==(Tempera a, Tempera b)
        {
            bool retorno = false;
            if(a.marca == b.marca && a.color == b.color && a != null && b!= null)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Tempera a, Tempera b)
        {
            bool retorno = false;
            if(a != null && b!= null)
            {
            retorno =  !(a.marca == b.marca && a.color == b.color);
            }
            return retorno;
        }

        public static  Tempera operator +(Tempera a, int marca)
        {
            a.cantidad += marca;
            return a;
        }

        public static Tempera operator +(Tempera a,Tempera b)
        {
            if(a.cantidad == b.cantidad && a !=null && b!= null)
            {
                a += b.cantidad;
            }
            return a;
        }

    }
}
