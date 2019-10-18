using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clase_16
{
    public class Cocina
    {
        private int _codigo;
        private bool _esIndustrial;
        private double _precio;

        public int Codigo
        {
            get { return this._codigo; }
        }

        public bool EsIndustrial
        {
            get { return this._esIndustrial; }
        }

        public double Precio
        {
            get { return this._precio; }
        }

        public Cocina(int codigo,double precio, bool esIndustrial)
        {
            this._codigo = codigo;
            this._esIndustrial = esIndustrial;
            this._precio = precio;
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Cocina && obj == this)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator ==(Cocina a, Cocina b)
        {
            bool retorno = false;

            if(!object.Equals(a,null) && !object.Equals(b,null))
            {
                if(a.Codigo == b.Codigo)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Cocina a, Cocina b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Codigo: " + this.Codigo.ToString() + " - " + "Precio: " + this.Precio.ToString() + " - " + "Es Industrial?: " + this.EsIndustrial.ToString() + "\n");
            return sb.ToString();
        }
    }
}
