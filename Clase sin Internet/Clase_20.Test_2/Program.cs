using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_20.Entidades;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace Clase_20.Test_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "\\ListaPersonas.xml";

            List<Persona> lista = new List<Persona>();
            Persona per = new Persona("pername", "persur", 42);
            Empleado emp = new Empleado("empname", "empsur", 25, 1234, 15000);
            Alumno alu = new Alumno("aluname", "alusur", 15, 10);
            lista.Add(per);
            lista.Add(emp);
            lista.Add(alu);

            XmlSerializer xml = new XmlSerializer(typeof(List<Persona>));
            TextWriter tw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + path);
            xml.Serialize(tw, lista);
            tw.Close();

            TextReader tr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + path);
            lista =(List<Persona>)xml.Deserialize(tr);
            tr.Close();

            Console.ReadLine();
        }
    }
}
