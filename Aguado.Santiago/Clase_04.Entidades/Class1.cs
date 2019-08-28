using System;

namespace Clase_04.Entidades
{
    public class Cosa
    {
        public int entero;
        public string cadena;
        public DateTime fecha;

        public string Mostrar()
        {
            return this.cadena + '-' + this.entero.ToString() + '-' + this.fecha.ToString() + '\n';
        }

        public void EstablecerValor(int ent)
        {
            this.entero = ent;
        }

        public void EstablecerValor(string str)
        {
            this.cadena = str;
        }

        public void EstablecerValor(DateTime fech)
        {
            this.fecha = fech;
        }

        public Cosa()
        {
            this.entero = -1;
            this.cadena = "sdgdfhdfh";
            this.fecha = DateTime.Now;
        }

        public Cosa(string str):this() //(solo para constructores)
        {
           // this.entero = -1;//se puede borrar
            this.cadena = str;
           // this.fecha = DateTime.Now;//se puede borrar
        }

        public Cosa(string str, DateTime fech):this(str)
        {
            //this.entero = -1;//se puede borrar
            //this.cadena = str;//se puede borrar
            this.fecha = fech; 
        }

        public Cosa(string str, DateTime fech, int ent):this(str,fech)
        {
            this.entero = ent;
           // this.cadena = str;//se puede borrar
           // this.fecha = fech;//se puede borrar
        }
    }
}
