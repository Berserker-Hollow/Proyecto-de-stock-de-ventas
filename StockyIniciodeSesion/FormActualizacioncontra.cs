using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockyIniciodeSesion
{
    public partial class FormActualizacioncontra: Form
    {
        public FormActualizacioncontra()
        {
            InitializeComponent();
        }

        private void txtContraseña_Nueva_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtContraseña_Nueva_Enter(object sender, EventArgs e)
        {
            if (txtContraseña_Nueva.Text == "Contraseña Nueva")
            {
            }
            txtContraseña_Nueva.Text = "";
            txtContraseña_Nueva.ForeColor = Color.Black;
        }

        private void txtContraseña_Nueva_Leave(object sender, EventArgs e)
        {
            if (txtContraseña_Nueva.Text == "")
            {
            }
            txtContraseña_Nueva.Text = "Contraseña Nueva";
            txtContraseña_Nueva.ForeColor = Color.Gray;
        }

        private void txtConfirmar_Contraseña_Enter(object sender, EventArgs e)
        {
            if (txtConfirmar_Contraseña.Text == "Confirmar Contraseña")
            {
            }
            txtConfirmar_Contraseña.Text = "";
            txtContraseña_Nueva.ForeColor = Color.Black;
        }

        private void txtConfirmar_Contraseña_Leave(object sender, EventArgs e)
        {
            if (txtConfirmar_Contraseña.Text == "")
            {
            }
            txtConfirmar_Contraseña.Text = "Confirmar Contraseña";
            txtContraseña_Nueva.ForeColor = Color.Gray;
        }
    }
}
