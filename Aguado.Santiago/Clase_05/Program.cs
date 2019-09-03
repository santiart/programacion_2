using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_05.Entidades;

namespace Clase_05
{
    class Program
    {
        static void Main(string[] args)
        {
            tinta t = new tinta();
            Pluma p = new Pluma();
            string str = (string)t;
            //string str = (string)p;
            Console.WriteLine(str);
            p += t;
            str = p;
            Console.WriteLine(p);

            Console.ReadKey();
        }
    }
}
