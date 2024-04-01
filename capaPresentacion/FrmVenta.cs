using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using CapaNegocio;
using CapaDatos;

namespace capaPresentacion
{
    public partial class FrmVenta : Form
    {
        //public int Id_descuento = 1;
        //public int Id_cliente = 2;



        


        public int Id_usuario = 1;
        private bool IsNuevo;
        private DataTable dtdetalle;

        private decimal totalPagado = 0;
        private decimal SubTotal = 0;
        private decimal Cambio = 0;
        private decimal Descuento = 0;

        private static FrmVenta _instancia;




        //para que se mantenga el cliente

        private string clienteIdSeleccionado;
        private string nombreClienteSeleccionado;
        private string apellidoClienteSeleccionado;





        public static FrmVenta GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmVenta();
            }
            return _instancia;
        }

        public void setCliente(string id_cliente, string nombre_cliente, string apellido_cliente)
        {
            txtIdcliente.Text = id_cliente;
            txtCliente.Text = $"{nombre_cliente} {apellido_cliente}";
        }


        //public void setProducto(string id_unidad_medida, string nombre_unidad)
        //{
        //    txtUnidadmedida.Text = nombre_unidad;
        //    txtIdunidad_medida.Text = id_unidad_medida;
        //    //txtPrecio.Text = precio_producto;
        //}




        public FrmVenta()
        {
           

            InitializeComponent();





            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;

            lfecha.Text = DateTime.Now.ToString();







        }







        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void Limpiar()
        {
            txtIdproducto.Text = string.Empty;
            txtIdcliente.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtUnidadmedida.Text = string.Empty;
            lblnombre.Text = string.Empty;

            lblSubtotal.Text = "0.0";
            lblDescuento.Text = "0.0";
            lblTotal_Pagado.Text = "0.0";

            txtEfectivo.Text = string.Empty;
            crearTabla();
        }



        private void LimpiarDetalle()
        {
            txtIdproducto.Text = string.Empty;
            txtProducto.Text = string.Empty;
            txtDescuento.Text = string.Empty;
            //txtCliente.Text= string.Empty;
            txtCantidad.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtUnidadmedida.Text = string.Empty;
        }

        private void Habilitar(bool valor)
        {

            //dtFecha.Enabled = valor;
            rbEfectivo.Enabled = valor;
            rbCredito.Enabled = valor;
            txtEfectivo.Enabled = valor;
            txtCantidad.ReadOnly = !valor;
            txtPrecio.ReadOnly = !valor;
            btnBuscarProducto.Enabled = valor;
            btnBuscarCliente.Enabled = valor;
            btnAgregar.Enabled = valor;
            btnQuitar.Enabled = valor;
            btnDescuento.Enabled = valor;
            txtUnidadmedida.Enabled = valor;
            txtCliente.Enabled = valor;
            txtProducto.Enabled = valor;

            //desabilito los datagripviw
            dataListadoC.Enabled = valor;
            dataListadoP.Enabled = valor;


        }


        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo)
            {
                Habilitar(true);
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            else
            {
                Habilitar(false);
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
        }



        //Metodo Mostrar
        //private void Mostrar()
        //{
        //    this.dataListadoP.DataSource = NProducto.MostrarProducto();
        //    this.OcultarColumnas();
        //    //this.lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.RowCount);
        //    //this.tabControl1.SelectedIndex = 0;
        //}

        //Metodo BuscarFechas
        //private void BuscarFechas()
        //{
        //    this.dataListado.DataSource = NVenta.BuscarFechas(dtFecha1.Value.ToString("yyyy/MM/dd"),
        //        dtFecha2.Value.ToString("yyyy/MM/dd"));
        //    this.OcultarColumnas();
        //    this.lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.RowCount);
        //}



        //private void MostrarDetalle()
        //{
        //    this.dataListadoDetalle.DataSource = NVenta.MostrarDetalle(txtIdventa.Text);
        //}

        private void crearTabla()
        {
            dtdetalle = new DataTable("Detalle");
            dtdetalle.Columns.Add("id_producto", System.Type.GetType("System.Int32"));
            dtdetalle.Columns.Add("producto", System.Type.GetType("System.String"));
            dtdetalle.Columns.Add("cantidad", System.Type.GetType("System.Decimal"));
            dtdetalle.Columns.Add("unidad_medida", System.Type.GetType("System.String"));
            dtdetalle.Columns.Add("precio", System.Type.GetType("System.Decimal"));
            dtdetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            dtdetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            //Relacionar el DataGridView con el DataTable
            dataListadoDetalle.DataSource = dtdetalle;
        }









        private void timer1_Tick(object sender, EventArgs e)
        {
            lfecha.Text = DateTime.Now.ToString();
        }


        //private void btnBuscar_Click(object sender, EventArgs e)
        //{
        //    this.BuscarFechas();
        //}






        //private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
        //    {
        //        DataGridViewCheckBoxCell ChkEliminar =
        //            (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
        //        ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
        //    }
        //}








        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            Botones();
            Limpiar();
            Habilitar(true);
            txtCliente.Focus();
            LimpiarDetalle();


            //para que deje poner otro cliente
            dataListadoC.Enabled = true;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo = false;
            Botones();
            Limpiar();
            Habilitar(false);
            LimpiarDetalle();
        }



        private void btnDescuento_Click(object sender, EventArgs e)
        {
            txtDescuento.Enabled = !txtDescuento.Enabled; // Cambiar el estado de habilitado/deshabilitado del ComboBox
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (txtIdcliente.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                }
                else
                {
                    if (IsNuevo)
                    {
                        // Insertar la venta
                        rpta = NVenta.Insertar(Convert.ToInt32(clienteIdSeleccionado), Id_usuario,
                            Convert.ToDateTime(lfecha.Text), tipoPagoSeleccionado, totalPagado, Descuento, dtdetalle);


                        // Disminuir el stock de los productos vendidos
                        foreach (DataRow row in dtdetalle.Rows)
                        {
                            int id_producto = Convert.ToInt32(row["id_producto"]);
                            int cantidad = Convert.ToInt32(row["cantidad"]);
                            // Llamar al método DisminuirStock para cada producto vendido
                            rpta = new DDetalle_Venta().DisminuirStock(id_producto, cantidad);
                            if (!rpta.Equals("OK"))
                            {
                                // Si ocurre un error al disminuir el stock de algún producto, mostrar mensaje de error y salir del bucle
                                MensajeError(rpta);
                                break;
                            }
                        }
                    }
                    if (rpta.Equals("OK"))
                    {
                        MensajeOK("Se insertó de forma correcta los registros");
                    }
                    else
                    {
                        MensajeError(rpta);
                    }
                    IsNuevo = false;
                    Botones();
                    Limpiar();
                    LimpiarDetalle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }





        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdproducto.Text == string.Empty || txtCantidad.Text == string.Empty ||
                    txtUnidadmedida.Text == string.Empty || txtPrecio.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdproducto, "Ingrese un valor");
                    errorIcono.SetError(txtCantidad, "Ingrese un valor");
                    errorIcono.SetError(txtPrecio, "Ingrese un valor");
                    errorIcono.SetError(txtUnidadmedida, "ingrese la unidad de medida");
                    errorIcono.SetError(rbEfectivo, "Seleccione el tipo de pago");
                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtdetalle.Rows)
                    {
                        if (Convert.ToInt32(row["id_producto"]) == Convert.ToInt32(txtIdproducto.Text))
                        {
                            registrar = false;
                            MensajeError("Ya se encuentra el artículo en el detalle");
                        }
                    }
                    if (registrar)
                    {
                        decimal subTotal = Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtPrecio.Text);

                        // Si el botón de descuento está deshabilitado, asigna un valor de 0 al descuento
                        decimal descuento = 0;
                        if (txtDescuento.Enabled)
                        {
                            descuento = Convert.ToDecimal(txtDescuento.Text);
                        }

                        decimal totalProducto = subTotal - descuento;

                        // Actualizar totales
                        SubTotal += subTotal;
                        lblSubtotal.Text = SubTotal.ToString("#0.00#");

                        Descuento += descuento;
                        lblDescuento.Text = Descuento.ToString("#0.00#");

                        totalPagado += totalProducto;
                        lblTotal_Pagado.Text = totalPagado.ToString("#0.00#");

                        // Agregar el detalle al dataListadoDetalle
                        DataRow row = dtdetalle.NewRow();
                        row["id_producto"] = Convert.ToInt32(txtIdproducto.Text);
                        row["producto"] = txtProducto.Text;
                        row["cantidad"] = Convert.ToDecimal(txtCantidad.Text);
                        row["unidad_medida"] = txtUnidadmedida.Text;
                        row["precio"] = Convert.ToDecimal(txtPrecio.Text);
                        row["descuento"] = descuento;
                        row["subtotal"] = totalProducto;
                        dtdetalle.Rows.Add(row);

                        LimpiarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }




        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            CalcularCambio();
        }

        private void CalcularCambio()
        {
            if (!string.IsNullOrWhiteSpace(txtEfectivo.Text))
            {
                decimal efectivo = Convert.ToDecimal(txtEfectivo.Text);
                decimal totalPagado = Convert.ToDecimal(lblTotal_Pagado.Text);

                decimal cambio = efectivo - totalPagado;
                lblCambio.Text = cambio.ToString("#0.00#");
            }
            else
            {
                lblCambio.Text = "0.00";
            }
        }



        //private void dataListadoDetalle_DoubleClick(object sender, EventArgs e)
        //{
        //    txtIdventa.Text = Convert.ToString(dataListado.CurrentRow.Cells["id_venta"].Value);
        //    txtCliente.Text = Convert.ToString(dataListado.CurrentRow.Cells["cliente"].Value);
        //    //cbProducto.Text = Convert.ToString(dataListado.CurrentRow.Cells["producto"].Value);
        //    //txtCantidad.Text = Convert.ToString(dataListado.CurrentRow.Cells["cantidad"].Value);
        //    //cbUnidadmedida.Text = Convert.ToString(dataListado.CurrentRow.Cells["unidad_medida"].Value);
        //    dtFecha.Value = Convert.ToDateTime(dataListado.CurrentRow.Cells["fecha_venta"].Value);
        //    //txtPrecio.Text = Convert.ToString(dataListado.CurrentRow.Cells["Producto"].Value);
        //    //cbDescuento.Text = Convert.ToString(dataListado.CurrentRow.Cells["descuento"].Value);

        //    lblTotal_Pagado.Text = Convert.ToString(dataListado.CurrentRow.Cells["total"].Value);

        //    MostrarDetalle();
        //    //tabControl1.SelectedIndex = 1;
        //}








        private string tipoPagoSeleccionado = "";


        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEfectivo.Checked)
            {
                tipoPagoSeleccionado = "Efectivo";
                txtEfectivo.Enabled = true;
            }
        }

        private void rbCredito_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCredito.Checked)
            {
                tipoPagoSeleccionado = "Crédito";
                txtEfectivo.Enabled = false;
            }
        }





        //SECTOR DE CLIENTE-----------------------
        private void MostrarC()
        {
            dataListadoC.DataSource = NCliente.MostrarCliente();
            //OcultarColumnas();
            //lblTotalC.Text = "Total de Registros: " + Convert.ToString(dataListadoC.RowCount);
        }


        private void dataListadoC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataListadoC.Rows[e.RowIndex];

                // Obtener los datos de la fila seleccionada y asignarlos a los TextBox correspondientes
                clienteIdSeleccionado = row.Cells["id_cliente"].Value.ToString();
                nombreClienteSeleccionado = row.Cells["nombre_cliente"].Value.ToString();
                apellidoClienteSeleccionado = row.Cells["apellido_cliente"].Value.ToString();

                //txtIdcliente.Text = row.Cells["id_cliente"].Value.ToString();
                //txtCliente.Text = row.Cells["nombre_cliente"].Value.ToString() + " " + row.Cells["apellido_cliente"].Value.ToString();
                //lblnombre.Text = row.Cells["nombre_cliente"].Value.ToString() + " " + row.Cells["apellido_cliente"].Value.ToString();

                //txtApellido.Text = row.Cells["Apellido"].Value.ToString();
                // Otros campos...

                // Llenar los campos correspondientes con los datos del cliente seleccionado

                txtIdcliente.Text = clienteIdSeleccionado;
                txtCliente.Text = nombreClienteSeleccionado + " " + apellidoClienteSeleccionado; // Mostrar en txtCliente
                lblnombre.Text = nombreClienteSeleccionado + " " + apellidoClienteSeleccionado; // Mostrar en lblnombre


                //para que deje poner otro cliente
                dataListadoC.Enabled = false;


            }
        }


        private void BuscarNombreC()
        {
            dataListadoC.DataSource = NCliente.BuscarNombreC(txtCliente.Text);
            //lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListadoC.RowCount);
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarNombreC();

        }

        //------------------------------------







        //SECTOR DE PRODUCTO-----------------------

        //Metodo para ocultar columnas del dataListado
        private void OcultarColumnasP()
        {
            if (dataListadoP.RowCount > 0)
            {
                this.dataListadoP.Columns[0].Visible = false;
                this.dataListadoP.Columns[1].Visible = false;
                this.dataListadoP.Columns[2].Visible = true;
                this.dataListadoP.Columns[3].Visible = true;
                this.dataListadoP.Columns[4].Visible = true;
                this.dataListadoP.Columns[5].Visible = true;
                this.dataListadoP.Columns[6].Visible = true;
                //this.dataListadoP.Columns[7].Visible = true;
            }
        }


        private void MostrarP()
        {
            dataListadoP.DataSource = NProducto.MostrarProducto();
            OcultarColumnasP();
            //lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListadoP.RowCount);
        }



        //private void dataListadoP_DoubleClick(object sender, EventArgs e)
        //{
        //    FrmVenta form = FrmVenta.GetInstancia();
        //    string par1, par2, par3;
        //    par1 = Convert.ToString(dataListado.CurrentRow.Cells["id_producto"].Value);
        //    par2 = Convert.ToString(dataListado.CurrentRow.Cells["nombre_producto"].Value);
        //    par3 = Convert.ToString(dataListado.CurrentRow.Cells["precio_producto"].Value);
        //    form.setProducto(par1, par2, par3);
        //    Hide();
        //}


        private void dataListadoP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataListadoP.Rows[e.RowIndex];

                // Obtener los datos de la fila seleccionada y asignarlos a los TextBox correspondientes
                txtIdproducto.Text = row.Cells["id_producto"].Value.ToString();
                txtProducto.Text = row.Cells["nombre_producto"].Value.ToString();
                txtPrecio.Text = row.Cells["precio"].Value.ToString();
                txtUnidadmedida.Text = row.Cells["unidad_medida"].Value.ToString();
                // Otros campos...

                // Opcional: Puedes cerrar el formulario aquí si lo deseas
                // this.Close();
            }
        }


        private void BuscarNombreP()
        {
            dataListadoP.DataSource = NProducto.BuscarNombreP(txtProducto.Text);
            //lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListadoP.RowCount);
        }
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            BuscarNombreP();
        }




        //---------------------------------------------------------------

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            //Mostrar();
            Habilitar(false);
            Botones();
            crearTabla();
            // TODO: esta línea de código carga datos en la tabla 'bDVentasDataSet1.producto' Puede moverla o quitarla según sea necesario.
            //this.productoTableAdapter.Fill(this.bDVentasDataSet1.producto);


            //calculos
            txtEfectivo.TextChanged += txtEfectivo_TextChanged;

            //ocultar columnas de tablas
            OcultarColumnasP();

            //mostrar tablas
            MostrarC();

            MostrarP();


            //busquedas
            BuscarNombreP();
        }




        private void FrmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }


    }
}
