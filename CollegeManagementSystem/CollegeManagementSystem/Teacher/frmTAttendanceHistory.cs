using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CollegeManagementSystem.Teacher
{
    public partial class frmTAttendanceHistory : Form
    {
        public frmTAttendanceHistory()
        {
            InitializeComponent();
            this.cmbFilter.SelectedIndex = 0;
        }

        #region "Object and variables"
        DataTable dt;
        #endregion

        #region "Form events"
        private void frmTAttendanceHistory_Load(object sender, EventArgs e)
        {
            Filter();
        }

        private void frmTAttendanceHistory_KeyDown(object sender, KeyEventArgs e)
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
                dataAttendanceHistory.Rows[dataAttendanceHistory.Rows.Count - 1].Cells["TeacherName"].Value = dr["TeacherName"];
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
                case "Teacher Name":
                    BindData("Select * From TeacherAttendance Where TeacherName like '" + txtSearch.Text.Trim() + "%'");
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
