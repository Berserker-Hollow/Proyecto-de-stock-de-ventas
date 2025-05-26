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
    public partial class FormCodigoVerificacion: Form
    {
        public FormCodigoVerificacion()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SesionRecuperacion.CodigoVerificacion = new Random().Next(100000, 999999).ToString();
            SesionRecuperacion.Expiracion = DateTime.Now.AddMinutes(5);
            try
            {
                CorreoHelper.EnviarCodigo(SesionRecuperacion.CorreoUsuario, SesionRecuperacion.CodigoVerificacion);
                MessageBox.Show("Código reenviado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al reenviar el código: " + ex.Message);
            }
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == SesionRecuperacion.CodigoVerificacion &&
                DateTime.Now <= SesionRecuperacion.Expiracion)
            {
                FormCambiarContraseña cambio = new FormCambiarContraseña();
                cambio.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Código incorrecto o expirado.");
            }
        }
    }
}
