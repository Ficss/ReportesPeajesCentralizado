﻿using ComponentFactory.Krypton.Toolkit;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportesPeajes;
using ReportesPrincipal;
using ReportesBriceno;
using ReportesMayo;
using ReportesManga;
using ReportesSitioCero;
using Squirrel;
using System.Net;
using AccesoDatos;
using System.Data.SqlClient;
using System.Configuration;
using ReportesOrellaDos;
using ReporteCajaDerecha;
using ReporteCajaIzquierda;
using ReportesSantaIsabel;
using ReportesCajaManual;
namespace MainWindows
{
    public partial class Padre : KryptonForm
    {
        #region Variables de inicialización
        ReportesPeajeOrella po;
        ReportesPeajePrincipal pp;
        ReportesPeajeBriceno pb;
        ReportesPeajeMayo pm;
        ReportesPeajeManga pma;
        ReportesPeajeSitioCero sc;
        ReportesPeajeOrellaDos pod;
        ReportesCajaDerecha rcd;
        ReportesCajaIzquierda rci;
        ReportesCajaSantaIsabel rsi;
        FormReportesCajaManual rcm;
        CodigosIngreso ci;
        RegistroClientes rc;
        AboutBox1 ab;
        #endregion
        #region Constructor por defecto
        public Padre()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            InitializeComponent();
            CheckForUpdate();
            string pc = Environment.MachineName;
            if (pc.Equals("HRIQUELME-NTBK"))
            {
                lblClientes.Visible = true;
                lblCodigos.Visible = true;
            }
            else if (pc.Equals("DESARROLLO-NTBK"))
            {
                lblClientes.Visible = true;
                lblCodigos.Visible = true;
            }
            else
            {
                lblClientes.Visible = false;
                lblCodigos.Visible = false;
            }
        }
        #endregion
        #region Cambiar Visibilidad barra de estado
        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }
        #endregion
        #region Ordenar ventanas en cascada
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        #endregion
        #region Ordenar ventanas en vertical
        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        #endregion
        #region Ordenar ventanas en horizontal
        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        #endregion
        #region Ordenar por icono
        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        #endregion
        #region Cerrar formularios activoss
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        #endregion
        #region Cambiar color de tema
        //private void kryptonLinkLabel4_LinkClicked(object sender, EventArgs e)
        //{
        //    Random r = new Random();
        //    int random = r.Next(0, 10);
        //    kryptonManager1.GlobalPaletteMode = (PaletteModeManager)Convert.ToInt32(random);
        //}
        #endregion
        #region Método de verificación de actualizaciones
        private async void CheckForUpdate()
        {
            try
            {
                using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/Ficss/ReportesPeajesCentralizado"))
                {
                    try
                    {
                        var updateInfo = await mgr.CheckForUpdate();
                        if (updateInfo.ReleasesToApply.Any())
                        {
                            var versionCount = updateInfo.ReleasesToApply.Count;
                            MessageBox.Show($"{versionCount} actualización encontrada");
                            var versionWord = versionCount > 1 ? "versiones" : "version";
                            var message = new StringBuilder().AppendLine($"La aplicación está {versionCount} {versionWord} detrás.").
                                                              AppendLine("Si elige actualizar, los cambios no tomarán efectos hasta que la aplicación no sea reiniciada.").
                                                              AppendLine("¿Desea descargar e instalar la actualización?").
                                                              AppendLine("Ante cualquier duda llamar al anexo 219 o 220").
                                                              ToString();
                            var result = MessageBox.Show(message, "¿Actualizar Aplicación?", MessageBoxButtons.YesNo);
                            if (result != DialogResult.Yes)
                            {
                                notificacion("Actualización rechazada por el usuario");
                                return;
                            }
                            notificacion("Descargando actualización");
                            //var updateSize = ByteSize.FromBytes(updateInfo.FutureReleaseEntry.Filesize);
                            var updateResult = await mgr.UpdateApp();

                            notificacion($"Descarga completa. Versión {updateResult.Version} tomará efecto cuando la aplicación sea reiniciada.");
                        }
                        else
                        {
                            notificacionInicio.BalloonTipIcon = ToolTipIcon.Info;
                            notificacionInicio.BalloonTipTitle = "Sistema Reportes Peajes";
                            notificacionInicio.BalloonTipText = "No hay actualizaciones pendientes";
                            notificacionInicio.ShowBalloonTip(5000);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"¡Hubo un problema durante el proceso de actualización! {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message + Environment.NewLine;
                if (ex.InnerException != null)
                    message += ex.InnerException.Message;
                MessageBox.Show(message);
            }
        }
        #endregion
        #region Load
        private void Padre_Load(object sender, EventArgs e)
        {
            Principal();
            Orella();
            OrellaDos();
            Briceno();
            Mayo();
            Sitiocero();
        }
        #endregion
        #region Abrir aboutbox
        private void acercaDeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ab = AboutBox1.Instance();
            //ab.MdiParent = this;
            ab.StartPosition = FormStartPosition.CenterScreen;
            ab.WindowState = FormWindowState.Normal;
            ab.Show();
            ab.Activate();
        }
        #endregion
        #region Salir del sistema
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #region Abrir aboutbox
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ab = AboutBox1.Instance();
            //ab.MdiParent = this;
            ab.StartPosition = FormStartPosition.CenterScreen;
            ab.WindowState = FormWindowState.Normal;
            ab.Show();
            ab.Activate();
        }
        #endregion
        #region Abrir índice (incompleto)
        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Comprobar actualizaciones
        private void comprobarActualizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForUpdate();
        }
        #endregion
        #region Abrir reportes orella

        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
        {
            po = ReportesPeajeOrella.Instance();
            po.MdiParent = this;
            po.WindowState = FormWindowState.Normal;
            po.Show();
            po.WindowState = FormWindowState.Maximized;
            po.Show();
            po.Activate();
        }
        #endregion
        #region Abrir reportes orella dos
        private void kryptonLinkLabel3_LinkClicked(object sender, EventArgs e)
        {
            pod = ReportesPeajeOrellaDos.Instance();
            pod.MdiParent = this;
            pod.WindowState = FormWindowState.Normal;
            pod.Show();
            pod.WindowState = FormWindowState.Maximized;
            pod.Show();
            pod.Activate();
        }
        #endregion
        #region Abrir reportes principal
        private void kryptonLinkLabel7_LinkClicked(object sender, EventArgs e)
        {
            pp = ReportesPeajePrincipal.Instance();
            pp.MdiParent = this;
            pp.WindowState = FormWindowState.Normal;
            pp.Show();
            pp.WindowState = FormWindowState.Maximized;
            pp.Show();
            pp.Activate();
        }
        #endregion
        #region Abrir reportes briceño
        private void kryptonLinkLabel10_LinkClicked(object sender, EventArgs e)
        {
            pb = ReportesPeajeBriceno.Instance();
            pb.MdiParent = this;
            pb.WindowState = FormWindowState.Normal;
            pb.Show();
            pb.WindowState = FormWindowState.Maximized;
            pb.Show();
            pb.Activate();
        }
        #endregion
        #region Abrir reportes mayo
        private void kryptonLinkLabel11_LinkClicked(object sender, EventArgs e)
        {
            pm = ReportesPeajeMayo.Instance();
            pm.MdiParent = this;
            pm.WindowState = FormWindowState.Normal;
            pm.Show();
            pm.WindowState = FormWindowState.Maximized;
            pm.Show();
            pm.Activate();
        }
        #endregion
        #region Abrir reportes manga
        private void kryptonLinkLabel5_LinkClicked(object sender, EventArgs e)
        {
            pma = ReportesPeajeManga.Instance();
            pma.MdiParent = this;
            pma.WindowState = FormWindowState.Normal;
            pma.Show();
            pma.WindowState = FormWindowState.Maximized;
            pma.Show();
            pma.Activate();
        }
        #endregion
        #region Abrir reportes sitio cero
        private void kryptonLinkLabel2_LinkClicked(object sender, EventArgs e)
        {
            sc = ReportesPeajeSitioCero.Instance();
            sc.MdiParent = this;
            sc.WindowState = FormWindowState.Normal;
            sc.Show();
            sc.WindowState = FormWindowState.Maximized;
            sc.Show();
            sc.Activate();
        }
        #endregion
        private void kryptonLinkLabel4_LinkClicked(object sender, EventArgs e)
        {
            rcd = ReportesCajaDerecha.Instance();
            rcd.MdiParent = this;
            rcd.WindowState = FormWindowState.Normal;
            rcd.Show();
            rcd.WindowState = FormWindowState.Maximized;
            rcd.Show();
            rcd.Activate();
        }

        private void kryptonLinkLabel8_LinkClicked(object sender, EventArgs e)
        {
            rci = ReportesCajaIzquierda.Instance();
            rci.MdiParent = this;
            rci.WindowState = FormWindowState.Normal;
            rci.Show();
            rci.WindowState = FormWindowState.Maximized;
            rci.Show();
            rci.Activate();
        }

        private void kryptonLinkLabel9_LinkClicked(object sender, EventArgs e)
        {
            rsi = ReportesCajaSantaIsabel.Instance();
            rsi.MdiParent = this;
            rsi.WindowState = FormWindowState.Normal;
            rsi.Show();
            rsi.WindowState = FormWindowState.Maximized;
            rsi.Show();
            rsi.Activate();
        }

        private void kryptonLinkLabel6_LinkClicked(object sender, EventArgs e)
        {
            rcm = FormReportesCajaManual.Instance();
            rcm.MdiParent = this;
            rcm.WindowState = FormWindowState.Normal;
            rcm.Show();
            rcm.WindowState = FormWindowState.Maximized;
            rcm.Show();
            rcm.Activate();
        }
        #region Abrir formulario de registro códigos de ingreso
        private void lblCodigos_LinkClicked(object sender, EventArgs e)
        {
            ci = CodigosIngreso.Instance();
            ci.MdiParent = this;
            ci.WindowState = FormWindowState.Normal;
            ci.Show();
            ci.WindowState = FormWindowState.Maximized;
            ci.Show();
            ci.Activate();
        }
        #endregion
        #region Abrir formulario de registro clientes
        private void lblClientes_LinkClicked(object sender, EventArgs e)
        {
            rc = RegistroClientes.Instance();
            rc.MdiParent = this;
            rc.WindowState = FormWindowState.Normal;
            rc.Show();
            rc.WindowState = FormWindowState.Maximized;
            rc.Show();
            rc.Activate();
        }
        #endregion
        #region Inicialización de notificación
        public void notificacion(string mensaje)
        {
            notificacionInicio.BalloonTipIcon = ToolTipIcon.Info;
            notificacionInicio.BalloonTipTitle = "Actualización Disponible";
            notificacionInicio.BalloonTipText = mensaje;
            notificacionInicio.ShowBalloonTip(5000);
        }
        #endregion
        #region MyRegion
        private void button2_Click(object sender, EventArgs e)
        {
            Principal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Orella();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Briceno();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mayo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sitiocero();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            OrellaDos();
        }
        #endregion
        #region Métodos para comprobar conexion y actualizar label - Peaje principal
        private void Principal()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PP"].ConnectionString);
            if (Prueba.QuickOpen(con, 600) == true)
            {
                pbPrincipal.Image = Properties.Resources.icons8_system_information;
                kryptonLinkLabel7.Text = "Reportes peaje principal";
            }
            else
            {
                pbPrincipal.Image = Properties.Resources.icons8_no_network;
                kryptonLinkLabel7.Text = "Reportes peaje principal - [No conectado]";
            }
        }
        #endregion
        #region Métodos para comprobar conexion y actualizar label - Peaje orella
        private void Orella()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PO"].ConnectionString);
            if (Prueba.QuickOpen(con, 600) == true)
            {
                pbOrella.Image = Properties.Resources.icons8_system_information;
                kryptonLinkLabel1.Text = "Reportes peaje Orella";
            }
            else
            {
                pbOrella.Image = Properties.Resources.icons8_no_network;
                kryptonLinkLabel1.Text = "Reportes peaje Orella - [No conectado]";
            }
        }
        #endregion
        #region Métodos para comprobar conexion y actualizar label - Peaje orella dos
        private void OrellaDos()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["OD"].ConnectionString);
            if (Prueba.QuickOpen(con, 600) == true)
            {
                pbOD.Image = Properties.Resources.icons8_system_information;
                kryptonLinkLabel3.Text = "Reportes peaje Orella dos";
            }
            else
            {
                pbOD.Image = Properties.Resources.icons8_no_network;
                kryptonLinkLabel3.Text = "Reportes peaje Orella dos - [No conectado]";
            }
        }
        #endregion
        #region Métodos para comprobar conexion y actualizar label - Peaje briceño
        private void Briceno()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PB"].ConnectionString);
            if (Prueba.QuickOpen(con, 1000) == true)
            {
                pbBriceno.Image = Properties.Resources.icons8_system_information;
                kryptonLinkLabel10.Text = "Reportes peaje Briceño";
            }
            else
            {
                pbBriceno.Image = Properties.Resources.icons8_no_network;
                kryptonLinkLabel10.Text = "Reportes peaje Briceño - [No conectado]";
            }
        }
        #endregion
        #region Métodos para comprobar conexion y actualizar label - Peaje mayo
        private void Mayo()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PM"].ConnectionString);
            if (Prueba.QuickOpen(con, 600) == true)
            {
                pbMayo.Image = Properties.Resources.icons8_system_information;
                kryptonLinkLabel11.Text = "Reportes peaje 21 de mayo ";
            }
            else
            {
                pbMayo.Image = Properties.Resources.icons8_no_network;
                kryptonLinkLabel11.Text = "Reportes peaje 21 de mayo - [No conectado]";
            }
        }
        #endregion
        #region Métodos para comprobar conexion y actualizar label - Peaje sitio cero
        private void Sitiocero()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SC"].ConnectionString);
            if (Prueba.QuickOpen(con, 1000) == true)
            {
                pbSC.Image = Properties.Resources.icons8_system_information;
                kryptonLinkLabel2.Text = "Reporteas peaje sitio cero";
            }
            else
            {
                pbSC.Image = Properties.Resources.icons8_no_network;
                kryptonLinkLabel2.Text = "Reportes peaje sitio cero - [No conectado]";
            }
        }


        #endregion

        
    }
}
