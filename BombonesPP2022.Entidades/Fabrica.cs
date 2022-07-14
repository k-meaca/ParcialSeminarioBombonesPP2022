using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombonesPP2022.Entidades
{
    public class Fabrica
    {
        //ATRIBUTOS

        private int fabricaId;
        private string nombre;
        private string direccion;
        private string gerente;
        private byte[] rowVersion;

        private Pais pais;

        //PROPIEDADES
        public int FabricaId { get => fabricaId; }

        public string Nombre { get => nombre; }

        public string Direccion { get => direccion; }

        public string Gerente { get => gerente; }

        public int PaisId { get => pais.PaisId; }

        public byte[] RowVersion { get => rowVersion; }

        public string Pais { get => pais.Nombre; }

        //CONSTRUCTOR
        public Fabrica(int fabricaId, string nombre, string direccion, string gerente, Pais pais, byte[] rowVersion)
        {
            this.fabricaId = fabricaId;
            this.nombre = nombre;
            this.direccion = direccion;
            this.gerente = gerente;
            this.pais = pais;
            this.rowVersion = rowVersion;
        }

    }
}
