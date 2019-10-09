using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Concesionaria
    {
        private int capacidad;
        private List<Vehiculo> vehiculos;

        public double PrecioDeAutos
        {
            get { return this.ObtenerPrecio(EVehiculo.PrecioDeAutos); }
        }

        public double PrecioDeMotos
        {
            get { return this.ObtenerPrecio(EVehiculo.PrecioDeMotos); }
        }

        public double PrecioTotal
        {
            get { return this.ObtenerPrecio(EVehiculo.PrecioTotal); }
        }

        private Concesionaria()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        private Concesionaria(int capacidad)
        {
            this.capacidad = capacidad;
        }

        public static implicit operator Concesionaria(int capacidad)
        {
            Concesionaria c = new Concesionaria();
            if(c.capacidad == capacidad)
            {
                return c;
            }
            return c;
        }

        public static string Mostrar(Concesionaria c)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Capacaidad: " + c.capacidad.ToString() + "\n"
                + "Total por autos: " + c.PrecioDeAutos.ToString() + "\n"
                + "Total por motos: " + c.PrecioDeMotos.ToString() + "\n"
                + "total: " + c.PrecioTotal.ToString() + "\n");
            return sb.ToString();
        }

        private double ObtenerPrecio(EVehiculo tipoVehiculo)
        {
            int costo = 0;

            switch(tipoVehiculo)
            {
                case EVehiculo.PrecioDeAutos:
                    foreach(Vehiculo v in this.vehiculos)
                    {
                        costo += v.VelocidadMaxima;
                    }
                    break;
                case EVehiculo.PrecioDeMotos:
                    foreach(Vehiculo v in this.vehiculos)
                    {
                        costo += v.VelocidadMaxima;
                    }
                    break;
                case EVehiculo.PrecioTotal:
                    foreach(Vehiculo v in this.vehiculos)
                    {
                        costo += v.VelocidadMaxima;
                    }
                    break;
            }
            return costo;
        }

        public static bool operator ==(Concesionaria c, Vehiculo v)
        {
            bool retorno = false;

            if(!object.Equals(c,null) && !object.Equals(v,null))
            {
                if(c.vehiculos.Contains(v))
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Concesionaria c, Vehiculo v)
        {
            return !(c == v);
        }

        public static Concesionaria operator +(Concesionaria c, Vehiculo v)
        {
            if(c != v && c.capacidad < c.vehiculos.Count)
            {
                c.vehiculos.Add(v);
            }
            return c;
        }
    }
}
