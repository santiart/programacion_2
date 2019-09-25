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
            get { return ; }
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
            return 0;
        }

        public override string ToString()
        {
            return _listaDeLlamadas.ToString();
        }

    }
}
