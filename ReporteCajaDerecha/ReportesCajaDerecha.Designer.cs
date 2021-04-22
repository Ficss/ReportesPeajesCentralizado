
namespace ReporteCajaDerecha
{
    partial class ReportesCajaDerecha
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            frm = null;
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportesCajaDerecha));
            this.sp_informe_total_vehiculosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CajaDerechaDataSet = new ReporteCajaDerecha.CajaDerechaDataSet();
            this.sp_informe_total_vehiculos_rangoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.kryptonHeaderGroup8 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnDetalleDiario = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonDateTimePicker2 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPage2 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.kryptonHeaderGroup10 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.dtpUltimaSemana = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.dtpPrimeraSemana = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.btnDetalleSemanal = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel15 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel16 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPage3 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.kryptonHeaderGroup9 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonDateTimePicker3 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonDateTimePicker4 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.btnDetalleMensual = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel13 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel14 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.sp_informe_total_vehiculosTableAdapter = new ReporteCajaDerecha.CajaDerechaDataSetTableAdapters.sp_informe_total_vehiculosTableAdapter();
            this.sp_informe_total_vehiculos_rangoTableAdapter = new ReporteCajaDerecha.CajaDerechaDataSetTableAdapters.sp_informe_total_vehiculos_rangoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sp_informe_total_vehiculosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CajaDerechaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_informe_total_vehiculos_rangoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup8.Panel)).BeginInit();
            this.kryptonHeaderGroup8.Panel.SuspendLayout();
            this.kryptonHeaderGroup8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            this.kryptonPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup10.Panel)).BeginInit();
            this.kryptonHeaderGroup10.Panel.SuspendLayout();
            this.kryptonHeaderGroup10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).BeginInit();
            this.kryptonPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup9.Panel)).BeginInit();
            this.kryptonHeaderGroup9.Panel.SuspendLayout();
            this.kryptonHeaderGroup9.SuspendLayout();
            this.SuspendLayout();
            // 
            // sp_informe_total_vehiculosBindingSource
            // 
            this.sp_informe_total_vehiculosBindingSource.DataMember = "sp_informe_total_vehiculos";
            this.sp_informe_total_vehiculosBindingSource.DataSource = this.CajaDerechaDataSet;
            // 
            // CajaDerechaDataSet
            // 
            this.CajaDerechaDataSet.DataSetName = "CajaDerechaDataSet";
            this.CajaDerechaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_informe_total_vehiculos_rangoBindingSource
            // 
            this.sp_informe_total_vehiculos_rangoBindingSource.DataMember = "sp_informe_total_vehiculos_rango";
            this.sp_informe_total_vehiculos_rangoBindingSource.DataSource = this.CajaDerechaDataSet;
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Bar.CheckButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.kryptonNavigator1.Bar.ItemOrientation = ComponentFactory.Krypton.Toolkit.ButtonOrientation.FixedTop;
            this.kryptonNavigator1.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.kryptonNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.NavigatorMode = ComponentFactory.Krypton.Navigator.NavigatorMode.BarCheckButtonGroupOutside;
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2,
            this.kryptonPage3});
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(1008, 562);
            this.kryptonNavigator1.TabIndex = 4;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Controls.Add(this.reportViewer1);
            this.kryptonPage1.Controls.Add(this.kryptonHeaderGroup8);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(1006, 533);
            this.kryptonPage1.Text = "Detalle diario";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "9868AB1BDF8943E9389B6335B79A3AB9";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.DocumentMapWidth = 45;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sp_informe_total_vehiculosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReporteCajaDerecha.DetalleDiario.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 85);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1006, 448);
            this.reportViewer1.TabIndex = 17;
            // 
            // kryptonHeaderGroup8
            // 
            this.kryptonHeaderGroup8.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeaderGroup8.HeaderPositionSecondary = ComponentFactory.Krypton.Toolkit.VisualOrientation.Top;
            this.kryptonHeaderGroup8.HeaderVisiblePrimary = false;
            this.kryptonHeaderGroup8.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup8.Name = "kryptonHeaderGroup8";
            // 
            // kryptonHeaderGroup8.Panel
            // 
            this.kryptonHeaderGroup8.Panel.Controls.Add(this.btnDetalleDiario);
            this.kryptonHeaderGroup8.Panel.Controls.Add(this.kryptonDateTimePicker2);
            this.kryptonHeaderGroup8.Panel.Controls.Add(this.kryptonLabel12);
            this.kryptonHeaderGroup8.Size = new System.Drawing.Size(1006, 85);
            this.kryptonHeaderGroup8.TabIndex = 16;
            // 
            // btnDetalleDiario
            // 
            this.btnDetalleDiario.Location = new System.Drawing.Point(252, 12);
            this.btnDetalleDiario.Name = "btnDetalleDiario";
            this.btnDetalleDiario.Size = new System.Drawing.Size(112, 40);
            this.btnDetalleDiario.TabIndex = 8;
            this.btnDetalleDiario.Values.Text = "Recuperar Datos";
            this.btnDetalleDiario.Click += new System.EventHandler(this.btnDetalleDiario_Click);
            // 
            // kryptonDateTimePicker2
            // 
            this.kryptonDateTimePicker2.CalendarShowToday = false;
            this.kryptonDateTimePicker2.CalendarShowTodayCircle = false;
            this.kryptonDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.kryptonDateTimePicker2.Location = new System.Drawing.Point(113, 22);
            this.kryptonDateTimePicker2.MinDate = new System.DateTime(2017, 12, 7, 0, 0, 0, 0);
            this.kryptonDateTimePicker2.Name = "kryptonDateTimePicker2";
            this.kryptonDateTimePicker2.Size = new System.Drawing.Size(133, 21);
            this.kryptonDateTimePicker2.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonDateTimePicker2.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonDateTimePicker2.TabIndex = 7;
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Location = new System.Drawing.Point(8, 22);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(107, 20);
            this.kryptonLabel12.TabIndex = 6;
            this.kryptonLabel12.Values.Text = "Seleccionar Fecha";
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Controls.Add(this.reportViewer2);
            this.kryptonPage2.Controls.Add(this.kryptonHeaderGroup10);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(1006, 533);
            this.kryptonPage2.Text = "Detalle semanal";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "DBB158A9183942AD76B44EAB98C2DABF";
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.sp_informe_total_vehiculos_rangoBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "ReporteCajaDerecha.DetalleSemanal.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 85);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(1006, 448);
            this.reportViewer2.TabIndex = 8;
            // 
            // kryptonHeaderGroup10
            // 
            this.kryptonHeaderGroup10.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeaderGroup10.HeaderPositionSecondary = ComponentFactory.Krypton.Toolkit.VisualOrientation.Top;
            this.kryptonHeaderGroup10.HeaderVisiblePrimary = false;
            this.kryptonHeaderGroup10.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup10.Name = "kryptonHeaderGroup10";
            // 
            // kryptonHeaderGroup10.Panel
            // 
            this.kryptonHeaderGroup10.Panel.Controls.Add(this.dtpUltimaSemana);
            this.kryptonHeaderGroup10.Panel.Controls.Add(this.dtpPrimeraSemana);
            this.kryptonHeaderGroup10.Panel.Controls.Add(this.btnDetalleSemanal);
            this.kryptonHeaderGroup10.Panel.Controls.Add(this.kryptonLabel15);
            this.kryptonHeaderGroup10.Panel.Controls.Add(this.kryptonLabel16);
            this.kryptonHeaderGroup10.Size = new System.Drawing.Size(1006, 85);
            this.kryptonHeaderGroup10.TabIndex = 7;
            // 
            // dtpUltimaSemana
            // 
            this.dtpUltimaSemana.CalendarShowToday = false;
            this.dtpUltimaSemana.CalendarShowTodayCircle = false;
            this.dtpUltimaSemana.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpUltimaSemana.Location = new System.Drawing.Point(305, 21);
            this.dtpUltimaSemana.MinDate = new System.DateTime(2017, 12, 8, 0, 0, 0, 0);
            this.dtpUltimaSemana.Name = "dtpUltimaSemana";
            this.dtpUltimaSemana.Size = new System.Drawing.Size(131, 21);
            this.dtpUltimaSemana.TabIndex = 6;
            // 
            // dtpPrimeraSemana
            // 
            this.dtpPrimeraSemana.CalendarShowToday = false;
            this.dtpPrimeraSemana.CalendarShowTodayCircle = false;
            this.dtpPrimeraSemana.CalendarTodayDate = new System.DateTime(2017, 12, 13, 13, 2, 18, 0);
            this.dtpPrimeraSemana.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPrimeraSemana.Location = new System.Drawing.Point(91, 21);
            this.dtpPrimeraSemana.MinDate = new System.DateTime(2017, 12, 8, 0, 0, 0, 0);
            this.dtpPrimeraSemana.Name = "dtpPrimeraSemana";
            this.dtpPrimeraSemana.Size = new System.Drawing.Size(131, 21);
            this.dtpPrimeraSemana.TabIndex = 7;
            // 
            // btnDetalleSemanal
            // 
            this.btnDetalleSemanal.Location = new System.Drawing.Point(442, 11);
            this.btnDetalleSemanal.Name = "btnDetalleSemanal";
            this.btnDetalleSemanal.Size = new System.Drawing.Size(112, 40);
            this.btnDetalleSemanal.TabIndex = 5;
            this.btnDetalleSemanal.Values.Text = "Recuperar Datos";
            this.btnDetalleSemanal.Click += new System.EventHandler(this.btnDetalleSemanal_Click);
            // 
            // kryptonLabel15
            // 
            this.kryptonLabel15.Location = new System.Drawing.Point(228, 21);
            this.kryptonLabel15.Name = "kryptonLabel15";
            this.kryptonLabel15.Size = new System.Drawing.Size(71, 20);
            this.kryptonLabel15.TabIndex = 3;
            this.kryptonLabel15.Values.Text = "Fecha Final";
            // 
            // kryptonLabel16
            // 
            this.kryptonLabel16.Location = new System.Drawing.Point(10, 21);
            this.kryptonLabel16.Name = "kryptonLabel16";
            this.kryptonLabel16.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel16.TabIndex = 4;
            this.kryptonLabel16.Values.Text = "Fecha Inicio";
            // 
            // kryptonPage3
            // 
            this.kryptonPage3.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage3.Controls.Add(this.reportViewer3);
            this.kryptonPage3.Controls.Add(this.kryptonHeaderGroup9);
            this.kryptonPage3.Flags = 65534;
            this.kryptonPage3.LastVisibleSet = true;
            this.kryptonPage3.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage3.Name = "kryptonPage3";
            this.kryptonPage3.Size = new System.Drawing.Size(1006, 533);
            this.kryptonPage3.Text = "Detalle mensual";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "0627FB7571454C41A68C39D45B5BD3E8";
            // 
            // reportViewer3
            // 
            this.reportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.sp_informe_total_vehiculos_rangoBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "ReporteCajaDerecha.DetalleMensual.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(0, 85);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.ServerReport.BearerToken = null;
            this.reportViewer3.Size = new System.Drawing.Size(1006, 448);
            this.reportViewer3.TabIndex = 9;
            // 
            // kryptonHeaderGroup9
            // 
            this.kryptonHeaderGroup9.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeaderGroup9.HeaderPositionSecondary = ComponentFactory.Krypton.Toolkit.VisualOrientation.Top;
            this.kryptonHeaderGroup9.HeaderVisiblePrimary = false;
            this.kryptonHeaderGroup9.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup9.Name = "kryptonHeaderGroup9";
            // 
            // kryptonHeaderGroup9.Panel
            // 
            this.kryptonHeaderGroup9.Panel.Controls.Add(this.kryptonDateTimePicker3);
            this.kryptonHeaderGroup9.Panel.Controls.Add(this.kryptonDateTimePicker4);
            this.kryptonHeaderGroup9.Panel.Controls.Add(this.btnDetalleMensual);
            this.kryptonHeaderGroup9.Panel.Controls.Add(this.kryptonLabel13);
            this.kryptonHeaderGroup9.Panel.Controls.Add(this.kryptonLabel14);
            this.kryptonHeaderGroup9.Size = new System.Drawing.Size(1006, 85);
            this.kryptonHeaderGroup9.TabIndex = 8;
            // 
            // kryptonDateTimePicker3
            // 
            this.kryptonDateTimePicker3.CalendarTodayDate = new System.DateTime(2017, 9, 4, 0, 0, 0, 0);
            this.kryptonDateTimePicker3.CustomFormat = "MM: MMMM";
            this.kryptonDateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kryptonDateTimePicker3.Location = new System.Drawing.Point(114, 21);
            this.kryptonDateTimePicker3.Name = "kryptonDateTimePicker3";
            this.kryptonDateTimePicker3.ShowUpDown = true;
            this.kryptonDateTimePicker3.Size = new System.Drawing.Size(131, 21);
            this.kryptonDateTimePicker3.TabIndex = 8;
            // 
            // kryptonDateTimePicker4
            // 
            this.kryptonDateTimePicker4.CalendarTodayDate = new System.DateTime(2017, 9, 4, 0, 0, 0, 0);
            this.kryptonDateTimePicker4.CustomFormat = "yyyy";
            this.kryptonDateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kryptonDateTimePicker4.Location = new System.Drawing.Point(355, 21);
            this.kryptonDateTimePicker4.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.kryptonDateTimePicker4.Name = "kryptonDateTimePicker4";
            this.kryptonDateTimePicker4.ShowUpDown = true;
            this.kryptonDateTimePicker4.Size = new System.Drawing.Size(131, 21);
            this.kryptonDateTimePicker4.TabIndex = 7;
            // 
            // btnDetalleMensual
            // 
            this.btnDetalleMensual.Location = new System.Drawing.Point(492, 11);
            this.btnDetalleMensual.Name = "btnDetalleMensual";
            this.btnDetalleMensual.Size = new System.Drawing.Size(112, 40);
            this.btnDetalleMensual.TabIndex = 6;
            this.btnDetalleMensual.Values.Text = "Recuperar Datos";
            this.btnDetalleMensual.Click += new System.EventHandler(this.btnDetalleMensual_Click);
            // 
            // kryptonLabel13
            // 
            this.kryptonLabel13.Location = new System.Drawing.Point(251, 21);
            this.kryptonLabel13.Name = "kryptonLabel13";
            this.kryptonLabel13.Size = new System.Drawing.Size(98, 20);
            this.kryptonLabel13.TabIndex = 4;
            this.kryptonLabel13.Values.Text = "Seleccionar Año";
            // 
            // kryptonLabel14
            // 
            this.kryptonLabel14.Location = new System.Drawing.Point(10, 21);
            this.kryptonLabel14.Name = "kryptonLabel14";
            this.kryptonLabel14.Size = new System.Drawing.Size(98, 20);
            this.kryptonLabel14.TabIndex = 5;
            this.kryptonLabel14.Values.Text = "Seleccionar Mes";
            // 
            // sp_informe_total_vehiculosTableAdapter
            // 
            this.sp_informe_total_vehiculosTableAdapter.ClearBeforeFill = true;
            // 
            // sp_informe_total_vehiculos_rangoTableAdapter
            // 
            this.sp_informe_total_vehiculos_rangoTableAdapter.ClearBeforeFill = true;
            // 
            // ReportesCajaDerecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.kryptonNavigator1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportesCajaDerecha";
            this.Text = "Reportes Caja Derecha";
            this.Load += new System.EventHandler(this.ReportesCajaDerecha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_informe_total_vehiculosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CajaDerechaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_informe_total_vehiculos_rangoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup8.Panel)).EndInit();
            this.kryptonHeaderGroup8.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup8.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup8)).EndInit();
            this.kryptonHeaderGroup8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            this.kryptonPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup10.Panel)).EndInit();
            this.kryptonHeaderGroup10.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup10.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup10)).EndInit();
            this.kryptonHeaderGroup10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).EndInit();
            this.kryptonPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup9.Panel)).EndInit();
            this.kryptonHeaderGroup9.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup9.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup9)).EndInit();
            this.kryptonHeaderGroup9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage2;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage3;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup8;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDetalleDiario;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup10;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpUltimaSemana;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpPrimeraSemana;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDetalleSemanal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel15;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel16;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup9;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker3;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDetalleMensual;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel13;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel14;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_informe_total_vehiculosBindingSource;
        private CajaDerechaDataSet CajaDerechaDataSet;
        private CajaDerechaDataSetTableAdapters.sp_informe_total_vehiculosTableAdapter sp_informe_total_vehiculosTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private System.Windows.Forms.BindingSource sp_informe_total_vehiculos_rangoBindingSource;
        private CajaDerechaDataSetTableAdapters.sp_informe_total_vehiculos_rangoTableAdapter sp_informe_total_vehiculos_rangoTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
    }
}

