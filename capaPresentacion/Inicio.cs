using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaEntidad;
using FontAwesome.Sharp;

namespace capaPresentacion
{
    public partial class Inicio : Form
    {



      








        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;







        public Inicio(Usuario objusuario)
        {
            


            usuarioActual = objusuario;
            InitializeComponent();
        }

        private void menupago_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Login form = new Login();
                form.Show();
                this.Hide();
            }
        }


        private void Inicio_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = usuarioActual.nombre_usuario;
        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if (FormularioActivo !=null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.SteelBlue;

            contenedor.Controls.Add(formulario);
            formulario.Show();
        }
        private void menuusuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuario());
        }

        private void menuventas_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmVenta());

        }

        private void menuproductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProductos());

        }

        private void menucompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmCompras());

        }

        private void menuclientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmCliente());

        }

        private void iconMenuItem2_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmPago());

        }

        private void submenuventas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menureportes, new FrmVentalista());

        }

        private void reporteDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteCliente report = new ReporteCliente();
            report.ShowDialog();
        }
    }
}
