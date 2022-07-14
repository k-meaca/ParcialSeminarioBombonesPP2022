using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BombonesPP2022.Servicios;
using BombonesPP2022.Entidades;
using BombonesPP2022.Windows.Utilidades;

namespace BombonesPP2022.Windows
{
    public partial class frmTipoChocolate : Form
    {
        
        //ATRIBUTOS
        private ServicioChocolates servicio;

        //CONSTRUCTOR
        public frmTipoChocolate()
        {
            InitializeComponent();

            servicio = new ServicioChocolates();

            CargarGrilla();
        }

        //METODOS

        //PRIVADOS

        private void AgregarFila(DataGridViewRow fila)
        {
            DatosDataGridView.Rows.Add(fila);
        }

        private void CargarGrilla()
        {
            List<Chocolate> chocolates = servicio.ObtenerChocolates();

            foreach(Chocolate chocolate in chocolates)
            {
                DataGridViewRow fila = ManejadorDeGrilla.CrearFila(chocolate, DatosDataGridView);
                AgregarFila(fila);
            }
        }

        //private DataGridViewRow CrearFila(Chocolate chocolate)
        //{
        //    DataGridViewRow fila = new DataGridViewRow();

        //    fila.CreateCells(DatosDataGridView);

        //    fila.Cells[colChocolate.Index].Value = chocolate.Nombre;

        //    fila.Tag = chocolate;

        //    return fila;

        //}

        //PUBLICOS

        //EVENTOS

    }
}
