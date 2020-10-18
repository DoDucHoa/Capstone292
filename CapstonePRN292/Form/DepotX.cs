using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CapstonePRN292
{
    public partial class DepotX : DevExpress.XtraEditors.XtraForm
    {
        public DepotX()
        {
            InitializeComponent();
        }

        private void DepotX_Load(object sender, EventArgs e)
        {

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminX fr = new AdminX();
            fr.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DepotX_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to log out ?", "Notify", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}