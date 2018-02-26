using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesoDatos
{
    public class CodigoIngreso
    {
        #region Atributos
        public int item { get; set; }
        public DateTime fechainicio { get; set; }
        public DateTime fechafin { get; set; }
        public DateTime fechaentrega { get; set; }
        public int cantidad { get; set; }
        public int saldo { get; set; }
        public int codcliente { get; set; }
        public int codlocal { get; set; }
        public int estado { get; set; }
        public int periodo { get; set; }
        public string numlocal { get; set; }
        #endregion
        #region Método para crear código de ingreso
        //Método para crear codigo de ingreso
        public bool CrearCodigo()
        {
            try
            {
                SqlConnection miconexion = Consultas.conectarPrincipal();
                miconexion.Open();
                SqlCommand consulta = new SqlCommand("INSERT INTO CODIGO_INGRESO(COD_CODIGO_INGRESO, FECHA_INICIO, FECHA_TERMINO, FECHA_ENTREGA, CANTIDAD, SALDO, COD_CLIENTE, COD_LOCAL, COD_ESTADO, PERIODO, NUM_LOCAL) VALUES(@item, @finicio, @ffin, @fentrega, @cantidad, @saldo, @ccliente, @clocal, @estado, @periodo, @nlocal)", miconexion);
                consulta.Parameters.Add(new SqlParameter("@item", this.item));
                consulta.Parameters.Add(new SqlParameter("@finicio", this.fechainicio));
                consulta.Parameters.Add(new SqlParameter("@ffin", this.fechafin));
                consulta.Parameters.Add(new SqlParameter("@fentrega", this.fechaentrega));
                consulta.Parameters.Add(new SqlParameter("@cantidad", this.cantidad));
                consulta.Parameters.Add(new SqlParameter("@saldo", this.saldo));
                consulta.Parameters.Add(new SqlParameter("@ccliente", this.codcliente));
                consulta.Parameters.Add(new SqlParameter("@clocal", this.codlocal));
                consulta.Parameters.Add(new SqlParameter("@estado", this.estado));
                consulta.Parameters.Add(new SqlParameter("@periodo", this.periodo));
                consulta.Parameters.Add(new SqlParameter("@nlocal", this.numlocal));
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
        #region Método para actualizar saldo
        //Método para actualizar saldo
        public bool ActualizarSaldo(int periodo, string codcliente)
        {
            try
            {
                SqlConnection miconexion = Consultas.conectarPrincipal();
                miconexion.Open();
                SqlCommand consulta = new SqlCommand("UPDATE CODIGO_INGRESO SET SALDO = @C_SALDO where periodo = @periodo and cod_cliente = @cliente", miconexion);
                consulta.Parameters.Add(new SqlParameter("@C_SALDO", this.saldo));
                consulta.Parameters.Add(new SqlParameter("@periodo", periodo));
                consulta.Parameters.Add(new SqlParameter("@cliente", codcliente));
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
