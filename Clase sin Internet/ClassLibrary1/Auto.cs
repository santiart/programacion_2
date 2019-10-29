using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO; 

namespace Clase_20.Entidades
{
    public class Auto : IXML
    {
        public string marca;
        public double precio;

        public Auto()
        {
            this.marca = "";
            this.precio = 0;
        }

        public Auto(string marca, double precio)
        {
            this.marca = marca;
            this.precio = precio;
        }

        public bool Guardar(string path)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Auto));

                TextWriter tw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + path);

                xml.Serialize(tw, this);

                tw.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public bool Leer(string path, out object obj)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Auto));

                TextReader tr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + path);

                obj = xml.Deserialize(tr);

                tr.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                obj = null;
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Marca: " + this.marca + "-" + "Precio: " + this.precio.ToString());

            return sb.ToString();
        }
    }
}
