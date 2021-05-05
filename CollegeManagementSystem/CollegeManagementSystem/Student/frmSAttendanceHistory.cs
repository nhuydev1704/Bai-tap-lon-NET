using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CollegeManagementSystem.Student
{
    public partial class frmSAttendanceHistory : Form
    {
        #region "Object and variables"
        DataTable dt;
        #endregion

        public frmSAttendanceHistory()
        {
            InitializeComponent();
            this.cmbFilter.SelectedIndex = 0;
        }

        #region "Form events"
        private void frmSAttendanceHistory_Load(object sender, EventArgs e)
        {
            Filter();
        }

        private void frmSAttendanceHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region "Methods"
        private void BindData(string sql)
        {
            dataAttendanceHistory.Rows.Clear();
            var getdata = new lib.DatabaseConnection();
            dt = new DataTable();
            dt = getdata.getTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                dataAttendanceHistory.Rows.Add();
                dataAttendanceHistory.Rows[dataAttendanceHistory.Rows.Count - 1].Cells["Id"].Value = dr["Id"];
                dataAttendanceHistory.Rows[dataAttendanceHistory.Rows.Count - 1].Cells["StudentName"].Value = dr["StudentName"];
                dataAttendanceHistory.Rows[dataAttendanceHistory.Rows.Count - 1].Cells["RollNo"].Value = dr["RollNo"];
                dataAttendanceHistory.Rows[dataAttendanceHistory.Rows.Count - 1].Cells["Course"].Value = dr["Course"];
                dataAttendanceHistory.Rows[dataAttendanceHistory.Rows.Count - 1].Cells["Semester"].Value = dr["Semester"];
                dataAttendanceHistory.Rows[dataAttendanceHistory.Rows.Count - 1].Cells["AttendanceDate"].Value = dr["AttendanceDate"];
                dataAttendanceHistory.Rows[dataAttendanceHistory.Rows.Count - 1].Cells["Attendance"].Value = dr["Attendance"];
            }
        }

        private void Filter()
        {
            if (this.cmbFilter.Text == "(None)")
            {
                this.txtSearch.Enabled = false;
            }
            else
            {
                this.txtSearch.Enabled = true;
            }
        }
        #endregion

        #region "Other events"
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbFilter.Text)
            {
                case "Roll No":
                    BindData("Select * From StuAttendance Where RollNo like '" + txtSearch.Text.Trim() + "%'");
                    break;
                case "Student Name":
                    BindData("Select * From StuAttendance Where StudentName like '" + txtSearch.Text.Trim() + "%'");
                    break;
            }
        }
        #endregion

        #region "Button events"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
