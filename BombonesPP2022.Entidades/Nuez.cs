using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombonesPP2022.Entidades
{
    public class Nuez
    {
        
        //ATRIBUTOS

        private int tipoNuezId;
        private string nombreNuez;
        private byte[] rowVersion;

        //PROPIEDADES

        public int TipoNuezId { get => tipoNuezId; }
        public string Nombre { get => nombreNuez; }

        public byte[] RowVersion { get => rowVersion; }

        //CONSTRUCTOR
        public Nuez(int tipoNuezId, string nombreNuez, byte[] rowVersion)
        {
            this.tipoNuezId = tipoNuezId;
            this.nombreNuez = nombreNuez;
            this.rowVersion = rowVersion;
        }
    }
}
