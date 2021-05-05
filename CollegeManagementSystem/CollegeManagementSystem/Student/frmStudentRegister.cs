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

namespace CollegeManagementSystem.Student
{
    public partial class frmStudentRegister : Form
    {
        #region "object and variables"
        private string StudentId = "";
        DataTable dt;
        lib.StudentDetails objStudentDetails = new lib.StudentDetails();
        lib.DatabaseConnection objCon = new lib.DatabaseConnection();
        Global objGlobal = new Global();
        #endregion

        public frmStudentRegister()
        {
            InitializeComponent();
            this.cmbFilter.SelectedIndex = 0;
        }

        #region "Form events"
        private void frmStudentRegister_Load(object sender, EventArgs e)
        {
            Filter();
            _AutoNumber();
            BindData();
            CourseList();
            SemesterList();
        }

        private void frmStudentRegister_KeyDown(object sender, KeyEventArgs e)
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
                    this.btnUpdate.Enabled = false;
                    this.btnDelete.Enabled = false;
                }
        }
        #endregion

        #region "Methods"
        private bool isValidation()
        {
            bool isValid = true;
            if (txtRollNo.Text == string.Empty)
            {
                MessageBox.Show("Roll number is required.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRollNo.Focus();
                isValid = false;
            }
            else
                if (txtStudentName.Text == string.Empty)
                {
                    MessageBox.Show("Student name is required.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtStudentName.Focus();
                    isValid = false;
                }
                else
                    if (rdMale.Checked == false && rdFemale.Checked == false)
                    {
                        MessageBox.Show("Select Gender.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        isValid = false;
                    }
                    else
                        if (txtAddress.Text == string.Empty)
                        {
                            MessageBox.Show("Address is required.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtAddress.Focus();
                            isValid = false;
                        }
                        else
                            if (txtPhoneNo.Text == string.Empty)
                            {
                                MessageBox.Show("Phone number is required.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtPhoneNo.Focus();
                                isValid = false;
                            }
                            else
                                if (!objGlobal.IsAllDigits(txtPhoneNo.Text))
                                {
                                    MessageBox.Show("Phone no can not accepted charecter", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtPhoneNo.Focus();
                                    txtPhoneNo.SelectAll();
                                    isValid = false;
                                }
                                else
                                    if (txtPhoneNo.Text.Trim().Length > 17 || txtPhoneNo.Text.Trim().Length < 10)
                                    {
                                        MessageBox.Show("Phone number length must be between 10 to 17 digits accept.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        txtPhoneNo.SelectAll();
                                        txtPhoneNo.Focus();
                                        isValid = false;
                                    }
                                    else
                                        if (txtEmail.Text == string.Empty)
                                        {
                                            MessageBox.Show("Email id is required.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            txtEmail.Focus();
                                            isValid = false;
                                        }
                                        else
                                            if (!objGlobal.getInvalidInput(txtEmail.Text, Global.Emailpattern, "Invalid email. give email in correct format, for example(Ram32@gmail.com, Ram@gmail.com, Ram_22@gmail.com)", Global.Caption))
                                            {
                                                txtEmail.SelectAll();
                                                txtEmail.Focus();
                                                isValid = false; ;
                                            }
            return isValid;
        }

        private void BindData()
        {
            string Data = "SELECT * From Regstudent";
            var getdata = new lib.DatabaseConnection();
            dt = new DataTable();
            dt = getdata.getTable(Data);
            foreach (DataRow dr in dt.Rows)
            {
                dataStudentView.Rows.Add();
                dataStudentView.Rows[dataStudentView.Rows.Count - 1].Cells["SID"].Value = dr["Id"];
                dataStudentView.Rows[dataStudentView.Rows.Count - 1].Cells["RollNo"].Value = dr["RollNo"];
                dataStudentView.Rows[dataStudentView.Rows.Count - 1].Cells["StudentName"].Value = dr["StudentName"];
                dataStudentView.Rows[dataStudentView.Rows.Count - 1].Cells["Gender"].Value = dr["Gender"];
                dataStudentView.Rows[dataStudentView.Rows.Count - 1].Cells["Address"].Value = dr["Address"];
                dataStudentView.Rows[dataStudentView.Rows.Count - 1].Cells["DOB"].Value = dr["DateOfBirth"];
                dataStudentView.Rows[dataStudentView.Rows.Count - 1].Cells["AdmissionDate"].Value = dr["AdmissionDate"];
                dataStudentView.Rows[dataStudentView.Rows.Count - 1].Cells["PhoneNo"].Value = dr["PhoneNo"];
                dataStudentView.Rows[dataStudentView.Rows.Count - 1].Cells["Email"].Value = dr["Email"];
                dataStudentView.Rows[dataStudentView.Rows.Count - 1].Cells["Country"].Value = dr["Country"];
                dataStudentView.Rows[dataStudentView.Rows.Count - 1].Cells["Shift"].Value = dr["Shift"];
                dataStudentView.Rows[dataStudentView.Rows.Count - 1].Cells["Course"].Value = dr["Course"];
                dataStudentView.Rows[dataStudentView.Rows.Count - 1].Cells["Semester"].Value = dr["Semester"];
                dataStudentView.Rows[dataStudentView.Rows.Count - 1].Cells["StudentPic"].Value = dr["StudentPic"];
            }
        }

        private void ClearAll()
        {
            this.StudentId = "";
            this.txtRollNo.Clear();
            this.txtStudentName.Clear();
            this.rdMale.Checked = false;
            this.rdFemale.Checked = false;
            this.txtAddress.Clear();
            this.mtxtDOB.Clear();
            this.mtxtAdmissionDate.Clear();
            this.txtPhoneNo.Clear();
            this.txtEmail.Clear();
            this.cmbCountry.SelectedIndex = -1;
            this.cmbShift.SelectedIndex = -1;
            this.cmbCourse.SelectedIndex = -1;
            this.cmbSemester.SelectedIndex = -1;
            this.picStudent.Image = null;
            this.cmbFilter.SelectedIndex = 0;
            this.txtSearch.Clear();
            _AutoNumber();
            this.txtRollNo.Focus();
        }

        protected void _AutoNumber()
        {
            StudentId = Global.AutoNumber("Select max(Id) FROM Regstudent", 1).ToString();
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

        private void Filter()
        {
            if (this.cmbFilter.Text == "(None)")
            {
                this.txtSearch.Enabled = false;
                this.btnSearch.Enabled = false;
            }
            else
            {
                this.txtSearch.Enabled = true;
                this.btnSearch.Enabled = true;
            }
        }

        private void GetDataBind(string sql)
        {
            var getdata = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = getdata.getSearchData(sql);
            if (dt.Rows.Count > 0)
            {
                StudentId = dt.Rows[0]["Id"].ToString();
                txtRollNo.Text = dt.Rows[0]["RollNo"].ToString();
                txtStudentName.Text = dt.Rows[0]["StudentName"].ToString();
                if (dt.Rows[0]["Gender"].ToString().Trim().Equals("Male") == true)
                {
                    this.rdMale.Checked = true;
                }
                else
                {
                    this.rdFemale.Checked = true;
                }
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                mtxtDOB.Text = dt.Rows[0]["DateOfBirth"].ToString();
                mtxtAdmissionDate.Text = dt.Rows[0]["AdmissionDate"].ToString();
                txtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                cmbCountry.Text = dt.Rows[0]["Country"].ToString();
                cmbShift.Text = dt.Rows[0]["Shift"].ToString();
                cmbCourse.Text = dt.Rows[0]["Course"].ToString();
                cmbSemester.Text = dt.Rows[0]["Semester"].ToString();
                objGlobal.getPictureFromDatabase(picStudent, dt, 0, "StudentPic");
            }
            else
            {
                MessageBox.Show("Record not found!", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSearch.Focus();
                txtSearch.SelectAll();
            }
        }

        private void SearchDetails(string ListType, string getText)
        {
            switch (ListType)
            {
                case "Roll no":
                    GetDataBind("SELECT * From Regstudent WHERE RollNo='" + getText.Trim() + "'");
                    break;
                case "Student name":
                    GetDataBind("SELECT * From Regstudent WHERE StudentName='" + getText.Trim() + "'");
                    break;
                case "Phone no":
                    GetDataBind("SELECT * From Regstudent WHERE PhoneNo='" + getText.Trim() + "'");
                    break;
                case "Email":
                    GetDataBind("SELECT * From Regstudent WHERE Email='" + getText.Trim() + "'");
                    break;
            }
        }
        #endregion
         
        #region "Gridview events and other events"
        private void mtxtDOB_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (this.ActiveControl == mtxtDOB)
                return;
            if (!e.IsValidInput)
            {
                MessageBox.Show("Date of birth or Empty\nThe Date supplied must be a valid date in the format dd/mm/yyyy.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                mtxtDOB.Focus();
                mtxtDOB.SelectAll();
            }
        }

        private void mtxtAdmissionDate_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (this.ActiveControl == mtxtAdmissionDate)
                return;
            if (!e.IsValidInput)
            {
                MessageBox.Show("Addmision Date or Empty\nThe Date supplied must be a valid date in the format dd/mm/yyyy.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                mtxtAdmissionDate.Focus();
                mtxtAdmissionDate.SelectAll();
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void dataStudentRegisterView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex > 13)  // ignore header row and any column
                return;
            this.StudentId = dataStudentView.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtRollNo.Text = dataStudentView.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtStudentName.Text = dataStudentView.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (dataStudentView.Rows[e.RowIndex].Cells[3].Value.ToString().Trim().Equals("Male") == true)
            {
                rdMale.Checked = true;
            }
            else
            {
                rdFemale.Checked = true;
            }
            txtAddress.Text = dataStudentView.Rows[e.RowIndex].Cells[4].Value.ToString();
            mtxtDOB.Text = dataStudentView.Rows[e.RowIndex].Cells[5].Value.ToString();
            mtxtAdmissionDate.Text = dataStudentView.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtPhoneNo.Text = dataStudentView.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtEmail.Text = dataStudentView.Rows[e.RowIndex].Cells[8].Value.ToString();
            cmbCountry.Text = dataStudentView.Rows[e.RowIndex].Cells[9].Value.ToString();
            cmbShift.Text = dataStudentView.Rows[e.RowIndex].Cells[10].Value.ToString();
            cmbCourse.Text = dataStudentView.Rows[e.RowIndex].Cells[11].Value.ToString();
            cmbSemester.Text = dataStudentView.Rows[e.RowIndex].Cells[12].Value.ToString();
            objGlobal.getPictureFromDataGridView(picStudent, dataStudentView, e, 13);
            this.btnSave.Enabled = false;
            this.btnUpdate.Enabled = true;
            this.btnDelete.Enabled = true;
        }
        #endregion

        #region "Button events"
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtSearch.Text == string.Empty)
            {
                MessageBox.Show("Type " + cmbFilter.Text + "!", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSearch.Focus();
                return;
            }
            else
            {
                SearchDetails(cmbFilter.Text, txtSearch.Text);
                this.btnSave.Enabled = false;
                this.btnUpdate.Enabled = true;
                this.btnDelete.Enabled = true;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            openFile.Filter = "JPEG|*.jpg|All files|*.*";
            DialogResult rs = openFile.ShowDialog();
            if (rs == DialogResult.OK)
            {
                picStudent.Image = null;
                picStudent.Image = Image.FromFile(openFile.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isValidation())
                {
                    return;
                }
                else
                    if (!string.IsNullOrEmpty(objCon.GetSqlData("Select PhoneNo From Regstudent Where PhoneNo='" + txtPhoneNo.Text + "'")))
                    {
                        MessageBox.Show("A duplicate phone no can not accepted.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtPhoneNo.Focus();
                        txtPhoneNo.SelectAll();
                        return;
                    }

                objStudentDetails.SId = StudentId.ToString();
                objStudentDetails.StudentName = txtStudentName.Text;
                objStudentDetails.RollNo = txtRollNo.Text;
                if (this.rdMale.Checked == true)
                {
                    objStudentDetails.Gender = rdMale.Text;
                }
                else
                    if (this.rdFemale.Checked == true)
                    {
                        objStudentDetails.Gender = rdFemale.Text;
                    }
                objStudentDetails.Address = txtAddress.Text;
                objStudentDetails.DateOfBirth = mtxtDOB.Text;
                objStudentDetails.AdmissionDate = mtxtAdmissionDate.Text;
                objStudentDetails.PhoneNumber = txtPhoneNo.Text;
                objStudentDetails.EmailId = txtEmail.Text;
                objStudentDetails.StudentPicture = picStudent;
                objStudentDetails.Country = cmbCountry.Text;
                objStudentDetails.Shift = cmbShift.Text;
                objStudentDetails.Course = cmbCourse.Text;
                objStudentDetails.Semester = cmbSemester.Text;
                objStudentDetails.AddStuAdmission();
                MessageBox.Show("Saved Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll();
                dataStudentView.Rows.Clear();
                BindData();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRollNo.Focus();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isValidation())
                    return;

                objStudentDetails.SId = StudentId.ToString();
                objStudentDetails.StudentName = txtStudentName.Text;
                objStudentDetails.RollNo = txtRollNo.Text;
                if (this.rdMale.Checked == true)
                {
                    objStudentDetails.Gender = rdMale.Text;
                }
                else
                    if (this.rdFemale.Checked == true)
                    {
                        objStudentDetails.Gender = rdFemale.Text;
                    }
                objStudentDetails.Address = txtAddress.Text;
                objStudentDetails.DateOfBirth = mtxtDOB.Text;
                objStudentDetails.AdmissionDate = mtxtAdmissionDate.Text;
                objStudentDetails.PhoneNumber = txtPhoneNo.Text;
                objStudentDetails.EmailId = txtEmail.Text;
                objStudentDetails.StudentPicture = picStudent;
                objStudentDetails.Country = cmbCountry.Text;
                objStudentDetails.Shift = cmbShift.Text;
                objStudentDetails.Course = cmbCourse.Text;
                objStudentDetails.Semester = cmbSemester.Text;
                objStudentDetails.UpdateStuAdmission();
                MessageBox.Show("Update Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll();
                dataStudentView.Rows.Clear();
                BindData();
                this.btnSave.Enabled = true;
                this.btnUpdate.Enabled = false;
                this.btnDelete.Enabled = false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    objStudentDetails.SId = StudentId.ToString();
                    objStudentDetails.DeleteStuAdmission();
                    MessageBox.Show("Delete Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                    dataStudentView.Rows.Clear();
                    BindData();
                    this.btnSave.Enabled = true;
                    this.btnUpdate.Enabled = false;
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
            Close();
        }
        #endregion
    }
}