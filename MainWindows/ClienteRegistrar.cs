using AccesoDatos;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;

namespace MainWindows
{
    public partial class ClienteRegistrar : KryptonForm
    {
        #region Inicialización de variables
        Padre p;
        Consultas s = new Consultas();
        #endregion
        #region Constructor por defecto
        public ClienteRegistrar()
        {
            InitializeComponent();
        }
        #endregion
        #region Singleton
        //Singleton
        private static ClienteRegistrar frm = null;
        public static ClienteRegistrar Instance()
        {

            if (frm == null)
            {
                frm = new ClienteRegistrar();
            }
            return frm;
        }
        #endregion
        #region Limpiar campos de texto
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtRazon.Clear();
            this.txtDireccion.Clear();
            this.txtGiro.Clear();
        }
        #endregion
        #region Abrir formulario registro clientes al cerrar formulario de creación de clientes
        private void ClienteRegistrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            p = (Padre)this.MdiParent;
            RegistroClientes rc = null;
            rc = RegistroClientes.Instance();
            rc.MdiParent = p;
            rc.Show();
            rc.Activate();
            rc.WindowState = FormWindowState.Maximized;
            this.Dispose();
        }
        #endregion
        #region Crear cliente
        private void btnCrear_Click(object sender, EventArgs e)
        {
            CLIENTE c = new CLIENTE();

            try
            {
                if (txtRut.Text.Length == 0)
                {
                    KryptonMessageBox.Show("CAMPO RUT ESTÁ VACÍO", "MENSAJE DE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtRazon.Text.Length == 0)
                    {
                        KryptonMessageBox.Show("CAMPO RAZÓN ESTÁ VACÍO", "MENSAJE DE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (txtGiro.Text.Length == 0)
                        {
                            KryptonMessageBox.Show("CAMPO GIRO ESTÁ VACÍO", "MENSAJE DE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            if (txtDireccion.Text.Length == 0)
                            {
                                KryptonMessageBox.Show("CAMPO DIRECCION ESTÁ VACÍO", "MENSAJE DE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                if (!s.validarRut(txtRut.Text))
                                {
                                    KryptonMessageBox.Show("RUT INGRESADO NO ES VÁLIDO", "MENSAJE DE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    string rut = txtRut.Text;
                                    string rutsindv = null;
                                    string dv = null;
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
                                    //Rut Cliente
                                    c.rut = Convert.ToInt32(rutsindv);
                                    //Dígito Verificador Cliente
                                    c.dv = dv;
                                    //Razón Cliente
                                    c.razon = txtRazon.Text;
                                    //Giro Cliente
                                    c.giro = txtGiro.Text;
                                    //Direccion
                                    c.direccion = txtDireccion.Text;
                                    //Seleccionar por defecto en 1
                                    c.seleccionar = 1;
                                    //Estado Cliente por defecto en 1 (Activo)
                                    c.estado = 1;
                                    if (c.CrearCliente())
                                    {
                                        MessageBox.Show("Cliente Creado");
                                        txtRut.ResetText();
                                        txtRazon.Clear();
                                        txtDireccion.Clear();
                                        txtGiro.Clear();
                                        p = (Padre)this.MdiParent;
                                        RegistroClientes rc = null;
                                        rc = RegistroClientes.Instance();
                                        rc.MdiParent = p;
                                        rc.Show();
                                        rc.WindowState = FormWindowState.Maximized;
                                        rc.Activate();
                                        this.Dispose();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error al guardar");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion
        #region Load
        private void ClienteRegistrar_Load(object sender, EventArgs e)
        {
            txtRut.Select();
        }
        #endregion
        #region Format rut
        private void txtRut_Leave(object sender, EventArgs e)
        {
            txtRut.Text = s.formatear(txtRut.Text);
        }
        #endregion
    }
}
