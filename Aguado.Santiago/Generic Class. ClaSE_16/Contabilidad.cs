using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Class.Clase_16
{
    public class Contabilidad<T,U> where T : Documento where U : Documento ,new()
    {
        private List<T> egresos;
        private List<U> ingresos;

        public static Contabilidad<T,U> operator +(Contabilidad<T,U> c, T egresos)
        {
            if(!c.egresos.Contains(egresos))
            {
                c.egresos.Add(egresos);
            }
            return c;
        }

        public static Contabilidad<T,U> operator +(Contabilidad<T,U> c, U ingresos)
        {
            if(!c.ingresos.Contains(ingresos))
            {
                c.ingresos.Add(ingresos);
            }
            return c;
        }
    }
}
