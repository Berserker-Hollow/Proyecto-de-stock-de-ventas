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

namespace StockyIniciodeSesion
{
    public partial class FormInicio: Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            FormMenu nuevaVentana = new FormMenu();  // Crea una instancia del segundo formulario
            nuevaVentana.Show();               // Muestra el nuevo formulario
            this.Hide();                       // Oculta el formulario actual (opcional)

            SoundPlayer Sonido = new SoundPlayer();
            Sonido.SoundLocation = "C:/Users/monti/Downloads/One Piece/One-Piece-Nami_s-Theme.wav";
            Sonido.Stop();

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
        { SoundPlayer Sonido = new SoundPlayer();
            Sonido.SoundLocation = "C:/Users/monti/Downloads/One Piece/One-Piece-Nami_s-Theme.wav";
            Sonido.Play();

           



        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            SoundPlayer Sonido = new SoundPlayer();
            Sonido.SoundLocation = "C:/Users/monti/Downloads/One Piece/One-Piece-Nami_s-Theme.wav";
            Sonido.Stop();


        }
    }
}
