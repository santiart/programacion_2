using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EntidadesSP
{
    public class Ticketeadora<T> where T : Utiles 
    {
        public static bool ImprimirTicket(Cartuchera<T> c)
        {
            bool retorno = false;
            
            try
            {
                string file = "//tickets.txt";

                StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + file, true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("Precio Total: $" + c.PrecioTotal.ToString() + "\n");
                sw.Close();

                retorno = true;
            }
            catch(Exception e)
            {
                throw e;
            }

            return retorno;
        }
    }
}
