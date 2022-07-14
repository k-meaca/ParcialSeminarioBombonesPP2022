using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombonesPP2022.Entidades;
using BombonesPP2022.Datos.Repositorios;

namespace BombonesPP2022.Servicios
{
    public class ServicioChocolates
    {

        //ATRIBUTOS

        private RepositorioChocolates repositorio;

        //CONSTRUCTOR

        public ServicioChocolates()
        {
            repositorio = new RepositorioChocolates();
        }

        //METODOS

        //PUBLICOS

        public List<Chocolate> ObtenerChocolates()
        {
            return repositorio.ObtenerChocolates();
        }
    }
}
