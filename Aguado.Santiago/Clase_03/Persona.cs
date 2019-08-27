using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_03
{
    class Persona
    {
        public string name;
        public string surname;
        public int dni;

        public Persona(string name, string surname, int dni)
        {
            this.name = name;
            this.surname = surname;
            this.dni = dni;
        }
        public string Mostrar()
        {
            return this.name + '-' + this.surname + '-' + this.dni.ToString() + '\n';
        }


    }
}
