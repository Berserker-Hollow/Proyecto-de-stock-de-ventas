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
    public partial class FormCorreoElectronico: Form
    {
        public FormCorreoElectronico()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();

            if (string.IsNullOrEmpty(correo))
            {
                MessageBox.Show("Ingresa un correo válido.");
                return;
            }

            SesionRecuperacion.CorreoUsuario = correo;
            SesionRecuperacion.CodigoVerificacion = new Random().Next(100000, 999999).ToString();
            SesionRecuperacion.Expiracion = DateTime.Now.AddMinutes(5);

            try
            {
                CorreoHelper.EnviarCodigo(correo, SesionRecuperacion.CodigoVerificacion);
                MessageBox.Show("Código enviado. Revisa tu correo.");
                FormCodigoVerificacion fcv = new FormCodigoVerificacion();
                fcv.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo: " + ex.Message);
            }
        }
    }
}
