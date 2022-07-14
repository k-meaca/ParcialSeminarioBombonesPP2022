using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BombonesPP2022.Windows.Utilidades
{
    public static class MostradorDeMensajes
    {

        //METODOS

        //PUBLICOS

        public static DialogResult MensajeConAccion(string mensaje)
        {
            DialogResult accion;

            accion = MessageBox.Show(mensaje, "Adevertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            return accion;
        }
        public static void MostrarMensaje(TipoDeMensaje tipo, string mensaje)
        {
            switch (tipo)
            {
                case TipoDeMensaje.Error:
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case TipoDeMensaje.Advertencia:
                    MessageBox.Show(mensaje, "Adevertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    break;
                case TipoDeMensaje.Exito:
                    MessageBox.Show(mensaje, "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
            }
        }
    }
}
