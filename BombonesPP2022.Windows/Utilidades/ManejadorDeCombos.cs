using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombonesPP2022.Entidades;
using BombonesPP2022.Servicios;
using System.Windows.Forms;

namespace BombonesPP2022.Windows.Utilidades
{
    public static class ManejadorDeCombos
    {
        private static ServicioChocolates servicioChocolates;
        private static ServicioRellenos servicioRellenos;
        private static ServicioNueces servicioNueces;
        private static ServicioFabricas servicioFabricas;

        static ManejadorDeCombos()
        {
            servicioChocolates = new ServicioChocolates();
            servicioRellenos = new ServicioRellenos();
            servicioNueces = new ServicioNueces();
            servicioFabricas = new ServicioFabricas();
        }
        
        //METODOS

        //PRIVADOS
        //PUBLICOS
        public static void CargarChocolates(ComboBox comboChocolates)
        {
            List<Chocolate> chocolates = servicioChocolates.ObtenerChocolates();

            foreach (Chocolate chocolate  in chocolates)
            {
                comboChocolates.Items.Add(chocolate.Nombre);
            }

            comboChocolates.SelectedIndex = 0;

            comboChocolates.Tag = chocolates;
        } 

        public static void CargarNueces(ComboBox comboNueces)
        {
            List<Nuez> nueces = servicioNueces.ObtenerNueces();

            foreach(Nuez nuez in nueces)
            {
                comboNueces.Items.Add(nuez.Nombre);
            }

            comboNueces.SelectedIndex = 0;
            comboNueces.Tag = nueces;
        }

        public static void CargarRellenos(ComboBox comboRellenos)
        {
            List<Relleno> rellenos = servicioRellenos.ObtenerRellenos();

            foreach (Relleno relleno in rellenos)
            {
                comboRellenos.Items.Add(relleno.Nombre);
            }

            comboRellenos.SelectedIndex = 0;
            comboRellenos.Tag = rellenos;
        }

        public static void CargarFabrica(ComboBox comboFabricas)
        {
            List<Fabrica> fabricas = servicioFabricas.ObtenerFabricas();

            foreach (Fabrica fabrica in fabricas)
            {
                comboFabricas.Items.Add(fabrica.Nombre);
            }

            comboFabricas.SelectedIndex = 0;
            comboFabricas.Tag = fabricas;
        }

    }
}
