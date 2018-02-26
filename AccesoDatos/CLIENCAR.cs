using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AccesoDatos
{
    public class CLIENCAR
    {
        #region Atributo
        public int estado { get; set; }
        #endregion
        #region Método para desactivar cliente
        //MÉTODO PARA DESACTIVAR CLIENTE
        //Fecha creación 07/09/17
        //nrut= número rut sin dígito verificador
        public bool desactivarCliente(string nrut)
        {
            try
            {
                SqlConnection miconexion = Consultas.conectarPrincipal();
                miconexion.Open();
                SqlCommand consulta = new SqlCommand("UPDATE CLIENCAR SET ESTADO= :U_ESTADO WHERE RUT = @nrut ", miconexion);
                consulta.Parameters.Add(new SqlParameter("@U_ESTADO", this.estado));
                consulta.Parameters.Add(new SqlParameter("@nrut", nrut));
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
