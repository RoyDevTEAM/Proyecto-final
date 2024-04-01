using System;
using System.Drawing;
using System.Windows.Forms;

namespace capaPresentacion
{
    partial class FrmCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbltitulo = new System.Windows.Forms.Label();
            this.txt_Buscar = new System.Windows.Forms.TextBox();
            this.lbl_Buscar = new System.Windows.Forms.Label();
            this.dgv_Cliente = new System.Windows.Forms.DataGridView();
            this.lbl_Telefono = new System.Windows.Forms.Label();
            this.lbl_CI = new System.Windows.Forms.Label();
            this.txt_Apellido = new System.Windows.Forms.TextBox();
            this.lbl_Apellido = new System.Windows.Forms.Label();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.lbl_Nombre = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Telefono = new System.Windows.Forms.TextBox();
            this.txt_Direccion = new System.Windows.Forms.TextBox();
            this.cbx_Estado = new System.Windows.Forms.ComboBox();
            this.lbl_Estado = new System.Windows.Forms.Label();
            this.lbl_Direccion = new System.Windows.Forms.Label();
            this.txt_CI = new System.Windows.Forms.TextBox();
            this.pnl_Contenedor = new System.Windows.Forms.Panel();
            this.txt_ID = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btn_Opc2 = new System.Windows.Forms.Button();
            this.btn_Opc1 = new System.Windows.Forms.Button();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Cliente)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnl_Contenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbltitulo
            // 
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.BackColor = System.Drawing.Color.Transparent;
            this.lbltitulo.Font = new System.Drawing.Font("Arial Black", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lbltitulo.Location = new System.Drawing.Point(597, -2);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(233, 54);
            this.lbltitulo.TabIndex = 3;
            this.lbltitulo.Text = "CLIENTES";
            this.lbltitulo.Click += new System.EventHandler(this.lbltitulo_Click);
            // 
            // txt_Buscar
            // 
            this.txt_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Buscar.Location = new System.Drawing.Point(200, 259);
            this.txt_Buscar.Multiline = true;
            this.txt_Buscar.Name = "txt_Buscar";
            this.txt_Buscar.Size = new System.Drawing.Size(401, 39);
            this.txt_Buscar.TabIndex = 6;
            this.txt_Buscar.TextChanged += new System.EventHandler(this.txt_Buscar_TextChanged);
            // 
            // lbl_Buscar
            // 
            this.lbl_Buscar.AutoSize = true;
            this.lbl_Buscar.Font = new System.Drawing.Font("Arial Narrow", 19.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Buscar.Location = new System.Drawing.Point(19, 262);
            this.lbl_Buscar.Name = "lbl_Buscar";
            this.lbl_Buscar.Size = new System.Drawing.Size(170, 31);
            this.lbl_Buscar.TabIndex = 5;
            this.lbl_Buscar.Text = "Buscar Cliente:";
            // 
            // dgv_Cliente
            // 
            this.dgv_Cliente.AllowUserToAddRows = false;
            this.dgv_Cliente.AllowUserToDeleteRows = false;
            this.dgv_Cliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Cliente.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_Cliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Cliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Cliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar});
            this.dgv_Cliente.Location = new System.Drawing.Point(17, 304);
            this.dgv_Cliente.Name = "dgv_Cliente";
            this.dgv_Cliente.ReadOnly = true;
            this.dgv_Cliente.RowHeadersVisible = false;
            this.dgv_Cliente.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_Cliente.Size = new System.Drawing.Size(1392, 361);
            this.dgv_Cliente.TabIndex = 9;
            this.dgv_Cliente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Cliente_CellClick);
            // 
            // lbl_Telefono
            // 
            this.lbl_Telefono.AutoSize = true;
            this.lbl_Telefono.Font = new System.Drawing.Font("Arial Narrow", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Telefono.Location = new System.Drawing.Point(737, 8);
            this.lbl_Telefono.Name = "lbl_Telefono";
            this.lbl_Telefono.Size = new System.Drawing.Size(97, 27);
            this.lbl_Telefono.TabIndex = 40;
            this.lbl_Telefono.Text = "Telefono:";
            // 
            // lbl_CI
            // 
            this.lbl_CI.AutoSize = true;
            this.lbl_CI.Font = new System.Drawing.Font("Arial Narrow", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CI.Location = new System.Drawing.Point(543, 7);
            this.lbl_CI.Name = "lbl_CI";
            this.lbl_CI.Size = new System.Drawing.Size(42, 27);
            this.lbl_CI.TabIndex = 38;
            this.lbl_CI.Text = "C.I:";
            // 
            // txt_Apellido
            // 
            this.txt_Apellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Apellido.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_Apellido.Location = new System.Drawing.Point(273, 37);
            this.txt_Apellido.Multiline = true;
            this.txt_Apellido.Name = "txt_Apellido";
            this.txt_Apellido.Size = new System.Drawing.Size(240, 36);
            this.txt_Apellido.TabIndex = 37;
            // 
            // lbl_Apellido
            // 
            this.lbl_Apellido.AutoSize = true;
            this.lbl_Apellido.Font = new System.Drawing.Font("Arial Narrow", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Apellido.Location = new System.Drawing.Point(268, 6);
            this.lbl_Apellido.Name = "lbl_Apellido";
            this.lbl_Apellido.Size = new System.Drawing.Size(93, 27);
            this.lbl_Apellido.TabIndex = 36;
            this.lbl_Apellido.Text = "Apellido:";
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ID.Location = new System.Drawing.Point(10, 58);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(39, 29);
            this.lbl_ID.TabIndex = 34;
            this.lbl_ID.Text = "ID:";
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Nombre.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_Nombre.Location = new System.Drawing.Point(16, 37);
            this.txt_Nombre.Multiline = true;
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(227, 36);
            this.txt_Nombre.TabIndex = 33;
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.AutoSize = true;
            this.lbl_Nombre.Font = new System.Drawing.Font("Arial Narrow", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Nombre.Location = new System.Drawing.Point(12, 7);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(90, 27);
            this.lbl_Nombre.TabIndex = 32;
            this.lbl_Nombre.Text = "Nombre:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.txt_Nombre);
            this.panel1.Controls.Add(this.txt_Apellido);
            this.panel1.Controls.Add(this.txt_Telefono);
            this.panel1.Controls.Add(this.txt_Direccion);
            this.panel1.Controls.Add(this.cbx_Estado);
            this.panel1.Controls.Add(this.lbl_Estado);
            this.panel1.Controls.Add(this.lbl_Direccion);
            this.panel1.Controls.Add(this.txt_CI);
            this.panel1.Controls.Add(this.lbl_Telefono);
            this.panel1.Controls.Add(this.lbl_CI);
            this.panel1.Controls.Add(this.lbl_Nombre);
            this.panel1.Controls.Add(this.lbl_Apellido);
            this.panel1.Location = new System.Drawing.Point(73, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1091, 184);
            this.panel1.TabIndex = 48;
            // 
            // txt_Telefono
            // 
            this.txt_Telefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Telefono.Location = new System.Drawing.Point(742, 38);
            this.txt_Telefono.Multiline = true;
            this.txt_Telefono.Name = "txt_Telefono";
            this.txt_Telefono.Size = new System.Drawing.Size(148, 35);
            this.txt_Telefono.TabIndex = 41;
            // 
            // txt_Direccion
            // 
            this.txt_Direccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Direccion.Location = new System.Drawing.Point(17, 116);
            this.txt_Direccion.Multiline = true;
            this.txt_Direccion.Name = "txt_Direccion";
            this.txt_Direccion.Size = new System.Drawing.Size(495, 52);
            this.txt_Direccion.TabIndex = 43;
            // 
            // cbx_Estado
            // 
            this.cbx_Estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Estado.FormattingEnabled = true;
            this.cbx_Estado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbx_Estado.Location = new System.Drawing.Point(930, 38);
            this.cbx_Estado.Name = "cbx_Estado";
            this.cbx_Estado.Size = new System.Drawing.Size(132, 34);
            this.cbx_Estado.TabIndex = 47;
            // 
            // lbl_Estado
            // 
            this.lbl_Estado.AutoSize = true;
            this.lbl_Estado.Font = new System.Drawing.Font("Arial Narrow", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Estado.Location = new System.Drawing.Point(926, 8);
            this.lbl_Estado.Name = "lbl_Estado";
            this.lbl_Estado.Size = new System.Drawing.Size(81, 27);
            this.lbl_Estado.TabIndex = 44;
            this.lbl_Estado.Text = "Estado:";
            // 
            // lbl_Direccion
            // 
            this.lbl_Direccion.AutoSize = true;
            this.lbl_Direccion.Font = new System.Drawing.Font("Arial Narrow", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Direccion.Location = new System.Drawing.Point(12, 86);
            this.lbl_Direccion.Name = "lbl_Direccion";
            this.lbl_Direccion.Size = new System.Drawing.Size(105, 27);
            this.lbl_Direccion.TabIndex = 42;
            this.lbl_Direccion.Text = "Direccion:";
            // 
            // txt_CI
            // 
            this.txt_CI.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CI.Location = new System.Drawing.Point(548, 38);
            this.txt_CI.Multiline = true;
            this.txt_CI.Name = "txt_CI";
            this.txt_CI.Size = new System.Drawing.Size(159, 35);
            this.txt_CI.TabIndex = 39;
            // 
            // pnl_Contenedor
            // 
            this.pnl_Contenedor.BackColor = System.Drawing.Color.SteelBlue;
            this.pnl_Contenedor.Controls.Add(this.txt_ID);
            this.pnl_Contenedor.Controls.Add(this.btn_Opc2);
            this.pnl_Contenedor.Controls.Add(this.lbl_ID);
            this.pnl_Contenedor.Controls.Add(this.btn_Opc1);
            this.pnl_Contenedor.Controls.Add(this.lbltitulo);
            this.pnl_Contenedor.Controls.Add(this.lbl_Buscar);
            this.pnl_Contenedor.Controls.Add(this.dgv_Cliente);
            this.pnl_Contenedor.Controls.Add(this.txt_Buscar);
            this.pnl_Contenedor.Controls.Add(this.panel1);
            this.pnl_Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Contenedor.Location = new System.Drawing.Point(0, 0);
            this.pnl_Contenedor.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Contenedor.Name = "pnl_Contenedor";
            this.pnl_Contenedor.Size = new System.Drawing.Size(1443, 697);
            this.pnl_Contenedor.TabIndex = 49;
            // 
            // txt_ID
            // 
            this.txt_ID.AutoSize = true;
            this.txt_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ID.ForeColor = System.Drawing.Color.White;
            this.txt_ID.Location = new System.Drawing.Point(10, 89);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(0, 44);
            this.txt_ID.TabIndex = 49;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Editar";
            this.dataGridViewImageColumn1.Image = global::capaPresentacion.Properties.Resources.Edit;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 1853;
            // 
            // btn_Opc2
            // 
            this.btn_Opc2.BackColor = System.Drawing.Color.Red;
            this.btn_Opc2.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btn_Opc2.FlatAppearance.BorderSize = 2;
            this.btn_Opc2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btn_Opc2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Opc2.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Opc2.ForeColor = System.Drawing.Color.White;
            this.btn_Opc2.Image = global::capaPresentacion.Properties.Resources.cross__1_;
            this.btn_Opc2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Opc2.Location = new System.Drawing.Point(1234, 156);
            this.btn_Opc2.Name = "btn_Opc2";
            this.btn_Opc2.Size = new System.Drawing.Size(146, 63);
            this.btn_Opc2.TabIndex = 46;
            this.btn_Opc2.Text = "Cancelar";
            this.btn_Opc2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Opc2.UseVisualStyleBackColor = false;
            this.btn_Opc2.Click += new System.EventHandler(this.btn_Opc2_Click);
            // 
            // btn_Opc1
            // 
            this.btn_Opc1.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_Opc1.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btn_Opc1.FlatAppearance.BorderSize = 2;
            this.btn_Opc1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btn_Opc1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Opc1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Opc1.ForeColor = System.Drawing.Color.White;
            this.btn_Opc1.Image = global::capaPresentacion.Properties.Resources.user_add__2_;
            this.btn_Opc1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Opc1.Location = new System.Drawing.Point(1198, 76);
            this.btn_Opc1.Name = "btn_Opc1";
            this.btn_Opc1.Size = new System.Drawing.Size(208, 63);
            this.btn_Opc1.TabIndex = 8;
            this.btn_Opc1.Text = "Agregar Cliente";
            this.btn_Opc1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Opc1.UseVisualStyleBackColor = false;
            this.btn_Opc1.Click += new System.EventHandler(this.btn_Opc1_Click);
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Image = global::capaPresentacion.Properties.Resources.Edit;
            this.Editar.MinimumWidth = 6;
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            // 
            // FrmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 697);
            this.Controls.Add(this.pnl_Contenedor);
            this.Name = "FrmCliente";
            this.Text = "FrmCliente";
            this.Load += new System.EventHandler(this.FrmCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Cliente)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_Contenedor.ResumeLayout(false);
            this.pnl_Contenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        private void lbltitulo_Click(object sender, EventArgs e)
        {
            
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label lbltitulo;
        private System.Windows.Forms.TextBox txt_Buscar;
        private System.Windows.Forms.Label lbl_Buscar;
        private System.Windows.Forms.Button btn_Opc1;
        private System.Windows.Forms.DataGridView dgv_Cliente;
        private System.Windows.Forms.Label lbl_Telefono;
        private System.Windows.Forms.Label lbl_CI;
        private System.Windows.Forms.TextBox txt_Apellido;
        private System.Windows.Forms.Label lbl_Apellido;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.Label lbl_Nombre;
        private System.Windows.Forms.Button btn_Opc2;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_Contenedor;
        private TextBox txt_Direccion;
        private Label lbl_Direccion;
        private TextBox txt_Telefono;
        private ComboBox cbx_Estado;
        private Label lbl_Estado;
        private TextBox txt_CI;
        private Label txt_ID;
        private DataGridViewImageColumn Editar;
        private DataGridViewImageColumn dataGridViewImageColumn1;
    }
}