using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            SoundPlayer Sonido = new SoundPlayer();
            Sonido.SoundLocation = "C:/Users/monti/Downloads/One Piece/PS4-Home-Screen-Music-1-Hour.wav";
            Sonido.Play();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SoundPlayer Sonido = new SoundPlayer();
            Sonido.SoundLocation = "C:/Users/monti/Downloads/One Piece/PS4-Home-Screen-Music-1-Hour.wav";
            Sonido.Stop();
        }
    }
}
