using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombonesPP2022.Entidades
{
    public class Chocolate
    {
        //ATRIBUTOS

        private int tipoChocolateId;
        private string tipoChocolate;
        private byte[] rowVersion;

        //PROPIEDADES

        public int TipoChocolateId { get => tipoChocolateId; }
        public string Nombre { get => tipoChocolate; }
        public byte[] RowVersion { get => rowVersion; }

        //CONSTRUCTOR
        public Chocolate(int tipoChocolateId, string tipoChocolate, byte[] rowVersion)
        {
            this.tipoChocolateId = tipoChocolateId;
            this.tipoChocolate = tipoChocolate;
            this.rowVersion = rowVersion;
        }
    }
}
