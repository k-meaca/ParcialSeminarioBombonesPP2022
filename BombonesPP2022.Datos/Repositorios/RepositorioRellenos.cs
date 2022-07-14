using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BombonesPP2022.Entidades;

namespace BombonesPP2022.Datos.Repositorios
{
    public class RepositorioRellenos
    {
        //METODOS

        //PRIVADOS

        private Relleno CrearRelleno(SqlDataReader lector)
        {
            int tipoRellenoId = lector.GetInt32(0);
            string nombreRelleno = lector.GetString(1);
            byte[] rowVersion = (byte[])lector[2];

            return new Relleno(tipoRellenoId, nombreRelleno, rowVersion);
        }


        //PUBLICOS

        public List<Relleno> ObtenerRellenos()
        {

            try
            {
                List<Relleno> rellenos = new List<Relleno>();

                string query = "SELECT * FROM TiposDeRelleno";

                using (SqlConnection conexion = ConexionBD.AbrirConexion())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            rellenos.Add(CrearRelleno(lector));
                        }
                    }

                }

                return rellenos;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
