using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BombonesPP2022.Entidades;

namespace BombonesPP2022.Windows.Utilidades
{
    public static class ManejadorDeGrilla
    {

        public static DataGridViewRow CrearFila(object elemento, DataGridView datos)
        {
            DataGridViewRow fila = new DataGridViewRow();

            fila.CreateCells(datos);

            if(elemento is Chocolate)
            {
                fila.Cells[0].Value = ((Chocolate)elemento).Nombre;
            }
            else if(elemento is Bombon)
            {
                Bombon bombon = (Bombon)elemento;

                fila.Cells[0].Value = bombon.Nombre;
                fila.Cells[1].Value = bombon.Relleno;
                fila.Cells[2].Value = bombon.Chocolate;
                fila.Cells[3].Value = bombon.Nuez;
                fila.Cells[4].Value = bombon.PrecioVenta;
                fila.Cells[5].Value = bombon.Fabrica;
            }

            fila.Tag = elemento;

            return fila;
        }

    }
}
