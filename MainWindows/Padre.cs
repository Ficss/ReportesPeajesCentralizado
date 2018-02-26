using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReportesPeajes;
using ReportesPrincipal;
using Squirrel;

namespace MainWindows
{
    public partial class Padre : KryptonForm
    {
        #region Variables de inicialización
        ReportesPeajeOrella po;
        ReportesPeajePrincipal pp;
        AboutBox1 ab;
        #endregion
        #region Constructor por defecto
        public Padre()
        {
            InitializeComponent();
        }
        #endregion

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

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

        private void kryptonLinkLabel4_LinkClicked(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 10);
            kryptonManager1.GlobalPaletteMode = (PaletteModeManager)Convert.ToInt32(random);
        }

        private void Padre_Load(object sender, EventArgs e)
        {
            CheckForUpdate();
        }

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
        private void acercaDeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ab = AboutBox1.Instance();
            //ab.MdiParent = this;
            ab.StartPosition = FormStartPosition.CenterScreen;
            ab.WindowState = FormWindowState.Normal;
            ab.Show();
            ab.Activate();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ab = AboutBox1.Instance();
            //ab.MdiParent = this;
            ab.StartPosition = FormStartPosition.CenterScreen;
            ab.WindowState = FormWindowState.Normal;
            ab.Show();
            ab.Activate();
        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comprobarActualizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForUpdate();
        }
    }
}
