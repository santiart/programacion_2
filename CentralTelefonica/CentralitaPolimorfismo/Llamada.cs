using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
  public abstract class Llamada
  {
    protected float _duracion;
    protected string _nroDestino;
    protected string _nroOrigen;

    public abstract float CostoLlamada { get; }

    public float Duracion
    {
      get { return this._duracion; }
    }

    public string NroDestino
    {
      get { return this._nroDestino; }
    }

    public string NroOrigen
    {
      get { return this._nroOrigen; }
    }

    public Llamada(string origen, string destino, float duracion)
    {
      this._duracion = duracion;
      this._nroDestino = destino;
      this._nroOrigen = origen;
    }

    protected virtual string Mostrar()
    {
      StringBuilder retorno = new StringBuilder("Numero de origen: " + this._nroOrigen +
          "Numero de Destino: " + this._nroDestino +
          "Duracion de la Llamada" + this._duracion.ToString() + "\n");
      return retorno.ToString();
    }

    public static bool operator ==(Llamada uno, Llamada dos)
    {
      bool retorno = false;

      if (!object.Equals(uno, null) && !object.Equals(dos, null))
      {
        if (object.Equals(uno, dos) &&
            uno._nroDestino == dos._nroDestino &&
            uno._nroOrigen == dos._nroOrigen)
        {
          retorno = true;
        }
      }
      return retorno;
    }

    public static bool operator !=(Llamada uno, Llamada dos)
    {
      return !(uno == dos);
    }

    public static int OrdenarPorDuracionDesc(Llamada uno, Llamada dos)
    {
      string durUno = uno.Duracion.ToString();
      string durDos = dos.Duracion.ToString();
      return -1 * string.Compare(durUno, durDos);
    }

    public static int OrdenarPorDuracionAsc(Llamada uno, Llamada dos)
    {
      return -1 * OrdenarPorDuracionDesc(uno, dos);
    }

  }
}
