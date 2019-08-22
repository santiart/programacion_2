using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clase_02.Entidades;

namespace Clase_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Clase_02";
            string mensaje;
            

           Sello.Mensaje("hello world");

            mensaje = Sello.imprimir();

            Console.WriteLine(mensaje);

            Sello.Borrar();

            mensaje = Sello.imprimir();

            Console.WriteLine(mensaje);

            Sello.Mensaje("hola");
            Sello.color = ConsoleColor.Red;

            mensaje=Sello.imprimirEnColor();

            Console.WriteLine(mensaje);



            Console.Read();
            /*

            string nombre;
       
            

            MiClase.edad = 33;
            MiClase.nombre = "agustin";
            
            MiClase.MostrarEdad();

            nombre= MiClase.retornarNombre();

            Console.Write("el nombre es : {0}\n", MiClase.nombre);


            MiLibreria.MiClase.nombre = "roberto";
            nombre = MiLibreria.MiClase.RetornarNombre();

            Console.Write("el nombre es : {0}\n", MiLibreria.MiClase.nombre);*/





        }
    }
}
