using CapstonePRN292._3._Data_Layer;
using CapstonePRN292.DBHelper;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Windows.Forms;

namespace CapstonePRN292
{
    public partial class AdminX : DevExpress.XtraEditors.XtraForm
    {
        DBConnection B = new DBConnection();
        DataTable dtBike;
        public AdminX()
        {
            InitializeComponent();
            loadBikeList();
            loadCategoryList();
            loadCompanyList();
            loadAccountList();
        }

        private void loadBikeList()
        {
            string sql = "SELECT dbo.Bike.id AS [ID]," +
                "dbo.Bike.name AS [Name]," +
                "dbo.BikeCategory.name AS [Category]," +
                "dbo.Bike.price AS [Price]," +
                "dbo.Company.name AS [Company]," +
                "dbo.Bike.version AS [Version]," +
                "dbo.Bike.cc AS [CC] " +
                "FROM dbo.Bike, dbo.Company, dbo.BikeCategory " +
                "WHERE dbo.Bike.idCategory = dbo.BikeCategory.id " +
                "AND dbo.Bike.idCompany = dbo.Company.id";
            DBConnection connection = new DBConnection();
            dgvBike.DataSource = connection.dataTable(sql);
        }

        private void loadCategoryList()
        {
            string sql = "SELECT id AS [ID]," +
                "name AS [Type] " +
                "FROM dbo.BikeCategory";
            DBConnection connection = new DBConnection();
            dgvCategory.DataSource = connection.dataTable(sql);
        }

        private void loadCompanyList()
        {
            string sql = "SELECT id AS [ID]," +
                "name AS [Company Name] " +
                "FROM Company";
            DBConnection connection = new DBConnection();
            dgvCompany.DataSource = connection.dataTable(sql);
        }

        private void loadAccountList()
        {
            //string query = "EXEC dbo.USP_GetAccountByUserName @username";
            //DBConnection provider = new DBConnection();
            //dgvAccount.DataSource = provider.ExecuteQuery(query, new object[] { "sa" });

            string sql = "SELECT username AS [Username], " +
                "fullname AS [Full Name], " +
                "isAdmin AS [Admin] " +
                "FROM Account";
            DBConnection connection = new DBConnection();
            dgvAccount.DataSource = connection.dataTable(sql);
        }

        private void dgvBike_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvBike.Rows[e.RowIndex];
                txtIDB.Text = row.Cells[0].Value.ToString();
                txtNameB.Text = row.Cells[1].Value.ToString();
                txtCategoryB.Text = row.Cells[2].Value.ToString();
                txtPriceB.Text = row.Cells[3].Value.ToString();
                txtCompanyB.Text = row.Cells[4].Value.ToString();
                txtVersionB.Text = row.Cells[5].Value.ToString();
                txtCCB.Text = row.Cells[6].Value.ToString();

            }
        }

        private void getAllBike()
        {
            dtBike = B.getBike();
            txtIDB.DataBindings.Clear();
            txtNameB.DataBindings.Clear();
            dgvBike.DataSource = dtBike;
        }


        private void btnAddB_Click(object sender, System.EventArgs e)
        {
            string Name = txtNameB.Text;
            int Category = int.Parse(txtCategoryB.Text);
            float Price = float.Parse(txtPriceB.Text);
            int Company = int.Parse(txtCompanyB.Text);
            int Version = int.Parse(txtVersionB.Text);
            int CC = int.Parse(txtCCB.Text);

            Bike b = new Bike
            {
                NameB = Name,
                CategoryB = Category,
                PriceB = Price,
                CompanyB = Company,
                VersionB = Version,
                CCB = CC
            };
            bool r = B.addNewBike(b);
            string s = (r == true ? "successful" : "fail");
            MessageBox.Show("Add " + s);
            getAllBike();
        }
    }
}