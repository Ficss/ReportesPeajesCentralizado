namespace MainWindows
{
    partial class RegistroClientes
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
            frm = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NINGRESO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TINGRESO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTADO = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.CLOCAL = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.NLOCAL = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.RAZON = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.RUT = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.FH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPeriodo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnEliminar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnRegistrar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblSeleccionado = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.dgvCodigosGenerados = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.NUMLOCAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PERIODO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTCODIGOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonPage2 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.dgvDetalleCodigos = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvClientes = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodigosGenerados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            this.kryptonPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCodigos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // NINGRESO
            // 
            this.NINGRESO.HeaderText = "Número Ingreso";
            this.NINGRESO.Name = "NINGRESO";
            this.NINGRESO.ReadOnly = true;
            // 
            // TINGRESO
            // 
            this.TINGRESO.HeaderText = "Turno Ingreso";
            this.TINGRESO.Name = "TINGRESO";
            this.TINGRESO.ReadOnly = true;
            // 
            // ESTADO
            // 
            this.ESTADO.HeaderText = "Estado Local";
            this.ESTADO.Name = "ESTADO";
            this.ESTADO.ReadOnly = true;
            this.ESTADO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ESTADO.Width = 94;
            // 
            // CLOCAL
            // 
            this.CLOCAL.HeaderText = "Código Local";
            this.CLOCAL.Name = "CLOCAL";
            this.CLOCAL.ReadOnly = true;
            this.CLOCAL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CLOCAL.Width = 98;
            // 
            // NLOCAL
            // 
            this.NLOCAL.HeaderText = "Número Local";
            this.NLOCAL.Name = "NLOCAL";
            this.NLOCAL.ReadOnly = true;
            this.NLOCAL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NLOCAL.Width = 102;
            // 
            // RAZON
            // 
            this.RAZON.HeaderText = "Nombre Cliente";
            this.RAZON.Name = "RAZON";
            this.RAZON.ReadOnly = true;
            this.RAZON.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RAZON.Width = 110;
            // 
            // RUT
            // 
            this.RUT.HeaderText = "RUT Cliente";
            this.RUT.Name = "RUT";
            this.RUT.ReadOnly = true;
            this.RUT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RUT.Width = 91;
            // 
            // FH
            // 
            dataGridViewCellStyle4.Format = "G";
            dataGridViewCellStyle4.NullValue = null;
            this.FH.DefaultCellStyle = dataGridViewCellStyle4;
            this.FH.HeaderText = "Fecha & Hora Ingreso";
            this.FH.Name = "FH";
            this.FH.ReadOnly = true;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(663, 3);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(105, 20);
            this.txtPeriodo.TabIndex = 4;
            this.txtPeriodo.TextChanged += new System.EventHandler(this.txtPeriodo_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(547, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(110, 20);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Filtrar por Periodo";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(140, 15);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(160, 37);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Values.Text = "Activar/Desactivar Cliente";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(22, 15);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(112, 37);
            this.btnRegistrar.TabIndex = 1;
            this.btnRegistrar.Values.Text = "Registrar Cliente ";
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // lblSeleccionado
            // 
            this.lblSeleccionado.Location = new System.Drawing.Point(401, 22);
            this.lblSeleccionado.Name = "lblSeleccionado";
            this.lblSeleccionado.Size = new System.Drawing.Size(6, 2);
            this.lblSeleccionado.TabIndex = 0;
            this.lblSeleccionado.Values.Text = "";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(401, 48);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(181, 20);
            this.kryptonLabel2.TabIndex = 0;
            this.kryptonLabel2.Values.Text = "Presione ENTER para modificar.";
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.btnEliminar);
            this.kryptonGroupBox2.Panel.Controls.Add(this.btnRegistrar);
            this.kryptonGroupBox2.Panel.Controls.Add(this.lblSeleccionado);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(1008, 105);
            this.kryptonGroupBox2.TabIndex = 1;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox2);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1008, 562);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonGroupBox1.Location = new System.Drawing.Point(0, 111);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonNavigator1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtPeriodo);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.dgvClientes);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(1008, 451);
            this.kryptonGroupBox1.TabIndex = 0;
            this.kryptonGroupBox1.Values.Heading = "Registro Clientes";
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonNavigator1.Bar.ItemOrientation = ComponentFactory.Krypton.Toolkit.ButtonOrientation.FixedTop;
            this.kryptonNavigator1.Bar.TabStyle = ComponentFactory.Krypton.Toolkit.TabStyle.LowProfile;
            this.kryptonNavigator1.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.kryptonNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Location = new System.Drawing.Point(549, 36);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.NavigatorMode = ComponentFactory.Krypton.Navigator.NavigatorMode.BarCheckButtonGroupOutside;
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2});
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(449, 381);
            this.kryptonNavigator1.TabIndex = 6;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Controls.Add(this.dgvCodigosGenerados);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(447, 352);
            this.kryptonPage1.Text = "Códigos Generados";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "A626DD86AE654D8BFFBECE301FB60F08";
            // 
            // dgvCodigosGenerados
            // 
            this.dgvCodigosGenerados.AllowUserToAddRows = false;
            this.dgvCodigosGenerados.AllowUserToDeleteRows = false;
            this.dgvCodigosGenerados.AllowUserToResizeRows = false;
            this.dgvCodigosGenerados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCodigosGenerados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCodigosGenerados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NUMLOCAL,
            this.PERIODO,
            this.CANTCODIGOS,
            this.SALDO});
            this.dgvCodigosGenerados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCodigosGenerados.Location = new System.Drawing.Point(0, 0);
            this.dgvCodigosGenerados.MultiSelect = false;
            this.dgvCodigosGenerados.Name = "dgvCodigosGenerados";
            this.dgvCodigosGenerados.ReadOnly = true;
            this.dgvCodigosGenerados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCodigosGenerados.Size = new System.Drawing.Size(447, 352);
            this.dgvCodigosGenerados.TabIndex = 6;
            this.dgvCodigosGenerados.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCodigosGenerados_KeyDown);
            this.dgvCodigosGenerados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvCodigosGenerados_MouseDoubleClick);
            // 
            // NUMLOCAL
            // 
            this.NUMLOCAL.HeaderText = "Número Local";
            this.NUMLOCAL.Name = "NUMLOCAL";
            this.NUMLOCAL.ReadOnly = true;
            // 
            // PERIODO
            // 
            this.PERIODO.HeaderText = "Periodo";
            this.PERIODO.Name = "PERIODO";
            this.PERIODO.ReadOnly = true;
            // 
            // CANTCODIGOS
            // 
            this.CANTCODIGOS.HeaderText = "Cantidad Códigos";
            this.CANTCODIGOS.Name = "CANTCODIGOS";
            this.CANTCODIGOS.ReadOnly = true;
            // 
            // SALDO
            // 
            this.SALDO.HeaderText = "Saldo";
            this.SALDO.Name = "SALDO";
            this.SALDO.ReadOnly = true;
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Controls.Add(this.dgvDetalleCodigos);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(447, 352);
            this.kryptonPage2.Text = "Detalle Códigos";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "EA7AFD4CD94F414BB5981EC844BA8885";
            // 
            // dgvDetalleCodigos
            // 
            this.dgvDetalleCodigos.AllowUserToAddRows = false;
            this.dgvDetalleCodigos.AllowUserToDeleteRows = false;
            this.dgvDetalleCodigos.AllowUserToResizeRows = false;
            this.dgvDetalleCodigos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleCodigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleCodigos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvDetalleCodigos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalleCodigos.Location = new System.Drawing.Point(0, 0);
            this.dgvDetalleCodigos.MultiSelect = false;
            this.dgvDetalleCodigos.Name = "dgvDetalleCodigos";
            this.dgvDetalleCodigos.ReadOnly = true;
            this.dgvDetalleCodigos.Size = new System.Drawing.Size(447, 352);
            this.dgvDetalleCodigos.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Número Ingreso";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle6.Format = "G";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "Fecha & Hora Ingreso";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Turno Ingreso";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AllowUserToResizeRows = false;
            this.dgvClientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RUT,
            this.RAZON,
            this.NLOCAL,
            this.CLOCAL,
            this.ESTADO});
            this.dgvClientes.Location = new System.Drawing.Point(7, 73);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvClientes.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(533, 344);
            this.dgvClientes.TabIndex = 1;
            this.dgvClientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvClientes_KeyDown);
            this.dgvClientes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvClientes_MouseClick);
            // 
            // RegistroClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.kryptonPanel1);
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "RegistroClientes";
            this.Text = "Registro de clientes";
            this.Load += new System.EventHandler(this.RegistroClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodigosGenerados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            this.kryptonPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCodigos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn NINGRESO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TINGRESO;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ESTADO;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn CLOCAL;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn NLOCAL;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn RAZON;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn RUT;
        private System.Windows.Forms.DataGridViewTextBoxColumn FH;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPeriodo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEliminar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRegistrar;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblSeleccionado;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvClientes;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage2;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvCodigosGenerados;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMLOCAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn PERIODO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTCODIGOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALDO;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvDetalleCodigos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}