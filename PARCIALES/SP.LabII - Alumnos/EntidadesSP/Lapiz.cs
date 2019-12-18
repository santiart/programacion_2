using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data;
using System.IO;

namespace EntidadesSP
{
    public class Lapiz : Utiles, ISerializa, IDeserializa
    {
        public ConsoleColor color;
        public ETipoTrazo trazo;

        public Lapiz(ConsoleColor color, ETipoTrazo trazo, string marca, double precio) : base(marca,precio)
        {
            this.color = color;
            this.trazo = trazo;
        }

        public override bool PreciosCuidados
        {
            get { return true; }
        }

        public string path => throw new NotImplementedException();

        public bool Xml()
        {
            bool retorno = false;

            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Lapiz));
                TextWriter tw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "Aguado.Santiago.lapiz.xml");
                xml.Serialize(tw, this);
                tw.Close();

                retorno = true;
            }
            catch(Exception e)
            {
                throw e;
            }

            return retorno;
        }

        bool IDeserializa.Xml(out Lapiz pencil)
        {
            bool retorno = false;
            pencil = null;

            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Lapiz));
                TextReader tr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "Aguado.Santiago.lapiz.xml");
                pencil = (Lapiz)xml.Deserialize(tr);
                tr.Close();

                retorno = true;
            }
            catch(Exception e)
            {
                throw e;
            }

            return retorno;
        }

        protected override string UtilesToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("LAPIZ \n");
            sb.AppendFormat(base.UtilesToString());
            sb.AppendFormat("COLOR: " + this.color + "\n");
            sb.AppendFormat("TRAZO: " + this.trazo + "\n");
            sb.AppendFormat("PRECIOS CUIDADOS: " + this.PreciosCuidados.ToString() + "\n");
            return sb.ToString();
        }
    }
}
