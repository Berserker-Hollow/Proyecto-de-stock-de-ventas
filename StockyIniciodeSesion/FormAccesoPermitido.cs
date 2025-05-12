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
    public partial class FormAccesoPermitido: Form
    {
        public FormAccesoPermitido()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu menu = new FormMenu();
            menu.Show();
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            SoundPlayer Sonido = new SoundPlayer();
            Sonido.SoundLocation = "C:/Users/monti/Downloads/One Piece/wwd.mp3juice.blog-HOME-Resonance-_192-KBps_.wav";
            Sonido.Play();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            SoundPlayer Sonido = new SoundPlayer();
            Sonido.SoundLocation = "C:/Users/monti/Downloads/One Piece/wwd.mp3juice.blog-HOME-Resonance-_192-KBps_.wav";
            Sonido.Stop();
        }
    }
}
