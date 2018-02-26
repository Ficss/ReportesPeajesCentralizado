using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesoDatos
{
    public class CLIENTE
    {
        #region Atributos
        public int rut { get; set; }
        public string dv { get; set; }
        public string razon { get; set; }
        public string giro { get; set; }
        public string direccion { get; set; }
        public int estado { get; set; }
        public int seleccionar { get; set; }
        #endregion
        #region Método para crear cliente
        //Método para crear cliente
        //Fecha creación: 07/09/17
        public bool CrearCliente()
        {
            try
            {
                SqlConnection miconexion = Consultas.conectarPrincipal();
                miconexion.Open();
                SqlCommand consulta = new SqlCommand("INSERT INTO CLIENTES(RUT, DIG, RAZON, DIRECCION, GIRO, SELECCIONAR, COD_ESTADO) VALUES(@rut, @dv, @razon, @direccion, @giro, @seleccionar, @estado)", miconexion);
                consulta.Parameters.Add(new SqlParameter("@rut", this.rut));
                consulta.Parameters.Add(new SqlParameter("@dv", this.dv));
                consulta.Parameters.Add(new SqlParameter("@razon", this.razon));
                consulta.Parameters.Add(new SqlParameter("@direccion", this.direccion));
                consulta.Parameters.Add(new SqlParameter("@giro", this.giro));
                consulta.Parameters.Add(new SqlParameter("@seleccionar", this.seleccionar));
                consulta.Parameters.Add(new SqlParameter("@estado", this.estado));
                consulta.ExecuteNonQuery();
                miconexion.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                return false;
            }
        }
        #endregion
        #region Método para modificar cliente
        //Método para modificar cliente
        //Fecha creación: 06/10/16
        //nrut = rut sin dígito verificador
        public bool ModificarCliente(string nrut, string dv)
        {
            try
            {
                SqlConnection miconexion = Consultas.conectarPrincipal();
                miconexion.Open();
                SqlCommand consulta = new SqlCommand("UPDATE CLIENTES SET RAZON = @razon, GIRO= @giro , DIRECCION = @direccion WHERE RUT = @nrut AND DIG = @dv", miconexion);
                consulta.Parameters.Add(new SqlParameter("@razon", this.razon));
                consulta.Parameters.Add(new SqlParameter("@giro", this.giro));
                consulta.Parameters.Add(new SqlParameter("@direccion", this.direccion));
                consulta.Parameters.Add(new SqlParameter("@nrut", nrut));
                consulta.Parameters.Add(new SqlParameter("@dv", dv));
                consulta.ExecuteNonQuery();
                miconexion.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                return false;
            }
        }
        #endregion
    }
}
