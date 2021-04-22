using AccesoDatos;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReporteCajaDerecha
{
    public partial class ReportesCajaDerecha : KryptonForm
    {
        #region Singleton
        private static ReportesCajaDerecha frm = null;
        public static ReportesCajaDerecha Instance()
        {

            if (frm == null)
            {
                frm = new ReportesCajaDerecha();
            }
            return frm;
        }
        #endregion
        public ReportesCajaDerecha()
        {
            InitializeComponent();
            //Se setea campos de fecha con la fecha desde que salio a producción el sistema
            kryptonDateTimePicker2.MaxDate = DateTime.Now;
            DateTime today = DateTime.Today;

            int daysToAdd = 7 - (int)today.DayOfWeek;

            DateTime nextSaturday = today.AddDays(daysToAdd);

            dtpPrimeraSemana.MaxDate = nextSaturday;
            dtpUltimaSemana.MaxDate = nextSaturday;
        }

        private void btnDetalleDiario_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha_elegida = kryptonDateTimePicker2.Value.Date;
                string fecha = fecha_elegida.ToString("dd-MM-yyyy");
                string con = Properties.Settings.Default.RD;
                using (SqlConnection connection = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_informe_total_vehiculos", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        this.sp_informe_total_vehiculosTableAdapter.Fill(this.CajaDerechaDataSet.sp_informe_total_vehiculos, Convert.ToDateTime(fecha));
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

        private void btnDetalleSemanal_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha_inicial = dtpPrimeraSemana.Value.Date;
                DateTime fecha_final = dtpUltimaSemana.Value.Date;
                string fecha_i = fecha_inicial.ToString("dd/MM/yyyy");
                string fecha_f = fecha_final.ToString("dd/MM/yyyy");
                string con = Properties.Settings.Default.RD;
                using (SqlConnection connection = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_informe_total_vehiculos_rango", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fecha_inicio", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_i);
                        cmd.Parameters.Add("@fecha_fin", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_f);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        this.sp_informe_total_vehiculos_rangoTableAdapter.Fill(this.CajaDerechaDataSet.sp_informe_total_vehiculos_rango, Convert.ToDateTime(fecha_i), Convert.ToDateTime(fecha_f));
                    }
                }

                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("desde", fecha_i),
                new ReportParameter("hasta", fecha_f),
                };
                reportViewer2.LocalReport.SetParameters(rparams);
                this.reportViewer2.RefreshReport();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }

        private void btnDetalleMensual_Click(object sender, EventArgs e)
        {
            try
            {
                string formated = kryptonDateTimePicker3.Value.Month.ToString() + '/' + kryptonDateTimePicker4.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(formated);
                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                string con = Properties.Settings.Default.RD;
                using (SqlConnection connection = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_informe_total_vehiculos_rango", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fecha_inicio", SqlDbType.DateTime).Value = Convert.ToDateTime(firstDayOfMonth);
                        cmd.Parameters.Add("@fecha_fin", SqlDbType.DateTime).Value = Convert.ToDateTime(lastDayOfMonth);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        this.sp_informe_total_vehiculos_rangoTableAdapter.Fill(this.CajaDerechaDataSet.sp_informe_total_vehiculos_rango, Convert.ToDateTime(firstDayOfMonth), Convert.ToDateTime(lastDayOfMonth));
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

        private void ReportesCajaDerecha_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.RD);
            if (Prueba.QuickOpen(con, 600) == false)
            {
                MessageBox.Show("No se puso establecer una conexión a la base de datos.\n  " +
                                "Las causas pueden ser:\n " +
                                "-No está conectado a la red Vega Monumental.\n" +
                                " -Peaje está cerrado.\n" +
                                " -El cable de red está desconectado de su computador", "Peaje Mayo");
                this.DialogResult = DialogResult.Cancel;
                this.BeginInvoke(new MethodInvoker(this.Close));
            }
        }
    }
}
