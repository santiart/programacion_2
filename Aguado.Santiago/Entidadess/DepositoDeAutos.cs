using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidadess
{
    public class DepositoDeAutos
    {
        private int _capacidadMaxima;
        private List<Auto> _lista;

        public DepositoDeAutos(int capacidad)
        {
            this._lista = new List<Auto>();
            this._capacidadMaxima = capacidad;
        }

        public bool Agregar(Auto a)
        {
           return (this + a);
        }

        private int GetIndice(Auto a)
        {
            int index = 0;
            //for(int i = 0; i < _lista.Count; i++)
            //{
            //    if(this._lista[i] == a)
            //    {
            //        index = i;
            //        break;
            //    }
            //}
            foreach(Auto c in this._lista)
            {
                if(c == a)
                    return index;
                index++;
            }
            return -1;
        }

        public static bool operator +(DepositoDeAutos d, Auto a)
        {
            bool retorno = false;
            
            if(d._lista.Count < d._capacidadMaxima)
            {
                d._lista.Add(a);
                retorno = true;
            }
            return retorno;
        }

        public static bool operator -(DepositoDeAutos d, Auto a)
        {
            bool retorno = false;
            if(d.GetIndice(a) != -1)
            {
                d._lista.RemoveAt(d.GetIndice(a));
                retorno = true;
            }
            return retorno;
        }

        public bool Remover(Auto a)
        {
            return (this - a);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Capacidad Maxima: " + this._capacidadMaxima.ToString()+ "\n");
            sb.AppendFormat("Listado de Autos: \n");
            for(int i= 0; i < this._lista.Count; i++)
            {
                sb.AppendFormat(this._lista[i].ToString());
            }
            return sb.ToString();
        }
    }
}
