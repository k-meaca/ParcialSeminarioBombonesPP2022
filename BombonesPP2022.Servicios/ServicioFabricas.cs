using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombonesPP2022.Entidades;
using BombonesPP2022.Datos.Repositorios;

namespace BombonesPP2022.Servicios
{
    public class ServicioFabricas
    {
        //ATRIBUTOS

        private RepositorioFabricas repositorio;

        //CONSTRUCTOR

        public ServicioFabricas()
        {
            repositorio = new RepositorioFabricas();
        }

        //METODOS

        //PUBLICOS

        public List<Fabrica> ObtenerFabricas()
        {
            return repositorio.ObtenerFabricas();
        }
    }
}
