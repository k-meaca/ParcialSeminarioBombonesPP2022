﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombonesPP2022.Datos.Repositorios;
using BombonesPP2022.Entidades;

namespace BombonesPP2022.Servicios
{
    public class ServicioNueces
    {
        //ATRIBUTOS

        private RepositorioNueces repositorio;


        //CONSTRUCTOR

        public ServicioNueces()
        {
            repositorio = new RepositorioNueces();
        }

        //METODOS

        //PUBLICOS

        public List<Nuez> ObtenerNueces()
        {
            return repositorio.ObtenerNueces();
        }
    }
}
