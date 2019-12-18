using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace ClasesSegundoParcial
{
    [XmlInclude(typeof(Cartuchera<Utiles>))]
    public class Cartuchera<T> where T : Utiles
    {
        public delegate void SuperaPrecio(object cartuchera, EventArgs e);


        protected int capacidad;
        protected List<T> elementos;
        public event SuperaPrecio EventoPrecio;

        public Cartuchera()
        {
            this.elementos = new List<T>();            
        }
        public Cartuchera(int capacidad)
            : this()
        {
            this.capacidad = capacidad;
        }

        public List<T> Elementos
        {
            get => this.elementos;
        }
        public double PrecioTotal
        {
            get
            {
                double precioTot = 0;
                foreach(Utiles item in this.elementos)
                {
                    precioTot += item.precio;
                }
                return precioTot;
            }
        }

        public override string ToString()
        {
            string cartuchera;
            cartuchera = string.Format("Tipo: {0}\nPrecio: {1}\nCapacidad: {2}\n", typeof(T).ToString(),
                                        this.PrecioTotal.ToString(), this.capacidad.ToString());
            foreach (Utiles item in this.elementos)
            {
                cartuchera += item.ToString();
            }
            return cartuchera;
        }

        public static Cartuchera<T> operator +(Cartuchera<T> c, T item)
        {
            if(c.elementos.Count < c.capacidad)
            {
                c.elementos.Add(item);
                if(c.PrecioTotal > 85 && c.EventoPrecio != null)
                {
                    c.EventoPrecio(c, EventArgs.Empty);
                }
            }
            else
            {
                throw new CartucheraLlenaException();
            }
            return c;
        }

        
    }
}
