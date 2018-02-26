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

        }

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
    }
}
