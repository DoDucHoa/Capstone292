using CapstonePRN292.DBHelper;

namespace CapstonePRN292
{
    public partial class AdminX : DevExpress.XtraEditors.XtraForm
    {
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
    }
}