namespace ReportesPrincipal
{
    partial class HorasVehiculos
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
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblBoletaFinal = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblBoletaInicial = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblCodigo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblTurno = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dgvHoras = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoras)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.lblBoletaFinal);
            this.kryptonPanel1.Controls.Add(this.lblBoletaInicial);
            this.kryptonPanel1.Controls.Add(this.lblCodigo);
            this.kryptonPanel1.Controls.Add(this.lblTurno);
            this.kryptonPanel1.Controls.Add(this.dgvHoras);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(384, 266);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // lblBoletaFinal
            // 
            this.lblBoletaFinal.Location = new System.Drawing.Point(93, 4);
            this.lblBoletaFinal.Name = "lblBoletaFinal";
            this.lblBoletaFinal.Size = new System.Drawing.Size(15, 20);
            this.lblBoletaFinal.TabIndex = 5;
            this.lblBoletaFinal.Values.Text = "-";
            this.lblBoletaFinal.Visible = false;
            // 
            // lblBoletaInicial
            // 
            this.lblBoletaInicial.Location = new System.Drawing.Point(114, 4);
            this.lblBoletaInicial.Name = "lblBoletaInicial";
            this.lblBoletaInicial.Size = new System.Drawing.Size(15, 20);
            this.lblBoletaInicial.TabIndex = 5;
            this.lblBoletaInicial.Values.Text = "-";
            this.lblBoletaInicial.Visible = false;
            // 
            // lblCodigo
            // 
            this.lblCodigo.Location = new System.Drawing.Point(135, 4);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(15, 20);
            this.lblCodigo.TabIndex = 4;
            this.lblCodigo.Values.Text = "-";
            this.lblCodigo.Visible = false;
            // 
            // lblTurno
            // 
            this.lblTurno.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.lblTurno.Location = new System.Drawing.Point(90, 123);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(15, 20);
            this.lblTurno.TabIndex = 3;
            this.lblTurno.Values.Text = "-";
            this.lblTurno.Visible = false;
            // 
            // dgvHoras
            // 
            this.dgvHoras.AllowUserToAddRows = false;
            this.dgvHoras.AllowUserToDeleteRows = false;
            this.dgvHoras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoras.Location = new System.Drawing.Point(0, 0);
            this.dgvHoras.MultiSelect = false;
            this.dgvHoras.Name = "dgvHoras";
            this.dgvHoras.ReadOnly = true;
            this.dgvHoras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoras.Size = new System.Drawing.Size(384, 266);
            this.dgvHoras.TabIndex = 0;
            // 
            // HorasVehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 266);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "HorasVehiculos";
            this.ShowIcon = false;
            this.Text = "Hora de entradas ";
            this.Load += new System.EventHandler(this.HorasVehiculos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvHoras;
        public ComponentFactory.Krypton.Toolkit.KryptonLabel lblCodigo;
        public ComponentFactory.Krypton.Toolkit.KryptonLabel lblBoletaInicial;
        public ComponentFactory.Krypton.Toolkit.KryptonLabel lblBoletaFinal;
        public ComponentFactory.Krypton.Toolkit.KryptonLabel lblTurno;
    }
}