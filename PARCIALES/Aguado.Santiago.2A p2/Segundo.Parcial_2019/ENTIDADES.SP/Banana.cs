using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES.SP
{
    public class Banana : Fruta
    {
        protected string _paisOrigen;

        public Banana(string color, double peso, string paisOrigen) : base(color,peso)
        {
            this._paisOrigen = paisOrigen;
        }

        public string Nombre
        {
            get { return "Banana"};
        }

        public override bool TieneCarozo
        {
            get { return false; }
        }

        protected override string FrutaToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(this.ToString());
            sb.AppendFormat("PAIS ORIGEN: " + this._paisOrigen + "\n");
            sb.AppendFormat("TIENE CAROZO: " + this.TieneCarozo.ToString() + "\n");
            return sb.ToString();
        }
    }
}
