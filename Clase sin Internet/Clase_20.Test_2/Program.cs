using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_20.Entidades;

namespace Clase_20.Test_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "\\Auto.xml";

            Auto car1 = new Auto("Ferrari",100);

            car1.Guardar(path);
            //FALTA LEER

            Console.WriteLine(car1.ToString());
            Console.ReadLine();
        }
    }
}
