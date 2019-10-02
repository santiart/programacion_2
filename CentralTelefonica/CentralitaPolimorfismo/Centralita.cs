using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    public class Centralita
    {
        List<Llamada> _listaDeLlamadas = new List<Llamada>();
        protected string _razonSocial;

        public float GananciaPorLocal
        {
            get { return this.CalcularGanancia(TipoLlamada.Local); }
        }

        public float GananciaPorProvincial
        {
            get { return this.CalcularGanancia(TipoLlamada.Provincial); }
        }

        public float GananciaTotal
        {
            get { return this.CalcularGanancia(TipoLlamada.Todas); }
        }

        public List<Llamada> llamadas
        {
            get { return this._listaDeLlamadas; }
        }

        private void AgregarLlamada(Llamada nuevaLlamada)
        {
            this._listaDeLlamadas.Add(nuevaLlamada);
        }

        private float CalcularGanancia(TipoLlamada tipo)
        {
            float result = 0;
            switch(tipo)
            {
                case TipoLlamada.Local:
                    foreach(Llamada llamada in this._listaDeLlamadas)
                    {
                        if(llamada is Local)
                        {
                            result += llamada.CostoLlamada;
                        }
                    }
                    break;
                case TipoLlamada.Provincial:
                    foreach(Llamada llamada in this._listaDeLlamadas)
                    {
                        if(llamada is Local)
                        {
                            result += llamada.CostoLlamada;
                        }
                    }
                    break;
                case TipoLlamada.Todas:
                    foreach(Llamada llamada in this._listaDeLlamadas)
                    {
                        if(llamada is Local)
                        {
                            result += llamada.CostoLlamada;
                        }
                    }
                    break;
            }
            return result;
        }

        public Centralita()
        {
            this._listaDeLlamadas = new List<Llamada>();
        }

        public Centralita(string nombreEmpresa): this()
        {
            this._razonSocial = nombreEmpresa;
        }

        public override string ToString()
        {
            return _listaDeLlamadas.ToString();
        }

        public void OrdenarLlamadas()
        {
            this.llamadas.Sort(Llamada.OrdenarPorDuracion);
        }

    }
}
