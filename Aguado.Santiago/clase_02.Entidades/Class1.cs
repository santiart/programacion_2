using System;

namespace clase_02.Entidades
{
    public class Sello
    {
        public static string mensaje;
        public static ConsoleColor color;

        public static void Mensaje( string mensaje)
        {
            Sello.mensaje = mensaje;
        }

        public static string imprimir()
        {
            Sello.color = ConsoleColor.White;

            return ArmarFormatoMensaje();
        }

        public static void Borrar()
        {
            Sello.mensaje = " ";
        }

        public static string imprimirEnColor()
        {
            Console.ForegroundColor = color;

            return ArmarFormatoMensaje();
        }

        private static string ArmarFormatoMensaje()
        {
            string techo=null;
            int tam = Sello.mensaje.Length;
            int i;
            

            for(i=0;i<tam+2;i++)
            {
                techo += "*";
                 
            }
            return techo + "\n*" + Sello.mensaje + "*\n" + techo;

        }
        

        

    }
}
