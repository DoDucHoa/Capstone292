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
using CapstonePRN292._1._Form_Layer;
using CapstonePRN292._2._Business_Layer;

namespace CapstonePRN292
{
    public partial class DepotX : DevExpress.XtraEditors.XtraForm
    {
        string username;
        public DepotX(string username)
        {
            this.username = username;
            InitializeComponent();
            loadCustomerTable();
            loadBikeTable();
            loadComboBox();
        }

        void loadDepot()
        {

        }

        private void DepotX_Load(object sender, EventArgs e)
        {

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isAdmin = DepotDAO.isAdmin(username);
            if (isAdmin)
            {
                AdminX fr = new AdminX();
                fr.ShowDialog();
            }
            else
            {
                MessageBox.Show("You don't have permit to access this!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            string sql = "SELECT name AS [Full Name]," +
                "email AS [Email]," +
                "address AS [Address]," +
                "birth AS [Birth] " +
                "FROM dbo.Customer";
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

        private void accountsInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCustomer fr = new AddCustomer();
            fr.ShowDialog();
            loadCustomerTable();
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvCustomer.Rows[e.RowIndex];
                txtCusname.Text = row.Cells[0].Value.ToString();
                txtAddress.Text = row.Cells[2].Value.ToString();
            }
        }

        private void dgvBike_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvBike.Rows[e.RowIndex];
                txtBikeName.Text = row.Cells[0].Value.ToString();
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            string cusName = txtCusname.Text;
            string bikeName = txtBikeName.Text;
        }

        private void loadComboBox()
        {
            string sql_paymethod = "SELECT method " +
                "FROM PaymentMethod";
            DBConnection connection = new DBConnection();
            cbPayment.DataSource = connection.dataTable(sql_paymethod);
            cbPayment.DisplayMember = "method";
        }
    }
}