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
    public partial class FormAgregarProducto: Form
    {
        public FormAgregarProducto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            string Nombre = txtNombreProducto.Text;
            decimal Precio = decimal.Parse(txtPrecio.Text);
            int Cantidad = int.Parse(txtCantidad.Text);
            DateTime UltimaEntrada = DateTime.Parse(txtUltimaEntrada.Text);



        }
    }
}
