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
            get { return this.CostoLlamada; }
        }

        private float CalcularCosto()
        {
            //return Duracion * ;
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

        public Provincial(string origen, string destino, float duracion, Franja miFranja) :base(origen,destino,duracion)
        {
            this._franjaHoraria = miFranja;
        }

        public Provincial(Llamada unaLlamada, Franja miFranja): this(unaLlamada.NroOrigen,unaLlamada.NroDestino,unaLlamada.Duracion,miFranja)
        {

        }

        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}
