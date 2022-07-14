using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BombonesPP2022.Entidades;

namespace BombonesPP2022.Datos.Repositorios
{
    public class RepositorioPaises
    {
        //METODOS

        //PRIVADOS

        private Pais CrearPais(SqlDataReader lector)
        {
            int tipoPaisId = lector.GetInt32(0);
            string nombrePais = lector.GetString(1);
            byte[] rowVersion = (byte[])lector[2];

            return new Pais(tipoPaisId, nombrePais, rowVersion);
        }


        //PUBLICOS

        public List<Pais> ObtenerPaises()
        {

            try
            {
                List<Pais> nueces = new List<Pais>();

                string query = "SELECT * FROM Paises";

                using (SqlConnection conexion = ConexionBD.AbrirConexion())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            nueces.Add(CrearPais(lector));
                        }
                    }

                }

                return nueces;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
