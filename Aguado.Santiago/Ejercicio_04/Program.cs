using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ejercicio_04";

            int i;
            int contador=0;
            int number=0;
            int accumulator;
            do
            {
                accumulator = 0;

                for (i = 1; i < number; i++)
                {
                    if ((number % i) == 0)
                    {
                        accumulator += i;
                    }
                }

                if (accumulator == i)
                {
                    Console.WriteLine("el numero {0} es perfecto", i);
                    contador++;
                }
                number++;

            } while(contador<10);




        }
    }
}
