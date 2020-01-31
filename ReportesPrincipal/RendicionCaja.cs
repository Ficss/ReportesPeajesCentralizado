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

namespace ReportesPrincipal
{
    public partial class RendicionCaja : KryptonForm
    {

        #region Singleton
        private static RendicionCaja frm = null;
        public static RendicionCaja Instance()
        {
            if (frm == null)
            {
                frm = new RendicionCaja();
            }
            return frm;
        }
        #endregion
        public RendicionCaja()
        {
            InitializeComponent();
            lblFecha.Text = $"Fecha: {DateTime.Now.ToShortDateString()}";
        }

        private void RendicionCaja_Load(object sender, EventArgs e)
        {


        }
    }
}
