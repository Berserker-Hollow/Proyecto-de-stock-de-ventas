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
            FormCodigoVerificacion nuevocodigoverificacion = new FormCodigoVerificacion();  // Crea una instancia del segundo formulario
            nuevocodigoverificacion.Show();               // Muestra el nuevo formulario
            this.Hide();                       // Oculta el formulario actual (opcional)

        }
    }
}
