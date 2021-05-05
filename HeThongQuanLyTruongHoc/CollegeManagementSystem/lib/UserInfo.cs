using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace CollegeManagementSystem.lib
{
    public class UserInfo : lib.DatabaseConnection
    {
        private string _userid;
        private string _username;
        private string _loginname;
        private string _password;
        private string _role;
        private string _active;
        private string sql = "";

        public string UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }

        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        public string LoginName
        {
            get { return _loginname; }
            set { _loginname = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public string Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public DataTable LoginUser()
        {
            sql = "Select * From ULogin Where LoginName='" + _loginname + "'and Password='" + _password + "'";
            return getTable(sql);
        }

        public bool ChangePassword()
        {
            sql = "Update ULogin set Password=@Password where UserName=@UserName";
            return ExecuteNonQuery(sql);
        }

        public bool CreateNewUser()
        {
            sql = "INSERT INTO ULogin(UserId,UserName,LoginName,Password,UserType,Active) VALUES ('" 
                + _userid + "','" 
                + _username + "','" 
                + _loginname + "','" 
                + _password + "','" 
                + _role + "','" 
                + _active + "')";
            return ExecuteNonQuery(sql);
        }

        public bool UpdateUsers()
        {
            sql = "Update ULogin Set UserName='"
                + _username + "',LoginName='"
                + _loginname + "',Password='"
                + _password + "',UserType='"
                + _role + "',Active='"
                + _active + "' Where UserId='" + _userid + "'";
            return ExecuteNonQuery(sql);
        }

        public bool DeleteUser()
        {
            sql = "Delete From ULogin Where UserId='" + _userid + "'";
            return ExecuteNonQuery(sql);
        }
    }
}
