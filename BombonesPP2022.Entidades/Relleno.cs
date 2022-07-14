using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombonesPP2022.Entidades
{
    public class Relleno
    {
        //ATRIBUTOS

        private int tipoRellenoId;
        private string tipoRelleno;
        private byte[] rowVersion;

        //PROPIEDADES

        public int TipoRellenoId { get => tipoRellenoId; }
        public string Nombre { get => tipoRelleno; }

        public byte[] RowVersion { get => rowVersion; }

        //CONSTRUCTOR

        public Relleno(int tipoRellenoId, string tipoRelleno, byte[] rowVersion)
        {
            this.tipoRellenoId = tipoRellenoId;
            this.tipoRelleno = tipoRelleno;
            this.rowVersion = rowVersion;
        }

    }
}
