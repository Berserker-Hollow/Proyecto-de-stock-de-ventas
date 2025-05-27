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
    public partial class FormLoginJefe: Form
    {
        public FormLoginJefe()
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

        private void btnAcceder_Click(object sender, EventArgs e)
        {
        }
    }
}
