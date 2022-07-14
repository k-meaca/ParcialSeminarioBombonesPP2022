using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BombonesPP2022.Entidades;

namespace BombonesPP2022.Datos.Repositorios
{
    public class RepositorioNueces
    {

        //METODOS

        //PRIVADOS

        private Nuez CrearNuez(SqlDataReader lector)
        {
            int tipoNuezId = lector.GetInt32(0);
            string nombreNuez = lector.GetString(1);
            byte[] rowVersion = (byte[])lector[2];

            return new Nuez(tipoNuezId, nombreNuez, rowVersion);
        }


        //PUBLICOS

        public List<Nuez> ObtenerNueces()
        {

            try
            {
                List<Nuez> nueces = new List<Nuez>();

                string query = "SELECT * FROM TipoDeNuez";

                using (SqlConnection conexion = ConexionBD.AbrirConexion())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            nueces.Add(CrearNuez(lector));
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
