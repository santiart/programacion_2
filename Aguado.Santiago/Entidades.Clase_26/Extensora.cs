using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Externa.Sellada;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace Entidades.Clase_26
{
    public static class Extensora
    {
        public static string ObtenerInfo(this PersonaExternaSellada p)
        {
            return "Nombre: " + p.Nombre + ", Apellido: " + p.Apellido + ", Edad: " + p.Edad + ", Sexo: " + p.Sexo + "\n";
        }

        public static bool EsNulo(this Object o)
        {
            bool retorno = false;

            if(object.Equals(o,null))
            {
                retorno = true;
            }
            return retorno;
        }

        public static List<Persona> ObtenerListadoBD(this Persona p)
        {
            try
            {
                List<Persona> listaPersonas = new List<Persona>();

                SqlConnection sql = new SqlConnection(Properties.Settings.Default.conexion);
                sql.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sql;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT TOP 1000 [id],[nombre],[apellido],[edad]FROM[personas_bd].[dbo].[personas]";

                SqlDataReader reader = cmd.ExecuteReader();

                //DataTable dt = new DataTable();
                //dt.Load(reader);

                while (reader.Read() != false)
                {
                    listaPersonas.Add(new Persona(reader["nombre"].ToString(), reader["apellido"].ToString(), int.Parse(reader["edad"].ToString())));
                }
                reader.Close();
                sql.Close();
                return listaPersonas;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }       
        }
    }
}
