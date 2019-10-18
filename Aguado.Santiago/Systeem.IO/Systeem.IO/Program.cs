using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Systeem.IO
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Archivos";
            //string file = @"C:\\miCarpeta\\miArchivo.txt";
            //string file2 = @"C:\\miCarpeta\\incidencias.log";

            //Environment.GetFolderPath(Environment.SpecialFolder.Windows);

            //try//contiene las lineas de codigo que suelen tirar excepciones
            //{
            //    StreamWriter sw = new StreamWriter(file);//,true
            //    StreamWriter arch = new StreamWriter(file2, true);

            //    sw.WriteLine("hola mundo");
            //    sw.WriteLine(DateTime.Now);//siempre va a sobreescribir, por eso agregamos un booleano que indicara si quiero agregar cosas o no(path,true)
            //    sw.Close();
            //    arch.Close();
            //}
            //catch(DirectoryNotFoundException e)//captura la linea de codigo que le pasa el try
            //{
            //    Console.WriteLine(e.ToString());
            //}
            //catch(ArgumentException a)
            //{
            //    Console.WriteLine(a.ToString());
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e.ToString());
            //}
            //finally
            //{
            //    StreamReader sr = new StreamReader(file,true);
            //    //string read = sr.ReadToEnd();
            //    string line;
            //    while((line = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(line);
            //    }

            //    Console.ReadLine();

            //    using (StreamWriter writer = new StreamWriter(file))
            //    {
            //        string lines;
            //        do
            //        {
            //            lines = sr.ReadLine();
            //            Console.WriteLine(lines);

            //        } while (lines != null);
            //    }

            //    sr.Dispose();
            //    Console.ReadKey();
            //    //dispose ibera los recursos que hayan sido tomados por el objeto

            try
            {
                Program.Metodo1();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);

                try
                {
                    using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\incidencias.log"))
                    {
                        sw.WriteLine(e.StackTrace);
                    }

                    using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\incidencias.log"))
                    {
                        sw.WriteLine(e.StackTrace);
                    }
                }
                catch { }
            }
            Console.ReadLine();
        }

        public static void Metodo1()
        {
            try
            {
                Program.Metodo2();
            }
            catch(Exception e)
            {
                Console.WriteLine("estoy en el metodo 1");
                Console.WriteLine(e.InnerException.InnerException.Message);
                throw new Exception("excepcion del metodo 1", e);
            }
        }
        public static void Metodo2()
        {
            try
            {
                Program.Metodo3();
            }
            catch(DirectoryNotFoundException m)
            {
                Console.WriteLine("estoy en el metodo 2");
                Console.WriteLine(m.InnerException.Message);
                throw new DirectoryNotFoundException("excepcion del metodo 2", m);
            }
        }

        public static void Metodo3()
        {
            try
            {
                Program.Metodo4();
            }
            catch(ArgumentException m)
            {
                Console.WriteLine("estoy en el metodo 3");
                Console.WriteLine(m.Message);
                throw new DirectoryNotFoundException("Excepciion del metodo 3", m);
            }
        }

        public static void Metodo4()
        {
            Console.WriteLine("estoy en el metodo 4");
            throw new ArgumentException("Excepcion del metodo 4");     
        }
    }
}
