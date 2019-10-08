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
            return "color: " + this.color.ToString() + "\n" + "Marca: " + this.marca + "\n" + "Cantidad: " + this.cantidad.ToString() + "\n\n";
        }

        public static implicit operator string(Tempera t)
        {
            string retorno = " ";
            if(!object.Equals(t,null))
            retorno = t.Mostrar();
            return retorno;
        }

        public static bool operator ==(Tempera a, Tempera b)
        {
            bool retorno = false;
            if(!object.Equals(a,null) && !object.Equals(b,null))
            {
                if(a.color == b.color && a.marca == b.marca)
                {
                    retorno = true;
                }
            }
            else if (object.Equals(a, null) && object.Equals(b, null))
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Tempera a, Tempera b)
        {
            return !(a == b);
        }

        public static  Tempera operator +(Tempera a, int num)
        {
            a.cantidad += num;
            return a;
        }

        public static Tempera operator +(Tempera a,Tempera b)
        {
            if(a == b)
            {
                a += b.cantidad;
            }
            return a;
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
