using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_17.Entidades
{
    public class Deportivo : Auto, IAFIP, IARBA
    {
        protected int _caballosFuerza;

        public Deportivo(double precio, string patente, int caballosFuerza) : base(precio,patente)
        {
            this._caballosFuerza = caballosFuerza;
        }

        public double CalcularImpuestos()
        {
            return _precio * 0.28;
        }

        double IARBA.CalcularImpuestos()
        {
            return _precio * 0.23;
        }
    }
}
