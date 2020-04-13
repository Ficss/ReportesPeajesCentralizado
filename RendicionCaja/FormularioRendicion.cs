using System;
using System.Configuration;
using System.Collections.Generic;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace RendicionCaja
{
    public partial class FormularioRendicion : KryptonForm
    {
        ReportDataSource rs = new ReportDataSource();

        #region Singleton
        private static FormularioRendicion frm = null;
        public static FormularioRendicion Instance()
        {
            if (frm == null)
            {
                frm = new FormularioRendicion();
            }
            return frm;
        }
        #endregion

        #region Constructor por defecto
        public FormularioRendicion()
        {
            InitializeComponent();
            lblFecha.Text = $"Fecha: {DateTime.Now.ToShortDateString()}";
            txtMonto.Maximum = Decimal.MaxValue;
            txtMontoVehiculo.Maximum = Decimal.MaxValue;
            txtDesde.Maximum = Decimal.MaxValue;
            txtHasta.Maximum = Decimal.MaxValue;
            cbTurno.SelectedIndex = -1;
        }
        #endregion

        #region Método para ingresar datos y mostrar Rendicion        
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //DateTime fecha_elegida = DateTime.Now;
                //string fecha = fecha_elegida.ToString("dd-MM-yyyy");
                //string con = Properties.Settings.Default.principalConnectionString;
                //using (SqlConnection connection = new SqlConnection(con))
                //{
                //    using (SqlCommand cmd = new SqlCommand("sp_informe_al_dia", connection))
                //    {
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@v_fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha_elegida).AddDays(-1);
                //connection.Open();
                //cmd.ExecuteNonQuery();
                //connection.Close();
                // TODO: esta línea de código carga datos en la tabla 'peajeMDataSet.informe_al_dia' Puede moverla o quitarla según sea necesario.
                //this.informe_al_diaTableAdapter.Fill(this.peajeMDataSet.informe_al_dia);
                //    }
                //}

                string valor = txtTotalValor.Text;
                string totalmonto = txtTotalMonto.Text;
                string turno = cbTurno.SelectedItem.ToString();
                int folio = 1;
                if (txtNombreCajero.Text == string.Empty)
                {
                    MessageBox.Show("Debe ingresar su nombre");
                    txtNombreCajero.Focus();
                }
                else if (txtDesde.Value == 0 || txtHasta.Value == 0 || txtMonto.Value == 0)
                {
                    MessageBox.Show("Uno de los campos contiene valor 0, verifique");
                }
                else if (!valor.Equals(totalmonto))
                {
                    MessageBox.Show("Uno de los montos no coincide, verifique");
                }
                else
                {
                    //string con = Properties.Settings.Default.principalConnectionString;
                    //using (SqlConnection connection = new SqlConnection(con))
                    //{
                    //    using (SqlCommand cmd = new SqlCommand("SELECT MAX(" +
                    //                                           "FROM usuario " +
                    //                                           "WHERE cod_usuario = ( " +
                    //                                           "SELECT DISTINCT b.cod_usuario " +
                    //                                           "FROM boleta b " +
                    //                                           "INNER JOIN turnos t ON b.cod_turno = t.cod_turno " +
                    //                                           "WHERE nombre_turno LIKE  @cod + '%'" +
                    //                                           "AND fecha = @hoy)", connection))

                    //    {
                    //        cmd.Parameters.AddWithValue("@cod", turno);
                    //        connection.Open();
                    //        SqlDataReader reader = cmd.ExecuteReader();
                    //        if (reader.Read())
                    //        {
                    //            string nombre = reader.GetString(0);
                    //            string codTurno = Convert.ToString(reader.GetByte(1));
                    //            txtNombreCajero.Text = nombre.Trim();
                    //            lblCodUsuario.Text = codTurno;
                    //        }
                    //        else
                    //        {
                    //            txtNombreCajero.Text = string.Empty;
                    //        }
                    //    }
                    //}

                    MessageBox.Show($"Se ha generado rendición con n° de folio {folio}");

                    ReporteRendicion rep = ReporteRendicion.Instance();
                    List<Datos> lst = new List<Datos>();
                    lst.Clear();

                    for (int i = 0; i < dgvVehiculo.Rows.Count - 1; i++)
                    {
                        Datos d = new Datos
                        {
                            Descripcion = dgvVehiculo.Rows[i].Cells[0].Value.ToString(),
                            Cantidad = Convert.ToInt32(dgvVehiculo.Rows[i].Cells[1].Value.ToString()),
                            Valor = Convert.ToInt32(dgvVehiculo.Rows[i].Cells[2].Value.ToString()),
                            Total = Convert.ToInt32(dgvVehiculo.Rows[i].Cells[3].Value.ToString()),
                        };
                        lst.Add(d);
                    }


                    rs.Name = "DataSet1";
                    rs.Value = lst;
                    
                    rep.reportViewer1.LocalReport.DataSources.Clear();
                    rep.reportViewer1.LocalReport.DataSources.Add(rs);
                    rep.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportesPrincipal.RendicionCaja.rdlc";


                    ReportParameter[] rparams = new ReportParameter[] {
                    new ReportParameter("NombreCajero", txtNombreCajero.Text),
                    new ReportParameter("Fecha", DateTime.Now.ToShortDateString()),
                    new ReportParameter("Turno", turno),
                    new ReportParameter("Folio", folio.ToString()),
                    new ReportParameter("Desde", txtDesde.Value.ToString()),
                    new ReportParameter("Hasta", txtHasta.Value.ToString()),
                    new ReportParameter("Monto", txtMonto.Value.ToString("C")),
                    new ReportParameter("Cantidad", txtCantidad.Text),
                    new ReportParameter("Emitidas", txtEmitidas.Text),
                    new ReportParameter("TotalMonto", txtTotalMonto.Text)
                        };
                    rep.reportViewer1.LocalReport.SetParameters(rparams);

                    rep.StartPosition = FormStartPosition.CenterScreen;
                    rep.WindowState = FormWindowState.Normal;
                    rep.Show();
                    rep.Activate();



                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Busca info del vehiculo por el código ingresado
        private void txtCodVehiculo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCodVehiculo.Text == string.Empty || string.IsNullOrWhiteSpace(txtCodVehiculo.Text))
                    {
                        MessageBox.Show("Campo código vehículo vacío, ingrese un valor");
                    }
                    else
                    {
                        string con = ConfigurationManager.ConnectionStrings["PRINCIPAL"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(con))
                        {
                            int cod = Convert.ToInt32(txtCodVehiculo.Text);
                            using (SqlCommand cmd = new SqlCommand("SELECT desc_vehiculos, valor FROM vehiculos WHERE cod_vehiculos = @cod", connection))
                            {
                                //cmd.Parameters.Add("@cod", SqlDbType.Int).Value = cod;
                                cmd.Parameters.AddWithValue("@cod", cod);
                                connection.Open();
                                SqlDataReader reader = cmd.ExecuteReader();

                                if (reader.Read())
                                {
                                    txtNombreVehiculo.Text = reader.GetString(0).Trim();
                                    txtMontoVehiculo.Text = Convert.ToString(reader.GetInt32(1));
                                    txtCantidadVehiculos.Focus();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Agregar filas a datagridview
        private void txtCantidadVehiculos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCantidadVehiculos.Text == string.Empty || string.IsNullOrWhiteSpace(txtCantidadVehiculos.Text))
                    {
                        MessageBox.Show("Campo cantidad vacío, ingrese un valor");
                    }
                    else
                    {
                        int rowId = dgvVehiculo.Rows.Add();

                        DataGridViewRow row = dgvVehiculo.Rows[rowId];

                        string vehiculo = string.Concat(txtCodVehiculo.Text, " - ", txtNombreVehiculo.Text);

                        int cantidad = Convert.ToInt32(txtCantidadVehiculos.Text);
                        int valor = Convert.ToInt32(txtMontoVehiculo.Value);
                        int total = valor * cantidad;

                        row.Cells["VEHICULO"].Value = vehiculo;
                        row.Cells["CANTIDAD"].Value = cantidad;
                        row.Cells["VALOR"].Value = valor;
                        row.Cells["TOTAL"].Value = total;

                        txtCodVehiculo.Text = string.Empty;
                        txtCantidadVehiculos.Text = string.Empty;
                        txtNombreVehiculo.Text = string.Empty;
                        txtMontoVehiculo.Value = 0;
                        txtCodVehiculo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Mostrar totales en campos de texto
        private void dgvVehiculo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int sumcantidad = 0;
            for (int i = 0; i < dgvVehiculo.Rows.Count; i++)
            {
                if (dgvVehiculo.Rows[i].Cells[1].Value.ToString() != string.Empty)
                {
                    sumcantidad += Convert.ToInt32(dgvVehiculo.Rows[i].Cells[1].Value);
                }
                txtTotalCantidad.Text = sumcantidad.ToString();
            }

            int sumtotal = 0;
            for (int i = 0; i < dgvVehiculo.Rows.Count; i++)
            {
                if (dgvVehiculo.Rows[i].Cells[1].Value.ToString() != string.Empty)
                {
                    sumtotal += Convert.ToInt32(dgvVehiculo.Rows[i].Cells[3].Value);
                }
                txtTotalValor.Text = sumtotal.ToString("C");
            }
        }
        #endregion

        #region Selecciona turno y busca el codigo de usuario 
        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string cod = cbTurno.SelectedItem.ToString();
                string hoy = DateTime.Now.ToShortDateString();
                var con = ConfigurationManager.ConnectionStrings["PM"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT RTRIM(nombre) + ' ' + RTRIM(ap_paterno) + ' ' + RTRIM(ap_materno), cod_usuario " +
                                                           "FROM usuario " +
                                                           "WHERE cod_usuario = ( " +
                                                           "SELECT DISTINCT b.cod_usuario " +
                                                           "FROM boleta b " +
                                                           "INNER JOIN turnos t ON b.cod_turno = t.cod_turno " +
                                                           "WHERE nombre_turno LIKE  @cod + '%'" +
                                                           "AND fecha = @hoy)", connection))
                    {
                        cmd.Parameters.AddWithValue("@cod", cod);
                        cmd.Parameters.AddWithValue("@hoy", hoy);
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string nombre = reader.GetString(0);
                            string codTurno = Convert.ToString(reader.GetByte(1));
                            txtNombreCajero.Text = nombre.Trim();
                            lblCodUsuario.Text = codTurno;
                        }
                        else
                        {
                            txtNombreCajero.Text = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Muestra cantidad entre desde y hasta 
        private void txtHasta_ValueChanged(object sender, EventArgs e)
        {
            CuentaCantidad();
        }

        private void txtDesde_ValueChanged(object sender, EventArgs e)
        {
            CuentaCantidad();
        }
        #endregion

        #region Método para obtener cantidad de documentos emitidos
        private void CuentaCantidad()
        {
            int desde = (int)txtDesde.Value;
            int hasta = (int)txtHasta.Value;
            int cantidad = (hasta - desde) + 1;
            txtEmitidas.Text = cantidad <= 0 ? "0" : cantidad.ToString();
        }
        #endregion

        #region Formatea monto en pesos
        private void txtMonto_ValueChanged(object sender, EventArgs e)
        {
            int monto = (int)txtMonto.Value;

            txtTotalMonto.Text = monto.ToString("C");
        }
        #endregion
    }
}
