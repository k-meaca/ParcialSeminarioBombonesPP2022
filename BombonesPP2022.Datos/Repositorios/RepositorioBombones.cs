using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombonesPP2022.Entidades;
using System.Data.SqlClient;

namespace BombonesPP2022.Datos.Repositorios
{
    public class RepositorioBombones
    {

        //ATRIBUTOS

        private RepositorioFabricas repositorioFabricas;
        private RepositorioChocolates repositorioChocolates;
        private RepositorioNueces repositorioNueces;
        private RepositorioRellenos repositorioRellenos;

        //CONSTRUCTOR

        public RepositorioBombones()
        {
            repositorioFabricas = new RepositorioFabricas();
            repositorioChocolates = new RepositorioChocolates();
            repositorioNueces = new RepositorioNueces();
            repositorioRellenos = new RepositorioRellenos();
        }

        //METODOS

        //PRIVADOS

        private Bombon CrearBombon(SqlDataReader lector, List<Chocolate> chocolates,List<Nuez> nueces,List<Relleno> rellenos,List<Fabrica> fabricas)
        {
            int bombonId = lector.GetInt32(0);
            string nombreBombon = lector.GetString(1);
            int tipoChocolateId = lector.GetInt32(2);
            int tipoNuezId = lector.GetInt32(3);
            int tipoRellenoId = lector.GetInt32(4);
            decimal precioVenta = lector.GetDecimal(5);
            int stock = lector.GetInt16(6);
            int fabricaId = lector.GetInt32(7);
            byte[] rowVersion = (byte[])lector[8];

            Chocolate chocolate = chocolates.Find(c => c.TipoChocolateId == tipoChocolateId);
            Nuez nuez = nueces.Find(n => n.TipoNuezId == tipoNuezId);
            Relleno relleno = rellenos.Find(r => r.TipoRellenoId == tipoRellenoId);
            Fabrica fabrica = fabricas.Find(f => f.FabricaId == fabricaId);

            return new Bombon(nombreBombon, chocolate, nuez, relleno, precioVenta, stock, fabrica);
        }


        //PUBLICOS

        public void AgregarBombon(Bombon bombon)
        {
            int bombonId;
            byte[] rowVersion;

            try
            {
                string query = "INSERT INTO Bombones (NombreBombon, TipoChocolateId, TipoNuezId, TipoRellenoId, PrecioVenta, Stock, FabricaId)  " +
                                "VALUES (@Nombre, @TipoChocolateId, @TipoNuezId, @TipoRellenoId, @PrecioVenta, @Stock, @FabricaId)  " +
                                "SELECT @@IDENTITY";
                
                using(SqlConnection conexion = ConexionBD.AbrirConexion() )
                using(SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.Parameters.AddWithValue("@Nombre", bombon.Nombre);
                    comando.Parameters.AddWithValue("@TipoChocolateId", bombon.TipoChocolateId);
                    comando.Parameters.AddWithValue("@TipoNuezId", bombon.TipoNuezId);
                    comando.Parameters.AddWithValue("@TipoRellenoId", bombon.TipoRellenoId);
                    comando.Parameters.AddWithValue("@PrecioVenta", bombon.PrecioVenta);
                    comando.Parameters.AddWithValue("@Stock", bombon.Stock);
                    comando.Parameters.AddWithValue("@FabricaId", bombon.FabricaId);

                    bombonId = Convert.ToInt32(comando.ExecuteScalar());
                }

                string otraQuery = "SELECT RowVersion FROM Bombones WHERE BombonId = @BombonId";

                using (SqlConnection otraConexion = ConexionBD.AbrirConexion())
                using (SqlCommand otroComando = new SqlCommand(otraQuery, otraConexion))
                {
                    otroComando.CommandType = System.Data.CommandType.Text;
                    otroComando.Parameters.AddWithValue("@BombonId", bombonId);

                    rowVersion = (byte[])otroComando.ExecuteScalar();
                }

                bombon.InstanciarIdYRowVersion(bombonId, rowVersion);
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool ExisteBombon(string nombre)
        {
            try
            {
                bool seEncuentra = false;

                string query = "SELECT COUNT(*) FROM Bombones WHERE NombreBombon = @Nombre";

                using(SqlConnection conexion = ConexionBD.AbrirConexion())
                using(SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.Parameters.AddWithValue("@Nombre", nombre);

                    seEncuentra = Convert.ToBoolean(comando.ExecuteScalar());
                }

                return seEncuentra;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public void EliminarBombon(Bombon bombon)
        {
            try
            {
                string query = "DELETE FROM Bombones WHERE BombonId = @BombonId AND RowVersion = @RowVersion";

                using(SqlConnection conexion = ConexionBD.AbrirConexion())
                using(SqlCommand comando = new SqlCommand(query,conexion))
                {
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.Parameters.AddWithValue("@BombonId", bombon.BombonId);
                    comando.Parameters.AddWithValue("@RowVersion", bombon.RowVersion);

                    comando.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public List<Bombon> ObtenerBombones()
        {

            List<Chocolate> chocolates = repositorioChocolates.ObtenerChocolates();
            List<Nuez> nueces = repositorioNueces.ObtenerNueces();
            List<Relleno> rellenos = repositorioRellenos.ObtenerRellenos();
            List<Fabrica> fabricas = repositorioFabricas.ObtenerFabricas();

            try
            {
                List<Bombon> bombones = new List<Bombon>();

                string query = "SELECT * FROM Bombones";

                using (SqlConnection conexion = ConexionBD.AbrirConexion())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            bombones.Add(CrearBombon(lector,chocolates,nueces,rellenos,fabricas));
                        }
                    }

                }

                return bombones;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
