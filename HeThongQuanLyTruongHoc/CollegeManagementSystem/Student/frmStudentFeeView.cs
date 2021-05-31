using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;
using CollegeManagementSystem.lib;

namespace CollegeManagementSystem
{
    public partial class frmStudentFeeView : Form
    {
        public frmStudentFeeView()
        {
            InitializeComponent();
        }

        private void frmStudentFeeView_Load(object sender, EventArgs e)
        {
            ViewStudentFeeRecord();
        }

        private void ViewStudentFeeRecord()
        {
            string QueryData = "SELECT FeeMaster.FeeId as 'Mã Học Phí',FeeMaster.StudentName as 'Tên Sinh Viên',FeeMaster.RollNo as  'Mã Sinh Viên',FeeMaster.Course as  'Khóa Học',FeeMaster.Semester as  'Học Kỳ',FeeDetails.CategoryName as  'Danh Mục',FeeDetails.PaidDate as  'Ngày Thanh Toán',FeeDetails.TotalAmount as  'Tổng Số Tiền',FeeDetails.PaidAmount as  'Đã Thanh Toán',FeeDetails.DueAmount as  'Còn Lại' FROM FeeMaster JOIN FeeDetails ON FeeMaster.FeeID = FeeDetails.FeeID";
            SqlDataAdapter Adpt = new SqlDataAdapter(QueryData, DatabaseConnection.Con);
            DataSet Dset = new DataSet();
            Adpt.Fill(Dset, "StudentFeeView");
            dataStudentFeeView.DataSource = Dset.Tables[0];
        }

        private void txtSearchbyStuName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string QueryData = "SELECT FeeMaster.FeeId as 'Mã Học Phí',FeeMaster.StudentName as 'Tên Sinh Viên',FeeMaster.RollNo as  'Mã Sinh Viên',FeeMaster.Course as  'Khóa Học',FeeMaster.Semester as  'Học Kỳ',FeeDetails.CategoryName as  'Danh Mục',FeeDetails.PaidDate as  'Ngày Thanh Toán',FeeDetails.TotalAmount as  'Tổng Số Tiền',FeeDetails.PaidAmount as  'Đã Thanh Toán',FeeDetails.DueAmount as  'Còn Lại' FROM FeeMaster JOIN FeeDetails ON FeeMaster.FeeID = FeeDetails.FeeID Where";
                QueryData = QueryData + " FeeMaster.StudentName like '" + txtSearchbyStuName.Text.Trim() + "%'";
                SqlDataAdapter Adpt = new SqlDataAdapter(QueryData, DatabaseConnection.Con);
                DataSet Dset = new DataSet();
                Adpt.Fill(Dset, "StudentFeeView");
                dataStudentFeeView.DataSource = Dset.Tables[0];
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Institute Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataStudentFeeView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
