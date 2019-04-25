using ComponentFactory.Krypton.Toolkit;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;

namespace ReportesPrincipal
{
    public partial class HorasVehiculos : KryptonForm
    {
        #region Singleton
        private static HorasVehiculos frm = null;
        public static HorasVehiculos Instance()
        {
            if (frm == null)
            {
                frm = new HorasVehiculos();
            }
            return frm;
        }
        #endregion
        #region Constructor por defecto
        public HorasVehiculos()
        {
            InitializeComponent();
        }
        #endregion
        #region Método Load
        private void HorasVehiculos_Load(object sender, EventArgs e)
        {
            try
            {
                string con = Properties.Settings.Default.principalConnectionString;
                using (SqlConnection connection = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_HorasVehiculos", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@boleta_inicial", SqlDbType.Int).Value = Convert.ToInt32(lblBoletaInicial.Text);
                        cmd.Parameters.Add("@boleta_final", SqlDbType.Int).Value = Convert.ToInt32(lblBoletaFinal.Text);
                        cmd.Parameters.Add("@cod_vehiculo", SqlDbType.Int).Value = lblCodigo.Text;
                        cmd.Parameters.Add("@turno", SqlDbType.Int).Value = lblTurno.Text;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvHoras.DataSource = dt;

                            if (dt.Rows.Count > 0)
                            {


                                string celdaseliminadas = dgvHoras.Rows[0].Cells[0].Value.ToString();

                                for (int i = 1; i < dgvHoras.Rows.Count; i++)
                                {
                                    if (dgvHoras.Rows[i].Cells[0].Value.ToString() == celdaseliminadas)
                                    {
                                        dgvHoras.Rows[i].Cells[0].Value = string.Empty;
                                    }
                                    else
                                    {
                                        celdaseliminadas = dgvHoras.Rows[i].Cells[0].Value.ToString();
                                    }
                                }
                            }else
                            {
                                dgvHoras.Visible = false;
                                lblTurno.ForeColor = System.Drawing.Color.White;
                                lblTurno.Visible = true;
                                lblTurno.Text = "NO HAY DATOS PARA MOSTRAR";
                                //MessageBox.Show("No hay datos para mostrar");
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
    }
}
