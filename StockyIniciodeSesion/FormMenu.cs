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
    public partial class FormMenu: Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnReproducir2_Click(object sender, EventArgs e)
        {
            try
            {
                // Ruta relativa desde el directorio Debug
                string ruta = Path.Combine(Application.StartupPath, @"One Piece\Chill-and-nostalgic-wii-music-♡.wav");

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

        private void btnDetener2_Click(object sender, EventArgs e)
        {
            SoundPlayer Sonido = new SoundPlayer();
            Sonido.SoundLocation = "C:/Users/monti/Downloads/One Piece/Chill-and-nostalgic-wii-music-♡.wav";
            Sonido.Stop();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLoginJefe nuevologinJefe = new FormLoginJefe();
            nuevologinJefe.Show();
            this.Hide();

         
            SoundPlayer Sonido = new SoundPlayer();
            Sonido.SoundLocation = "C:/Users/monti/Downloads/One Piece/hill-and-nostalgic-wii-music-♡.wav";
            Sonido.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuProducto nuevomenuproducto = new FormMenuProducto();
            nuevomenuproducto.Show();
            this.Hide();

            SoundPlayer Sonido = new SoundPlayer();
            Sonido.SoundLocation = "C:/Users/monti/Downloads/One Piece/hill-and-nostalgic-wii-music-♡.wav";
            Sonido.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuconfiguracion nuevomenuconfiguracion = new FormMenuconfiguracion();
            nuevomenuconfiguracion.Show();
            this.Hide();

            SoundPlayer Sonido = new SoundPlayer();
            Sonido.SoundLocation = "C:/Users/monti/Downloads/One Piece/hill-and-nostalgic-wii-music-♡.wav";
            Sonido.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuCliente nuevomenucliente = new FormMenuCliente();
            nuevomenucliente.Show();
            this.Hide();

            SoundPlayer Sonido = new SoundPlayer();
            Sonido.SoundLocation = "C:/Users/monti/Downloads/One Piece/hill-and-nostalgic-wii-music-♡.wav";
            Sonido.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
