using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_08.Entidades
{
    public class Libro
    {
        private string titulo;
        private string autor;
        private List<Capitulo> capitulos = new List<Capitulo>();

        public string Titulo
        {
            get { return this.titulo; }
        }

        public string Autor
        {
            get { return this.autor; }
        }

        public Libro(string title, string autor)
        {
            this.titulo = title;
            this.autor = autor;
        }

        public int CantidadPaginas
        {
            get
            {
                int cant = 0;

                foreach(Capitulo c in this.capitulos)
                {
                    cant += c.Paginas;
                }
                return cant;
            }
        }

        public int CantidadCapitulos
        {
            get
            {
                int cant = capitulos.Count();
                return cant;
            }
        }

        public Capitulo this[int index]
        {
            get
            {
                Capitulo c = null;
                if(index >= 0 && index <= this.capitulos.Count)
                {
                    c = this.capitulos[index];
                }
                return c;
            }
            set
            {

                if (index <= this.capitulos.Count && index > 0)
                {
                    this.capitulos.Insert(index, value);
                }
                else if(index == this.capitulos.Count)
                {
                    this.capitulos.Add(value);
                }

            }
        }


    }
}
