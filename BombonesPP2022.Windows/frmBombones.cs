using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BombonesPP2022.Entidades;
using BombonesPP2022.Servicios;
using BombonesPP2022.Windows.Utilidades;
using System.Data.SqlClient;

namespace BombonesPP2022.Windows
{
    public partial class frmBombones : Form
    {
        //ATRIBUTOS

        private ServicioBombones servicio;

        //CONSTRUCTOR
        public frmBombones()
        {
            InitializeComponent();

            servicio = new ServicioBombones();

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
            List<Bombon> bombones = servicio.ObtenerBombones();

            foreach(Bombon bombon in bombones)
            {
                DataGridViewRow fila = ManejadorDeGrilla.CrearFila(bombon,DatosDataGridView);
                AgregarFila(fila);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmBombonAE frmAgregar = new frmBombonAE(this);

            btnBorrar.Enabled = false;

            frmAgregar.Show();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if(DatosDataGridView.SelectedRows.Count > 0)
            {
                DialogResult accion = MostradorDeMensajes.MensajeConAccion("Desea eliminar este dato?");

                if(accion == DialogResult.OK)
                {
                    try
                    {
                        Bombon bombon = (Bombon)DatosDataGridView.SelectedRows[0].Tag;

                        servicio.EliminarBombon(bombon);

                        DatosDataGridView.Rows.Remove(DatosDataGridView.SelectedRows[0]);

                        MostradorDeMensajes.MostrarMensaje(TipoDeMensaje.Exito, "El bombon se ha eliminado exitosamente.");
                    }
                    catch (SqlException)
                    {
                        MostradorDeMensajes.MostrarMensaje(TipoDeMensaje.Error, "No se ha podido eliminar el dato.");
                    }
                    catch (Exception)
                    {
                        MostradorDeMensajes.MostrarMensaje(TipoDeMensaje.Error, "Ha ocurrido algo inesperado.");
                    }


                }

            }
        }

        //PUBLICOS

        public void AgregarBombon(Bombon bombon)
        {
            var fila = ManejadorDeGrilla.CrearFila(bombon, DatosDataGridView);
            AgregarFila(fila);
        }

        public void HabilitarBotones()
        {
            btnAgregar.Enabled = true;
            btnBorrar.Enabled = true;
        }

        //EVENTOS
    }
}
