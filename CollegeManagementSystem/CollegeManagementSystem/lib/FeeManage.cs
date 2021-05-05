using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeManagementSystem.lib
{
    public class FeeManage : DatabaseConnection
    {
        private int _feeid = 0;
        private int _studentid = 0;
        private int _categoryid = 0;
        private string _categoryname;
        private int _totalamount;
        private string _studentname;
        private string _rollno;
        private string _course;
        private string _semester;
        private string _paiddate;
        private int _paidamount;
        private string _dueamount;
        private string sql = "";

        public int FeeId
        {
            get { return _feeid; }
            set { _feeid = value; }
        }

        public int StudentId
        {
            get { return _studentid; }
            set { _studentid = value; }
        }

        public int CategoryId
        {
            get { return _categoryid; }
            set { _categoryid = value; }
        }

        public string CategoryName
        {
            get { return _categoryname; }
            set { _categoryname = value; }
        }

        public int TotalAmount
        {
            get { return _totalamount; }
            set
            {
                if (value >= 0)
                    _totalamount = value;
                else
                    throw new ArgumentOutOfRangeException("Amount", value, "Amount must be >= 0");
            }
        }

        public string StudentName
        {
            get { return _studentname; }
            set { _studentname = value; }
        }

        public string RollNo
        {
            get { return _rollno; }
            set { _rollno = value; }
        }

        public string Course
        {
            get { return _course; }
            set { _course = value; }
        }

        public string Semester
        {
            get { return _semester; }
            set { _semester = value; }
        }

        public string PaidDate
        {
            get { return _paiddate; }
            set { _paiddate = value; }
        }

        public int PaidAmount
        {
            get { return _paidamount; }
            set { _paidamount = value; }
        }

        public string DueAmount
        {
            get { return _dueamount; }
            set { _dueamount = value; }
        }

        public bool AddFeeManage()
        {
            sql = "INSERT INTO FeeManage(Id,Category,Amount) values ('" + _categoryid + "', '" + _categoryname + "', '" + _totalamount + "')"; // insert
            return ExecuteNonQuery(sql);
        }

        public bool UpdateFeeManage()
        {
            sql = "UPDATE FeeManage SET Category='" + _categoryname + "',Amount= '" + _totalamount + "' WHERE Id='" + _categoryid + "'"; // update
            return ExecuteNonQuery(sql);
        }

        public bool DeleteFeeManage()
        {
            sql = "DELETE FROM FeeManage Where Id='" + _categoryid + "'"; //delete
            return ExecuteNonQuery(sql);
        }

        public bool AddFeeMaster()
        {
            sql = "INSERT INTO FeeMaster(FeeId,StudentName,RollNo,Course,Semester)Values('" + _feeid + "', '" + _studentname + "', '" + _rollno + "', '" + _course + "', '" + _semester + "')";
            return ExecuteNonQuery(sql);
        }

        public bool AddFeeDetails()
        {
            sql = "INSERT INTO FeeDetails(FeeId,CategoryName,PaidDate,TotalAmount,PaidAmount,DueAmount)Values('" + _feeid + "', '" + _categoryname + "','" + _paiddate + "', '" + _totalamount + "', '" + _paidamount + "', '" + _dueamount + "')";
            return ExecuteNonQuery(sql);
        }

        //public bool UpdateFeeMaster()
        //{
        //    sql = "";
        //    return ExecuteNonQuery(sql);
        //}

        public bool UpdateFeeDetails()
        {
            sql = "Update FeeDetails Set PaidDate='" + _paiddate + "',TotalAmount='" + _totalamount + "',PaidAmount='" + _paidamount + "',DueAmount='" + _dueamount + "' WHERE FeeId='" + _feeid + "' AND CategoryName='" + _categoryname + "'";
            return ExecuteNonQuery(sql);
        }

        /// <summary>
        /// Fee Calculation
        /// </summary>
        /// <returns></returns>
        /// 
        public int CalculateFee(int TotalAmount,int PaidAmount)
        {
            return TotalAmount - PaidAmount;
        }
    }
}