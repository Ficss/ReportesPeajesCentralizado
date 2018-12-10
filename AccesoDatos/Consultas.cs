using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AccesoDatos
{
    public class Consultas
    {
        #region Métodos para Briceño
        #region Conexión a la BD Briceño
        public static SqlConnection conectarBriceno()
        {
            SqlConnection miconexion = new SqlConnection("Data Source=PBRICEÑO-PC;Initial Catalog=peajeM;Persist Security Info=True; User ID=sa;Password=Vegam123");
            return miconexion;
        }
        #endregion
        #endregion
        #region Métodos para Principal
        #region Conexión a la BD Principal
        public static SqlConnection conectarPrincipal()
        {
            SqlConnection miconexion = new SqlConnection("Data Source=principal-pc;Initial Catalog=peajeM; User ID=sa;Password=Vegam123");
            return miconexion;
        }
        #endregion
        #region Método para obtener nombre cajero con el turno
        //Método para obtener nombre cajero con el turno
        //public string obtenerNombre(string turno)
        //{
        //    string nombre = null;
        //    SqlConnection miconexion = conectarPrincipal();
        //    miconexion.Open();
        //    SqlCommand cmd = new SqlCommand("SELECT  " +
        //                                    "FROM Usuario " +
        //                                    "WHERE CL.RUT = C.cod_cliente " +
        //                                    "AND C.COD_CLIENTE = @rut", miconexion);
        //    cmd.Parameters.Add(new SqlParameter("@rut", turno));
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        nombre = dr.GetString(0);
        //    }
        //    miconexion.Close();
        //    return nombre;
        //}
        #endregion
        #endregion
        #region Métodos para Orella
        #region Conexión a la BD Orella
        public static SqlConnection conectarOrella()
        {
            SqlConnection miconexion = new SqlConnection("Data Source=peajeorella-pc;Initial Catalog=peajeM;User ID=sa;Password=Vegam123");
            return miconexion;
        }
        #endregion
        #endregion
        #region Método para llenar gridview de clientes en Registro clientes
        //Método para llenar gridview de clientes en Registro clientes
        public DataTable llenarTablaClientes()
        {
            SqlConnection miconexion = conectarPrincipal();
            miconexion.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT dbo.Fn_FormatearRut( cast(C.RUT as varchar) + cast(C.DIG as varchar)) as RUT, rtrim( LTRIM( C.RAZON)) AS RAZON, L.NUMERO AS NLOCAL, I.IDLOCAL CLOCAL, I.ESTADO  " +
                                            "FROM CLIENTES C, CLIENCAR I, LOCAL L " +
                                            "WHERE I.RUT = C.RUT " +
                                            "AND L.IDLOCAL = I.IDLOCAL " +
                                            "ORDER BY C.RAZON ASC, I.IDLOCAL ASC", miconexion);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt.Load(dr);
            }
            miconexion.Close();
            return dt;
        }
        #endregion
        #region Método para llenar gridview de codigos generados en registro cliente

        //Método para llenar gridview de codigos generados en registro cliente
        public DataTable llenarTablaRegistroClientes(string numlocal)
        {
            SqlConnection miconexion = conectarPrincipal();
            miconexion.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT NUM_LOCAL AS NUMLOCAL, PERIODO, CANTIDAD AS CANTCODIGOS, SALDO " +
                                            "FROM CODIGO_INGRESO " +
                                            "WHERE num_local = @numlocal ", miconexion);
            cmd.Parameters.Add(new SqlParameter("@numlocal", numlocal));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt.Load(dr);
            }
            miconexion.Close();
            return dt;
        }
        #endregion
        #region Método para llenar gridview de codigos generados en registro cliente
        //Método para llenar gridview de codigos generados en registro cliente
        public DataTable llenarTablaRegistroClientesFiltrado(string numlocal, string periodo)
        {
            SqlConnection miconexion = conectarPrincipal();
            miconexion.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT NUM_LOCAL AS NUMLOCAL, PERIODO, CANTIDAD AS CANTCODIGOS, SALDO " +
                                            "FROM CODIGO_INGRESO " +
                                            "WHERE num_local = @numlocal " +
                                            "AND periodo LIKE @periodo + '%'", miconexion);
            cmd.Parameters.Add(new SqlParameter("@numlocal", numlocal));
            cmd.Parameters.Add(new SqlParameter("@periodo", periodo));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt.Load(dr);
            }
            miconexion.Close();
            return dt;
        }
        #endregion
        #region Método para llenar gridview de codigos generados en registro cliente
        //Método para llenar gridview de codigos generados en registro cliente
        public DataTable llenarTablaDetalleCodigos(string numlocal, int periodo)
        {
            SqlConnection miconexion = conectarPrincipal();
            miconexion.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT I.NUM_INGRESO as NINGRESO, cast(I.FECHA as varchar) + ' ' + cast(CONVERT(VARCHAR(8), I.HORA, 8) as varchar) AS FH, T.NOMBRE_TURNO AS TINGRESO " +
                                            "FROM ingreso_codigos I, turnos T " +
                                            "WHERE I.cod_turno = T.cod_turno " +
                                            "AND I.num_local = @numlocal " +
                                            "AND I.periodo = @periodo ", miconexion);
            cmd.Parameters.Add(new SqlParameter("@numlocal", numlocal));
            cmd.Parameters.Add(new SqlParameter("@periodo", periodo));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt.Load(dr);
            }
            miconexion.Close();
            return dt;
        }
        #endregion
        #region Método para llenar gridview de clientes en Codigos de Ingreso
        //Método para llenar gridview de clientes en Codigos de Ingreso
        public DataTable llenarTablaClientesCI()
        {
            SqlConnection miconexion = conectarPrincipal();
            miconexion.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT dbo.Fn_FormatearRut( cast(C.RUT as varchar) + cast(C.DIG as varchar)) as RUT, rtrim( LTRIM( C.RAZON)) AS RAZON, L.NUMERO AS NLOCAL  " +
                                            "FROM CLIENTES C, CLIENCAR I, LOCAL L " +
                                            "WHERE I.RUT = C.RUT " +
                                            "AND L.IDLOCAL = I.IDLOCAL " +
                                            "ORDER BY C.RAZON ASC, I.IDLOCAL ASC", miconexion);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt.Load(dr);
            }
            miconexion.Close();
            return dt;
        }
        #endregion
        #region Método para llenar gridview de codigos generados en registro cliente
        //Método para llenar gridview de codigos generados en registro cliente
        public DataTable llenarTablaClientesResultado(int rut)
        {
            SqlConnection miconexion = conectarPrincipal();
            miconexion.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT rtrim( LTRIM(CL.RAZON)) AS RAZON, C.NUM_LOCAL AS NLOCAL, C.CANTIDAD AS CCODIGOS, C.SALDO AS CRESTANTES, C.PERIODO AS PERIODO " +
                                            "FROM CODIGO_INGRESO C, CLIENTES CL " +
                                            "WHERE CL.RUT = C.cod_cliente " +
                                            "AND C.COD_CLIENTE = @rut", miconexion);
            cmd.Parameters.Add(new SqlParameter("@rut", rut));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt.Load(dr);
            }
            miconexion.Close();
            return dt;
        }
        #endregion
        #region Método que valida el rut ingresado en el campo de texto RUT
        //Método que valida el rut ingresado en el campo de texto RUT
        //Usado para crear clientes
        public bool validarRut(string rut)
        {
            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));
                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));
                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return validacion;
        }
        #endregion
        #region Formatear Rut
        public String formatear(String rut)
        {
            int cont = 0;
            String format;
            if (rut.Length == 0)
            {
                return "";
            }
            else
            {
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                format = "-" + rut.Substring(rut.Length - 1);
                for (int i = rut.Length - 2; i >= 0; i--)
                {
                    format = rut.Substring(i, 1) + format;
                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        format = "." + format;
                        cont = 0;
                    }
                }
                return format;
            }
        }
        #endregion
    }
}
