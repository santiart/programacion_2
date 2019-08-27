using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio_02";
            Console.ForegroundColor = ConsoleColor.Blue;

            int number;
            int resultCuadrado;
            int resultCube;

            do
            {
                Console.Write("enter a number : ");
                number = int.Parse(Console.ReadLine());

                if(number<=0)
                {
                    Console.WriteLine("ERROR. ¡Reingresar número!");
                }
                
            } while (number <= 0);
            
            resultCuadrado = (int)(Math.Pow(number,2));
            resultCube = (int)(Math.Pow(number, 3));

            Console.WriteLine("the cuadrado of the number  is :{0}", resultCuadrado);
            Console.WriteLine("the cube of the number is {0}", resultCube);

            Console.Read();



        }
    }
}
