using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidadess
{
    public class Auto
    {
        private string _color;
        private string _marca;

        public string Color
        {
            get { return this._color; }
        }

        public string Marca
        {
            get { return this._marca; }
        }

        public Auto(string color, string marca)
        {
            this._color = color;
            this._marca = marca;
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Auto && obj == this)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator ==(Auto a, Auto b)
        {
            bool retorno = false;
            if(!object.Equals(a,null) && !object.Equals(b,null))
            {
                if(a.Marca == b.Marca && a.Color == b.Color)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Auto a, Auto b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Marca: " + this.Marca + " - " + "Color: " + this.Color + "\n");
            return sb.ToString();
        }
    }
}
