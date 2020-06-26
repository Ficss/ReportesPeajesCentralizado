using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Principal;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Threading;
using AccesoDatos;

namespace ReportesPrincipal
{
    public partial class ReportesPeajePrincipal : KryptonForm
    {
        #region Singleton
        private static ReportesPeajePrincipal frm = null;
        public static ReportesPeajePrincipal Instance()
        {
            if (frm == null)
            {
                frm = new ReportesPeajePrincipal();
            }
            return frm;
        }
        #endregion
        #region Constructor por defecto
        public ReportesPeajePrincipal()
        {
            InitializeComponent();
            kryptonDateTimePicker1.MaxDate = DateTime.Now.AddDays(-1);
            dtpInicialDetalle.MaxDate = DateTime.Now.AddDays(-1);
            dtpFinalDetalle.MaxDate = DateTime.Now.AddDays(-1);

            DateTime today = DateTime.Today;

            int daysToAdd = 7 - (int)today.DayOfWeek;

            DateTime nextSaturday = today.AddDays(daysToAdd);

            dtpPrimeraSemana.MaxDate = nextSaturday;
            dtpUltimaSemana.MaxDate = nextSaturday;
            cbTipo.SelectedIndex = -1;
            //Cell
            dgvCierresZ.BorderStyle = BorderStyle.None;
            dgvCierresZ.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvCierresZ.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCierresZ.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgvCierresZ.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvCierresZ.DefaultCellStyle.Font = new System.Drawing.Font("Cambria", 10);
            dgvCierresZ.BackgroundColor = Color.White;

            //Header
            dgvCierresZ.EnableHeadersVisualStyles = false;
            dgvCierresZ.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCierresZ.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgvCierresZ.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCierresZ.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft San Seriff", 12);
            
        }
        #endregion
        #region Load
        private void ReportesPeajePrincipal_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'peajeMDataSet.informe_diario' Puede moverla o quitarla según sea necesario.
            this.informe_diarioTableAdapter.Fill(this.peajeMDataSet.informe_diario);
            // TODO: esta línea de código carga datos en la tabla 'peajeMDataSet.informe_diario_manual' Puede moverla o quitarla según sea necesario.
            this.informe_diario_manualTableAdapter.Fill(this.peajeMDataSet.informe_diario_manual);
            ComprobarConexion();
        }
        #endregion
        #region Método para comprobar conexion a equipo   
        public void ComprobarConexion() {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.principalConnectionString);
            if (Prueba.QuickOpen(con, 1000) == false)
            {
                MessageBox.Show("No se puso establecer una conexión a la base de datos.\n  " +
                                "Las causas pueden ser:\n " +
                                "-No está conectado a la red Vega Monumental.\n" +
                                " -Peaje está cerrado.\n"+
                                " -Cable de red está desconectado de su computador", "Peaje Principal");
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.BeginInvoke(new MethodInvoker(this.Close));
            }
        }
        #endregion
        #region Cargar informe al día - Report 7
        private void btnBuscarDiario_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha_elegida = DateTime.Now;
                string fecha = fecha_elegida.ToString("dd-MM-yyyy");
                string con = Properties.Settings.Default.principalConnectionString;
                using (SqlConnection connection = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_informe_al_dia", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_elegida).AddDays(-1);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeMDataSet.informe_al_dia' Puede moverla o quitarla según sea necesario.
                        this.informe_al_diaTableAdapter.Fill(this.peajeMDataSet.informe_al_dia);
                    }
                }
                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("fecha", fecha)
                };
                reportViewer7.LocalReport.SetParameters(rparams);
                this.reportViewer7.RefreshReport();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Cargar informe diario - Report 1
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha_elegida = kryptonDateTimePicker1.Value.Date;
                string fecha = fecha_elegida.ToString("dd-MM-yyyy");
                string con = Properties.Settings.Default.principalConnectionString;
                using (SqlConnection connection = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_informe_diario", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeMDataSet.informe_diario' Puede moverla o quitarla según sea necesario.
                        this.informe_diarioTableAdapter.Fill(this.peajeMDataSet.informe_diario);
                    }
                    using (SqlCommand cmd = new SqlCommand("sp_informe_diario_manual", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeMDataSet.informe_diario' Puede moverla o quitarla según sea necesario.
                        this.informe_diario_manualTableAdapter.Fill(this.peajeMDataSet.informe_diario_manual);
                    }
                }
                reportViewer1.LocalReport.EnableHyperlinks = true;
                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("fecha", fecha)
                };

                reportViewer1.LocalReport.SetParameters(rparams);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Cargar informe mensual - Report 2 
        private void btnRecaudacionMensual_Click(object sender, EventArgs e)
        {
            string formated = dtpMes.Value.Month.ToString() + '/' + dtpAn.Value.Year.ToString();
            DateTime date = Convert.ToDateTime(formated);
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            string con = Properties.Settings.Default.principalConnectionString;
            using (SqlConnection connection = new SqlConnection(con))
            {
                using (SqlCommand cmd = new SqlCommand("sp_informe_recaudacion_mensual", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@v_fecha_inicio", SqlDbType.DateTime).Value = Convert.ToDateTime(firstDayOfMonth);
                    cmd.Parameters.Add("@v_fecha_final", SqlDbType.DateTime).Value = Convert.ToDateTime(lastDayOfMonth);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    // TODO: esta línea de código carga datos en la tabla 'peajeMDataSet.informe_recaudacion_mensual' Puede moverla o quitarla según sea necesario.
                    this.informe_recaudacion_mensualTableAdapter.Fill(this.peajeMDataSet.informe_recaudacion_mensual);
                }
            }
            ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("desde", firstDayOfMonth.ToShortDateString()),
                new ReportParameter("hasta", lastDayOfMonth.ToShortDateString()),
                };

            reportViewer2.LocalReport.SetParameters(rparams);
            this.reportViewer2.RefreshReport();
        }
        #endregion
        #region Cargar informe semanal - Report 3
        private void btnInformeSemanal_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha_inicial = dtpPrimeraSemana.Value.Date;
                DateTime fecha_final = dtpUltimaSemana.Value.Date;
                string fecha_i = fecha_inicial.ToString("dd/MM/yyyy");
                string fecha_f = fecha_final.ToString("dd/MM/yyyy");
                string con = Properties.Settings.Default.principalConnectionString;
                using (SqlConnection connection = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_informe_recaudacion_semanal", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha_inicio", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_i);
                        cmd.Parameters.Add("@v_fecha_final", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_f);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeMDataSet.informe_recaudacion_semanal' Puede moverla o quitarla según sea necesario.
                        this.informe_recaudacion_semanalTableAdapter.Fill(this.peajeMDataSet.informe_recaudacion_semanal);
                    }
                }
                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("desde", fecha_i),
                new ReportParameter("hasta", fecha_f),
                };

                reportViewer3.LocalReport.SetParameters(rparams);
                this.reportViewer3.RefreshReport();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Cargar informe mensual cajeros - Report 4
        private void btnMensualCajeros_Click(object sender, EventArgs e)
        {
            try
            {
                string formated = dtpMesCajero.Value.Month.ToString() + '/' + dtpAnCajero.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(formated);
                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                string con = Properties.Settings.Default.principalConnectionString;
                using (SqlConnection connection = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_informe_mensual_cajeros_nuevo", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha_inicio", SqlDbType.DateTime).Value = Convert.ToDateTime(firstDayOfMonth);
                        cmd.Parameters.Add("@v_fecha_final", SqlDbType.DateTime).Value = Convert.ToDateTime(lastDayOfMonth);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeMDataSet.informe_recaudacion_mensual' Puede moverla o quitarla según sea necesario.
                        this.informe_cajeroTableAdapter.Fill(this.peajeMDataSet.informe_cajero);
                    }
                    using (SqlCommand cmd = new SqlCommand("sp_informe_acumulado_cajero", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha_inicio", SqlDbType.DateTime).Value = Convert.ToDateTime(firstDayOfMonth);
                        cmd.Parameters.Add("@v_fecha_final", SqlDbType.DateTime).Value = Convert.ToDateTime(lastDayOfMonth);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeMDataSet.informe_recaudacion_mensual' Puede moverla o quitarla según sea necesario.
                        this.informe_acumuladoTableAdapter.Fill(this.peajeMDataSet.informe_acumulado);
                    }
                }
                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("desde", firstDayOfMonth.ToShortDateString()),
                new ReportParameter("hasta", lastDayOfMonth.ToShortDateString()),
                };

                reportViewer4.LocalReport.SetParameters(rparams);
                this.reportViewer4.RefreshReport();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Cargar informe vehículo vendedor - Report 5
        private void btnVehiculosVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = "vendedor";
                string formated = dtpMesVendedorInicial.Value.Month.ToString() + '/' + dtpAnVendedorInicial.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(formated);
                var firstDayOfMonth1 = new DateTime(date.Year, date.Month, 1);
                var lastDayOfMonth1 = firstDayOfMonth1.AddMonths(1).AddDays(-1);

                string formated2 = dtpMesVendedorFinal.Value.Month.ToString() + '/' + dtpAnVendedorFinal.Value.Year.ToString();
                DateTime date2 = Convert.ToDateTime(formated2);
                var firstDayOfMonth2 = new DateTime(date2.Year, date2.Month, 1);
                var lastDayOfMonth2 = firstDayOfMonth2.AddMonths(1).AddDays(-1);

                string con = Properties.Settings.Default.principalConnectionString;
                using (SqlConnection connection = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_inf_vehiculo_vendedor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha_inicio1", SqlDbType.DateTime).Value = Convert.ToDateTime(firstDayOfMonth1);
                        cmd.Parameters.Add("@v_fecha_final1", SqlDbType.DateTime).Value = Convert.ToDateTime(lastDayOfMonth1);
                        cmd.Parameters.Add("@v_fecha_inicio2", SqlDbType.DateTime).Value = Convert.ToDateTime(firstDayOfMonth2);
                        cmd.Parameters.Add("@v_fecha_final2", SqlDbType.DateTime).Value = Convert.ToDateTime(lastDayOfMonth2);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeMDataSet.inf_vehiculos_compara_mes' Puede moverla o quitarla según sea necesario.
                        this.inf_vehiculos_compara_mesTableAdapter.Fill(this.peajeMDataSet.inf_vehiculos_compara_mes);
                    }
                }
                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("desdePrimerMes", firstDayOfMonth1.ToShortDateString()),
                new ReportParameter("hastaPrimerMes", lastDayOfMonth1.ToShortDateString()),
                new ReportParameter("desdeSegundoMes", firstDayOfMonth2.ToShortDateString()),
                new ReportParameter("hastaSegundoMes", lastDayOfMonth2.ToShortDateString()),
                new ReportParameter("nombre", nombre )
                };
                
                reportViewer5.LocalReport.SetParameters(rparams);
                this.reportViewer5.RefreshReport();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Cargar informe vehículo comprador - Report 6
        private void btnVehiculosComprador_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = "comprador";
                string formated = dtpMesCompradorInicial.Value.Month.ToString() + '/' + dtpAnCompradorInicial.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(formated);
                var firstDayOfMonth1 = new DateTime(date.Year, date.Month, 1);
                var lastDayOfMonth1 = firstDayOfMonth1.AddMonths(1).AddDays(-1);

                string formated2 = dtpMesCompradorFinal.Value.Month.ToString() + '/' + dtpAnCompradorFinal.Value.Year.ToString();
                DateTime date2 = Convert.ToDateTime(formated2);
                var firstDayOfMonth2 = new DateTime(date2.Year, date2.Month, 1);
                var lastDayOfMonth2 = firstDayOfMonth2.AddMonths(1).AddDays(-1);

                string con = Properties.Settings.Default.principalConnectionString;
                using (SqlConnection connection = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_inf_vehiculo_comprador", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha_inicio1", SqlDbType.DateTime).Value = Convert.ToDateTime(firstDayOfMonth1);
                        cmd.Parameters.Add("@v_fecha_final1", SqlDbType.DateTime).Value = Convert.ToDateTime(lastDayOfMonth1);
                        cmd.Parameters.Add("@v_fecha_inicio2", SqlDbType.DateTime).Value = Convert.ToDateTime(firstDayOfMonth2);
                        cmd.Parameters.Add("@v_fecha_final2", SqlDbType.DateTime).Value = Convert.ToDateTime(lastDayOfMonth2);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeMDataSet.inf_vehiculos_compara_mes' Puede moverla o quitarla según sea necesario.
                        this.inf_vehiculos_compara_mesTableAdapter.Fill(this.peajeMDataSet.inf_vehiculos_compara_mes);
                    }
                }
                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("desdePrimerMes", firstDayOfMonth1.ToShortDateString()),
                new ReportParameter("hastaPrimerMes", lastDayOfMonth1.ToShortDateString()),
                new ReportParameter("desdeSegundoMes", firstDayOfMonth2.ToShortDateString()),
                new ReportParameter("hastaSegundoMes", lastDayOfMonth2.ToShortDateString()),
                new ReportParameter("nombre", nombre )
                };

                reportViewer6.LocalReport.SetParameters(rparams);
                this.reportViewer6.RefreshReport();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Abrir formulario para ver horas de entradas de los vehículos
        private void reportViewer1_Hyperlink(object sender, HyperlinkEventArgs e)
        {
            Uri link = new Uri(e.Hyperlink);

            if (link.Authority == "someaction")
            {
                e.Cancel = true;
                char[] sep = new char[] { '=' };
                var param = link.Query.Split(sep);
                string rowId = param[1];

                string id = rowId.Remove(rowId.Length - 1, 1);
                string turno = rowId.Substring(rowId.Length - 1, 1);


                int boletainicial = 0;
                int boletafinal = 0;

                string fecha_elegida = kryptonDateTimePicker1.Value.ToShortDateString();
                SqlConnection miconexion = new SqlConnection();
                miconexion.ConnectionString = Properties.Settings.Default.principalConnectionString;
                miconexion.Open();
                SqlCommand consulta = new SqlCommand("SELECT boleta_inicial, boleta_final From cierre_z WHERE fecha = @fecha", miconexion);
                consulta.Parameters.Add(new SqlParameter("@fecha", fecha_elegida));
                SqlDataReader reader = consulta.ExecuteReader();
                if (reader.Read())
                {
                    boletainicial = reader.GetInt32(0);
                    boletafinal = reader.GetInt32(1);
                }

                HorasVehiculos hv = null;
                hv = HorasVehiculos.Instance();
                hv.lblCodigo.Text = id;
                hv.lblBoletaInicial.Text = Convert.ToString(boletainicial);
                hv.lblBoletaFinal.Text = Convert.ToString(boletafinal);
                hv.lblTurno.Text = turno;
                hv.StartPosition = FormStartPosition.CenterScreen;
                hv.Show();
                hv.WindowState = FormWindowState.Normal;
                hv.Activate();
            }
        }
        #endregion
        #region Cargar informe Detalle Peaje - Report 8
        private void btnDetalle_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime fecha_inicial = dtpInicialDetalle.Value.Date;
                DateTime fecha_final = dtpFinalDetalle.Value.Date;
                string fecha_i = fecha_inicial.ToString("dd-MM-yyyy");
                string fecha_f = fecha_final.ToString("dd-MM-yyyy");
                int tipo = cbTipo.SelectedIndex;
                this.DetallePeajeTableAdapter.Fill(this.peajeMDataSet.DetallePeaje, Convert.ToDateTime(fecha_i), Convert.ToDateTime(fecha_f), tipo);

                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("desde", fecha_i),
                new ReportParameter("hasta", fecha_f),
                };
                reportViewer8.LocalReport.SetParameters(rparams);
                this.reportViewer8.RefreshReport();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
        }
        #endregion
        #region Cargar grilla con los datos de los cierres Z
        private void btnCierresZ_Click(object sender, EventArgs e)
        {
            try
            {
                string formated = dtpMesCierreZ.Value.Month.ToString() + '/' + dtpAnCierreZ.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(formated);
                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                DataTable dt = new DataTable();
                string con = Properties.Settings.Default.principalConnectionString;
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();
                    SqlCommand myCmd = new SqlCommand("sp_Cargar_CierreZ", connection);
                    myCmd.CommandType = CommandType.StoredProcedure;
                    myCmd.Parameters.Add("@finicial", SqlDbType.DateTime).Value = Convert.ToDateTime(firstDayOfMonth);
                    myCmd.Parameters.Add("@ffinal", SqlDbType.DateTime).Value = Convert.ToDateTime(lastDayOfMonth);
                    SqlDataAdapter da = new SqlDataAdapter(myCmd);
                    da.Fill(dt);
                    dgvCierresZ.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
            //dgvCierresZ.DataBind();
        }
        #endregion

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            var dia = new SaveFileDialog();
            dia.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dia.Filter = "Excel Worksheets (*.xlsx)|*.xlsx|xls file (*.xls)|*.xls|All files (*.*)|*.*";
            if (dia.ShowDialog(this) == DialogResult.OK)
            {
                Excel._Application xlApp = new Excel.Application();
                Excel._Workbook xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
                Excel._Worksheet xlWorkSheet = null; 
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet = xlWorkBook.ActiveSheet;
                xlWorkSheet.Name = "Principal";

                for (int x = 1; x < dgvCierresZ.Columns.Count + 1; x++)
                {
                    xlWorkSheet.Cells[1,x] = dgvCierresZ.Columns[x - 1].HeaderText;
                }

                for (int i = 0; i < dgvCierresZ.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvCierresZ.Columns.Count; j++)
                    {
                        //xlWorkSheet.Cells[i + 2, j + 1] = dgvCierresZ.Rows[i].Cells[j].Value.ToString();
                        xlWorkSheet.Cells[i + 2, j + 1] = dgvCierresZ.Rows[i].Cells[j].Value;
                    }
                }
                
                xlWorkBook.SaveAs(dia.FileName, Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                xlWorkBook.Close(true, Type.Missing, Type.Missing);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
                MessageBox.Show($"Datos exportados exitósamente en: {dia.InitialDirectory}");
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
                
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void ReportesPeajePrincipal_SizeChanged(object sender, EventArgs e)
        {
            btnBuscarDiario.Left = (this.ClientSize.Width - btnBuscarDiario.Width) / 2;
        }
    }
   
}