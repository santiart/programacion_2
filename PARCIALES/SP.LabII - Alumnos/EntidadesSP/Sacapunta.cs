using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    public class Sacapunta : Utiles
    {
        public bool deMetal;

        public Sacapunta(bool deMetal, double precio, string marca) : base(marca,precio)
        {
            this.deMetal = deMetal;
        }

        public override bool PreciosCuidados
        {
            get { return false; }
        }

        protected override string UtilesToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SACAPUNTAS \n");
            sb.AppendFormat(base.UtilesToString());
            sb.AppendFormat("DE METAL: " + this.deMetal.ToString() + "\n");
            sb.AppendFormat("PRECIOS CUIDADOS: " + this.PreciosCuidados.ToString() + "\n");
            return sb.ToString();
        }
    }
}
