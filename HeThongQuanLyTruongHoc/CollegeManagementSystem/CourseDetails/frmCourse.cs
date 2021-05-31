using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CollegeManagementSystem.lib;

namespace CollegeManagementSystem.CourseDetails
{
    public partial class frmCourse : Form
    {

        public frmCourse()
        {
            InitializeComponent();
        }

        #region "Tạo đổi tượng và biến"
        private string CourseId = "";
        lib.CourseDetails CourseDetails = new lib.CourseDetails();
        #endregion

        #region "Sự kiện form load"
        private void frmCourse_Load(object sender, EventArgs e)
        {
            SemesterList();
            _AutoNumber();
            BindData();
        }

        private void frmCourse_KeyDown(object sender, KeyEventArgs e)
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
                    this.btnSave.Enabled = true;
                    this.btnDelete.Enabled = false;
                }
        }
        #endregion

        #region "Phương thức"
        private void BindData()
        {
            string Data = "SELECT * From Course";
            var getdata = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = getdata.getTable(Data);
            foreach (DataRow dr in dt.Rows)
            {
                dataGridCourseDetails.Rows.Add();
                dataGridCourseDetails.Rows[dataGridCourseDetails.Rows.Count - 1].Cells["Id"].Value = dr["Id"];
                dataGridCourseDetails.Rows[dataGridCourseDetails.Rows.Count - 1].Cells["CourseName"].Value = dr["CourseName"];
                dataGridCourseDetails.Rows[dataGridCourseDetails.Rows.Count - 1].Cells["Semester"].Value = dr["Semester"];
            }
        }

        private void ClearAll()
        {
            CourseId = "";
            txtCourseName.Clear();
            cmbSemester.SelectedIndex = -1;
            _AutoNumber();
            txtCourseName.Focus();
        }

        private void SemesterList()
        {
            var selectQuery = "SELECT * from Semester";
            var sql = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = sql.getData(selectQuery);
            foreach (DataRow dr in dt.Rows)
            {
                this.cmbSemester.Items.Add(dr["SemesterId"]);
            }
        }

        private void _AutoNumber()
        {
            CourseId = Global.AutoNumber("SELECT max(Id) From Course", 101).ToString();
        }

        private bool CheckValidation()
        {
            var objCon = new lib.DatabaseConnection();
            bool isValid = true;
            if (txtCourseName.Text == string.Empty)
            {
                MessageBox.Show("Tên khóa học bắt buộc.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCourseName.Focus();
                isValid = false;
            }
            else
                if (cmbSemester.Text == string.Empty)
                {
                    MessageBox.Show("Học kỳ không được chọn.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbSemester.Focus();
                    isValid = false;
                }
                else
                    if (!string.IsNullOrEmpty(objCon.GetSqlData("Select Semester from Course Where CourseName='" + txtCourseName.Text.Trim() + "' AND Semester='" + cmbSemester.Text.Trim() + "'")))
                    {
                        MessageBox.Show("Đã có học kỳ trong khóa học.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCourseName.Focus();
                        txtCourseName.SelectAll();
                        isValid = false;
                    }
            return isValid;
        }
        #endregion

        #region "Datagid view sự kiện"
        private void dataSubjectSetupView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex > 2)  // ignore header row and any column
                return;
            this.CourseId = dataGridCourseDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCourseName.Text = dataGridCourseDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbSemester.Text = dataGridCourseDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.btnSave.Enabled = false;
            this.btnDelete.Enabled = true;
        }
        #endregion

        #region "Sự kiện button"
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckValidation())
                    return;

                CourseDetails.CourseId = CourseId;
                CourseDetails.CourseName = txtCourseName.Text;
                CourseDetails.Semester = cmbSemester.Text;
                CourseDetails.AddCourse();
                MessageBox.Show("Lưu thành công.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll();
                dataGridCourseDetails.Rows.Clear();
                BindData();
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
                DialogResult DResult;
                DResult = MessageBox.Show("Bạn có muốn xóa?", Global.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DResult == DialogResult.Yes)
                {
                    CourseDetails.CourseId = CourseId;
                    CourseDetails.DeleteCourse();
                    MessageBox.Show("Xóa thành công.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                    dataGridCourseDetails.Rows.Clear();
                    BindData();
                    this.btnSave.Enabled = true;
                    this.btnDelete.Enabled = false;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}