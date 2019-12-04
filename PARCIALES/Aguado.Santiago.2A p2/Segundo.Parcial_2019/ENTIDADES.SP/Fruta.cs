using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES.SP
{
    public abstract class Fruta
    {
        protected string _color;
        protected double _peso;
        public abstract bool TieneCarozo { get; }

        public Fruta(string color, double peso)
        {
            this._color = color;
            this._peso = peso;
        }

        protected virtual string FrutaToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("COLOR: " + this._color + "\n");
            sb.AppendFormat("PESO: " + this._peso + "\n");
            return sb.ToString();
        }
    }
}
