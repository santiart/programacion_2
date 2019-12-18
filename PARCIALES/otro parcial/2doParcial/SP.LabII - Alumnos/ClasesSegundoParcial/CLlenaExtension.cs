using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesSegundoParcial
{
    public static class CLlenaExtension
    {
        public static string InformarNovedad(this CartucheraLlenaException ex)
        {
            return ex.Message;
        }
    }
}
