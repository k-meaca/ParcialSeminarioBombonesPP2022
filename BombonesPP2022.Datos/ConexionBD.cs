using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace BombonesPP2022.Datos
{
    public static class ConexionBD
    {
        private static readonly string conexionString;
        private static SqlConnection conexion;

        static ConexionBD()
        {
            conexionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        }

        public static SqlConnection AbrirConexion()
        {
            try
            {
                conexion = new SqlConnection(conexionString);
                conexion.Open();
                return conexion;
            }
            catch (SqlException)
            {
                throw;
            }
        }
        
        public static void CerrarConexion()
        {
            if(conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
