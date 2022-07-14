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
using BombonesPP2022.Windows.Utilidades;
using BombonesPP2022.Servicios;
using System.Data.SqlClient;

namespace BombonesPP2022.Windows
{
    public partial class frmBombonAE : Form
    {
        private frmBombones referenciaFormulario;

        private ServicioBombones servicioBombones;
        public frmBombonAE(frmBombones formulario)
        {
            InitializeComponent();

            referenciaFormulario = formulario;

            ManejadorDeCombos.CargarChocolates(ChocolateComboBox);
            ManejadorDeCombos.CargarNueces(NuezComboBox);
            ManejadorDeCombos.CargarRellenos(RellenoComboBox);
            ManejadorDeCombos.CargarFabrica(FabricaComboBox);

            servicioBombones = new ServicioBombones();
        }

        //METODOS

        //PRIVADOS

        private bool CampoCompleto(TextBox campo)
        {
            if (string.IsNullOrEmpty(campo.Text))
            {
                mostradorErrores.SetError(campo, "Se debe llenar este campo");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CamposCompletos()
        {
            
            mostradorErrores.Clear();

            bool nombreCargado = CampoCompleto(txtNombreBombon);
            bool precioCargado = CampoCompleto(txtPrecio);
            bool stockCargado = CampoCompleto(txtStock);


            return nombreCargado && precioCargado && stockCargado;


        }

        private Chocolate ObtenerChocolate()
        {
            List<Chocolate> chocolates = (List<Chocolate>)ChocolateComboBox.Tag;

            string nombre = ChocolateComboBox.SelectedItem.ToString();

            return chocolates.Find(c => c.Nombre == nombre);
        }

        private Nuez ObtenerNuez()
        {
            List<Nuez> nueces = (List<Nuez>)NuezComboBox.Tag;

            string nombre = NuezComboBox.SelectedItem.ToString();

            return nueces.Find(n => n.Nombre == nombre);
        }

        private Relleno ObtenerRelleno()
        {
            List<Relleno> rellenos = (List<Relleno>)RellenoComboBox.Tag;

            string nombre = RellenoComboBox.SelectedItem.ToString();

            return rellenos.Find(r => r.Nombre == nombre);
        }

        private Fabrica ObtenerFabrica()
        {
            List<Fabrica> fabricas = (List<Fabrica>)FabricaComboBox.Tag;

            string nombre = FabricaComboBox.SelectedItem.ToString();

            return fabricas.Find(f => f.Nombre == nombre);
        }


        //PUBLICOS


        //EVENTOS

        private void txtNombreBombon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (CamposCompletos())
            {

                if (!servicioBombones.ExisteBombon(txtNombreBombon.Text))
                {
                    try
                    {
                        Chocolate chocolate = ObtenerChocolate();
                        Relleno relleno = ObtenerRelleno();
                        Nuez nuez = ObtenerNuez();
                        Fabrica fabrica = ObtenerFabrica();

                        Bombon bombon = new Bombon(txtNombreBombon.Text, chocolate, nuez, relleno,
                            Convert.ToDecimal(txtPrecio.Text), Convert.ToInt32(txtStock.Text), fabrica);

                        servicioBombones.AgregarBombon(bombon);

                        referenciaFormulario.AgregarBombon(bombon);

                        referenciaFormulario.HabilitarBotones();

                        MostradorDeMensajes.MostrarMensaje(TipoDeMensaje.Exito, "Se ha ingresado el bombon correctamente.");

                        this.Close();
                    }
                    catch (SqlException)
                    {
                        MostradorDeMensajes.MostrarMensaje(TipoDeMensaje.Error, "No se ha podido agregar el bombon.");
                    }
                    catch (Exception)
                    {
                        MostradorDeMensajes.MostrarMensaje(TipoDeMensaje.Error, "Ha ocurrido algo inesperado.");
                    }
                }
                else
                {
                    MostradorDeMensajes.MostrarMensaje(TipoDeMensaje.Error, "Ya existe un bombon con ese nombre.");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
