using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_20.Entidades;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace Clase_20
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "\\Persona.xml";
            string path2 = "\\Lista.xml";

            //List<Persona> ListaApodos = new List<Persona>();
            
            //foreach(Persona x in ListaApodos)
            //{
            //    x.Apodos.Add("Juancho");
            //    x.Apodos.Add("Gero");
            //    x.Apodos.Add("Robert");
            //}

            Persona per = new Persona("Juan", "Perez",15);
            Persona per2 = new Persona("Geronimo", "Paez",23);
            Persona per3 = new Persona("Roberto", "Gomez",45);

            Console.WriteLine(per.ToString());

            List<Persona> lista = new List<Persona>();
            lista.Add(per);
            lista.Add(per2);
            lista.Add(per3);

            try
            {
                XmlSerializer xmlS = new XmlSerializer(typeof(Persona));
                //XmlTextWriter xmlW = new XmlTextWriter();

                TextWriter txtW = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + path);
                xmlS.Serialize(txtW, per);
                txtW.Close();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                XmlSerializer xmlS = new XmlSerializer(typeof(Persona));

                TextReader txtR = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + path);
                per = (Persona)xmlS.Deserialize(txtR);
                Console.WriteLine(per.ToString());
                txtR.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                XmlSerializer xmlS = new XmlSerializer(typeof(List<Persona>));

                TextWriter Tw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + path2);

                xmlS.Serialize(Tw, lista);
                Tw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
