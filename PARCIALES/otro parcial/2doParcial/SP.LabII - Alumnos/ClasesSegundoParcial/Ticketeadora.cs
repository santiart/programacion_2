using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClasesSegundoParcial
{
    public static class Ticketeadora<T> where T : Utiles
    {
        public static bool ImprimirTicket(Cartuchera<T> c)
        {
            try
            {
                //Cartuchera<Utiles> c = (Cartuchera)cartuchera;
                StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                                    + @"\" + "tickets.log", true);
                writer.WriteLine("[{0}]\nPrecio: {1}", DateTime.Now.ToString(), c.PrecioTotal.ToString());
                writer.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
