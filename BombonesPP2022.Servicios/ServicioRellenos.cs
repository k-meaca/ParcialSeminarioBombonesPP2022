using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombonesPP2022.Datos.Repositorios;
using BombonesPP2022.Entidades;

namespace BombonesPP2022.Servicios
{
    public class ServicioRellenos
    {
        //ATRIBUTOS

        private RepositorioRellenos repositorio;

        //CONSTRUCTOR

        public ServicioRellenos()
        {
            repositorio = new RepositorioRellenos();
        }

        //METODOS

        //PUBLICOS

        public List<Relleno> ObtenerRellenos()
        {
            return repositorio.ObtenerRellenos();
        }
    }
}
