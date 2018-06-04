using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainWindows
{
    public partial class PB : Form
    {
        #region Singleton
        private static PB frm = null;
        public static PB Instance()
        {

            if (frm == null)
            {
                frm = new PB();
            }
            return frm;
        }
        #endregion
        public PB()
        {
            InitializeComponent();
        }
    }
}
