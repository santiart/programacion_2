using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clase_26;
using Entidades.Externa;
using Entidades.Externa.Sellada;

namespace Test.Clase_26
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona per = new Persona("Juan", "Perez", 123);
            //Console.WriteLine("Propiedades: ");
            //Console.WriteLine("Nombre: {0}, Apellido: {1}, Dni: {2}",per.Nombre,per.Apellido,per.Dni);
            //Console.WriteLine("\nGetters: ");
            //Console.WriteLine("Nombre: {0}, Apellido: {1}, Dni: {2}", per.ObtenerNombre(), per.ObtenerApellido(),per.ObtenerDni());
            //Console.WriteLine("\nMetodo: ");
            //Console.WriteLine(per.MostrarDatos());

            Console.WriteLine("persona heredada");
            PersonaHerredada per2 = new PersonaHerredada("Nombre","Apellido",34,Entidades.Externa.ESexo.Masculino);
            Console.WriteLine(per2.MostrarDatos());

            Console.WriteLine("Persona Sellada: ");
            PersonaExternaSellada personaSellada = new PersonaExternaSellada("Juan","Perez",25,Entidades.Externa.Sellada.ESexo.Masculino);
            Console.WriteLine(Extensora.ObtenerInfo(personaSellada));

            Console.WriteLine("EsNulo: ");
            object o = new object();
            o = null;
            Console.WriteLine(o.EsNulo() + "\n");

            List<Persona> lista = per.ObtenerListadoBD();

            foreach(Persona p in lista)
            {
                Console.WriteLine(p.MostrarDatos());
            }

            Console.Read();
        }
    }
}
