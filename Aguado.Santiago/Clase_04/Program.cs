using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_04.Entidades;

namespace Clase_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Cosa thing = new Cosa();
            thing.EstablecerValor(23);
            thing.EstablecerValor("pablo");
            thing.fecha = DateTime.Now;
           // DateTime fech = new DateTime(2018, 02, 03);

            Console.WriteLine(thing.Mostrar());

            Cosa first = new Cosa("juan");

            Console.WriteLine(first.Mostrar());

            Cosa second = new Cosa("agus gato",DateTime.Parse("1201/03/20"));
            Console.WriteLine(second.Mostrar());

            Cosa third = new Cosa("dfsdsdg",DateTime.Parse("5/12/6523"),35);
            Console.WriteLine(third.Mostrar());





            Console.ReadLine();
        }
    }
}
