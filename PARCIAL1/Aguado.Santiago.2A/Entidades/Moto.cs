using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto
    {
        public ECilindrada cilindrada;

        public override bool Equals(object obj)
        {
            bool retorno = false;

            if(obj is Moto)
            {
                retorno = true;
            }
            return retorno;
        }

        public static implicit operator Single(Moto m)
        {
            return 0;
        }

        public Moto(string marca, EPais pais, string modelo, float precio, ECilindrada cilindrada)
        {
            //Fabricante fabri = new Fabricante(marca, pais);
            this.cilindrada = cilindrada;
        }

        public static bool operator ==(Moto a, Moto b)
        {
            bool retorno = false;

            if(!object.Equals(a,null) && !object.Equals(b,null))
            {
                if(a.cilindrada == b.cilindrada)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Moto a, Moto b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CILINDRADA: " + this.cilindrada.ToString());
            return sb.ToString();
        }
    }
}
