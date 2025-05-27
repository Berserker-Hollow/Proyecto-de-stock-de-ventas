using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockyIniciodeSesion
{
    public partial class FormRegistro: Form
    {
        public FormRegistro()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string usuario = txtUsuario.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string clave = txtClave.Text;
            string confirmarClave = txtConfirmarClave.Text;
            string rol = "Empleado";

            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(clave) ||
                string.IsNullOrWhiteSpace(confirmarClave))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingresa un correo electrónico válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clave != confirmarClave)
            {
                MessageBox.Show("La contraseña y su confirmación no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = FormInicio.Conexion.ObtenerConexion())
            {
                try
                {
                    con.Open();

                    string existeQuery = @"SELECT COUNT(*) FROM Usuarios WHERE Usuario = @usuario OR CorreoElectronico = @correo;";
                    using (SqlCommand cmdExiste = new SqlCommand(existeQuery, con))
                    {
                        cmdExiste.Parameters.AddWithValue("@usuario", usuario);
                        cmdExiste.Parameters.AddWithValue("@correo", correo);

                        int count = Convert.ToInt32(cmdExiste.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("El nombre de usuario o correo ya está en uso.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    string insertQuery = @"
                        INSERT INTO Usuarios 
                            (NombreCompleto, Usuario, CorreoElectronico, Clave, Rol)
                        VALUES
                            (@nombre, @usuario, @correo, @clave, @rol);";

                    using (SqlCommand cmdInsert = new SqlCommand(insertQuery, con))
                    {
                        cmdInsert.Parameters.AddWithValue("@nombre", nombre);
                        cmdInsert.Parameters.AddWithValue("@usuario", usuario);
                        cmdInsert.Parameters.AddWithValue("@correo", correo);
                        cmdInsert.Parameters.AddWithValue("@clave", PasswordHelper.HashPassword(clave));
                        cmdInsert.Parameters.AddWithValue("@rol", rol);

                        int filas = cmdInsert.ExecuteNonQuery();
                        if (filas > 0)
                        {
                            MessageBox.Show("¡Registro exitoso!", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            new FormInicio().Show();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un problema al registrar. Intenta de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar o ejecutar la operación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}