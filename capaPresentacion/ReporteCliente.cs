using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class ReporteCliente : Form
    {
        public ReporteCliente()
        {
            InitializeComponent();
        }

        private void ReporteCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'reportClientData.cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter.FillClient(this.reportClientData.cliente);

            this.reportViewer1.RefreshReport();
        }
    }
}
