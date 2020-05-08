using System;
using System.Configuration;
using System.Collections.Generic;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace RendicionCaja
{
    public partial class FormularioRendicion : KryptonForm
    {
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
                string valor = txtTotalValor.Text;
                string totalmonto = txtTotalMonto.Text;
                string turno = cbTurno.SelectedItem.ToString();
                string emitidas = txtTotalCantidad.Text;
                string totalemitidas = txtTotalEmitidas.Text;
                string fecha = dtpFecha.Value.ToShortDateString();
                int folio = 0;
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
                    MessageBox.Show(" ingresados no coinciden, verifique");
                }
                else if (!emitidas.Equals(totalemitidas))
                {
                    MessageBox.Show("Cantidad de boletas emitidas no coinciden, verifique");
                }
                else
                {
                    string con = ConfigurationManager.ConnectionStrings["PP"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(con))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(id_registro)" +
                                                               "FROM registro_rendicion", connection))
                        {
                            connection.Open();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                folio = reader.GetInt32(0);
                                if (folio == 0)
                                {
                                    folio++;
                                    MessageBox.Show($"Se ha generado rendición con n° de folio {folio}");
                                }
                                else
                                {
                                    folio++;
                                    MessageBox.Show($"Se ha generado rendición con n° de folio {folio}");
                                }
                            }
                        }
                        connection.Close();
                        using (SqlCommand cmd = new SqlCommand("sp_RegistroDocumentosRendicion", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@cod_usuario", SqlDbType.Int).Value = Convert.ToInt32(lblCodUsuario.Text);
                            cmd.Parameters.Add("@fecharegistro", SqlDbType.Date).Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            cmd.Parameters.Add("@cod_turno", SqlDbType.Int).Value = Convert.ToInt32(cbTurno.SelectedIndex) + 1;
                            cmd.Parameters.Add("@idregistro", SqlDbType.Int).Value = Convert.ToInt32(folio);
                            cmd.Parameters.Add("@desde", SqlDbType.Int).Value = Convert.ToInt32(txtDesde.Value);
                            cmd.Parameters.Add("@hasta", SqlDbType.Int).Value = Convert.ToInt32(txtHasta.Value);
                            cmd.Parameters.Add("@cantidadnulas", SqlDbType.Int).Value = Convert.ToInt32(txtCantidadNulas.Value);
                            cmd.Parameters.Add("@monto", SqlDbType.Int).Value = Convert.ToInt32(txtMonto.Value);
                            cmd.Parameters.Add("@fecharendicion", SqlDbType.Date).Value = Convert.ToDateTime(fecha);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                        }
                        connection.Close();
                        foreach (DataGridViewRow dr in dgvVehiculo.Rows)
                        {
                            string cod = dr.Cells[0].Value.ToString().Substring(0, 3).Trim();
                            int cantidad = Convert.ToInt32(dr.Cells[1].Value.ToString());
                            using (SqlCommand cmd = new SqlCommand("sp_VehiculoRendicion", connection))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@id_registro", SqlDbType.Int).Value = Convert.ToInt32(folio);
                                cmd.Parameters.Add("@cod_vehiculos", SqlDbType.Int).Value = cod;
                                cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                            }
                        }
                    }



                    ReporteRendicion rep = ReporteRendicion.Instance();
                    List<Datos> lst = new List<Datos>();
                    lst.Clear();
                    foreach (DataGridViewRow dr in dgvVehiculo.Rows)
                    {
                        Datos d = new Datos
                        {
                            Descripcion = dr.Cells[0].Value.ToString(),
                            Cantidad = Convert.ToInt32(dr.Cells[1].Value.ToString()),
                            Valor = Convert.ToInt32(dr.Cells[2].Value.ToString()),
                            Total = Convert.ToInt32(dr.Cells[3].Value.ToString()),
                        };
                        lst.Add(d);
                    }
                    ReportDataSource rs = new ReportDataSource();
                    rs.Name = "DataSet1";
                    rs.Value = lst;
                    rep.reportViewer1.LocalReport.DataSources.Add(rs);
                    rep.reportViewer1.LocalReport.ReportEmbeddedResource = "RendicionCaja.Report1.rdlc";

                    ReportParameter[] rparams = new ReportParameter[] {
                    new ReportParameter("NombreCajero", txtNombreCajero.Text),
                    new ReportParameter("Desde", txtDesde.Value.ToString()),
                    new ReportParameter("Hasta", txtHasta.Value.ToString()),
                    new ReportParameter("Monto", txtMonto.Value.ToString("C")),
                    new ReportParameter("Cantidad", txtCantidadNulas.Text),
                    new ReportParameter("Emitidas", txtTotalEmitidas.Text),
                    new ReportParameter("TotalMonto", txtTotalMonto.Text),
                    new ReportParameter("Turno", turno),
                    new ReportParameter("Folio", folio.ToString()),
                    new ReportParameter("FechaRendicion",fecha)
                    };
                    rep.reportViewer1.LocalReport.SetParameters(rparams);

                    //var bindinglist = new BindingList<Datos>(lst);
                    //BindingSource bs = new BindingSource(bindinglist, null);
                    //dgvVehiculo.DataSource = source;               
                    //BindingSource bs = source;
                    //DataTable dt = (DataTable)bs.DataSource;

                    rep.reportViewer1.RefreshReport();

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
                        string con = ConfigurationManager.ConnectionStrings["PP"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(con))
                        {
                            int cod = Convert.ToInt32(txtCodVehiculo.Text);
                            using (SqlCommand cmd = new SqlCommand("SELECT desc_vehiculos, valor FROM vehiculos WHERE cod_vehiculos = @cod AND cod_tipo_vehiculo != 3 ", connection))
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

                        string vehiculo = string.Concat(txtCodVehiculo.Text, "  - ", txtNombreVehiculo.Text);

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
                var con = ConfigurationManager.ConnectionStrings["PP"].ConnectionString;
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
            txtTotalEmitidas.Text = cantidad <= 0 ? "0" : cantidad.ToString();
        }
        #endregion

        #region Formatea monto en pesos
        private void txtMonto_ValueChanged(object sender, EventArgs e)
        {
            int monto = (int)txtMonto.Value;

            txtTotalMonto.Text = monto.ToString("C");
        }
        #endregion

        private void txtCodVehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCantidadVehiculos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
