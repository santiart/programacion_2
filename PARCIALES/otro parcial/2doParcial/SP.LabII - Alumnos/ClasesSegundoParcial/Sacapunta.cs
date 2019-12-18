using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClasesSegundoParcial
{
    [XmlInclude(typeof(Sacapunta))]
    public class Sacapunta : Utiles
    {
        public bool deMetal;

        public Sacapunta() { }

        public Sacapunta(bool deMetal, double precio, string marca)
            :base(marca, precio)
        {
            this.deMetal = deMetal;
        }

        public override bool PreciosCuidados
        {
            get => false;
        }
        public bool DeMetal
        {
            get => this.deMetal;
            set => this.deMetal = value;
        }

        public override string ToString()
        {
            string sacapuntas = this.UtiliesToString();
            sacapuntas += string.Format("De metal: {0}\n",this.DeMetal.ToString());
            return sacapuntas;
        }
    }
}
