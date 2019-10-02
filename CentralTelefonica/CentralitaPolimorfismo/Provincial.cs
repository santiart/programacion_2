using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    public class Provincial : Local
    {
        protected Franja _franjaHoraria;

        public override float CostoLlamada
        {
            get { return this.CostoLlamada; }
        }

        private float CalcularCosto()
        {
            return base.Duracion * this.CostoLlamada;
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

        public string Mostrar()
        {
            StringBuilder retorno = new StringBuilder(base.Mostrar() + "Franja Horaria: " + this._franjaHoraria + "Costo de la Llamada: " + this.CostoLlamada);
            return retorno.ToString();
        }

        public Provincial(string origen, Franja miFranja, float duracion, string destino) :base(origen,destino,duracion,0)
        {
            this._franjaHoraria = miFranja;
        }

        public Provincial(Llamada unaLlamada, Franja miFranja): this(unaLlamada.NroOrigen, miFranja,unaLlamada.Duracion, unaLlamada.NroDestino)
        {
            switch(miFranja)
            {
                case Franja.Franja_1:
                    this._costo = 1.99f;
                    break;
                case Franja.Franja_2:
                    this._costo = 1.25f;
                    break;
                case Franja.Franja_3:
                    this._costo = 1.66f;
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}
