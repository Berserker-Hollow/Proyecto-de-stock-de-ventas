using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockyIniciodeSesion
{
    public partial class FormMenuconfiguracion: Form
    {
        public FormMenuconfiguracion()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                // Ruta relativa desde el directorio Debug
                string ruta = Path.Combine(Application.StartupPath, @"One Piece\PS4-Home-Screen-Music-1-Hour.wav");

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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SoundPlayer Sonido = new SoundPlayer();
            Sonido.SoundLocation = "C:/Users/monti/Downloads/One Piece/PS4-Home-Screen-Music-1-Hour.wav";
            Sonido.Stop();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu menu = new FormMenu();
            menu.Show();
            this.Close();

            SoundPlayer Sonido = new SoundPlayer();
            Sonido.SoundLocation = "C:/Users/monti/Downloads/One Piece/PS4-Home-Screen-Music-1-Hour.wav";
            Sonido.Stop();
        }
    }
}
