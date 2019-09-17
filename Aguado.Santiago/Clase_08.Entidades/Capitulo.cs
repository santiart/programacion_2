using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_08.Entidades
{
    public class Capitulo
    {
        private int numero;
        private string titulo;
        private int paginas;

        private static Random generadorDeNumeros;
        private static Random generadorDePaginas;

        public int Numero
        {
            get { return this.numero; }
        }

        public string Titulo
        {
            get { return this.titulo; }
        }

        public int Paginas
        {
            get { return this.paginas; }
        }

        static Capitulo()
        {
            Capitulo.generadorDeNumeros = new Random();
            Capitulo.generadorDePaginas = new Random();
        }

        private Capitulo(int number, string title, int pages)
        {
            this.numero = number;
            this.titulo = title;
            this.paginas = pages;
        }

        public static implicit operator Capitulo(string str)
        {
            Capitulo a = new Capitulo(Capitulo.generadorDeNumeros.Next(1,65),str,Capitulo.generadorDePaginas.Next(15,234));
            return a;
        }

        public static bool operator ==(Capitulo a, Capitulo b)
        {
            bool retorno = false;
            if(!object.Equals(a,null) && !object.Equals(b,null))
            {
                if(a.numero == b.numero && a.titulo == b.titulo && a.paginas == b.paginas)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Capitulo a, Capitulo b)
        {
            return !(a == b);
        }

    }
}
