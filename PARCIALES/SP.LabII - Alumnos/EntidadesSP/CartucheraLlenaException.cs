using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    public class CartucheraLlenaException : Exception
    {
        public CartucheraLlenaException(string mensaje) : base(mensaje) { }

        public string InformarNovedad()
        {
            return "se supero la cantidad permitida de elementos";
        }
    }
}
