﻿using CapstonePRN292._3._Data_Layer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace CapstonePRN292.DBHelper
{
    public class DBConnection
    {
        string connectionString = @"Data Source=LAPTOP-4LFO15O4\TRINT;Initial Catalog=BikeSaleSystemDB;User ID=sa;password=12345";

        public DataTable dataTable(string sql)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString)) //using để auto giải phóng bộ nhớ khi kết thúc khối lệnh
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
                connection.Close();
            }
            return dataTable;
        }
        public bool checkLogin(string us, string pw)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string sql = "SELECT username," +
                                "password " +
                         "FROM Account " +
                         "WHERE username = '" + us + "'" + " COLLATE SQL_Latin1_General_CP1_CS_AS " +
                         "AND password = '" + pw + "'" + " COLLATE SQL_Latin1_General_CP1_CS_AS";

            // Tạo một đối tượng Command với 2 tham số: Command Text & Connection.
            SqlCommand cmd = new SqlCommand(sql, connection);
            //đọc sql
            SqlDataReader data = cmd.ExecuteReader();
            if (data.Read() == true)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }

        public void createAccount(string sql, string username, string reEnter, string fullName, string email)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("password", reEnter);
            command.Parameters.AddWithValue("fullname", fullName);
            command.Parameters.AddWithValue("email", email);
            command.Parameters.AddWithValue("isAdmin", false);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }

        public bool checkExistUsername(string username)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string sql = "SELECT username " +
                         "FROM Account " +
                         "WHERE username = '" + username + "'" + " COLLATE SQL_Latin1_General_CP1_CS_AS ";                

            // Tạo một đối tượng Command với 2 tham số: Command Text & Connection.
            SqlCommand cmd = new SqlCommand(sql, connection);
            //đọc sql
            SqlDataReader data = cmd.ExecuteReader();
            if (data.Read() == true)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }
        
        public DataTable getBike()
        {
            string sql = "select * from Bike";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dtBike = new DataTable();
            try
            {
                if(connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                adapter.Fill(dtBike);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                connection.Close();
            }
            return dtBike;
        }


        public bool addNewBike(Bike b)
        {
            string sql = "Insert Bike values(@Name,@Category,@Price,@Company,@Version,@CC)";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            //command.Parameters.AddWithValue("@ID", b.IDB);
            command.Parameters.AddWithValue("@Name", b.NameB);
            command.Parameters.AddWithValue("@Category", b.CategoryB);
            command.Parameters.AddWithValue("@Price", b.PriceB);
            command.Parameters.AddWithValue("@Company", b.CompanyB);
            command.Parameters.AddWithValue("@Version", b.VersionB);
            command.Parameters.AddWithValue("@CC", b.CCB);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();  
            }
            int count = command.ExecuteNonQuery();
            return (count > 0);
        }

 



        //string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=BikeSaleSystemDB;User ID=sa;password=sa123456";
        //public DataTable ExecuteQuery(string query, object[] parameter = null)
        //{
        //    DataTable data = new DataTable();

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(query, connection);
        //        if (parameter != null)
        //        {
        //            string[] listPara = query.Split(' ');
        //            int i = 0;
        //            foreach (string item in listPara)
        //            {
        //                if (item.Contains('@'))
        //                {
        //                    command.Parameters.AddWithValue(item, parameter[i]);
        //                    i++;
        //                }
        //            }
        //        }
        //        SqlDataAdapter adapter = new SqlDataAdapter(command);
        //        adapter.Fill(data);
        //        connection.Close();
        //    }
        //    return data;
        //}
    }
}