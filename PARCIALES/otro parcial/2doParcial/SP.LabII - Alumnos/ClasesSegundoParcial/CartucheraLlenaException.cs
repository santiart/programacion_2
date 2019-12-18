using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesSegundoParcial
{
    public class CartucheraLlenaException : Exception
    {
        public CartucheraLlenaException()
            :base("Se intento agregar un elemento a la cartuchera pero no hay espacio")
        {

        }
    }
}
