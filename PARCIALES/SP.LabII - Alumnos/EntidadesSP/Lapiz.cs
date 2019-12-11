using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    public class Lapiz : Utiles
    {
        public ConsoleColor color;
        public ETipoTrazo trazo;

        public Lapiz(ConsoleColor color, ETipoTrazo trazo, string marca, double precio) : base(marca,precio)
        {
            this.color = color;
            this.trazo = trazo;
        }

        public override bool PreciosCuidados
        {
            get { return true; }
        }

        protected override string UtilesToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("LAPIZ \n");
            sb.AppendFormat(base.UtilesToString());
            sb.AppendFormat("COLOR: " + this.color + "\n");
            sb.AppendFormat("TRAZO: " + this.trazo + "\n");
            sb.AppendFormat("PRECIOS CUIDADOS: " + this.PreciosCuidados.ToString() + "\n");
            return sb.ToString();
        }
    }
}
