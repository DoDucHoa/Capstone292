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
using CapstonePRN292.DBHelper;

namespace CapstonePRN292
{
    public partial class DepotX : DevExpress.XtraEditors.XtraForm
    {
        public DepotX()
        {
            InitializeComponent();
            loadCustomerTable();
            loadBikeTable();
        }

        void loadDepot()
        {

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
    
        private void loadCustomerTable()
        {
            string sql = "SELECT dbo.Account.fullname AS [Full Name], " +
                "dbo.AccountInfo.age AS [Age], " +
                "dbo.AccountInfo.address AS [Address], " +
                "dbo.AccountInfo.birth AS [Birth] " +
                "FROM dbo.Account, dbo.AccountInfo " +
                "WHERE dbo.Account.username = dbo.AccountInfo.username " +
                "ORDER BY fullname";
            DBConnection connection = new DBConnection();
            dgvCustomer.DataSource = connection.dataTable(sql);
        }

        private void loadBikeTable()
        {
            string sql = "SELECT dbo.Bike.name AS [Name], " +
                "dbo.BikeCategory.name AS [Category], " +
                "price AS [Price], " +
                "dbo.Company.name AS [Company], " +
                "version AS [Version], " +
                "cc AS [CC] " +
                "FROM dbo.Bike, dbo.BikeCategory, dbo.Company " +
                "WHERE dbo.Bike.idCategory = dbo.BikeCategory.id " +
                "AND dbo.Bike.idCompany = dbo.Company.id";
            DBConnection connection = new DBConnection();
            dgvBike.DataSource = connection.dataTable(sql);
        }
    }
}