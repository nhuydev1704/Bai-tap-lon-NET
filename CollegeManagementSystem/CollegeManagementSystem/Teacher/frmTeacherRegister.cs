using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CollegeManagementSystem.Teacher
{
    public partial class frmTeacherRegister : Form
    {
        #region "Object and variables"
        private string _TeacherId;
        lib.TeacherDetails ObjTeacher = new lib.TeacherDetails();
        Global ObjGlobal = new Global();
        lib.DatabaseConnection objCon = new lib.DatabaseConnection();
        #endregion

        public frmTeacherRegister()
        {
            InitializeComponent();
            //this.mtxtRegisterDate.Focus();
            this.cmbFilter.SelectedIndex = 0;
        }

        #region "Form events"
        private void frmTeacherRegister_Load(object sender, EventArgs e)
        {
            Filter();
            _AutoNumber();
            BindData();
        }

        private void frmTeacherRegister_KeyDown(object sender, KeyEventArgs e)
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
        private bool CheckValidation()
        {
            bool isValid = true;
            if (txtTeacherName.Text == string.Empty)
            {
                MessageBox.Show("Teacher Name is required.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTeacherName.Focus();
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
                            MessageBox.Show("Phone Number is required.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtPhoneNo.Focus();
                            isValid = false;
                        }
                        else
                            if (!ObjGlobal.IsAllDigits(txtPhoneNo.Text))
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
                                    MessageBox.Show("Email is required.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtEmail.Focus();
                                    isValid = false;
                                }
                                else
                                    if (!ObjGlobal.getInvalidInput(txtEmail.Text, Global.Emailpattern, "Invalid email. give email in correct format, for example(Ram32@gmail.com, Ram@gmail.com, Ram_22@gmail.com)", Global.Caption))
                                    {
                                        txtEmail.SelectAll();
                                        txtEmail.Focus();
                                        isValid = false; ;
                                    }

            return isValid;
        }

        private void BindData()
        {
            string Data = "SELECT * From TeacherRegister";
            var getdata = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = getdata.getTable(Data);
            foreach (DataRow dr in dt.Rows)
            {
                dataStaffView.Rows.Add();
                dataStaffView.Rows[dataStaffView.Rows.Count - 1].Cells["TeacherId"].Value = dr["Id"];
                dataStaffView.Rows[dataStaffView.Rows.Count - 1].Cells["TeacherName"].Value = dr["TeacherName"];
                dataStaffView.Rows[dataStaffView.Rows.Count - 1].Cells["Gender"].Value = dr["Gender"];
                dataStaffView.Rows[dataStaffView.Rows.Count - 1].Cells["Address"].Value = dr["Address"];
                dataStaffView.Rows[dataStaffView.Rows.Count - 1].Cells["RegisterDate"].Value = dr["RegisterDate"];
                dataStaffView.Rows[dataStaffView.Rows.Count - 1].Cells["PhoneNo"].Value = dr["PhoneNo"];
                dataStaffView.Rows[dataStaffView.Rows.Count - 1].Cells["Email"].Value = dr["Email"];
                dataStaffView.Rows[dataStaffView.Rows.Count - 1].Cells["Experience"].Value = dr["Experience"];
                dataStaffView.Rows[dataStaffView.Rows.Count - 1].Cells["Photo"].Value = dr["TPhoto"];
            }
        }

        private void ClearAll()
        {
            this._TeacherId = "";
            this.mtxtRegisterDate.Clear();
            this.txtTeacherName.Clear();
            this.rdMale.Checked = false;
            this.rdFemale.Checked = false;
            this.txtAddress.Clear();
            this.txtEmail.Clear();
            this.txtPhoneNo.Clear();
            this.cmbExperience.SelectedIndex = -1;
            this.picTeacher.Image = null;
            this.cmbFilter.SelectedIndex = 0;
            this.txtSearch.Clear();
            _AutoNumber();
            //this.mtxtRegisterDate.Focus();
        }

        protected void _AutoNumber()
        {
            _TeacherId = Global.AutoNumber("Select max(Id) FROM TeacherRegister", 1).ToString();
        }

        private void GetDataBind(string sql)
        {
            var getdata = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = getdata.getSearchData(sql);
            if (dt.Rows.Count > 0)
            {
                _TeacherId = dt.Rows[0]["Id"].ToString();
                txtTeacherName.Text = dt.Rows[0]["TeacherName"].ToString();
                if (dt.Rows[0]["Gender"].ToString().Trim().Equals("Male") == true)
                {
                    this.rdMale.Checked = true;
                }
                else
                {
                    this.rdFemale.Checked = true;
                }
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                mtxtRegisterDate.Text = dt.Rows[0]["RegisterDate"].ToString();
                txtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                cmbExperience.Text = dt.Rows[0]["Experience"].ToString();
                ObjGlobal.getPictureFromDatabase(picTeacher, dt, 0, "TPhoto");
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
                case "Teacher name":
                    GetDataBind("SELECT * From TeacherRegister WHERE TeacherName='" + getText.Trim() + "'");
                    break;
                case "Phone no":
                    GetDataBind("SELECT * From TeacherRegister WHERE PhoneNo='" + getText.Trim() + "'");
                    break;
                case "Email":
                    GetDataBind("SELECT * From TeacherRegister WHERE Email='" + getText.Trim() + "'");
                    break;
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
        #endregion

        #region "DataGridView event and other events"
        private void mtxtRegisterDate_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (this.ActiveControl == mtxtRegisterDate)
                return;
         //   if (!e.IsValidInput)
          //  {
           //     MessageBox.Show("Register date or Empty\nThe Date supplied must be a valid date in the format dd/mm/yyyy.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           //     e.Cancel = true;
           //     mtxtRegisterDate.Focus();
            //    mtxtRegisterDate.SelectAll();
            //}
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void dataStaffView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex > 8)  // ignore header row and any column
                return;
            _TeacherId = dataStaffView.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTeacherName.Text = dataStaffView.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (dataStaffView.Rows[e.RowIndex].Cells[2].Value.ToString().Trim().Equals("Male") == true)
            {
                rdMale.Checked = true;
            }
            else
            {
                rdFemale.Checked = true;
            }
            txtAddress.Text = dataStaffView.Rows[e.RowIndex].Cells[3].Value.ToString();
            mtxtRegisterDate.Text = dataStaffView.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPhoneNo.Text = dataStaffView.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtEmail.Text = dataStaffView.Rows[e.RowIndex].Cells[6].Value.ToString();
            cmbExperience.Text = dataStaffView.Rows[e.RowIndex].Cells[7].Value.ToString();
            ObjGlobal.getPictureFromDataGridView(picTeacher, dataStaffView, e, 8);
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
                picTeacher.Image = null;
                picTeacher.Image = Image.FromFile(openFile.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckValidation())
                {
                    return;
                }
                else
                    if (!string.IsNullOrEmpty(objCon.GetSqlData("Select PhoneNo From TeacherRegister Where PhoneNo='" + txtPhoneNo.Text + "'")))
                    {
                        MessageBox.Show("A duplicate phone no can not accepted.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtPhoneNo.Focus();
                        txtPhoneNo.SelectAll();
                        return;
                    }

                ObjTeacher.TeacherId = _TeacherId;
                ObjTeacher.RegisterDate = mtxtRegisterDate.Text;
                ObjTeacher.TeacherName = txtTeacherName.Text;
                if (this.rdMale.Checked == true)
                {
                    ObjTeacher.Gender = rdMale.Text;
                }
                else
                    if (this.rdFemale.Checked == true)
                    {
                        ObjTeacher.Gender = rdFemale.Text;
                    }
                ObjTeacher.Address = txtAddress.Text;
                ObjTeacher.PhoneNo = txtPhoneNo.Text;
                ObjTeacher.Email = txtEmail.Text;
                ObjTeacher.Experience = cmbExperience.Text;
                ObjTeacher.TeacherPhoto = picTeacher;
                ObjTeacher.InsertTeacher();
                MessageBox.Show("Saved Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll();
                dataStaffView.Rows.Clear();
                BindData();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckValidation())
                    return;

                ObjTeacher.TeacherId = _TeacherId;
                ObjTeacher.RegisterDate = mtxtRegisterDate.Text;
                ObjTeacher.TeacherName = txtTeacherName.Text;
                if (this.rdMale.Checked == true)
                {
                    ObjTeacher.Gender = rdMale.Text;
                }
                else
                    if (this.rdFemale.Checked == true)
                    {
                        ObjTeacher.Gender = rdFemale.Text;
                    }
                ObjTeacher.Address = txtAddress.Text;
                ObjTeacher.PhoneNo = txtPhoneNo.Text;
                ObjTeacher.Email = txtEmail.Text;
                ObjTeacher.Experience = cmbExperience.Text;
                ObjTeacher.TeacherPhoto = picTeacher;
                ObjTeacher.UpdateTeacher();
                MessageBox.Show("Update Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll();
                dataStaffView.Rows.Clear();
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
                Result = MessageBox.Show("Are you sure you want to delete record?", Global.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    ObjTeacher.TeacherId = _TeacherId.ToString();
                    ObjTeacher.DeleteTeacher();
                    MessageBox.Show("Delete Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                    dataStaffView.Rows.Clear();
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
            this.Close();
        }
        #endregion
    }
}