using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BombonesPP2022.Entidades;

namespace BombonesPP2022.Datos.Repositorios
{
    public class RepositorioChocolates
    {
        //public void AgregarChocolate(string nombre)
        //{
        //    int chocolateId;
        //    byte[] rowVersion;

        //    try
        //    {
        //        string query = "INSERT INTO TiposDeChocolate (Chocolate) VALUES (@Nombre) SCOPE_IDENTITY() TipoChocolateId";
        //        using (SqlConnection conexion = ConexionBD.AbrirConexion())
        //        using (SqlCommand comando = new SqlCommand(query, conexion))
        //        {
        //            comando.CommandType = System.Data.CommandType.Text;
        //            comando.Parameters.AddWithValue("@Nombre", nombre);

        //        }

        //    }
        //}
        
        //METODOS

        //PRIVADOS

        private Chocolate CrearChocolate(SqlDataReader lector)
        {
            int tipoChocolateId = lector.GetInt32(0);
            string tipoChocolate = lector.GetString(1);
            byte[] rowVersion = (byte[])lector[2];

            return new Chocolate(tipoChocolateId, tipoChocolate, rowVersion);
        }

        //PUBLICOS
        public List<Chocolate> ObtenerChocolates()
        {

            try
            {
                List<Chocolate> chocolates = new List<Chocolate>();
                
                string query = "SELECT * FROM TiposDeChocolate";
                
                using(SqlConnection conexion = ConexionBD.AbrirConexion())
                using(SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            chocolates.Add(CrearChocolate(lector));
                        }
                    } 

                }

                return chocolates;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
