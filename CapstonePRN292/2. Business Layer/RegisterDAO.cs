using CapstonePRN292.DBHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstonePRN292._2._Business_Layer
{
    class RegisterDAO
    {
        public void loadToDatabase(string username, string reEnter, string fullName, string email)
        {
            string sql = "INSERT INTO Account " +
                "VALUES (@username," +
                "@password," +
                "@fullname," +
                "@email," +
                "@isAdmin)";
            DBConnection dBConnection = new DBConnection();
            dBConnection.createAccount(sql, username, reEnter, fullName, email);
        }
    }
}
