using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombonesPP2022.Entidades;
using BombonesPP2022.Datos.Repositorios;


namespace BombonesPP2022.Servicios
{
    public class ServicioBombones
    {

        //ATRIBUTOS

        private RepositorioBombones bombones;

        //CONSTRUCTOR

        public ServicioBombones()
        {
            bombones = new RepositorioBombones();
        }

        //METODOS


        //PUBLICOS

        public void AgregarBombon(Bombon bombon)
        {
            bombones.AgregarBombon(bombon);
        }

        public bool ExisteBombon(string nombre)
        {
            return bombones.ExisteBombon(nombre);
        }

        public void EliminarBombon(Bombon bombon)
        {
            bombones.EliminarBombon(bombon);
        }
        public List<Bombon> ObtenerBombones()
        {
            return bombones.ObtenerBombones();
        }
    }
}
