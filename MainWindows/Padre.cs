using ComponentFactory.Krypton.Toolkit;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportesPeajes;
using ReportesPrincipal;
using ReportesBriceno;
using Squirrel;

namespace MainWindows
{
    public partial class Padre : KryptonForm
    {
        #region Variables de inicialización
        ReportesPeajeOrella po;
        ReportesPeajePrincipal pp;
        ReportesPeajeBriceno pb;
        AboutBox1 ab;
        #endregion
        #region Constructor por defecto
        public Padre()
        {
            InitializeComponent();
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
        private void kryptonLinkLabel4_LinkClicked(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 10);
            kryptonManager1.GlobalPaletteMode = (PaletteModeManager)Convert.ToInt32(random);
        }
        #endregion
        #region Método de verificación de actualizaciones
        private async void CheckForUpdate()
        {
            try
            {
                using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/Ficss/ReportesPeajesCentralizado"))
                {
                    //this.logger.Info("Checking for updates");
                    try
                    {
                        var updateInfo = await mgr.CheckForUpdate();

                        if (updateInfo.ReleasesToApply.Any())
                        {
                            var versionCount = updateInfo.ReleasesToApply.Count;
                            MessageBox.Show($"{versionCount} actualización encontrada");
                            //this.logger.Info($"{versionCount} update(s) found.");
                            var versionWord = versionCount > 1 ? "versions" : "version";
                            var message = new StringBuilder().AppendLine($"La aplicación está {versionCount} {versionWord} detrás.").
                                                              AppendLine("Si elige actualizar, los cambios no tomarán efectos hasta que la aplicación no sea reiniciada.").
                                                              AppendLine("¿Desea descargar e instalar la actualización?").
                                                              AppendLine("Ante cualquier duda llamar al anexo 219 o 220").
                                                              ToString();

                            var result = MessageBox.Show(message, "¿Actualizar Aplicación?", MessageBoxButtons.YesNo);
                            //var result = MessageBox.Show(message, "App Update", MessageBoxButton.YesNo);
                            if (result != DialogResult.Yes)
                            {
                                MessageBox.Show("Actualización rechazada por el usuario");
                                //this.logger.Info("update declined by user.");
                                return;
                            }
                            MessageBox.Show("Descargando actualización", "Actualización en curso");
                            //this.logger.Info("Downloading updates");
                            var updateResult = await mgr.UpdateApp();
                            MessageBox.Show($"Descarga completa. Versión {updateResult.Version} tomará efecto cuando la aplicación sea reiniciada.");
                            //this.logger.Info($"Download complete. Version {updateResult.Version} will take effect when App is restarted.");

                        }
                        else
                        {
                            //this.logger.Info("No updates detected.");
                            MessageBox.Show("No hay actualizaciones pendientes");
                        }
                    }
                    catch (Exception ex)
                    {
                        //this.logger.Warn($"There was an issue during the update process! {ex.Message}");
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
            CheckForUpdate();
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
    }
}
