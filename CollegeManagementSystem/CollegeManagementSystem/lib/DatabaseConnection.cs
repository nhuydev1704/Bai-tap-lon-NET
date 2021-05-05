using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CollegeManagementSystem.lib
{
    public class DatabaseConnection
    {
        public static SqlConnection Con;

        public static SqlConnection GlobalConnection()
        {
            string ConString = @"Data Source=" + Global.ServerName + ";Initial Catalog=" + Global.Database + ";Integrated Security=True;User Id=" + Global.SUserId + ";Password=" + Global.SPassword + ";Connection Timeout=1000";
            //string ConString = @"Data Source=DESKTOP-2LLV29I\MSSQLSERVER01;Initial Catalog=College;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Con = new SqlConnection();
            Con.ConnectionString = ConString;
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
            Con.Open();
            return Con;
        }

        #region "Methods for query of [INSERT, SELECT, UPDATE, DELETE] and [PROCEDURE]"
        public bool ExecuteNonQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, GlobalConnection());
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            return true;
        }

        public string GetSqlData(string Sql)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(Sql, GlobalConnection());
                cmd.CommandTimeout = 500;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0][0].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }

        public DataTable getSearchData(string sql)
        {
            SqlDataAdapter DAdpt = new SqlDataAdapter(sql, GlobalConnection());
            DataSet Dset = new DataSet();
            DAdpt.Fill(Dset);
            return Dset.Tables[0];
        }

        public DataTable getData(string Sql)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(Sql, GlobalConnection());
            cmd.CommandTimeout = 500;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }

        public DataTable getTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adpt = new SqlDataAdapter(sql, GlobalConnection());
                adpt.Fill(dt);
                adpt.Dispose();
                return dt;
            }
            catch
            {
                return dt;
            }
        }
        #endregion
    }
}