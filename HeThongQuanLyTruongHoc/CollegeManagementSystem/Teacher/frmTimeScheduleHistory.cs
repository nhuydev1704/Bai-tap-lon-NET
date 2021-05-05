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
    public partial class frmTimeScheduleHistory : Form
    {
        public frmTimeScheduleHistory()
        {
            InitializeComponent();
            this.cmbFilter.SelectedIndex = 0;
        }

        #region "Object and variables"
        DataTable dt;
        #endregion

        #region "Form events"
        private void frmTimeScheduleHistory_Load(object sender, EventArgs e)
        {
            Filter();
        }

        private void frmTimeScheduleHistory_KeyDown(object sender, KeyEventArgs e)
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
            dataTimeScheduleHistory.Rows.Clear();
            var getdata = new lib.DatabaseConnection();
            dt = new DataTable();
            dt = getdata.getTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                dataTimeScheduleHistory.Rows.Add();
                dataTimeScheduleHistory.Rows[dataTimeScheduleHistory.Rows.Count - 1].Cells["Id"].Value = dr["Id"];
                dataTimeScheduleHistory.Rows[dataTimeScheduleHistory.Rows.Count - 1].Cells["TeacherName"].Value = dr["TeacherName"];
                dataTimeScheduleHistory.Rows[dataTimeScheduleHistory.Rows.Count - 1].Cells["Course"].Value = dr["Course"];
                dataTimeScheduleHistory.Rows[dataTimeScheduleHistory.Rows.Count - 1].Cells["Semester"].Value = dr["Semester"];
                dataTimeScheduleHistory.Rows[dataTimeScheduleHistory.Rows.Count - 1].Cells["SubjectName"].Value = dr["SubjectName"];
                dataTimeScheduleHistory.Rows[dataTimeScheduleHistory.Rows.Count - 1].Cells["Day"].Value = dr["SDay"];
                dataTimeScheduleHistory.Rows[dataTimeScheduleHistory.Rows.Count - 1].Cells["Shift"].Value = dr["Shift"];
                dataTimeScheduleHistory.Rows[dataTimeScheduleHistory.Rows.Count - 1].Cells["Time"].Value = dr["STime"];
                dataTimeScheduleHistory.Rows[dataTimeScheduleHistory.Rows.Count - 1].Cells["Period"].Value = dr["Period"];
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
                    BindData("Select * From Schedule Where TeacherName like '" + txtSearch.Text.Trim() + "%'");
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
