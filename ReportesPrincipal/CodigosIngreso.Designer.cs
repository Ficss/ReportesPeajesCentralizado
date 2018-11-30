namespace ReportesPrincipal
{
    partial class CodigosIngreso
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.chkSeleccionar = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.dgvClientesResultado = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.RAZON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NLOCAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCODIGOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRESTANTES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PERIODO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvClientes = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.CRUT = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.CRAZON = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.CLOCAL = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.SELECCIONAR = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.dtpAn = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.dtpMes = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.txtCodigo = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnRegistrar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblSeleccionado = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesResultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox2);
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
            this.kryptonGroupBox1.Location = new System.Drawing.Point(0, 134);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.chkSeleccionar);
            this.kryptonGroupBox1.Panel.Controls.Add(this.dgvClientesResultado);
            this.kryptonGroupBox1.Panel.Controls.Add(this.dgvClientes);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(1008, 428);
            this.kryptonGroupBox1.TabIndex = 3;
            this.kryptonGroupBox1.Values.Heading = "Información";
            // 
            // chkSeleccionar
            // 
            this.chkSeleccionar.Location = new System.Drawing.Point(385, 0);
            this.chkSeleccionar.Name = "chkSeleccionar";
            this.chkSeleccionar.Size = new System.Drawing.Size(117, 20);
            this.chkSeleccionar.TabIndex = 2;
            this.chkSeleccionar.Values.Text = "Seleccionar Todo";
            this.chkSeleccionar.CheckStateChanged += new System.EventHandler(this.chkSeleccionar_CheckStateChanged);
            // 
            // dgvClientesResultado
            // 
            this.dgvClientesResultado.AllowUserToAddRows = false;
            this.dgvClientesResultado.AllowUserToDeleteRows = false;
            this.dgvClientesResultado.AllowUserToResizeRows = false;
            this.dgvClientesResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientesResultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvClientesResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientesResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RAZON,
            this.NLOCAL,
            this.CCODIGOS,
            this.CRESTANTES,
            this.PERIODO});
            this.dgvClientesResultado.Location = new System.Drawing.Point(508, 26);
            this.dgvClientesResultado.Name = "dgvClientesResultado";
            this.dgvClientesResultado.ReadOnly = true;
            this.dgvClientesResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientesResultado.Size = new System.Drawing.Size(498, 374);
            this.dgvClientesResultado.TabIndex = 1;
            // 
            // RAZON
            // 
            this.RAZON.HeaderText = "Clientes Razón";
            this.RAZON.Name = "RAZON";
            this.RAZON.ReadOnly = true;
            this.RAZON.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RAZON.Width = 104;
            // 
            // NLOCAL
            // 
            this.NLOCAL.HeaderText = "Número Local";
            this.NLOCAL.Name = "NLOCAL";
            this.NLOCAL.ReadOnly = true;
            this.NLOCAL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NLOCAL.Width = 102;
            // 
            // CCODIGOS
            // 
            this.CCODIGOS.HeaderText = "Cantidad Códigos";
            this.CCODIGOS.Name = "CCODIGOS";
            this.CCODIGOS.ReadOnly = true;
            this.CCODIGOS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CCODIGOS.Width = 120;
            // 
            // CRESTANTES
            // 
            this.CRESTANTES.HeaderText = "Códigos Restantes";
            this.CRESTANTES.Name = "CRESTANTES";
            this.CRESTANTES.ReadOnly = true;
            this.CRESTANTES.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CRESTANTES.Width = 122;
            // 
            // PERIODO
            // 
            this.PERIODO.HeaderText = "Periodo";
            this.PERIODO.Name = "PERIODO";
            this.PERIODO.ReadOnly = true;
            this.PERIODO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PERIODO.Width = 77;
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AllowUserToResizeRows = false;
            this.dgvClientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CRUT,
            this.CRAZON,
            this.CLOCAL,
            this.SELECCIONAR});
            this.dgvClientes.Location = new System.Drawing.Point(-2, 26);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(504, 362);
            this.dgvClientes.TabIndex = 0;
            this.dgvClientes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvClientes_MouseClick);
            // 
            // CRUT
            // 
            this.CRUT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CRUT.HeaderText = "Clientes RUT";
            this.CRUT.Name = "CRUT";
            this.CRUT.ReadOnly = true;
            this.CRUT.Width = 103;
            // 
            // CRAZON
            // 
            this.CRAZON.HeaderText = "Clientes Razón";
            this.CRAZON.Name = "CRAZON";
            this.CRAZON.ReadOnly = true;
            this.CRAZON.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CRAZON.Width = 177;
            // 
            // CLOCAL
            // 
            this.CLOCAL.HeaderText = "Número Local";
            this.CLOCAL.Name = "CLOCAL";
            this.CLOCAL.ReadOnly = true;
            this.CLOCAL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CLOCAL.Width = 176;
            // 
            // SELECCIONAR
            // 
            this.SELECCIONAR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = false;
            this.SELECCIONAR.DefaultCellStyle = dataGridViewCellStyle1;
            this.SELECCIONAR.FalseValue = "false";
            this.SELECCIONAR.HeaderText = "";
            this.SELECCIONAR.IndeterminateValue = null;
            this.SELECCIONAR.Name = "SELECCIONAR";
            this.SELECCIONAR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SELECCIONAR.TrueValue = "true";
            this.SELECCIONAR.Width = 7;
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.dtpAn);
            this.kryptonGroupBox2.Panel.Controls.Add(this.dtpMes);
            this.kryptonGroupBox2.Panel.Controls.Add(this.txtCodigo);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel3);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox2.Panel.Controls.Add(this.btnRegistrar);
            this.kryptonGroupBox2.Panel.Controls.Add(this.lblSeleccionado);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(1008, 128);
            this.kryptonGroupBox2.TabIndex = 2;
            this.kryptonGroupBox2.Values.Heading = "Periodo";
            // 
            // dtpAn
            // 
            this.dtpAn.CustomFormat = "yyyy";
            this.dtpAn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAn.Location = new System.Drawing.Point(85, 16);
            this.dtpAn.Name = "dtpAn";
            this.dtpAn.ShowUpDown = true;
            this.dtpAn.Size = new System.Drawing.Size(100, 21);
            this.dtpAn.TabIndex = 6;
            // 
            // dtpMes
            // 
            this.dtpMes.CustomFormat = "MMMM";
            this.dtpMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMes.Location = new System.Drawing.Point(85, 42);
            this.dtpMes.Name = "dtpMes";
            this.dtpMes.ShowUpDown = true;
            this.dtpMes.Size = new System.Drawing.Size(100, 21);
            this.dtpMes.TabIndex = 6;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(85, 68);
            this.txtCodigo.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 22);
            this.txtCodigo.TabIndex = 5;
            this.txtCodigo.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(24, 68);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(55, 20);
            this.kryptonLabel3.TabIndex = 3;
            this.kryptonLabel3.Values.Text = "Códigos";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(46, 42);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(33, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Mes";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(46, 16);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(33, 20);
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "Año";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(191, 34);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(112, 37);
            this.btnRegistrar.TabIndex = 1;
            this.btnRegistrar.Values.Text = "Generar Código";
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
            // CodigosIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.kryptonPanel1);
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "CodigosIngreso";
            this.Text = "Codigos de ingreso";
            this.Load += new System.EventHandler(this.CodigosIngreso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesResultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkSeleccionar;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvClientesResultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAZON;
        private System.Windows.Forms.DataGridViewTextBoxColumn NLOCAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCODIGOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRESTANTES;
        private System.Windows.Forms.DataGridViewTextBoxColumn PERIODO;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvClientes;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn CRUT;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn CRAZON;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn CLOCAL;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn SELECCIONAR;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpAn;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpMes;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtCodigo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRegistrar;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblSeleccionado;
    }
}