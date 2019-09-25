using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    public class Local : Llamada
    {
        protected float _costo;

        public override float CostoLlamada
        {
            get { return this._costo; }
        }

        public float CalcularCosto()
        {
            float retorno;
            retorno = Duracion * CostoLlamada;
            return retorno;
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Local)
            {
                retorno = true;
            }
            return retorno;
        }

        public Local(Llamada unaLlamada, float costo) : this(unaLlamada.NroOrigen, unaLlamada.NroDestino, unaLlamada.Duracion, costo)//base(unaLlamada.NroOrigen, unaLlamada.NroDestino, unaLlamada.Duracion)
        {
        }

        public Local(string origen, string destino, float duracion,  float costo) : base(origen, destino, duracion)
        {
            this._costo = costo;
        }

        public string Mostrar()
        {
            StringBuilder retorno = new StringBuilder(base.Mostrar() + "Costo de La Llamada: " + this.CostoLlamada.ToString());
            return retorno.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}
