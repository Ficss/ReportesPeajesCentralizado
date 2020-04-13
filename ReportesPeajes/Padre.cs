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

namespace ReportesPeajes
{
    public partial class Padre : KryptonForm
    {
        ReportesPeajeOrella po = null;

        private int childFormNumber = 0;

        public Padre()
        {
            InitializeComponent();
        }
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
    }
}
