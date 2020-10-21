using CapstonePRN292.DBHelper;

namespace CapstonePRN292
{
    public partial class AdminX : DevExpress.XtraEditors.XtraForm
    {
        public AdminX()
        {
            InitializeComponent();
            loadAccountList();
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