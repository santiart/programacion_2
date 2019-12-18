using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EntidadesSP
{
    public class Cartuchera<T> where T : Utiles
    {
        protected int capacidad;
        protected List<T> elementos;

        public Cartuchera()
        {
            this.elementos = new List<T>();
        }

        public Cartuchera(int capacidad) : this()
        {
            this.capacidad = capacidad;
        }

        public List<T> Elementos
        {
            get { return this.elementos; }
        }

        public int PrecioTotal
        {
            get
            {
                double precioTotal = 0;

                foreach(T elemento in this.Elementos)
                {
                    precioTotal += elemento.precio;
                }

                return precioTotal;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("TIPO: " + "\n");
            sb.AppendFormat("CAPACIDAD" + this.capacidad.ToString() + "\n");
            sb.AppendFormat("CANTIDAD DE ELEMENTOS: " + this.Elementos.Count.ToString() + "\n");
            sb.AppendFormat("PRECIO TOTAL: " + this.PrecioTotal.ToString() + "\n");
            foreach(T elemento in this.elementos)
            {
                sb.AppendFormat(elemento.ToString() + "\n");
            }
            return sb.ToString();
        }

        public static Cartuchera<T> operator +(Cartuchera<T> c, T elementos)
        {
            if(c.Elementos.Count < c.capacidad)
            {
                c.Elementos.Add(elementos);

                if(c.PrecioTotal > 85)
                {
                    c.EventoPrecio(c, new EventArgs());
                }
            }
            else
            {
                throw new CartucheraLlenaException("");
            }
            return c;
        }

        public delegate void LimitePrecio(Cartuchera<T> c, EventArgs e);
        public event LimitePrecio EventoPrecio;

    }
}
