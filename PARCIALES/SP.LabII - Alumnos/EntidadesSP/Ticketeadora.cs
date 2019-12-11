using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EntidadesSP
{
    public class Ticketeadora
    {
        public bool ImprimirTicket()
        {
            bool retorno = false;
            
            if(File.Exists("//ticket.log"))
            {
                retorno = true;
            }

            return retorno;
        }
    }
}
