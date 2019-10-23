using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_17.Entidades
{
    public class Familiar : Auto
    {
        protected int _cantidadAcientos;

        public Familiar(double precio, string patente, int cantidadAcientos) : base(precio,patente)
        {
            this._cantidadAcientos = cantidadAcientos;
        }
    }
}
