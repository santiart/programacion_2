using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClasesSegundoParcial
{
    [XmlInclude(typeof(Goma))]
    public class Goma : Utiles
    {
        public bool soloLapiz;

        public Goma() { }

        public Goma(bool soloLapiz, string marca, double precio)
            : base(marca, precio)
        {
            this.soloLapiz = soloLapiz;
        }

        public override bool PreciosCuidados
        {
            get => true;
        }
        public bool SoloLapiz
        {
            get => this.soloLapiz;
            set => this.soloLapiz = value;
        }

        public override string ToString()
        {
            string goma = this.UtiliesToString();
            goma += string.Format("Solo lapiz: {0}", this.SoloLapiz.ToString());
            return goma;
        }
    }
}
