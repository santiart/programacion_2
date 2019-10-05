using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    public class Provincial : Llamada
    {
        protected Franja _franjaHoraria;

        public override float CostoLlamada
        {
            get { return this.CalcularCosto(); }
        }

        private float CalcularCosto()
        {
            float costo = 0;
            switch (this._franjaHoraria)
            {
              case Franja.Franja_1:
                costo = 1.99f * base.Duracion;
                break;
              case Franja.Franja_2:
                costo = 1.25f * base.Duracion;
                break;
              case Franja.Franja_3:
                costo = 1.66f * base.Duracion;
                break;
              default:
                break;
            }
            return costo;
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (obj is Provincial)
            {
                retorno = true;
            }
            return retorno;
        }

        protected override string Mostrar()
        {
            StringBuilder retorno = new StringBuilder(base.Mostrar() + "Franja Horaria: " + this._franjaHoraria + "Costo de la Llamada: " + this.CostoLlamada);
            return retorno.ToString();
        }

        public Provincial(string origen, Franja miFranja, float duracion, string destino) :base(origen,destino,duracion)
        {
            this._franjaHoraria = miFranja;
        }

        public Provincial(Llamada unaLlamada, Franja miFranja): this(unaLlamada.NroOrigen, miFranja,unaLlamada.Duracion, unaLlamada.NroDestino)
        {
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        public override int GetHashCode() { return 0; }
    }
}
