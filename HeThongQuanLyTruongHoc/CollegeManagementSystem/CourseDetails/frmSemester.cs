using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CollegeManagementSystem.CourseDetails
{
    public partial class frmSemester : Form
    {
        lib.CourseDetails ObjCourseDetails = new lib.CourseDetails();
        public frmSemester()
        {
            InitializeComponent();
        }

        #region "Form events"
        private void frmSemester_Load(object sender, EventArgs e)
        {
            _AutoNumber();
            BindData();
        }
        #endregion

        #region "Methods"
        protected void _AutoNumber()
        {
            txtSemester.Text = Global.AutoNumber("Select max(SemesterId) as SemesterId FROM Semester", 1).ToString();
        }

        private void BindData()
        {
            var SelectQuery = "SELECT * from Semester";
            var sql = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = sql.getData(SelectQuery);
            foreach (DataRow dr in dt.Rows)
            {
                this.lstSemester.Items.Add(dr["SemesterId"]);
            }
        }

        private void Process()
        {
            txtSemester.Clear();
            lstSemester.Items.Clear();
            BindData();
            _AutoNumber();
        }
        #endregion

        #region "ListBox events"
        private void lstSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            var SelectQuery = "Select * from Semester Where SemesterId='" + lstSemester.Text + "'";
            var sqlData = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = sqlData.getTable(SelectQuery);
            foreach (DataRow dr in dt.Rows)
            {
                txtSemester.Text = dr["SemesterId"].ToString();
            }

            this.btnAdd.Enabled = false;
            this.btnDelete.Enabled = true;
        }
        #endregion

        #region "Button events"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstSemester.Items.Count >= 8)
            {
                MessageBox.Show("Semester must be between 1 to 8 accept.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSemester.Focus();
                txtSemester.SelectAll();
                return;
            }
            else
            try
            {
                ObjCourseDetails.Semester = txtSemester.Text;
                ObjCourseDetails.AddSemester();
                MessageBox.Show("Saved Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Result;
                Result = MessageBox.Show("Are you sure you want delete record?", Global.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    ObjCourseDetails.Semester = txtSemester.Text;
                    ObjCourseDetails.DeleteSemester();
                    Process();
                    this.btnAdd.Enabled = true;
                    this.btnDelete.Enabled = false;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _AutoNumber();
                this.btnAdd.Enabled = true;
                this.btnDelete.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}