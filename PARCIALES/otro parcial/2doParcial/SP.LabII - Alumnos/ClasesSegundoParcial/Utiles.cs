using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClasesSegundoParcial
{
    //[XmlInclude(typeof(Utiles))]
    [Serializable]
    public abstract class Utiles
    {
        public string marca;
        public double precio;

        public Utiles() { }

        public Utiles(string marca, double precio)
        {
            this.marca = marca;
            this.precio = precio;
        }
        public string Marca
        {
            get => this.marca;
            set => this.marca = value;
        }
        public double Precio
        {
            get => this.precio;
            set => this.precio = value;
        }

        public abstract bool PreciosCuidados { get; }

        public string UtiliesToString()
        {
            string util;
            util = string.Format("Marca: {0}\nPrecio: {1}\n", this.Marca, this.Precio.ToString());
            return util;
        }


    }
}
