using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_16
{
    class Program
    {
        static void Main(string[] args)
        {
            Alumno alumno1 = new Alumno();
            Alumno alumno2 = new Alumno();
            Alumno alumno3 = new Alumno();

            alumno1.apellido = "Perez";
            alumno1.nombre = "Juan";
            alumno1.legajo = 35135413;

            alumno2.apellido = "Gomez";
            alumno2.nombre = "Pablo";
            alumno2.legajo = 235413541;

            alumno3.apellido = "Suarez";
            alumno3.nombre = "Ana";
            alumno3.legajo = 351453254;

            Console.WriteLine(alumno1.Mostrar());
            Console.WriteLine(alumno2.Mostrar());
            Console.WriteLine(alumno3.Mostrar());
            Console.ReadLine();
        }
    }
}
