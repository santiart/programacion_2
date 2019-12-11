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
                int suma = 0;
                suma += elementos.Count;
                if(suma > 85)
                {
                    this.EventoPrecio(this, suma);
                }
                else
                {
                    return suma;
                }
                return suma;
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
            }
            else
            {
                c.EventoPrecio += new Cartuchera<T>.LimitePrecio(c.ManejadorPrecio);
            }
            return c;
        }

        public delegate void LimitePrecio(Cartuchera<T> c, double precio);
        public event LimitePrecio EventoPrecio;

        public void ManejadorPrecio(Cartuchera<T> c,double precio)
        {
            string file = "//tickets.log";

            StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + file, true);
            sw.WriteLine("Precio excedido: " + precio.ToString() + "de la Cartuchera: " + c.ToString() + "\n");
            sw.Close();
        }
    }
}
