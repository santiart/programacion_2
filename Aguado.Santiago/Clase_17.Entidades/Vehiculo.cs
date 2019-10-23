using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_17.Entidades
{
    public class Vehiculo
    {
        protected double _precio;

        public void MostrarPrecio()
        {
            Console.WriteLine("Precio: {0} \n", this._precio);
        }

        public Vehiculo(double precio)
        {
            this._precio = precio;
        }
    }
}
