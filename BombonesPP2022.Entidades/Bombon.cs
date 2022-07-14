using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombonesPP2022.Entidades
{
    public class Bombon
    {

        //ATRIBUTOS

        private int bombonId;
        private string nombreBombon;
        private decimal precioVenta;
        private int stock;
        private byte[] rowVersion;

        private Chocolate chocolate;
        private Nuez nuez;
        private Relleno relleno;
        private Fabrica fabrica;

        //PROPIEDADES

        public int BombonId { get => bombonId; }
        public string Nombre { get => nombreBombon; }

        public int TipoChocolateId { get => chocolate.TipoChocolateId; }

        public int TipoNuezId { get => nuez.TipoNuezId; }

        public int TipoRellenoId { get => relleno.TipoRellenoId; }

        public int FabricaId { get => fabrica.FabricaId; }
        public decimal PrecioVenta { get => precioVenta; }

        public int Stock { get => stock; }

        public byte[] RowVersion { get => rowVersion; }

        public string Relleno { get => relleno.Nombre; }

        public string Chocolate { get => chocolate.Nombre;}

        public string Nuez { get => nuez.Nombre; }
        public string Fabrica { get => fabrica.Nombre; }

        //CONSTRUCTOR
        public Bombon(string nombreBombon, Chocolate chocolate, Nuez nuez,
            Relleno relleno, decimal precioVenta, int stock, Fabrica fabrica)
        {
            this.nombreBombon = nombreBombon;
            this.chocolate = chocolate;
            this.nuez = nuez;
            this.relleno = relleno;
            this.precioVenta = precioVenta;
            this.stock = stock;
            this.fabrica = fabrica;
        }

        //METODOS

        //PUBLICOS

        /// <summary>
        /// Coloca en el bombon su Id y el RowVersion generado si y solo si no fueron colocados anteriormente.
        /// </summary>
        /// <param name="bombonId">Se obtiene mediante SQL</param>
        /// <param name="rowVersion">Se obtiene mediante SQL</param>
        public void InstanciarIdYRowVersion(int bombonId, byte[] rowVersion)
        {
            if(this.bombonId == 0 && this.rowVersion == null)
            {
                this.bombonId = bombonId;
                this.rowVersion = rowVersion;
            }
        }

    }
}
