using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Externa;

namespace Entidades.Clase_26
{
    public class PersonaHerredada : PersonaExterna
    {
        public PersonaHerredada(string nombre, string apellido, int edad, ESexo sexo) : base(nombre, apellido, edad, sexo)
        {
        }

        #region Properties

        public string Apellido
        {
            get { return this._apellido; }
        }

        public string Nombre
        {
            get { return this._nombre; }
        }

        public int Edad
        {
            get { return this._edad; }
        }

        public Externa.ESexo Sexo
        {
            get { return this._sexo; }
        }

        #endregion

        public string MostrarDatos()
        {
            return "Nombre: " + this.Nombre + ", Apellido: " + this.Apellido + ", Edad: " + this.Edad + ", Sexo: " + this.Sexo + "\n";
        }
    }
}
