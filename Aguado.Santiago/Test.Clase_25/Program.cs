using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clase__25;

namespace Test.Clase_25
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            Empleado emp = new Empleado("Juan", "Perez", 123);
            emp.limiteSueldo += new LimiteSueldoDelegado(prog.ManejadorLimiteSueldo);
            emp.limiteSueldoMejorado += new SueldoMejoradoDel(ManejadorLimiteSueldoMejorado);
            emp.limiteSueldoMejorado += new SueldoMejoradoDel(prog.ManejadorLImiteSueldoMejorado2);
            emp.Sueldo = 33000;

            //Console.WriteLine(emp.ToString());
            Console.ReadKey();
        }
        
        public void ManejadorLimiteSueldo(double sueldo, Empleado emp)
        {
            Console.WriteLine("Empleado con sueldo aumentado, ALTO GATITO");
            Console.WriteLine(emp.ToString() + "sueldo: " + sueldo);
        }

        public static void ManejadorLimiteSueldoMejorado(Empleado emp, EmpleadoEventArgs e)
        {
            Console.WriteLine("Empleado con sueldo aumentado,ALTO GATO");
            Console.WriteLine(emp.ToString() + "Sueldo:" + e.SueldoAsignar.ToString());
        }

        public void ManejadorLImiteSueldoMejorado2(Empleado emp, EmpleadoEventArgs e)
        {
            Console.WriteLine("Empleado con sueldo aumentado,ALTO CHORRO");
            Console.WriteLine(emp.ToString() + "Sueldo:" + e.SueldoAsignar.ToString());
        }
    }
}
