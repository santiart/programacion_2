using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_03
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title="Ejercicio_04";

            Console.ForegroundColor = ConsoleColor.Yellow;


            int number;
            int i;
            int j;
            bool flag = true;
            

            Console.Write("enter a number : ");
            number = int.Parse(Console.ReadLine());

            for(i=2;i<=number;i++)
            {
                for (j = 2; j < i; j++)
                {
                    flag = false;

                    if ((i % j) == 0)
                    {

                        break;
                    }
                    else if (j == i - 1)
                    {
                        flag = true;
                    }
                }

                if(flag)
                {
                    Console.WriteLine("el numero {0} es un numero primo", i);
                }
            }

            Console.Read();
        }
    }
}
