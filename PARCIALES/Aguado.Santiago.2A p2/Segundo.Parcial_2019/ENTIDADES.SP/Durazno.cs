using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES.SP
{
    public class Durazno : Fruta
    {
        protected int _cantidadPelusa;

        public Durazno(string color, double peso, int cantidadPelusa) : base(color, peso)
        {
            this._cantidadPelusa = cantidadPelusa;
        }

        public string Nombre
        {
            get { return "Durazno"; }
        }

        public override bool TieneCarozo
        {
            get { return true; }
        }

        protected override string FrutaToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(this.ToString());
            sb.AppendFormat("CANTIDAD DE PELUSA: " + this._cantidadPelusa + "\n");
            sb.AppendFormat("TIENE CAROZO: " + this.TieneCarozo.ToString() + "\n");
            return sb.ToString();
        }
    }
}
