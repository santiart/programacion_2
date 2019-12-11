using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    public class Goma : Utiles
    {
        public bool soloLapiz;

        public Goma(bool soloLapiz, string marca, double precio) : base(marca,precio)
        {
            this.soloLapiz = soloLapiz;
        }

        public override bool PreciosCuidados
        {
            get { return true; }
        }

        protected override string UtilesToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("GOMA \n");
            sb.AppendFormat(base.UtilesToString());
            sb.AppendFormat("SOLO LAPIZ: " + this.soloLapiz.ToString() + "\n");
            sb.AppendFormat("PRECIOS CUIDADOS: " + this.PreciosCuidados.ToString() + "\n");
            return sb.ToString();
        }
    }
}
