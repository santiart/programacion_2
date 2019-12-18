using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ClasesSegundoParcial
{
    [Serializable]
    //[XmlInclude(typeof(Lapiz))]
    public class Lapiz : Utiles , ISerializa, IDeserializa
    {
        
        public ConsoleColor color;
        public ETipoTrazo trazo;

        public Lapiz() { }

        public Lapiz(ConsoleColor color, ETipoTrazo trazo, string marca, double precio)
            : base (marca, precio)
        {
            this.color = color;
            this.trazo = trazo;
        }

        public ConsoleColor Color
        {
            get => this.color;
            set => this.color = value;
        }
        public ETipoTrazo Trazo
        {
            get => this.trazo;
            set => this.trazo = value;
        }


        public override bool PreciosCuidados
        {
            get => true;
        }

        public string Path
        {
            get => Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\SuarezMurray.DemianJose.Lapiz.xml";
        }

        public override string ToString()
        {
            string lapiz = this.UtiliesToString();
            lapiz += string.Format("Color: {0}\nTrazo: {0}\n", this.Color.ToString(), this.Trazo.ToString());
            return lapiz;
        }

        public bool Xml()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Lapiz));
                TextWriter writer = new StreamWriter(this.Path);
                serializer.Serialize(writer, this);
                writer.Close();
                return true;
            }
            catch(Exception)
            {
                return false;
            }            
        }

        bool IDeserializa.Xml(out Lapiz l)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Lapiz));
                TextReader reader = new StreamReader(this.Path);                
                l = (Lapiz)serializer.Deserialize(reader);
                reader.Close();
                return true;
            }
            catch(Exception e)
            {
                l = null;
                return false;
            }
        }
    }
}
