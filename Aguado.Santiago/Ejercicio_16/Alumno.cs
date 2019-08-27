using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_16
{
    class Alumno
    {
        private byte nota1;
        private byte nota2;
        private float notaFinal;
        public string apellido;
        public int legajo;
        public string nombre;

        public void CalcularFinal()
        {
            if(this.nota1 >4 && this.nota2 >4)
            {
                Random notaFinal = new Random();
                notaFinal.Next(1, 10);   //Next(1,10);
            }
            else
            {
                notaFinal = -1;
            }

        }

        public void Estudiar(byte notaUno, byte notaDos)
        {
            notaUno = 8;
            notaDos = 5;
            this.nota1 = notaUno;
            this.nota2 = notaDos;
        }

        public string Mostrar()
        {
            return this.apellido + '-' + this.nombre + '-' + this.legajo.ToString() + '\n';
        }
    }
}
