using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CollegeManagementSystem.CourseDetails
{
    public partial class frmSubject : Form
    {
        public frmSubject()
        {
            InitializeComponent();
        }

        #region "Object and variables"
        private string SubjectId;
        private string CId;
        lib.CourseDetails objCourseDetails = new lib.CourseDetails();
        #endregion

        #region "Form events"
        private void frmSubject_Load(object sender, EventArgs e)
        {
            _AutoNumber();
            CourseList();
            BindData();
        }

        private void frmSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else
                if (e.KeyCode == Keys.Escape)
                {
                    ClearAll();
                    this.cmbSemester.Enabled = false;
                    this.btnSave.Enabled = true;
                    this.btnSave.Text = "&Save";
                    this.btnDelete.Enabled = false;
                }
        }
        #endregion

        #region "Methods"
        private bool CheckValidation()
        {
            var objCon = new lib.DatabaseConnection();
            bool isValid = true;
            if (cmbCourse.Text == string.Empty)
            {
                MessageBox.Show("Course name is required.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbCourse.Focus();
                isValid = false;
            }
            else
                if (cmbSemester.Text == string.Empty)
                {
                    MessageBox.Show("Semester is required.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbSemester.Focus();
                    isValid = false;
                }
                else
                    if (txtSubjectName.Text == string.Empty)
                    {
                        MessageBox.Show("Subject name is required.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cmbSemester.Focus();
                        isValid = false;
                    }
                    else
                        if (!string.IsNullOrEmpty(objCon.GetSqlData("Select SubjectName From SubjectDetails Where CourseName='" + cmbCourse.Text.Trim() + "' and Semester='" + cmbSemester.Text.Trim() + "' and SubjectName='" + txtSubjectName.Text.Trim() + "'")))
                        {
                            MessageBox.Show("A duplicate subject can not accepted in semester", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtSubjectName.Focus();
                            txtSubjectName.SelectAll();
                            isValid = false;
                        }
                        else
                            if (txtCredits.Text == string.Empty)
                            {
                                MessageBox.Show("Credits is required.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                cmbSemester.Focus();
                                isValid = false;
                            }
            return isValid;
        }

        protected void _AutoNumber()
        {
            this.SubjectId = Global.AutoNumber("Select max(Id) FROM SubjectDetails", 1).ToString();
        }

        private void BindData()
        {
            string Data = "SELECT * From SubjectDetails";
            var getdata = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = getdata.getTable(Data);
            foreach (DataRow dr in dt.Rows)
            {
                dataSubjectDetails.Rows.Add();
                dataSubjectDetails.Rows[dataSubjectDetails.Rows.Count - 1].Cells["SID"].Value = dr["Id"];
                dataSubjectDetails.Rows[dataSubjectDetails.Rows.Count - 1].Cells["CourseName"].Value = dr["CourseName"];
                dataSubjectDetails.Rows[dataSubjectDetails.Rows.Count - 1].Cells["Semester"].Value = dr["Semester"];
                dataSubjectDetails.Rows[dataSubjectDetails.Rows.Count - 1].Cells["SubjectName"].Value = dr["SubjectName"];
                dataSubjectDetails.Rows[dataSubjectDetails.Rows.Count - 1].Cells["Credits"].Value = dr["Credits"];
                dataSubjectDetails.Rows[dataSubjectDetails.Rows.Count - 1].Cells["CourseId"].Value = dr["CourseId"];
            }
        }

        private void ClearAll()
        {
            SubjectId = "";
            CId = "";
            cmbCourse.SelectedIndex = -1;
            txtSubjectName.Clear();
            txtCredits.Clear();
            cmbSemester.Items.Clear();
            this.cmbSemester.DropDownHeight = 106;
            _AutoNumber();
            cmbCourse.Focus();
        }

        private void CourseList()
        {
            var selectQuery = "SELECT Distinct CourseName from Course";
            var sql = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = sql.getData(selectQuery);
            foreach (DataRow dr in dt.Rows)
            {
                this.cmbCourse.Items.Add(dr["CourseName"]);
            }
        }
        #endregion

        #region "ComboBox and datagridview Events"
        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbSemester.Enabled = true;
            var sql = "SELECT * from Course Where CourseName='" + cmbCourse.Text + "'";
            var getdata = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = getdata.getSearchData(sql);
            this.cmbSemester.Items.Clear();
            this.cmbSemester.DropDownHeight = 106;
            foreach (DataRow dr in dt.Rows)
            {
                this.cmbSemester.Items.Add(dr["Semester"]);
            }
        }

        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sql = "SELECT * from Course Where CourseName='" + cmbCourse.Text + "' AND Semester='" + cmbSemester.Text + "'";
            var getdata = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = getdata.getSearchData(sql);
            foreach (DataRow dr in dt.Rows)
            {
                this.CId = dt.Rows[0]["Id"].ToString();
            }
        }

        private void dataSubjectDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex > 5)  // ignore header row and any column
                return;
            this.SubjectId = dataSubjectDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
            cmbCourse.Text = dataSubjectDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbSemester.Text = dataSubjectDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSubjectName.Text = dataSubjectDetails.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtCredits.Text = dataSubjectDetails.Rows[e.RowIndex].Cells[4].Value.ToString();
            this.CId = dataSubjectDetails.Rows[e.RowIndex].Cells[5].Value.ToString();
            this.btnSave.Text = "&Update";
            this.btnDelete.Enabled = true;
        }
        #endregion

        #region "Button events"
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckValidation())
                    return;
                objCourseDetails.SubjectCode = SubjectId;
                objCourseDetails.CourseId = CId;
                objCourseDetails.CourseName = cmbCourse.Text;
                objCourseDetails.Semester = cmbSemester.Text;
                objCourseDetails.SubjectName = txtSubjectName.Text;
                objCourseDetails.Credits = txtCredits.Text;
                if (this.btnSave.Text == "&Save")
                {
                    objCourseDetails.AddSubject();
                    MessageBox.Show("Saved Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    if (this.btnSave.Text == "&Update")
                    {
                        objCourseDetails.UpdateSubject();
                        MessageBox.Show("Update Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.btnSave.Text = "&Save";
                        this.btnDelete.Enabled = false;
                    }
                ClearAll();
                dataSubjectDetails.Rows.Clear();
                BindData();
            }
            catch (Exception ex)
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
                    objCourseDetails.SubjectCode = SubjectId;
                    objCourseDetails.DeleteSubject();
                    MessageBox.Show("Delete Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                    dataSubjectDetails.Rows.Clear();
                    BindData();
                    this.btnSave.Text = "&Save";
                    this.btnDelete.Enabled = false;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}