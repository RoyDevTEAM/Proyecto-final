using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

using CapaDatos;
using CapaNegocio;
using CapaEntidad;

namespace capaPresentacion
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
            cbx_Estado.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            try
            {
                dgv_Cliente.DataSource = CN_Cliente.ListarCliente(txt_Buscar.Text.Trim());

                btn_Opc2.Visible = false;
                MoverColumnaAlFinal(dgv_Cliente, "Editar");
                dgv_Cliente.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 13);
                dgv_Cliente.RowTemplate.Height = 40;
                dgv_Cliente.Columns["id_cliente"].Width = 80;
                dgv_Cliente.Columns["nombre_cliente"].Width = 220;
                dgv_Cliente.Columns["apellido_cliente"].Width = 240;
                dgv_Cliente.Columns["numero_carnet"].Width = 160;
                dgv_Cliente.Columns["telefono"].Width = 160;
                dgv_Cliente.Columns["direccion"].Width = 270;
                dgv_Cliente.Columns["estado"].Width = 100;
                dgv_Cliente.Columns["Editar"].Width = 200;

                dgv_Cliente.Columns["id_cliente"].HeaderText = "ID";
                dgv_Cliente.Columns["nombre_cliente"].HeaderText = "Nombre(s)";
                dgv_Cliente.Columns["apellido_cliente"].HeaderText = "Apellido(s)";
                dgv_Cliente.Columns["numero_carnet"].HeaderText = "Carnet Identidad";
                dgv_Cliente.Columns["telefono"].HeaderText = "Telefono";
                dgv_Cliente.Columns["direccion"].HeaderText = "Direccion";
                dgv_Cliente.Columns["estado"].HeaderText = "Estado";
                dgv_Cliente.Columns["Editar"].HeaderText = "Editar";
                foreach (DataGridViewColumn column in dgv_Cliente.Columns)
                {
                    column.HeaderCell.Style.Font = new System.Drawing.Font("Arial", 13, FontStyle.Bold);
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                dgv_Cliente.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txt_Buscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgv_Cliente.DataSource = CN_Cliente.ListarCliente(txt_Buscar.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dgv_Cliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Cliente.Columns[e.ColumnIndex].Name == "Editar")
            {
                DataGridViewRow selectedRow = dgv_Cliente.Rows[e.RowIndex];

                // Obtener los valores de las celdas de la fila seleccionada
                int id_cliente = Convert.ToInt32(selectedRow.Cells["id_cliente"].Value);
                string nombre_cliente = Convert.ToString(selectedRow.Cells["nombre_cliente"].Value);
                string apellido_cliente = Convert.ToString(selectedRow.Cells["apellido_cliente"].Value);
                string numero_carnet = Convert.ToString(selectedRow.Cells["numero_carnet"].Value);
                string telefono = Convert.ToString(selectedRow.Cells["telefono"].Value);
                string direccion = Convert.ToString(selectedRow.Cells["direccion"].Value);
                string estado = Convert.ToString(selectedRow.Cells["estado"].Value);

                this.txt_ID.Text = id_cliente.ToString();
                this.txt_Nombre.Text = nombre_cliente;
                this.txt_Apellido.Text = apellido_cliente;
                this.txt_CI.Text = numero_carnet;
                this.txt_Telefono.Text = telefono;
                this.txt_Direccion.Text = direccion;
                this.cbx_Estado.Text = estado;

                btn_Opc1.Text = "Modificar";
                btn_Opc2.Visible = true;

                modoFormulario = ModoFormulario.Modificar;
            }
        }

        private void btn_Opc1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_Nombre.Text) &&
                    string.IsNullOrWhiteSpace(txt_Apellido.Text) &&
                    string.IsNullOrWhiteSpace(txt_CI.Text) &&
                    string.IsNullOrWhiteSpace(txt_Telefono.Text) &&
                    string.IsNullOrWhiteSpace(txt_Direccion.Text) &&
                    string.IsNullOrWhiteSpace(cbx_Estado.Text))
                {
                    MessageBox.Show("Al menos un campo debe ser completado.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_Nombre.Text))
                {
                    MessageBox.Show("Por favor, llene el campo Nombre.");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(txt_Apellido.Text))
                {
                    MessageBox.Show("Por favor, llene el campo Apellido.");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(txt_CI.Text))
                {
                    MessageBox.Show("Por favor, llene el campo Número de Carnet.");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(txt_Telefono.Text))
                {
                    MessageBox.Show("Por favor, llene el campo Teléfono.");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(txt_Direccion.Text))
                {
                    MessageBox.Show("Por favor, llene el campo Dirección.");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(cbx_Estado.Text))
                {
                    MessageBox.Show("Por favor, seleccione un Estado.");
                    return;
                }

                if (!ValidarCamposCliente())
                {
                    return;
                }

                if (CN_Cliente.ExisteClientePorCarnet(txt_CI.Text, modoFormulario == ModoFormulario.Modificar ? txt_ID.Text : null))
                {
                    MessageBox.Show("Ya existe un cliente con el mismo Carnet de Identidad.");
                    return;
                }

                string nombre = CapitalizeEachWord(txt_Nombre.Text);
                string apellido = CapitalizeEachWord(txt_Apellido.Text);
                string direccion = CapitalizeEachWord(txt_Direccion.Text);

                if (modoFormulario == ModoFormulario.Agregar)
                {
                    Cliente nuevoCliente = new Cliente
                    {
                        nombre_cliente = nombre,
                        apellido_cliente = apellido,
                        numero_carnet = txt_CI.Text.Trim(),
                        telefono = txt_Telefono.Text.Trim(),
                        direccion = direccion,
                        estado = cbx_Estado.SelectedItem.ToString()
                    };

                    try
                    {
                        CN_Cliente.GuardarCliente(nuevoCliente);
                        dgv_Cliente.DataSource = CN_Cliente.ListarCliente(txt_Buscar.Text.Trim());
                        clear();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ex.StackTrace);
                    }
                }
                else
                {
                    Cliente clienteModificado = new Cliente
                    {
                        id_cliente = Convert.ToInt32(dgv_Cliente.CurrentRow.Cells["id_cliente"].Value),
                        nombre_cliente = txt_Nombre.Text.Trim(),
                        apellido_cliente = txt_Apellido.Text.Trim(),
                        numero_carnet = txt_CI.Text.Trim(),
                        telefono = txt_Telefono.Text.Trim(),
                        direccion = txt_Direccion.Text.Trim(),
                        estado = cbx_Estado.SelectedItem.ToString()
                    };

                    try
                    {
                        CN_Cliente.ModificarCliente(clienteModificado);
                        dgv_Cliente.DataSource = CN_Cliente.ListarCliente(txt_Buscar.Text.Trim());
                        clear();
                        btn_Opc2.Visible = false;
                        btn_Opc1.Text = "Agregar Cliente";
                        modoFormulario = ModoFormulario.Agregar;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Opc2_Click(object sender, EventArgs e)
        {
            if (modoFormulario == ModoFormulario.Modificar)
            {
                RestablecerFormulario();
            }
            else
            {
                clear();
                btn_Opc2.Visible = false;
                btn_Opc1.Text = "Agregar Cliente";
                modoFormulario = ModoFormulario.Agregar;
            }
        }

        private bool ValidarCamposCliente()
        {
            if (!Regex.IsMatch(txt_Nombre.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚüÜ\s]+$"))
            {
                MessageBox.Show("El nombre solo debe contener letras.");
                return false;
            }
            if (!Regex.IsMatch(txt_Apellido.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚüÜ\s]+$"))
            {
                MessageBox.Show("El apellido solo debe contener letras.");
                return false;
            }
            if (!Regex.IsMatch(txt_CI.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("El número de carnet solo debe contener números.");
                return false;
            }
            if (!Regex.IsMatch(txt_Telefono.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("El teléfono solo debe contener números.");
                return false;
            }
            return true;
        }

        private void clear()
        {
            this.txt_ID.Text = "";
            this.txt_Nombre.Text = "";
            this.txt_Apellido.Text = "";
            this.txt_CI.Text = "";
            this.txt_Telefono.Text = "";
            this.txt_Direccion.Text = "";
            this.cbx_Estado.SelectedIndex = -1;
        }

        private ModoFormulario modoFormulario = ModoFormulario.Agregar;
        private enum ModoFormulario
        {
            Agregar,
            Modificar
        }

        private string CapitalizeEachWord(string input)
        {
            string[] words = input.Split(' ');
            string formattedString = "";
            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    formattedString += char.ToUpper(word[0]) + word.Substring(1).ToLower() + " ";
                }
            }
            return formattedString.TrimEnd();
        }

        private void MoverColumnaAlFinal(DataGridView dataGridView, string nombreColumna)
        {
            if (dataGridView.Columns.Contains(nombreColumna))
            {
                int index = dataGridView.Columns[nombreColumna].DisplayIndex;
                dataGridView.Columns[nombreColumna].DisplayIndex = dataGridView.Columns.Count - 1;
            }
        }

        private void RestablecerFormulario()
        {
            btn_Opc1.Text = "Agregar Cliente";
            btn_Opc2.Visible = false;
            clear();

            modoFormulario = ModoFormulario.Agregar;
        }
    }
}
