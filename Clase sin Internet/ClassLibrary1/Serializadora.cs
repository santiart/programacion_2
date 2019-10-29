using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_20.Entidades
{
    static class Serializadora
    {
        public static bool Serializar(IXML inter)
        {
            inter.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Auto.xml");
            return true;
        }

        public static bool DeSerializar(IXML inter, out object obj)
        {
            inter.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Auto.xml",out obj);
            return true;
        }
    }
}
