using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Genericas
{
    public class Deposito<t>
    {
        private int _capacidadMaxima;
        private List<t> _lista;

        public bool Agregar(t a)
        {
            return (this + a);
        }

        public Deposito(int capacidad)
        {
            this._capacidadMaxima = capacidad;
            this._lista = new List<t>();
        }

        private int GetIndice(t a)
        {
            int index = -1;

            for (int i = 0; i < this._lista.Count; i++)
            {
                if (Equals(this._lista[i],a))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public static bool operator -(Deposito<t> d, t a)
        {
            bool retorno = false;

            if (d.GetIndice(a) != -1)
            {
                d._lista.RemoveAt(d.GetIndice(a));
                retorno = true;
            }
            return retorno;
        }

        public static bool operator +(Deposito<t> d,t a)
        {
            bool retorno = false;

            if (d._lista.Count < d._capacidadMaxima)
            {
                d._lista.Add(a);
                retorno = true;
            }
            return retorno;
        }

        public bool Remover(t a)
        {
            return (this - a);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Capacidad Maxima: " + this._capacidadMaxima.ToString() + "\n");
            sb.AppendFormat("Listado: \n");
            for (int i = 0; i < this._lista.Count; i++)
            {
                sb.AppendFormat(this._lista[i].ToString());
            }
            return sb.ToString();
        }
    }
}
