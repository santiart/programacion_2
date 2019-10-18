using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clase_16
{
    public class DepositoDeCocinas
    {
        private int _capacidadMaxima;
        private List<Cocina> _lista;

        public bool Agregar(Cocina c)
        {
            return (this + c);
        }

        public DepositoDeCocinas(int capacidad)
        {
            this._capacidadMaxima = capacidad;
            this._lista = new List<Cocina>();
        }

        private int GetIndice(Cocina c)
        {
            int index = 0;

            //for(int i = 0; i < this._lista.Count; i++)
            //{
            //    if(this._lista[i] == c)
            //    {
            //        index = i;
            //        break;
            //    }
            //}
            foreach(Cocina k in this._lista)
            {
                if (c == k)
                    return index;
                index++;
            }
            return -1;
        }

        public static bool operator -(DepositoDeCocinas d, Cocina c)
        {
            bool retorno = false;

            if(d.GetIndice(c) != -1)
            {
                d._lista.RemoveAt(d.GetIndice(c));
                retorno = true;
            }
            return retorno;
        }

        public static bool operator +(DepositoDeCocinas d, Cocina c)
        {
            bool retorno = false;

            if (d._lista.Count < d._capacidadMaxima)
            {
                d._lista.Add(c);
                retorno = true;
            }
            return retorno;
        }

        public bool Remover(Cocina c)
        {
            return (this - c);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Capacidad Maxima: " + this._capacidadMaxima.ToString() + "\n");
            sb.AppendFormat("Listado de Cocinas: \n");
            for(int i = 0; i < this._lista.Count; i++)
            {
                sb.AppendFormat(this._lista[i].ToString());
            }
            return sb.ToString();
        }
    }
}
