using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systeem.IO
{
    public class Metodo4Exception : Exception
    {
        public Metodo4Exception(string str)
        {
            str = "excepcion del metodo 4";
            Console.WriteLine(str);
        }

        public Metodo4Exception(string str, Exception e)
        {
            str = "excepcion en catch 2";
            Console.WriteLine(str, e.Message);
        }
    }
}
