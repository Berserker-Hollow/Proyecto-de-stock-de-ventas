using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Data.SqlClient;

namespace StockyIniciodeSesion
{

    public partial class FormInicio: Form
    {
        private SoundPlayer sonido;
        public FormInicio()
        {
            InitializeComponent();
        }
        public class Conexion
        {
            public static string cadena = "Server=tcp:berserkers3.database.windows.net,1433;" +
                                   "Initial Catalog=InventarioDB;" +
                                   "Persist Security Info=False;" +
                                   "User ID=roberto;" +
                                   "Password=Rr123456789;" +
                                   "MultipleActiveResultSets=False;" +
                                   "Encrypt=True;" +
                                   "TrustServerCertificate=False;" +
                                   "Connection Timeout=30;";
            public static SqlConnection ObtenerConexion()
            {
                return new SqlConnection(cadena);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string claveIngresada = txtClave.Text.Trim();

            if (usuario == "" || claveIngresada == "")
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña.");
                return;
            }

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Clave, Rol FROM Usuarios WHERE Usuario = @usuario";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string hashAlmacenado = reader["Clave"].ToString();
                                string rol = reader["Rol"].ToString();

                                if (PasswordHelper.VerifyPassword(claveIngresada, hashAlmacenado))
                                {
                                    MessageBox.Show("¡Inicio de sesión exitoso!\nRol: " + rol, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Hide();
                                    // Aquí puedes redirigir a la siguiente ventana del sistema
                                }
                                else
                                {
                                    MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Usuario no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
                }
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnReproducir_Click(object sender, EventArgs e)
        {
           
        }

        private void btnReproducir_Click_1(object sender, EventArgs e)
        {

            try
            {
                // Ruta relativa desde el directorio Debug
                string ruta = Path.Combine(Application.StartupPath, @"One Piece\One-Piece-Nami_s-Theme.wav");

                // Verifica si el archivo existe antes de intentar reproducirlo
                if (File.Exists(ruta))
                {
                    SoundPlayer Sonido = new SoundPlayer(ruta);
                    Sonido.Play(); // Usa .PlayLooping() si quieres que se repita
                }
                else
                {
                    MessageBox.Show("No se encontró el archivo de sonido en:\n" + ruta, "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar reproducir el sonido:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            if (sonido != null)
            {
                sonido.Stop();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRegistro nuevoRegistro = new FormRegistro();
            nuevoRegistro.Show();
            this.Hide();

            if (sonido != null)
            {
                sonido.Stop();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormCorreoElectronico nuevocodigorecuperacion = new FormCorreoElectronico();
            nuevocodigorecuperacion.Show();
            this.Hide();

            if (sonido != null)
            {
                sonido.Stop();
            }
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {

        }
    }
}
