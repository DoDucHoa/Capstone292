using CapstonePRN292._3._Data_Layer;
using CapstonePRN292.DBHelper;
using DevExpress.XtraReports.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstonePRN292._2._Business_Layer
{
    public class DepotDAO
    {
        private static DepotDAO instance;

        public static DepotDAO Instance
        {
            get { if (instance == null) instance = new DepotDAO(); return DepotDAO.instance; }
            private set { DepotDAO.instance = value; }
        }

        public DepotDAO() { }

        public void loadUserToDatabase(string fullname, string email, string address, string birth)
        {
            string sql = "INSERT INTO Customer " +
                "VALUES (@name," +
                "@email," +
                "@address," +
                "@birth)";
            DBConnection dBConnection = new DBConnection();
            dBConnection.createUser(sql, fullname, email, address, birth);
        }
    }
}
