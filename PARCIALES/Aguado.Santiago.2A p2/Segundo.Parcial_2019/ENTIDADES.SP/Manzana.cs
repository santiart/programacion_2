using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace ENTIDADES.SP
{
    public class Manzana : Fruta , IDeserializar, ISerializar
    {
        protected string _provinciaOrigen;

        public Manzana(string color, double peso, string provinciaOrigen) : base(color,peso)
        {
            this._provinciaOrigen = provinciaOrigen;
        }

        public string Nombre
        {
            get { return "Manzana"; }
        }

        public override bool TieneCarozo
        {
            get { return true; }
        }

        protected override string FrutaToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(this.ToString());
            sb.AppendFormat("PROVINCIA ORIGEN: " + this._provinciaOrigen + "\n");
            sb.AppendFormat("TIENE CAROZO: " + this.TieneCarozo.ToString() + "\n");
            return sb.ToString();
        }

        public bool Xml(string path, out Fruta f)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Cajon<T>));
                TextReader tr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + path);

                f = (Fruta)xml.Deserialize(tr);
                tr.Close();
                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool Xml(string path)
        {
            try
            {
                Cajon<T> c = new Cajon<T>();
                XmlSerializer xml = new XmlSerializer(typeof(Cajon<T>));
                TextWriter tw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + path);

                xml.Serialize(tw, c);
                tw.Close();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
