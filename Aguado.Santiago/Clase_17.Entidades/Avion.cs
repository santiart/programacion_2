using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_17.Entidades
{
    public class Avion : Vehiculo, IAFIP, IARBA
    {
        protected double _veliocidadMaxima;

        public Avion(double precio, double velocidadMaxima) : base(precio)
        {
            this._veliocidadMaxima = velocidadMaxima;
        }

        double IAFIP.CalcularImpuestos()
        {
            return _precio * 0.33;
        }

        double IARBA.CalcularImpuestos()
        {
            return _precio * 0.27;
        }
    }
}
