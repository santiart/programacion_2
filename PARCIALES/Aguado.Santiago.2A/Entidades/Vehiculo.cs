using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vehiculo
    {
        protected Fabricante fabricante;
        protected static Random generadorDeVelocidades;
        protected string modelo;
        protected float precio;
        protected int velocidadMaxima;

        public int VelocidadMaxima
        {
            get { return this.velocidadMaxima; }
        }

        public static explicit operator String(Vehiculo v)
        {
            return  v.Mostrar(v);
        }

        private string Mostrar(Vehiculo v)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("FABRICANTE: " + v.fabricante.ToString());
            sb.AppendFormat("MODELO: " + v.modelo);
            sb.AppendFormat("PRECIO: " + v.precio.ToString());
            sb.AppendFormat("VELOCIDAD MAXIMA: " + v.velocidadMaxima.ToString());

            return sb.ToString();
        }

        public static bool operator ==(Vehiculo a, Vehiculo b)
        {
            bool retorno = false;

            if (!object.Equals(a, null) && !object.Equals(b, null))
            {
                if (a.fabricante == b.fabricante && a.modelo == b.modelo)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Vehiculo a, Vehiculo b)
        {
            return !(a == b);
        }

        static Vehiculo()
        {
            generadorDeVelocidades = new Random(); 
        }

        public Vehiculo(float precio, string modelo, Fabricante fabri)
        {
            this.fabricante = fabri;
            this.precio = precio;
            this.modelo = modelo;
        }

        public Vehiculo(string marca, EPais pais, string modelo, float precio)
        {
            this.modelo = modelo;
            this.precio = precio;
            //Fabricante fabri = new Fabricante(marca, pais);
        }
    }
}
