using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_17.Entidades;

namespace Clase_17.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Deportivo dep = new Deportivo(1000, "dhd 654", 200);
            Avion avi = new Avion(1500, 976);
            Privado priv = new Privado(1000,946,30);
            Comercial com = new Comercial(180,946,150);
            Carreta carr = new Carreta(250);

            Console.WriteLine("Impuesto Nacional a pagar por deportivo: ");
            Program.Mostrar(dep);
            Console.WriteLine("Impuesto Nacional a pagar por auto avion: ");
            Program.Mostrar(avi);
            Console.WriteLine("Impuesto Nacional a pagar por avion privado: ");
            Program.Mostrar(priv);
            Console.WriteLine("Impuesto Nacional a pagar por avion comercial: ");
            Program.Mostrar(com);

            Console.ReadLine();
        }

        static void Mostrar(IAFIP impuestos)
        {
            Console.WriteLine(impuestos.CalcularImpuestos());
        }

        static void MostrarProvincial(IARBA impProv)
        {
            Console.WriteLine(impProv.CalcularImpuestos());
        }
    }
}
