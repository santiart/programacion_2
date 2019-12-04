using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Data;

namespace ENTIDADES.SP
{
    public class Cajon<T> : ISerializar
    {
        protected int _capacidad;
        protected List<T> _elementos;
        protected double _precioUnitario;

        #region Propiedades

        public int Capacidad
        {
            get { return this._capacidad; }
        }

        public List<T> Elementos
        {
            get { return this._elementos; }
        }

        public double PrecioTotal
        {
            get
            {
                return this._precioUnitario * Elementos.Count;
            }
        }

        #endregion

        #region Constructores

        public Cajon()
        {
            this._elementos = new List<T>();
        }

        public Cajon(int capacidad):this()
        {
            this._capacidad = capacidad;
        }

        public Cajon(double precioUnitario, int capacidad):this(capacidad)
        {
            this._precioUnitario = precioUnitario;
        }

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CAPACIDAD: " + this._capacidad + "\n");
            sb.AppendFormat("PRECIO TOTAL: " + this.PrecioTotal.ToString() + "\n");
            sb.AppendFormat("ELEMENTOS: " + this.Elementos.ToString());
            return sb.ToString();
        }

        public bool Xml(string path)
        {
            try
            {
                Cajon<T> c = new Cajon<T>();
                XmlSerializer xml = new XmlSerializer(typeof(Cajon<T>));
                TextWriter tw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + path);

                xml.Serialize(tw, c);
                tw.Close();
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static Cajon<T> operator +(Cajon<T> c, T elementos)
        {
            if(!object.Equals(c,null) && !object.Equals(elementos,null))
            {
                if(c.Elementos.Count < c._capacidad)
                {
                    c.Elementos.Add(elementos);
                }
            }
            return c;
        }

        public delegate void LimitePrecio(double precio, Cajon<T> c);
        public event LimitePrecio EventoPrecio;

        public void ManejadorPrecio(double precio, Cajon<T> c)
        {
            string file = "\\archivo.txt";
            StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + file, true);
            sw.WriteLine("Precio fuera de rango: " + precio + " del Cajon: " + c + "\n");
            sw.Close();
        }
    }
}
