using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto 
    {
        public ETipo tipo;

        public Auto(string modelo, float precio,Fabricante fabri, ETipo tipo)
        {
            this.tipo = tipo;
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;

            if(obj is Auto)
            {
                retorno = true;
            }
            return retorno;
        }

        public static explicit operator Single(Auto a)
        {
            return 0;
        }

        public static bool operator ==(Auto a, Auto b)
        {
            bool retorno = false;

            if(!object.Equals(a,null) && !object.Equals(b,null))
            {
                if( a == b && a.tipo == b.tipo)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Auto a, Auto b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Tipo: " + this.tipo.ToString());
            return sb.ToString();
        }
    }
}
