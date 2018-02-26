using ComponentFactory.Krypton.Toolkit;
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
using AccesoDatos;
using Microsoft.Reporting.WinForms;

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
        }
        #endregion
        #region Load
        private void ReportesPeajePrincipal_Load(object sender, EventArgs e)
        {
            kryptonDateTimePicker1.MaxDate = DateTime.Now;
        }
        #endregion
        #region Cargar informe diario - Report 1
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha_elegida = kryptonDateTimePicker1.Value.Date;
                string fecha = fecha_elegida.ToString("dd-MM-yyyy");
                DateTime fecha_final = kryptonDateTimePicker1.Value.Date;
                DateTime fecha_inicial = kryptonDateTimePicker1.Value.Date.AddDays(-1);
                string fecha_i = fecha_inicial.ToString("dd/MM/yyyy");
                string fecha_f = fecha_final.ToString("dd/MM/yyyy");
                using (SqlConnection con = Consultas.conectarPrincipal())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_informe_diario", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha_inicial", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_i);
                        cmd.Parameters.Add("@v_fecha_final", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_f);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajePrincipalDataSet.informe_diario' Puede moverla o quitarla según sea necesario.
                        this.informe_diarioTableAdapter.Fill(this.peajePrincipalDataSet.informe_diario);
                    }
                }
                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("fecha", fecha)
                };
                reportViewer1.LocalReport.SetParameters(rparams);
                this.reportViewer1.RefreshReport();

                //sp_informe_diario con cierre_z terminado el 18 de octubre 
                //cada consulta el día anterior se carga el sp_informe_diario original
                //if (dia_seleccionado >18/10/17) cargar sp_informe_diario con cierre_z
                //else cargar sp_informe_diario original

                //DateTime fecha_elegida = kryptonDateTimePicker1.Value.Date;
                //string fecha = fecha_elegida.ToString("yyyy-MM-dd");
                //using (SqlConnection con = Consultas.conectar())
                //{
                //    using (SqlCommand cmd = new SqlCommand("sp_informe_diario", con))
                //    {
                //        cmd.CommandType = CommandType.StoredProcedure;
                //        cmd.Parameters.Add("@v_fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_elegida);
                //        con.Open();
                //        cmd.ExecuteNonQuery();
                //        con.Close();
                //        // TODO: esta línea de código carga datos en la tabla 'peajeDataSet.informe_diario' Puede moverla o quitarla según sea necesario.
                //        this.informe_diarioTableAdapter.Fill(this.peajeDataSet.informe_diario);
                //    }
                //}
                //this.reportViewer1.RefreshReport();
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
            try
            {
                string formated = dtpMes.Value.Month.ToString() + '/' + dtpAn.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(formated);
                DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                DateTime fecha_inicial = firstDayOfMonth.Date.AddDays(-1);


                using (SqlConnection con = Consultas.conectarPrincipal())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_informe_recaudacion_mensual", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha_inicio", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_inicial).ToShortDateString();
                        cmd.Parameters.Add("@v_fecha_final", SqlDbType.DateTime).Value = Convert.ToDateTime(lastDayOfMonth);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeDataSet.informe_recaudacion_mensual' Puede moverla o quitarla según sea necesario.
                        this.informe_recaudacion_mensualTableAdapter.Fill(this.peajePrincipalDataSet.informe_recaudacion_mensual);
                    }
                }
                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("desde", firstDayOfMonth.ToShortDateString()),
                new ReportParameter("hasta", lastDayOfMonth.ToShortDateString()),
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
        #region Cargar informe semanal - Report 3
        private void btnInformeSemanal_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha_inicial = dtpPrimeraSemana.Value.Date.AddDays(-1);
                DateTime fecha_final = dtpUltimaSemana.Value.Date;
                string fecha_i = fecha_inicial.ToString("dd/MM/yyyy");
                string fecha_f = fecha_final.ToString("dd/MM/yyyy");
                using (SqlConnection con = Consultas.conectarPrincipal())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_informe_recaudacion_semanal", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha_inicio", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_i);
                        cmd.Parameters.Add("@v_fecha_final", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_f);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajePrincipalDataSet.informe_recaudacion_semanal' Puede moverla o quitarla según sea necesario.
                        this.informe_recaudacion_semanalTableAdapter.Fill(this.peajePrincipalDataSet.informe_recaudacion_semanal);
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
                string formated = DateTime.Now.Day.ToString() + '/' + dtpMesCajero.Value.Month.ToString() + '/' + dtpAnCajero.Value.Year.ToString();
                DateTime fecha_inicial = Convert.ToDateTime(formated);

                string fecha_finalF = null; //DateTime.Now.Day.ToString() + '/' + dtpMes.Value.AddMonths(1).ToString("MM") + '/' + dtpAn.Value.Year.ToString();
                DateTime fecha_final = DateTime.MinValue; //Convert.ToDateTime(fecha_finalF);

                string fecha_i = null;
                string fecha_f = null;

                if (dtpMesCajero.Value.Month == 12)
                {
                    fecha_finalF = DateTime.Now.Day.ToString() + '/' + dtpMesCajero.Value.Month.ToString() + '/' + dtpAnCajero.Value.AddYears(1).ToString("yyyy"); //kryptonDateTimePicker3.Value.Date.AddYears(1).AddDays(-1);
                }
                else
                {
                    fecha_finalF = DateTime.Now.Day.ToString() + '/' + dtpMesCajero.Value.AddMonths(1).ToString("MM") + '/' + dtpAnCajero.Value.Year.ToString(); //kryptonDateTimePicker3.Value.Date.AddMonths(1).AddDays(-1);
                }
                fecha_final = Convert.ToDateTime(fecha_finalF);
                fecha_inicial = fecha_inicial.Date.AddDays(-1);
                fecha_final = fecha_final.Date.AddDays(-1);
                fecha_i = fecha_inicial.ToString("dd/MM/yyyy");
                fecha_f = fecha_final.ToString("dd/MM/yyyy");

                var firstDayOfMonth = fecha_i;
                var lastDayOfMonth = fecha_f;

                using (SqlConnection con = Consultas.conectarPrincipal())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_informe_mensual_cajeros", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha_inicio", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_i);
                        cmd.Parameters.Add("@v_fecha_final", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_f);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajePrincipalDataSet.informe_recaudacion_mensual' Puede moverla o quitarla según sea necesario.
                        this.informe_recaudacion_mensualTableAdapter.Fill(this.peajePrincipalDataSet.informe_recaudacion_mensual);
                    }
                }
                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("desde", firstDayOfMonth),
                new ReportParameter("hasta", lastDayOfMonth),
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
                string formated1 = DateTime.Now.Day.ToString() + '/' + dtpMesVendedorInicial.Value.Month.ToString() + '/' + dtpAnVendedorInicial.Value.Year.ToString();
                DateTime fecha_inicial1 = Convert.ToDateTime(formated1);

                string fecha_finalF1 = null; //DateTime.Now.Day.ToString() + '/' + dtpMes.Value.AddMonths(1).ToString("MM") + '/' + dtpAn.Value.Year.ToString();
                DateTime fecha_final1 = DateTime.MinValue;

                string fecha_i1 = null;
                string fecha_f1 = null;

                if (dtpMesVendedorInicial.Value.Month == 12)
                {
                    fecha_finalF1 = DateTime.Now.Day.ToString() + '/' + dtpMesVendedorInicial.Value.Month.ToString() + '/' + dtpAnVendedorInicial.Value.AddYears(1).ToString("yyyy"); //kryptonDateTimePicker3.Value.Date.AddYears(1).AddDays(-1);
                }
                else
                {
                    fecha_finalF1 = DateTime.Now.Day.ToString() + '/' + dtpMesVendedorInicial.Value.AddMonths(1).ToString("MM") + '/' + dtpAnVendedorInicial.Value.Year.ToString(); //kryptonDateTimePicker3.Value.Date.AddMonths(1).AddDays(-1);
                }

                string formated2 = DateTime.Now.Day.ToString() + '/' + dtpMesVendedorFinal.Value.Month.ToString() + '/' + dtpAnVendedorFinal.Value.Year.ToString();
                DateTime fecha_inicial2 = Convert.ToDateTime(formated2);

                string fecha_finalF2 = null; //DateTime.Now.Day.ToString() + '/' + dtpMes.Value.AddMonths(1).ToString("MM") + '/' + dtpAn.Value.Year.ToString();
                DateTime fecha_final2 = DateTime.MinValue;

                string fecha_i2 = null;
                string fecha_f2 = null;

                if (dtpMesVendedorFinal.Value.Month == 12)
                {
                    fecha_finalF2 = DateTime.Now.Day.ToString() + '/' + dtpMesVendedorFinal.Value.Month.ToString() + '/' + dtpAnVendedorFinal.Value.AddYears(1).ToString("yyyy"); //kryptonDateTimePicker3.Value.Date.AddYears(1).AddDays(-1);
                }
                else
                {
                    fecha_finalF2 = DateTime.Now.Day.ToString() + '/' + dtpMesVendedorFinal.Value.AddMonths(1).ToString("MM") + '/' + dtpAnVendedorFinal.Value.Year.ToString(); //kryptonDateTimePicker3.Value.Date.AddMonths(1).AddDays(-1);
                }
                fecha_final1 = Convert.ToDateTime(fecha_finalF1);
                fecha_inicial1 = fecha_inicial1.Date.AddDays(-1);
                fecha_final1 = fecha_final1.Date.AddDays(-1);
                fecha_i1 = fecha_inicial1.ToString("dd/MM/yyyy");
                fecha_f1 = fecha_final1.ToString("dd/MM/yyyy");

                fecha_final2 = Convert.ToDateTime(fecha_finalF2);
                fecha_inicial2 = fecha_inicial2.Date.AddDays(-1);
                fecha_final2 = fecha_final2.Date.AddDays(-1);
                fecha_i2 = fecha_inicial2.ToString("dd/MM/yyyy");
                fecha_f2 = fecha_final2.ToString("dd/MM/yyyy");

                using (SqlConnection con = Consultas.conectarPrincipal())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_inf_vehiculo_vendedor", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha_inicio1", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_i1);
                        cmd.Parameters.Add("@v_fecha_final1", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_f1);
                        cmd.Parameters.Add("@v_fecha_inicio2", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_i2);
                        cmd.Parameters.Add("@v_fecha_final2", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_f2);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajePrincipalDataSet.inf_vehiculos_compara_mes' Puede moverla o quitarla según sea necesario.
                        this.inf_vehiculos_compara_mesTableAdapter.Fill(this.peajePrincipalDataSet.inf_vehiculos_compara_mes);
                    }
                }
                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("desdePrimerMes", fecha_i1),
                new ReportParameter("hastaPrimerMes", fecha_f1),
                new ReportParameter("desdeSegundoMes", fecha_i2),
                new ReportParameter("hastaSegundoMes", fecha_f2),
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
                string formated1 = DateTime.Now.Day.ToString() + '/' + dtpMesCompradorInicial.Value.Month.ToString() + '/' + dtpAnCompradorInicial.Value.Year.ToString();
                DateTime fecha_inicial1 = Convert.ToDateTime(formated1);

                string fecha_finalF1 = null; //DateTime.Now.Day.ToString() + '/' + dtpMes.Value.AddMonths(1).ToString("MM") + '/' + dtpAn.Value.Year.ToString();
                DateTime fecha_final1 = DateTime.MinValue;

                string fecha_i1 = null;
                string fecha_f1 = null;

                if (dtpMesCompradorInicial.Value.Month == 12)
                {
                    fecha_finalF1 = DateTime.Now.Day.ToString() + '/' + dtpMesCompradorInicial.Value.Month.ToString() + '/' + dtpAnCompradorInicial.Value.AddYears(1).ToString("yyyy"); //kryptonDateTimePicker3.Value.Date.AddYears(1).AddDays(-1);
                }
                else
                {
                    fecha_finalF1 = DateTime.Now.Day.ToString() + '/' + dtpMesCompradorInicial.Value.AddMonths(1).ToString("MM") + '/' + dtpAnCompradorInicial.Value.Year.ToString(); //kryptonDateTimePicker3.Value.Date.AddMonths(1).AddDays(-1);
                }

                string formated2 = DateTime.Now.Day.ToString() + '/' + dtpMesCompradorFinal.Value.Month.ToString() + '/' + dtpAnCompradorFinal.Value.Year.ToString();
                DateTime fecha_inicial2 = Convert.ToDateTime(formated2);

                string fecha_finalF2 = null; //DateTime.Now.Day.ToString() + '/' + dtpMes.Value.AddMonths(1).ToString("MM") + '/' + dtpAn.Value.Year.ToString();
                DateTime fecha_final2 = DateTime.MinValue;

                string fecha_i2 = null;
                string fecha_f2 = null;

                if (dtpMesCompradorFinal.Value.Month == 12)
                {
                    fecha_finalF2 = DateTime.Now.Day.ToString() + '/' + dtpMesCompradorFinal.Value.Month.ToString() + '/' + dtpAnCompradorFinal.Value.AddYears(1).ToString("yyyy"); //kryptonDateTimePicker3.Value.Date.AddYears(1).AddDays(-1);
                }
                else
                {
                    fecha_finalF2 = DateTime.Now.Day.ToString() + '/' + dtpMesCompradorFinal.Value.AddMonths(1).ToString("MM") + '/' + dtpAnCompradorFinal.Value.Year.ToString(); //kryptonDateTimePicker3.Value.Date.AddMonths(1).AddDays(-1);
                }
                fecha_final1 = Convert.ToDateTime(fecha_finalF1);
                fecha_inicial1 = fecha_inicial1.Date.AddDays(-1);
                fecha_final1 = fecha_final1.Date.AddDays(-1);
                fecha_i1 = fecha_inicial1.ToString("dd/MM/yyyy");
                fecha_f1 = fecha_final1.ToString("dd/MM/yyyy");

                fecha_final2 = Convert.ToDateTime(fecha_finalF2);
                fecha_inicial2 = fecha_inicial2.Date.AddDays(-1);
                fecha_final2 = fecha_final2.Date.AddDays(-1);
                fecha_i2 = fecha_inicial2.ToString("dd/MM/yyyy");
                fecha_f2 = fecha_final2.ToString("dd/MM/yyyy");

                using (SqlConnection con = Consultas.conectarPrincipal())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_inf_vehiculo_comprador", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@v_fecha_inicio1", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_i1);
                        cmd.Parameters.Add("@v_fecha_final1", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_f1);
                        cmd.Parameters.Add("@v_fecha_inicio2", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_i2);
                        cmd.Parameters.Add("@v_fecha_final2", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_f2);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        // TODO: esta línea de código carga datos en la tabla 'peajeDataSet.inf_vehiculos_compara_mes' Puede moverla o quitarla según sea necesario.
                        this.inf_vehiculos_compara_mesTableAdapter.Fill(this.peajePrincipalDataSet.inf_vehiculos_compara_mes);

                    }
                }
                ReportParameter[] rparams = new ReportParameter[] {
                new ReportParameter("desdePrimerMes", fecha_i1),
                new ReportParameter("hastaPrimerMes", fecha_f1),
                new ReportParameter("desdeSegundoMes", fecha_i2),
                new ReportParameter("hastaSegundoMes", fecha_f2),
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

    }
}
