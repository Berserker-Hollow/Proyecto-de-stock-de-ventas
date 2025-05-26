using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockyIniciodeSesion
{
    public partial class FormCambiarContraseña: Form
    {
        public FormCambiarContraseña()
        {
            InitializeComponent();
        }

        private void txtContraseña_Nueva_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtContraseña_Nueva_Enter(object sender, EventArgs e)
        {
            if (txtNueva.Text == "Contraseña Nueva")
            {
                txtNueva.Text = "";
                txtNueva.ForeColor = Color.Black;
                txtNueva.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Nueva_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNueva.Text))
            {
                txtNueva.Text = "Contraseña Nueva";
                txtNueva.ForeColor = Color.Gray;
                txtNueva.UseSystemPasswordChar = false;
            }
        }

        private void txtConfirmar_Contraseña_Enter(object sender, EventArgs e)
        {
            if (txtNueva.Text == "Contraseña Nueva")
            {
                txtNueva.Text = "";
                txtNueva.ForeColor = Color.Black;
                txtNueva.UseSystemPasswordChar = true;
            }
        }

        private void txtConfirmar_Contraseña_Leave(object sender, EventArgs e)
        {
        }

        private void FormCambiarContraseña_Load(object sender, EventArgs e)
        {
            txtNueva.Text = "Contraseña Nueva";
            txtNueva.ForeColor = Color.Gray;
            txtNueva.UseSystemPasswordChar = false;

            txtConfirmar.Text = "Confirmar Contraseña";
            txtConfirmar.ForeColor = Color.Gray;
            txtConfirmar.UseSystemPasswordChar = false;

            checkBox1.Checked = false;
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            string nueva = txtNueva.Text.Trim();
            string confirmar = txtConfirmar.Text.Trim();

            if (string.IsNullOrEmpty(nueva) || string.IsNullOrEmpty(confirmar))
            {
                MessageBox.Show("Por favor, completa ambos campos.");
                return;
            }

            if (nueva != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            string hash = PasswordHelper.HashPassword(nueva);

            try
            {
                using (SqlConnection conn = new SqlConnection("Server=ROBERTO;Database=InventarioDB;User Id=roberto;Password=12345;"))
                {
                    conn.Open();

                    string query = "UPDATE Usuarios SET Clave = @clave WHERE CorreoElectronico = @correo";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@clave", hash);
                        cmd.Parameters.AddWithValue("@correo", SesionRecuperacion.CorreoUsuario);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Contraseña actualizada correctamente.");
                            this.Hide(); // Oculta el formulario actual
                            FormInicio login = new FormInicio();
                            login.Show();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el correo en la base de datos.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la contraseña: " + ex.Message);
            }
        }

        private void txtConfirmar_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            {
                bool mostrar = checkBox1.Checked;

                if (txtNueva.Text != "Contraseña Nueva")
                    txtNueva.UseSystemPasswordChar = !mostrar;

                if (txtConfirmar.Text != "Confirmar Contraseña")
                    txtConfirmar.UseSystemPasswordChar = !mostrar;
            }
        }
    }
}
