using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace capaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            lblHora.Text = DateTime.Now.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<Usuario> listaUsuarios = new CN_Usuario().Listar();
            Usuario ousuario = listaUsuarios.FirstOrDefault(u => u.usuario == txtUsuario.Text && u.contrasena == txtContraseña.Text);

            if (ousuario != null)
            {
                Inicio form = new Inicio(ousuario);
                form.Show();
                this.Hide();

                form.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("No se encontró el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            this.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Configurar el temporizador
            timer1.Interval = 1000; // Configura el intervalo en 1 segundo (1000 ms)
            timer1.Tick += timer1_Tick; // Maneja el evento Tick del temporizador
            timer1.Start(); // Inicia el temporizador

            // Establecer el botón de ingreso como botón predeterminado
            this.AcceptButton = btnIngresar;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
