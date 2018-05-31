using AccesoDatos;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ReportesPeajes
{
    public partial class ReportesPeajeOrella : KryptonForm
    {
        #region Singleton
        private static ReportesPeajeOrella frm = null;
        public static ReportesPeajeOrella Instance()
        {

            if (frm == null)
            {
                frm = new ReportesPeajeOrella();
            }
            return frm;
        }
        #endregion
        #region Constructor por defecto
        public ReportesPeajeOrella()
        {
            InitializeComponent();
        }
        #endregion
        #region Load
        private void ReportesPeajeOrella_Load(object sender, EventArgs e)
        {
            //Se setea campos de fecha con la fecha desde que salio a producción el sistema
            kryptonDateTimePicker1.MaxDate = DateTime.Now.AddDays(-1);
            DateTime today = DateTime.Today;

            int daysToAdd = 7 - (int)today.DayOfWeek;

            DateTime nextSaturday = today.AddDays(daysToAdd);

            dtpPrimeraSemana.MaxDate = nextSaturday;
            dtpUltimaSemana.MaxDate = nextSaturday;
        }
        #endregion
        #region Cargar Informe Al Día - Report 1
        private void btnBuscarDiario_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha_elegida = DateTime.Now;
                string fecha = fecha_elegida.ToString("dd-MM-yyyy");
                using (SqlConnection con = Consultas.conectarOrella())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_informe_al_dia", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_elegida);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeOrellaDataSet.informe_al_dia' Puede moverla o quitarla según sea necesario.
                        this.informe_al_diaTableAdapter.Fill(this.peajeOrellaDataSet.informe_al_dia);
                    }
                }
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
        #region Cargar Informe Diario - Report 2
        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            try
            {
                DateTime fecha_elegida = kryptonDateTimePicker1.Value.Date;
                string fecha = fecha_elegida.ToString("dd-MM-yyyy");
                using (SqlConnection con = Consultas.conectarOrella())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_informe_diario", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_elegida);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeDataSet.informe_diario' Puede moverla o quitarla según sea necesario.
                        this.informe_diarioTableAdapter.Fill(this.peajeOrellaDataSet.informe_diario);
                    }
                }
                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("fecha", fecha)
                };

                reportViewer2.LocalReport.SetParameters(rparams);
                this.reportViewer2.RefreshReport();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Cargar Informe Mensual - Report 3
        private void btnRecaudacionMensual_Click(object sender, EventArgs e)
        {
            try
            {
                string formated = dtpMes.Value.Month.ToString() + '/' + dtpAn.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(formated);
                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                using (SqlConnection con = Consultas.conectarOrella())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_informe_recaudacion_mensual", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha_inicio", SqlDbType.DateTime).Value = Convert.ToDateTime(firstDayOfMonth);
                        cmd.Parameters.Add("@v_fecha_final", SqlDbType.DateTime).Value = Convert.ToDateTime(lastDayOfMonth);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeDataSet.informe_recaudacion_mensual' Puede moverla o quitarla según sea necesario.
                        this.informe_recaudacion_mensualTableAdapter.Fill(this.peajeOrellaDataSet.informe_recaudacion_mensual);
                    }
                }
                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("desde", firstDayOfMonth.ToShortDateString()),
                new ReportParameter("hasta", lastDayOfMonth.ToShortDateString()),
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
        #region Cargar Informe Semanal - Report 4
        private void btnInformeSemanal_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha_inicial = dtpPrimeraSemana.Value.Date;
                DateTime fecha_final = dtpUltimaSemana.Value.Date;
                string fecha_i = fecha_inicial.ToString("dd/MM/yyyy");
                string fecha_f = fecha_final.ToString("dd/MM/yyyy");
                using (SqlConnection con = Consultas.conectarOrella())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_informe_recaudacion_semanal", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha_inicio", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_i);
                        cmd.Parameters.Add("@v_fecha_final", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_f);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeDataSet.informe_recaudacion_semanal' Puede moverla o quitarla según sea necesario.
                        this.informe_recaudacion_semanalTableAdapter.Fill(this.peajeOrellaDataSet.informe_recaudacion_semanal);
                    }
                }
                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("desde", fecha_i),
                new ReportParameter("hasta", fecha_f),
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
        #region Cargar Informe Mensual Cajeros - Report 5
        private void btnMensualCajeros_Click(object sender, EventArgs e)
        {
            try
            {
                string formated = dtpMesCajero.Value.Month.ToString() + '/' + dtpAnCajero.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(formated);
                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                using (SqlConnection con = Consultas.conectarOrella())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_informe_mensual_cajeros_nuevo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha_inicio", SqlDbType.DateTime).Value = Convert.ToDateTime(firstDayOfMonth);
                        cmd.Parameters.Add("@v_fecha_final", SqlDbType.DateTime).Value = Convert.ToDateTime(lastDayOfMonth);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeDataSet.informe_recaudacion_mensual' Puede moverla o quitarla según sea necesario.
                        this.informe_cajeroTableAdapter.Fill(this.peajeOrellaDataSet.informe_cajero);
                    }
                    using (SqlCommand cmd = new SqlCommand("sp_informe_acumulado_cajero", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha_inicio", SqlDbType.DateTime).Value = Convert.ToDateTime(firstDayOfMonth);
                        cmd.Parameters.Add("@v_fecha_final", SqlDbType.DateTime).Value = Convert.ToDateTime(lastDayOfMonth);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeMDataSet.informe_recaudacion_mensual' Puede moverla o quitarla según sea necesario.
                        this.informe_acumuladoTableAdapter.Fill(this.peajeOrellaDataSet.informe_acumulado);
                    }
                }

                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("desde", firstDayOfMonth.ToShortDateString()),
                new ReportParameter("hasta", lastDayOfMonth.ToShortDateString()),
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
        #region Cargar Informe Vehículos Vendedor - Report 6
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

                using (SqlConnection con = Consultas.conectarOrella())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_inf_vehiculo_vendedor", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha_inicio1", SqlDbType.DateTime).Value = Convert.ToDateTime(firstDayOfMonth1);
                        cmd.Parameters.Add("@v_fecha_final1", SqlDbType.DateTime).Value = Convert.ToDateTime(lastDayOfMonth1);
                        cmd.Parameters.Add("@v_fecha_inicio2", SqlDbType.DateTime).Value = Convert.ToDateTime(firstDayOfMonth2);
                        cmd.Parameters.Add("@v_fecha_final2", SqlDbType.DateTime).Value = Convert.ToDateTime(lastDayOfMonth2);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeDataSet.inf_vehiculos_compara_mes' Puede moverla o quitarla según sea necesario.
                        this.inf_vehiculos_compara_mesTableAdapter.Fill(this.peajeOrellaDataSet.inf_vehiculos_compara_mes);
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
        #region Cargar Informe Vehículos Comprador - Report 7
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

                using (SqlConnection con = Consultas.conectarOrella())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_inf_vehiculo_comprador", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha_inicio1", SqlDbType.DateTime).Value = Convert.ToDateTime(firstDayOfMonth1);
                        cmd.Parameters.Add("@v_fecha_final1", SqlDbType.DateTime).Value = Convert.ToDateTime(lastDayOfMonth1);
                        cmd.Parameters.Add("@v_fecha_inicio2", SqlDbType.DateTime).Value = Convert.ToDateTime(firstDayOfMonth2);
                        cmd.Parameters.Add("@v_fecha_final2", SqlDbType.DateTime).Value = Convert.ToDateTime(lastDayOfMonth2);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeDataSet.inf_vehiculos_compara_mes' Puede moverla o quitarla según sea necesario.
                        this.inf_vehiculos_compara_mesTableAdapter.Fill(this.peajeOrellaDataSet.inf_vehiculos_compara_mes);

                    }
                }
                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("desdePrimerMes", firstDayOfMonth1.ToShortDateString()),
                new ReportParameter("hastaPrimerMes", lastDayOfMonth1.ToShortDateString()),
                new ReportParameter("desdeSegundoMes", firstDayOfMonth2.ToShortDateString()),
                new ReportParameter("hastaSegundoMes", lastDayOfMonth2.ToShortDateString()),
                new ReportParameter("nombre", nombre )
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
    }
}
