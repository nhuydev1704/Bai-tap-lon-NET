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
    public partial class frmTeacherAttendance : Form
    {
        public frmTeacherAttendance()
        {
            InitializeComponent();
        }

        #region "Object and Variables"
        private int AttendanceId;
        private string TeacherId;
        private int indexRow;
        lib.TeacherDetails objTAttendance = new lib.TeacherDetails();
        Global objGlobal = new Global();
        #endregion

        #region "Form events"
        private void frmTeacherAttendance_Load(object sender, EventArgs e)
        {
            GenerateGridViewAutoNo();
            CheckDataGridTable();
            TeacherList();
        }

        private void frmTeacherAttendance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ResetAll();
                GenerateGridViewAutoNo();
                this.btnAdd.Text = "Add";
                this.btnDelete.Enabled = false;
            }
        }
        #endregion

        #region "Methos"
        private bool isValidation(bool isValid)
        {
            if (this.cmbTeacherName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Teacher name is empty. select teacher name.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbTeacherName.Focus();
                isValid = false;
            }
            else
                if (rdPresent.Checked==false && rdAbsent.Checked==false)
                {
                    MessageBox.Show("Select attendance.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    isValid = false;
                }
            return isValid;
        }

        private void ResetAll()
        {
            this.TeacherId = "";
            this.cmbTeacherName.ResetText();
            this.rdPresent.Checked = false;
            this.rdAbsent.Checked = false;
            this.picTeacher.Image = null;
            this.cmbTeacherName.Focus();
        }

        private void CheckDataGridTable()
        {
            if (this.gridTeacherAttendanceData.Rows.Count != 0)
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
            AttendanceId = Global.AutoNumber("Select max(Id) From TeacherAttendance", 1);
            foreach (DataGridViewRow row in gridTeacherAttendanceData.Rows)
            {
                row.Cells["Id"].Value = AttendanceId;
                AttendanceId++;
            }
        }

        private void TeacherList()
        {
            var selectQuery = "SELECT TeacherName from TeacherRegister";
            var sql = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = sql.getData(selectQuery);
            foreach (DataRow dr in dt.Rows)
            {
                this.cmbTeacherName.Items.Add(dr["TeacherName"]);
            }
        }
        #endregion

        #region "ComboBox and GridView events"
        private void cmbTeacherName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TeacherId = "";
            this.picTeacher.Image = null;
            var sql = "SELECT * from TeacherRegister Where TeacherName='" + cmbTeacherName.Text.Trim() + "'";
            var getdata = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = getdata.getSearchData(sql);
            foreach (DataRow dr in dt.Rows)
            {
                this.TeacherId = dr["Id"].ToString();
                objGlobal.getPictureFromDatabase(picTeacher, dt, 0, "TPhoto");
            }
        }

        private void gridTeacherAttendanceData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex > 4)  // ignore header row and any column
                return;
            indexRow = e.RowIndex;
            DataGridViewRow row = gridTeacherAttendanceData.Rows[indexRow];
            this.AttendanceId = Convert.ToInt32(gridTeacherAttendanceData.Rows[e.RowIndex].Cells[0].Value.ToString());
            this.cmbTeacherName.Text = row.Cells[1].Value.ToString();
            this.datePicker.Text = row.Cells[2].Value.ToString();
            if (row.Cells[3].Value.ToString().Equals(rdPresent.Text) == true)
            {
                this.rdPresent.Checked = true;
            }
            else
            {
                this.rdAbsent.Checked = true;
            }
            this.TeacherId = row.Cells[4].Value.ToString();

            this.btnAdd.Text = "Modify";
            this.btnDelete.Enabled = true;
        }
        #endregion

        #region "Button Events"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!isValidation(true))
                return;
            try
            {
                if (this.btnAdd.Text == "Add")
                {
                    gridTeacherAttendanceData.Rows.Add();
                    gridTeacherAttendanceData.Rows[gridTeacherAttendanceData.Rows.Count - 1].Cells["Id"].Value = AttendanceId;
                    gridTeacherAttendanceData.Rows[gridTeacherAttendanceData.Rows.Count - 1].Cells["TeacherName"].Value = cmbTeacherName.Text;
                    gridTeacherAttendanceData.Rows[gridTeacherAttendanceData.Rows.Count - 1].Cells["AttendanceDate"].Value = datePicker.Text;
                    if (this.rdPresent.Checked == true)
                    {
                        gridTeacherAttendanceData.Rows[gridTeacherAttendanceData.Rows.Count - 1].Cells["Attendance"].Value = rdPresent.Text;
                    }
                    else
                        if (this.rdAbsent.Checked == true)
                        {
                            gridTeacherAttendanceData.Rows[gridTeacherAttendanceData.Rows.Count - 1].Cells["Attendance"].Value = rdAbsent.Text;
                        }
                    gridTeacherAttendanceData.Rows[gridTeacherAttendanceData.Rows.Count - 1].Cells["TId"].Value = TeacherId;
                    MessageBox.Show("Add Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetAll();
                }
                else
                    if (this.btnAdd.Text == "Modify")
                    {
                        DataGridViewRow newDataRow = gridTeacherAttendanceData.Rows[indexRow];
                        newDataRow.Cells[0].Value = AttendanceId;
                        newDataRow.Cells[1].Value = cmbTeacherName.Text;
                        newDataRow.Cells[2].Value = datePicker.Text;
                        if (this.rdPresent.Checked == true)
                        {
                            newDataRow.Cells[3].Value = rdPresent.Text;
                        }
                        else
                            if (this.rdAbsent.Checked == true)
                            {
                                newDataRow.Cells[3].Value = rdAbsent.Text;
                            }
                        newDataRow.Cells[4].Value = TeacherId;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete?", Global.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information).ToString().ToLower() == "yes")
            {
                this.gridTeacherAttendanceData.Rows.Remove(this.gridTeacherAttendanceData.Rows[indexRow]);
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
                for (int i = 0; i < gridTeacherAttendanceData.Rows.Count; i++)
                {
                    objTAttendance.AttendanceId = Convert.ToInt32(gridTeacherAttendanceData.Rows[i].Cells["Id"].Value.ToString());
                    objTAttendance.TeacherName = gridTeacherAttendanceData.Rows[i].Cells["TeacherName"].Value.ToString();
                    objTAttendance.AttendanceDate = gridTeacherAttendanceData.Rows[i].Cells["AttendanceDate"].Value.ToString();
                    objTAttendance.Attendance = gridTeacherAttendanceData.Rows[i].Cells["Attendance"].Value.ToString();
                    objTAttendance.TeacherId = gridTeacherAttendanceData.Rows[i].Cells["TId"].Value.ToString();
                    objTAttendance.AddTeacherAttendance();
                }
                MessageBox.Show("Saved Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridTeacherAttendanceData.Rows.Clear();
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
