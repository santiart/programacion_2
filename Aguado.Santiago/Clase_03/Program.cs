using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_03
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Persona person = new Persona("Santiago","Aguado",33457467);

            //person.name = "Santiago";
            //person.surname = "Aguado";
            //person.dni = 134234636;

            Console.WriteLine(person.Mostrar());

            Persona person2 = new Persona("Pablito", "Gomez", 235245624);

            //person2.name = "pablito";
            //person2.surname = "gomez";
            //person2.dni = 13535688;

            Console.WriteLine(person2.Mostrar());
            Console.ReadLine();
        }
    }
}
