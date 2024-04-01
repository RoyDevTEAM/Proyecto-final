using CapaNegocio;
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
    public partial class FrmVentalista : Form
    {
        public FrmVentalista()
        {
            InitializeComponent();
        }


        private void OcultarColumnas()
        {
            if (dataListado.RowCount > 0)
            {
                this.dataListado.Columns[0].Visible = false;
                this.dataListado.Columns[1].Visible = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        //Metodo BuscarFechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NVenta.BuscarFechas(dtFecha1.Value.ToString("yyyy/MM/dd"),
                dtFecha2.Value.ToString("yyyy/MM/dd"));
            this.OcultarColumnas();
            this.lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.RowCount);
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar =
                    (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }





        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = NVenta.MostrarDetalle(txtIdventa.Text);
        }

        private void dataListadoDetalle_DoubleClick(object sender, EventArgs e)
        {
            txtIdventa.Text = Convert.ToString(dataListado.CurrentRow.Cells["id_venta"].Value);
            //txtCliente.Text = Convert.ToString(dataListado.CurrentRow.Cells["cliente"].Value);
            ////cbProducto.Text = Convert.ToString(dataListado.CurrentRow.Cells["producto"].Value);
            ////txtCantidad.Text = Convert.ToString(dataListado.CurrentRow.Cells["cantidad"].Value);
            ////cbUnidadmedida.Text = Convert.ToString(dataListado.CurrentRow.Cells["unidad_medida"].Value);
            //dtFecha.Value = Convert.ToDateTime(dataListado.CurrentRow.Cells["fecha_venta"].Value);
            ////txtPrecio.Text = Convert.ToString(dataListado.CurrentRow.Cells["Producto"].Value);
            ////cbDescuento.Text = Convert.ToString(dataListado.CurrentRow.Cells["descuento"].Value);

            //lblTotal_Pagado.Text = Convert.ToString(dataListado.CurrentRow.Cells["total"].Value);

            MostrarDetalle();
            //tabControl1.SelectedIndex = 1;
        }

    }
}
