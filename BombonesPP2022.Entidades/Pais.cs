using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombonesPP2022.Entidades
{
    public class Pais
    {
        //ATRIBUTOS

        private int paisId;
        private string nombrePais;
        private byte[] rowVersion;


        //PROPIEDADEs

        public int PaisId { get => paisId; }

        public string Nombre { get => nombrePais; }

        public byte[] RowVersion { get => rowVersion; }

        //CONSTRUCTOR
        public Pais(int paisId, string nombrePais, byte[] rowVersion)
        {
            this.paisId = paisId;
            this.nombrePais = nombrePais;
            this.rowVersion = rowVersion;
        }
    }
}
