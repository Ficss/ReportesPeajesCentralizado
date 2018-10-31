using AccesoDatos;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace ReportesPrincipal
{
    public partial class CodigosIngreso : KryptonForm
    {
        #region Variables
        Consultas s = new Consultas();
        #endregion
        #region Singleton
        //Singleton
        private static CodigosIngreso frm = null;
        public static CodigosIngreso Instance()
        {

            if (frm == null)
            {
                frm = new CodigosIngreso();
            }
            return frm;
        }
        #endregion
        #region Constructor por defecto
        public CodigosIngreso()
        {
            InitializeComponent();
        }
        #endregion
        #region Load
        private void CodigosIngreso_Load(object sender, EventArgs e)
        {
            GetData();
            dgvClientes.ClearSelection();
        }
        #endregion
        #region Get Data
        private void GetData()
        {
            DataTable dt = s.llenarTablaClientes();
            foreach (DataRow item in dt.Rows)
            {
                int n = dgvClientes.Rows.Add();
                dgvClientes.Rows[n].Cells[0].Value = item["RUT"].ToString();
                dgvClientes.Rows[n].Cells[1].Value = item["RAZON"].ToString();
                dgvClientes.Rows[n].Cells[2].Value = item["NLOCAL"].ToString();
                dgvClientes.Rows[n].Cells[3].Value = false;
            }
        }
        #endregion
        #region  Registrar Códigos de ingreso
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Value >= 1)
                {
                    if (dtpAn.Value.Year >= DateTime.Now.Year)
                    {
                        if (dtpMes.Value.Month >= DateTime.Now.Month)
                        {
                            for (int i = 0; i < dgvClientes.Rows.Count; i++)
                            {
                                bool isCellChecked = Convert.ToBoolean(dgvClientes.Rows[i].Cells[3].Value);
                                if (isCellChecked == true)
                                {
                                    string rut = dgvClientes.Rows[i].Cells[0].Value.ToString();
                                    string razon = dgvClientes.Rows[i].Cells[1].Value.ToString();
                                    string nlocal = dgvClientes.Rows[i].Cells[2].Value.ToString();
                                    string sindv = null;
                                    if (rut.Length == 12)
                                    {
                                        sindv = rut.Substring(0, 10).Replace(".", string.Empty).Trim();
                                    }
                                    else if (rut.Length == 11)
                                    {
                                        sindv = rut.Substring(0, 9).Replace(".", string.Empty).Trim();
                                    }

                                    //Fragmento para crear Fecha inicial, final y entrega
                                    DateTime hoy = DateTime.Now;
                                    var FechaInicial = new DateTime(hoy.Year, hoy.Month, 1);
                                    var FechaFinal = FechaInicial.AddMonths(1).AddDays(-1);
                                    string FechaActual = DateTime.Now.ToShortDateString();
                                    //Fragmento para crear periodo
                                    int año = DateTime.Now.Year;
                                    int mes = DateTime.Now.Month;
                                    int periodo = año * 100 + mes;

                                    int Item = 0;
                                    int codlocal = 0;
                                    int periodoobtenido = 0;
                                    SqlConnection miconexion = Consultas.conectarPrincipal();
                                    miconexion.Open();
                                    SqlCommand consulta = new SqlCommand("SELECT periodo FROM codigo_ingreso WHERE periodo = @periodo AND cod_cliente = @rut;", miconexion);
                                    consulta.Parameters.Add(new SqlParameter("@periodo", periodo));
                                    consulta.Parameters.Add(new SqlParameter("@rut", sindv));
                                    SqlDataReader reader = consulta.ExecuteReader();
                                    if (reader.Read())
                                    {
                                        //Si hay datos en el periodo actual se modifica el saldo
                                        periodoobtenido = reader.GetInt32(0);
                                    }
                                    else
                                    {
                                        //Si no hay datos en el periodo actual se inserta los datos del cliente y código
                                        SqlConnection miconexion2 = Consultas.conectarPrincipal();
                                        miconexion2.Open();
                                        SqlCommand consulta2 = new SqlCommand("SELECT MAX(COD_CODIGO_INGRESO) FROM CODIGO_INGRESO; ", miconexion2);
                                        SqlDataReader reader2 = consulta2.ExecuteReader();
                                        if (reader2.Read())
                                        {
                                            if (!reader2.HasRows)
                                            {
                                                Item = 1;
                                                miconexion2.Close();
                                            }
                                            else
                                            {
                                                Item = 1 + reader2.GetInt32(0);
                                                miconexion2.Close();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se puede obtener información del registro", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }

                                    //Si no hay datos en el periodo actual se inserta los datos del cliente y código
                                    SqlConnection miconexion3 = Consultas.conectarPrincipal();
                                    miconexion3.Open();
                                    SqlCommand consulta3 = new SqlCommand("SELECT idlocal FROM cliencar WHERE rut = @rut ", miconexion3);
                                    consulta3.Parameters.Add(new SqlParameter("@rut", sindv));
                                    SqlDataReader reader3 = consulta3.ExecuteReader();
                                    if (reader3.Read())
                                    {
                                        codlocal = reader3.GetInt32(0);
                                        miconexion.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se puede obtener información del registro", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    CodigoIngreso ci = new CodigoIngreso();
                                    ci.item = Item;
                                    ci.fechainicio = FechaInicial;
                                    ci.fechafin = FechaFinal;
                                    ci.fechaentrega = Convert.ToDateTime(FechaActual);
                                    ci.cantidad = Convert.ToInt32(txtCodigo.Value);
                                    ci.saldo = Convert.ToInt32(txtCodigo.Value);
                                    ci.codcliente = Convert.ToInt32(sindv);
                                    ci.codlocal = codlocal;
                                    ci.estado = 1;
                                    ci.numlocal = nlocal;
                                    ci.periodo = periodo;
                                    int rutcliente = Convert.ToInt32(sindv);
                                    if (ci.CrearCodigo())
                                    {
                                        DataTable dt = s.llenarTablaClientesResultado(rutcliente);
                                        foreach (DataRow item in dt.Rows)
                                        {
                                            int n = dgvClientesResultado.Rows.Add();
                                            dgvClientesResultado.Rows[n].Cells[0].Value = item["RAZON"].ToString();
                                            dgvClientesResultado.Rows[n].Cells[1].Value = item["NLOCAL"].ToString();
                                            dgvClientesResultado.Rows[n].Cells[2].Value = item["CCODIGOS"].ToString();
                                            dgvClientesResultado.Rows[n].Cells[3].Value = item["CRESTANTES"].ToString();
                                            dgvClientesResultado.Rows[n].Cells[4].Value = item["PERIODO"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error al guardar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                }
                            }
                        }
                        else
                        {
                            KryptonMessageBox.Show("MES SELECCIONADO TIENE QUE SER IGUAL O MAYOR AL ACTUAL (" + DateTime.Now.ToString("MMMM").ToUpper() + ")", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        KryptonMessageBox.Show("AÑO SELECCIONADO TIENE QUE SER IGUAL AL ACTUAL (" + DateTime.Now.Year + ")", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    KryptonMessageBox.Show("CANTIDAD DE CÓDIGOS A GENERAR DEBE SER MAYOR A 0", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Seleccionar Todo
        private void chkSeleccionar_CheckStateChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                if (chkSeleccionar.Checked == false && chk.Value == chk.TrueValue)
                {
                    dgvClientes.ClearSelection();
                    chk.Value = chk.FalseValue;
                }
                else
                {
                    dgvClientes.SelectAll();
                    chk.Value = chk.TrueValue;
                }
            }
        }
        #endregion
        #region Seleccionar Cliente en grilla
        private void dgvClientes_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvClientes.SelectedRows)
                {

                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                    if (chk.Value == chk.FalseValue)
                    {
                        chk.Value = chk.TrueValue;
                    }
                    else
                    {
                        chk.Value = chk.FalseValue;
                    }
                }
            }
            catch (Exception) { }
        }
        #endregion
    }
}
