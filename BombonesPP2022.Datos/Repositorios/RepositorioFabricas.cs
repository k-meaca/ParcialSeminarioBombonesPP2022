using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombonesPP2022.Entidades;
using System.Data.SqlClient;

namespace BombonesPP2022.Datos.Repositorios
{
    public class RepositorioFabricas
    {

        //ATRIBUTOS

        RepositorioPaises repositorioPaises;

        //CONSTRUCTOR

        public RepositorioFabricas()
        {
            repositorioPaises = new RepositorioPaises();
        }

        //METODOS

        //PRIVADOS

        private Fabrica CrearFabrica(SqlDataReader lector, List<Pais> paises)
        {
            int fabricaId = lector.GetInt32(0);
            string nombreFabrica = lector.GetString(1);
            string direccion = lector.GetString(2);
            string gerente = lector.GetString(3);
            int paisId = lector.GetInt32(4);
            byte[] rowVersion = (byte[])lector[5];

            Pais pais = paises.Find(p => p.PaisId == paisId);

            return new Fabrica(fabricaId, nombreFabrica, direccion, gerente, pais, rowVersion);
        }


        //PUBLICOS

        public List<Fabrica> ObtenerFabricas()
        {
            List<Pais> paises = repositorioPaises.ObtenerPaises();

            try
            {
                List<Fabrica> fabricas = new List<Fabrica>();

                string query = "SELECT * FROM Fabricas";

                using (SqlConnection conexion = ConexionBD.AbrirConexion())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            fabricas.Add(CrearFabrica(lector,paises));
                        }
                    }

                }

                return fabricas;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
