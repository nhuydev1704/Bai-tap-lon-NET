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
    public partial class frmTimeSchedule : Form
    {
        public frmTimeSchedule()
        {
            InitializeComponent();
        }

        #region "Object and Variables"
        private int ScheduleId;
        private int TeacherId;
        private int CourseId;
        private int SubjCode;
        private int rowIndex;
        lib.TimeSchedule objTimeSchedule = new lib.TimeSchedule();
        Global objGlobal = new Global();
        #endregion

        #region "Form events"
        private void frmTimeSchedule_Load(object sender, EventArgs e)
        {
            GenerateGridViewAutoNo();
            CheckDataGridTable();
            TeacherList();
            CourseList();
        }

        private void frmTimeSchedule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ResetAll();
                GenerateGridViewAutoNo();
                btnAdd.Text = "Add";
                btnDelete.Enabled = false;
            }
        }
        #endregion

        #region "Methods"
        private bool Validation(bool isValid)
        {
            return isValid;
        }
        private void ResetAll()
        {
            cmbTeacherName.ResetText();
            picTeacher.Image = null;
            cmbCourse.SelectedIndex = -1;
            cmbSemester.SelectedIndex = -1;
            cmbSemester.Items.Clear();
            cmbSemester.DropDownHeight = 106;
            cmbSubjectName.SelectedIndex = -1;
            cmbSubjectName.Items.Clear();
            cmbSubjectName.DropDownHeight = 106;
            cmbDay.SelectedIndex = -1;
            cmbShift.SelectedIndex = -1;
            cmbTime.SelectedIndex = -1;
            cmbPeriod.SelectedIndex = -1;
            cmbTeacherName.Focus();
        }

        private void CheckDataGridTable()
        {
            if (this.gridTimeScheduleData.Rows.Count != 0)
            {
                this.btnConfirm.Enabled = true;
            }
            else
            {
                this.btnConfirm.Enabled = false;
            }
        }

        private void GenerateGridViewAutoNo()
        {
            ScheduleId = Global.AutoNumber("Select max(Id) From Schedule", 101);
            foreach (DataGridViewRow row in gridTimeScheduleData.Rows)
            {
                row.Cells["SId"].Value = ScheduleId;
                ScheduleId++;
            }
        }

        private void TeacherList()
        {
            var selectQuery = "SELECT * from TeacherRegister";
            var sql = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = sql.getData(selectQuery);
            foreach (DataRow dr in dt.Rows)
            {
                this.cmbTeacherName.Items.Add(dr["TeacherName"]);
            }
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

        private void BindDataA(string sql)
        {
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

        private void BindDataB(string sql)
        {
            var getdata = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = getdata.getSearchData(sql);
            foreach (DataRow dr in dt.Rows)
            {
                CourseId = Convert.ToInt32(dr["Id"]);
            }
        }
        #endregion

        #region "ComboBox and GridView events"
        private void cmbTeacherName_SelectedIndexChanged(object sender, EventArgs e)
        {
            picTeacher.Image = null;
            var sql = "SELECT * from TeacherRegister Where TeacherName='" + cmbTeacherName.Text + "'";
            var getdata = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = getdata.getSearchData(sql);
            foreach (DataRow dr in dt.Rows)
            {
                this.TeacherId = Convert.ToInt32(dr["Id"]);
                objGlobal.getPictureFromDatabase(picTeacher, dt, 0, "TPhoto");
            }
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbSemester.Enabled = true;
            BindDataA("SELECT * from Course Where CourseName='" + cmbCourse.Text + "'");
        }

        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbSubjectName.ResetText();
            this.cmbSubjectName.Items.Clear();
            this.cmbSubjectName.DropDownHeight = 106;
            BindDataB("SELECT * from Course Where CourseName='" + cmbCourse.Text + "' AND Semester='" + cmbSemester.Text + "'");
            var sql = "SELECT * from SubjectDetails Where CourseName='" + cmbCourse.Text + "' AND Semester='" + cmbSemester.Text + "'";
            var getdata = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = getdata.getSearchData(sql);
            foreach (DataRow dr in dt.Rows)
            {
                this.cmbSubjectName.Items.Add(dr["SubjectName"]);
            }
        }

        private void cmbSubjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sql = "SELECT * from SubjectDetails Where CourseName='" + cmbCourse.Text + "' AND Semester='" + cmbSemester.Text + "' AND SubjectName='" + cmbSubjectName.Text + "'";
            var getdata = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = getdata.getSearchData(sql);
            foreach (DataRow dr in dt.Rows)
            {
                this.SubjCode = Convert.ToInt32(dr["Id"]);
            }
        }

        private void gridTimeScheduleData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex > 11)  // ignore header row and any column
                return;
            rowIndex = e.RowIndex;
            DataGridViewRow row = gridTimeScheduleData.Rows[rowIndex];
            this.ScheduleId = Convert.ToInt32(row.Cells[0].Value.ToString());
            this.cmbTeacherName.Text = row.Cells[1].Value.ToString();
            this.cmbCourse.Text = row.Cells[2].Value.ToString();
            this.cmbSemester.Text = row.Cells[3].Value.ToString();
            this.cmbSubjectName.Text = row.Cells[4].Value.ToString();
            this.cmbDay.Text = row.Cells[5].Value.ToString();
            this.cmbShift.Text = row.Cells[6].Value.ToString();
            this.cmbTime.Text = row.Cells[7].Value.ToString();
            this.cmbPeriod.Text = row.Cells[8].Value.ToString();
            this.TeacherId = Convert.ToInt32(row.Cells[9].Value.ToString());
            this.CourseId = Convert.ToInt32(row.Cells[10].Value.ToString());
            this.SubjCode = Convert.ToInt32(row.Cells[11].Value.ToString());

            this.btnAdd.Text = "Modify";
            this.btnDelete.Enabled = true;
        }
        #endregion

        #region "Button events"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this.btnAdd.Text == "Add")
                    {
                        gridTimeScheduleData.Rows.Add();
                        gridTimeScheduleData.Rows[gridTimeScheduleData.Rows.Count - 1].Cells["SId"].Value = ScheduleId;
                        gridTimeScheduleData.Rows[gridTimeScheduleData.Rows.Count - 1].Cells["TeacherName"].Value = cmbTeacherName.Text;
                        gridTimeScheduleData.Rows[gridTimeScheduleData.Rows.Count - 1].Cells["Course"].Value = cmbCourse.Text;
                        gridTimeScheduleData.Rows[gridTimeScheduleData.Rows.Count - 1].Cells["Semester"].Value = cmbSemester.Text;
                        gridTimeScheduleData.Rows[gridTimeScheduleData.Rows.Count - 1].Cells["SubjectName"].Value = cmbSubjectName.Text;
                        gridTimeScheduleData.Rows[gridTimeScheduleData.Rows.Count - 1].Cells["Day"].Value = cmbDay.Text;
                        gridTimeScheduleData.Rows[gridTimeScheduleData.Rows.Count - 1].Cells["Shift"].Value = cmbShift.Text;
                        gridTimeScheduleData.Rows[gridTimeScheduleData.Rows.Count - 1].Cells["Time"].Value = cmbTime.Text;
                        gridTimeScheduleData.Rows[gridTimeScheduleData.Rows.Count - 1].Cells["Period"].Value = cmbPeriod.Text;
                        gridTimeScheduleData.Rows[gridTimeScheduleData.Rows.Count - 1].Cells["TeacherCode"].Value = TeacherId;
                        gridTimeScheduleData.Rows[gridTimeScheduleData.Rows.Count - 1].Cells["CourseCode"].Value = CourseId;
                        gridTimeScheduleData.Rows[gridTimeScheduleData.Rows.Count - 1].Cells["SubjectCode"].Value = SubjCode;
                        MessageBox.Show("Add Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetAll();
                    }
                    else
                        if (this.btnAdd.Text == "Modify")
                        {
                            DataGridViewRow newDataRow = gridTimeScheduleData.Rows[rowIndex];
                            newDataRow.Cells[0].Value = ScheduleId;
                            newDataRow.Cells[1].Value = cmbTeacherName.Text;
                            newDataRow.Cells[2].Value = cmbCourse.Text;
                            newDataRow.Cells[3].Value = cmbSemester.Text;
                            newDataRow.Cells[4].Value = cmbSubjectName.Text;
                            newDataRow.Cells[5].Value = cmbDay.Text;
                            newDataRow.Cells[6].Value = cmbShift.Text;
                            newDataRow.Cells[7].Value = cmbTime.Text;
                            newDataRow.Cells[8].Value = cmbPeriod.Text;
                            newDataRow.Cells[9].Value = TeacherId;
                            newDataRow.Cells[10].Value = CourseId;
                            newDataRow.Cells[11].Value = SubjCode;
                            MessageBox.Show("Modify Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetAll();
                            this.btnAdd.Text = "Add";
                            this.btnDelete.Enabled = false;
                        }
                    GenerateGridViewAutoNo();
                    CheckDataGridTable();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete?", Global.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information).ToString().ToLower() == "yes")
            {
                this.gridTimeScheduleData.Rows.Remove(this.gridTimeScheduleData.Rows[rowIndex]);
                MessageBox.Show("Delete Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ResetAll();
            this.btnAdd.Text = "Add";
            this.btnDelete.Enabled = false;
            GenerateGridViewAutoNo();
            CheckDataGridTable();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridTimeScheduleData.Rows.Count; i++)
                {
                    objTimeSchedule.ScheduleId = Convert.ToInt32(gridTimeScheduleData.Rows[i].Cells["SId"].Value);
                    objTimeSchedule.TeacherName = gridTimeScheduleData.Rows[i].Cells["TeacherName"].Value.ToString();
                    objTimeSchedule.Course = gridTimeScheduleData.Rows[i].Cells["Course"].Value.ToString(); ;
                    objTimeSchedule.Semester = gridTimeScheduleData.Rows[i].Cells["Semester"].Value.ToString();
                    objTimeSchedule.SubjectName = gridTimeScheduleData.Rows[i].Cells["SubjectName"].Value.ToString();
                    objTimeSchedule.Day = gridTimeScheduleData.Rows[i].Cells["Day"].Value.ToString();
                    objTimeSchedule.Shift = gridTimeScheduleData.Rows[i].Cells["Shift"].Value.ToString();
                    objTimeSchedule.Time = gridTimeScheduleData.Rows[i].Cells["Time"].Value.ToString();
                    objTimeSchedule.Period = gridTimeScheduleData.Rows[i].Cells["Period"].Value.ToString();
                    objTimeSchedule.TeacherId = Convert.ToInt32(gridTimeScheduleData.Rows[i].Cells["TeacherCode"].Value);
                    objTimeSchedule.CourseCode = Convert.ToInt32(gridTimeScheduleData.Rows[i].Cells["CourseCode"].Value);
                    objTimeSchedule.SubjectCode = Convert.ToInt32(gridTimeScheduleData.Rows[i].Cells["SubjectCode"].Value);
                    objTimeSchedule.AddTimeSchedule();
                }
                MessageBox.Show("Saved Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridTimeScheduleData.Rows.Clear();
                CheckDataGridTable();
                GenerateGridViewAutoNo();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
