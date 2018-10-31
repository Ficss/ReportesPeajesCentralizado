using AccesoDatos;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace MainWindows
{
    public partial class RegistroClientes : KryptonForm
    {
        #region Inicialización de variables
        Padre p;
        Consultas s = new Consultas();
        #endregion
        #region Constructor por defecto
        public RegistroClientes()
        {
            InitializeComponent();
        }
        #endregion
        #region Singleton
        //Singleton
        private static RegistroClientes frm = null;
        public static RegistroClientes Instance()
        {

            if (frm == null)
            {
                frm = new RegistroClientes();
            }
            return frm;
        }
        #endregion
        #region Load
        private void RegistroClientes_Load(object sender, EventArgs e)
        {
            GetData();
            dgvClientes.ClearSelection();
            dgvCodigosGenerados.ClearSelection();
        }
        #endregion
        #region Método GetData
        private void GetData()
        {
            DataTable dt = s.llenarTablaClientes();
            foreach (DataRow item in dt.Rows)
            {
                int n = dgvClientes.Rows.Add();
                dgvClientes.Rows[n].Cells[0].Value = item["RUT"].ToString();
                dgvClientes.Rows[n].Cells[1].Value = item["RAZON"].ToString();
                dgvClientes.Rows[n].Cells[2].Value = item["NLOCAL"].ToString();
                dgvClientes.Rows[n].Cells[3].Value = item["CLOCAL"].ToString();
                dgvClientes.Rows[n].Cells[4].Value = item["ESTADO"].ToString();
                if (item["ESTADO"].ToString().Equals("1"))
                {
                    dgvClientes.Rows[n].Cells[4].Value = "ACTIVO";
                }
                else
                {
                    dgvClientes.Rows[n].Cells[4].Value = "INACTIVO";
                }
            }
        }
        #endregion
        #region Seleccionar cliente
        private void dgvClientes_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string numlocal = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                dgvCodigosGenerados.Rows.Clear();
                DataTable dt = s.llenarTablaRegistroClientes(numlocal);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dgvCodigosGenerados.Rows.Add();
                    dgvCodigosGenerados.Rows[n].Cells[0].Value = item["NUMLOCAL"].ToString();
                    dgvCodigosGenerados.Rows[n].Cells[1].Value = item["PERIODO"].ToString();
                    dgvCodigosGenerados.Rows[n].Cells[2].Value = item["CANTCODIGOS"].ToString();
                    dgvCodigosGenerados.Rows[n].Cells[3].Value = item["SALDO"].ToString();
                }
                string nombres = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                //string MApellidoM = dgvUsuarios.CurrentRow.Cells[3].Value.ToString();
                //string concat = Nombre + " " + MApellidoP + " " + MApellidoM;
                lblSeleccionado.Text = "Usuario seleccionado: " + nombres.ToUpper();
            }
            catch (Exception) { }
        }
        #endregion
        #region Ver detalles de codigos generados
        private void dgvCodigosGenerados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int saldo = Convert.ToInt32(dgvCodigosGenerados.CurrentRow.Cells[3].Value.ToString());
                int cantidad = Convert.ToInt32(dgvCodigosGenerados.CurrentRow.Cells[2].Value.ToString());

                if (saldo == cantidad)
                {
                    KryptonMessageBox.Show("NO HAY DATOS QUE MOSTRAR", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    kryptonNavigator1.SelectedPage = kryptonPage2;
                    string numlocal = dgvCodigosGenerados.CurrentRow.Cells[0].Value.ToString().TrimEnd();
                    int periodo = Convert.ToInt32(dgvCodigosGenerados.CurrentRow.Cells[1].Value.ToString());

                    dgvDetalleCodigos.Rows.Clear();
                    DataTable dt = s.llenarTablaDetalleCodigos(numlocal, periodo);
                    foreach (DataRow item in dt.Rows)
                    {
                        int n = dgvDetalleCodigos.Rows.Add();
                        dgvDetalleCodigos.Rows[n].Cells[0].Value = item["NINGRESO"].ToString();
                        dgvDetalleCodigos.Rows[n].Cells[1].Value = item["FH"].ToString();
                        dgvDetalleCodigos.Rows[n].Cells[2].Value = item["TINGRESO"].ToString();
                    }
                }
            }
            catch (Exception) { }
        }
        #endregion
        #region Seleccionar cliente presionando enter
        private void dgvCodigosGenerados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int saldo = Convert.ToInt32(dgvCodigosGenerados.CurrentRow.Cells[3].Value.ToString());
                int cantidad = Convert.ToInt32(dgvCodigosGenerados.CurrentRow.Cells[2].Value.ToString());

                if (saldo == cantidad)
                {
                    KryptonMessageBox.Show("NO HAY DATOS QUE MOSTRAR", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    kryptonNavigator1.SelectedPage = kryptonPage2;
                    string numlocal = dgvCodigosGenerados.CurrentRow.Cells[0].Value.ToString().TrimEnd();
                    int periodo = Convert.ToInt32(dgvCodigosGenerados.CurrentRow.Cells[1].Value.ToString());

                    dgvDetalleCodigos.Rows.Clear();
                    DataTable dt = s.llenarTablaDetalleCodigos(numlocal, periodo);
                    foreach (DataRow item in dt.Rows)
                    {
                        int n = dgvDetalleCodigos.Rows.Add();
                        dgvDetalleCodigos.Rows[n].Cells[0].Value = item["NINGRESO"].ToString();
                        dgvDetalleCodigos.Rows[n].Cells[1].Value = item["FH"].ToString();
                        dgvDetalleCodigos.Rows[n].Cells[2].Value = item["TINGRESO"].ToString();
                    }
                }
            }
        }
        #endregion
        #region Filtrar por periodo
        private void txtPeriodo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string numlocal = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                dgvCodigosGenerados.Rows.Clear();
                DataTable dt = s.llenarTablaRegistroClientesFiltrado(numlocal, txtPeriodo.Text);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dgvCodigosGenerados.Rows.Add();
                    dgvCodigosGenerados.Rows[n].Cells[0].Value = item["NUMLOCAL"].ToString();
                    dgvCodigosGenerados.Rows[n].Cells[1].Value = item["PERIODO"].ToString();
                    dgvCodigosGenerados.Rows[n].Cells[2].Value = item["CANTCODIGOS"].ToString();
                    dgvCodigosGenerados.Rows[n].Cells[3].Value = item["SALDO"].ToString();
                }
            }
            catch (Exception) { }
        }
        #endregion
        #region Seleccionar cliente presionando enter
        private void dgvClientes_KeyDown(object sender, KeyEventArgs e)
        {
            //Si el usuario presiona tecla enter...
            if (e.KeyCode == Keys.Enter)
            {   //Aparecerá una ventana de confirmación 
                DialogResult rs = MessageBox.Show("¿Desea modificar?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                {
                    if (rs == DialogResult.Yes)
                    {
                        p = (Padre)this.MdiParent;
                        ClienteModificar am = null;
                        am = ClienteModificar.Instance();
                        am.MdiParent = p;
                        am.StartPosition = FormStartPosition.CenterScreen;
                        am.Show();
                        string rut = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                        string rutsindv = null;
                        string dv = null;
                        string razon = null;
                        string giro = null;
                        string direccion = null;
                        if (rut.Length == 12)
                        {
                            rutsindv = rut.Substring(0, 10).Replace(".", string.Empty).Trim();
                            dv = rut.Substring(11, 1).Trim();
                        }
                        else if (rut.Length == 11)
                        {
                            rutsindv = rut.Substring(0, 9).Replace(".", string.Empty).Trim();
                            dv = rut.Substring(10, 1).Trim();
                        }

                        SqlConnection miconexion = Consultas.conectarPrincipal();
                        miconexion.Open();
                        SqlCommand consulta = new SqlCommand("SELECT RAZON, GIRO, DIRECCION FROM CLIENTES WHERE RUT = @rut AND DIG = @dv", miconexion);
                        consulta.Parameters.Add(new SqlParameter("@rut", rutsindv));
                        consulta.Parameters.Add(new SqlParameter("@dv", dv));
                        SqlDataReader reader = consulta.ExecuteReader();
                        if (reader.Read())
                        {
                            razon = reader.GetString(0);
                            giro = reader.GetString(1);
                            direccion = reader.GetString(2);
                        }
                        am.lblMRut.Text = rut;
                        am.txtMRazon.Text = razon.Trim();
                        am.txtMGiro.Text = giro.Trim();
                        am.txtMDireccion.Text = direccion.Trim();
                        am.WindowState = FormWindowState.Normal;
                        am.Activate();
                        this.Dispose();
                    }
                }
            }
        }
        #endregion
        #region Registrar cliente
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            p = (Padre)this.MdiParent;
            ClienteRegistrar cr = null;
            cr = ClienteRegistrar.Instance();
            cr.MdiParent = p;
            cr.StartPosition = FormStartPosition.CenterScreen;
            cr.Show();
            cr.WindowState = FormWindowState.Normal;
            cr.Activate();
            this.Dispose();
        }
        #endregion
        #region Desactivar cliente
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int estado = 0;
                string rut = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                string sindv = null;
                if (rut.Length == 12)
                {
                    sindv = rut.Substring(0, 10).Replace(".", string.Empty).Trim();
                }
                else if (rut.Length == 11)
                {
                    sindv = rut.Substring(0, 9).Replace(".", string.Empty).Trim();
                }

                SqlConnection miconexion = Consultas.conectarPrincipal();
                miconexion.Open();
                SqlCommand consulta = new SqlCommand("SELECT ESTADO FROM CLIENCAR WHERE RUT = @rut", miconexion);
                consulta.Parameters.Add(new SqlParameter("@rut", sindv));
                SqlDataReader reader = consulta.ExecuteReader();
                if (reader.Read())
                {
                    estado = reader.GetInt32(0);
                }
                string nombre = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                if (estado == 1)
                {
                    DialogResult rs = KryptonMessageBox.Show("¿Seguro desea desactivar a: " + nombre.ToUpper() + "?", "DESACTIVAR CLIENTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    {
                        if (rs == DialogResult.Yes)
                        {
                            CLIENCAR c = new CLIENCAR();
                            c.estado = 0;
                            if (c.desactivarCliente(sindv))
                            {
                                MessageBox.Show("Cliente desactivado exitosamente");
                                this.dgvClientes.Rows.Clear();
                                GetData();
                            }
                            else
                            {
                                MessageBox.Show("Error al guardar cambios");
                            }
                        }
                    }
                }
                else if (estado == 0)
                {
                    DialogResult rs = KryptonMessageBox.Show("¿Seguro desea activar a: " + nombre.ToUpper() + "?", "ACTIVAR CLIENTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    {
                        if (rs == DialogResult.Yes)
                        {
                            CLIENCAR c = new CLIENCAR();
                            c.estado = 1;
                            if (c.desactivarCliente(sindv))
                            {
                                MessageBox.Show("Cliente activado exitosamente");
                                this.dgvClientes.Rows.Clear();
                                GetData();
                            }
                            else
                            {
                                MessageBox.Show("Error al guardar cambios");
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        #endregion
    }
}
