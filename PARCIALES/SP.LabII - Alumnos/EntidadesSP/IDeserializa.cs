using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    public interface IDeserializa
    {
        bool Xml(out Lapiz pencil);
    }
}
