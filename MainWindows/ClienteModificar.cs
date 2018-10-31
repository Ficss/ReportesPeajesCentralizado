using AccesoDatos;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;
namespace MainWindows
{
    public partial class ClienteModificar : KryptonForm
    {
        #region Inicialización de variables
        Padre p;
        #endregion
        #region Constructor por defecto
        public ClienteModificar()
        {
            InitializeComponent();
        }
        #endregion
        #region Singleton
        //Singleton
        private static ClienteModificar frm = null;
        public static ClienteModificar Instance()
        {

            if (frm == null)
            {
                frm = new ClienteModificar();
            }
            return frm;
        }
        #endregion
        #region Confirmación de modificación de cliente
        private void btnModificar_Click(object sender, EventArgs e)
        {
            CLIENTE c = new CLIENTE();
            string rut = lblMRut.Text;
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
            try
            {
                if (txtMDireccion.Text.Length == 0)
                {
                    KryptonMessageBox.Show("CAMPO DE DIRECCIÓN ESTA VACÍO", "MENSAJE DE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtMRazon.Text.Length == 0)
                    {
                        KryptonMessageBox.Show("CAMPO RAZÓN ESTA VACÍO", "MENSAJE DE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        if (txtMGiro.Text.Length == 0)
                        {
                            MessageBox.Show("CAMPO DE GIRO ESTA VACÍO", "MENSAJE DE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            //Dirección
                            c.direccion = txtMDireccion.Text;
                            //Giro
                            c.giro = txtMGiro.Text;
                            //Razon
                            c.razon = txtMRazon.Text;
                            if (c.ModificarCliente(rutsindv, dv))
                            {
                                MessageBox.Show(txtMRazon.Text + " Modificado");
                                lblMRut.ResetText();
                                txtMDireccion.Clear();
                                txtMGiro.Clear();
                                txtMRazon.Clear();
                                p = (Padre)this.MdiParent;
                                RegistroClientes rc = null;
                                rc = RegistroClientes.Instance();
                                rc.MdiParent = p;
                                rc.Show();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Limpiar campos de texto
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtMRazon.Clear();
            this.txtMDireccion.Clear();
            this.txtMGiro.Clear();
        }
        #endregion
        #region Abrir formulario registro clientes el cerrar formulario modificar clientes
        private void ClienteModificar_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
