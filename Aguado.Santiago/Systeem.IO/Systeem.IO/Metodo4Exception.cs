using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systeem.IO
{
    public class Metodo4Exception : Exception
    {
        public Metodo4Exception(string str):base(str)
        {
        }

        public Metodo4Exception(string str, Exception e):base(str,e)
        {
        }
    }
}
