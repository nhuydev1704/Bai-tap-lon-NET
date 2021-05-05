using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CollegeManagementSystem.Users
{
    public partial class frmCreateUser : Form
    {
        #region "Objects and variables"
        string _UId = "";
        string _Mode = "";
        lib.UserInfo ObjUserClass = new lib.UserInfo();
        lib.DatabaseConnection objCon = new lib.DatabaseConnection();
        Global objGlobal = new Global();
        #endregion

        public frmCreateUser()
        {
            InitializeComponent();
            this.chkActive.Checked = true;
        }

        #region "Form events"
        private void frmCreateUser_Load(object sender, EventArgs e)
        {
            _Mode = "NEW";
            GenerateNumber();
            timer1.Interval = 7 * 1000; //7 * 1000 = 7000, it means 7 second.
            timer1.Start();
            BindData();
        }

        private void frmCreateUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
        }
        #endregion

        #region "Methods"
        private void NewMode(bool _newmode)
        {
            if (_newmode == true)
            {
                this._Mode = "NEW";
                GenerateNumber();
                this.btnSave.Enabled = true;
                this.btnUpdate.Enabled = false;
                this.btnDelete.Enabled = false;
            }
        }

        private bool Validation()
        {
            bool isValid = true;
            if (txtUserName.Text == string.Empty)
            {
                this.lblMessageBox.ForeColor = Color.Red;
                this.lblMessageBox.Text = "User name is required.";
                txtUserName.Focus();
                isValid = false;
            }
            if (!string.IsNullOrEmpty(objCon.GetSqlData("Select UserName From ULogin Where UserName='" + txtUserName.Text + "'")))
            {
                this.lblMessageBox.ForeColor = Color.Red;
                this.lblMessageBox.Text = "A duplicate user name can not accepted.";
                txtUserName.Focus();
                txtUserName.SelectAll();
                isValid = false; ;
            }
            if (objGlobal.IsAllDigits(txtUserName.Text))
            {
                this.lblMessageBox.Text = "User name can not accepted digits";
                txtUserName.Focus();
                txtUserName.SelectAll();
                isValid = false;
            }
            //if (!objGlobal.getInvalidInput(txtUserName.Text, Global.PatternA, "Invalid negative number",Global.Caption))
            //{
            //    txtUserName.Focus();
            //    txtUserName.SelectAll();
            //    isValid = false;
            //}
            if (txtLoginName.Text == string.Empty)
            {
                this.lblMessageBox.ForeColor = Color.Red;
                this.lblMessageBox.Text = "Login name is required.";
                txtLoginName.Focus();
                isValid = false; ;
            }
            if (txtPassword.Text == string.Empty)
            {
                this.lblMessageBox.ForeColor = Color.Red;
                this.lblMessageBox.Text = "Password is required.";
                txtPassword.Focus();
                isValid = false; ;
            }
            if (txtPassword.Text.Trim().Length > 15 || txtPassword.Text.Trim().Length < 6)
            {
                this.lblMessageBox.Text = "Password length must be between 6 to 15 digits accept.";
                txtPassword.SelectAll();
                txtPassword.Focus();
                isValid = false;
            }
            if (txtConfirmPSW.Text == string.Empty)
            {
                this.lblMessageBox.ForeColor = Color.Red;
                this.lblMessageBox.Text = "Confirm password is empty.";
                txtConfirmPSW.Focus();
                isValid = false; ;
            }
            if (txtConfirmPSW.Text.Trim().Length > 15 || txtConfirmPSW.Text.Trim().Length < 6)
            {
                this.lblMessageBox.Text = "Confirm password length must be between 6 to 15 digits accept.";
                txtPassword.SelectAll();
                txtPassword.Focus();
                isValid = false;
            }
            if (txtPassword.Text != txtConfirmPSW.Text)
            {
                this.lblMessageBox.ForeColor = Color.Red;
                this.lblMessageBox.Text = "Password or confirm password is not matched.";
                txtConfirmPSW.Clear();
                txtPassword.Focus();
                txtPassword.SelectAll();
                isValid = false; ;
            }
            if (cmbRole.Text == string.Empty)
            {
                this.lblMessageBox.ForeColor = Color.Red;
                this.lblMessageBox.Text = "Select role.";
                cmbRole.Focus();
                isValid = false; ;
            }
            return isValid;
        }

        private void GenerateNumber()
        {
            _UId = Global.AutoNumber("Select Max(UserId) from ULogin", 1).ToString();
        }

        private void BindData()
        {
            var SelectQuery = "Select * From ULogin";
            var sql = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = sql.getTable(SelectQuery);
            foreach (DataRow dr in dt.Rows)
            {
                dataUsersView.Rows.Add();
                dataUsersView.Rows[dataUsersView.Rows.Count - 1].Cells["UserId"].Value = dr["UserId"];
                dataUsersView.Rows[dataUsersView.Rows.Count - 1].Cells["UserName"].Value = dr["UserName"];
                dataUsersView.Rows[dataUsersView.Rows.Count - 1].Cells["LoginName"].Value = dr["LoginName"];
                dataUsersView.Rows[dataUsersView.Rows.Count - 1].Cells["Password"].Value = dr["Password"];
                dataUsersView.Rows[dataUsersView.Rows.Count - 1].Cells["Role"].Value = dr["UserType"];
                dataUsersView.Rows[dataUsersView.Rows.Count - 1].Cells["Active"].Value = dr["Active"];
            }
        }

        private void ResetAll()
        {
            this._UId = "";
            txtUserName.Clear();
            txtLoginName.Clear();
            txtPassword.Clear();
            txtConfirmPSW.Clear();
            cmbRole.SelectedIndex = -1;
            txtUserName.Focus();
        }
        #endregion

        #region "Timer, Gridview, CheckBox Events"
        private void dataUsersView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex > 5)  // ignore header row and any column
                return;
            _UId = dataUsersView.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtUserName.Text = dataUsersView.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtLoginName.Text = dataUsersView.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPassword.Text = dataUsersView.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtConfirmPSW.Text = dataUsersView.Rows[e.RowIndex].Cells[3].Value.ToString();
            cmbRole.Text = dataUsersView.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (dataUsersView.Rows[e.RowIndex].Cells[5].Value.Equals("Yes") == true)
            {
                chkActive.Checked = true;
            }
            else
            {
                chkActive.Checked = false;
            }
            this.btnSave.Enabled = false;
            this.btnUpdate.Enabled = true;
            this.btnDelete.Enabled = true;
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActive.Checked == true)
            {
                chkActive.Text = "Yes";
            }
            else
            {
                chkActive.Text = "No";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblMessageBox.ResetText();
        }
        #endregion

        #region "Button events"
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation())
                {
                    return;
                }
                else
                {
                    ObjUserClass.UserId = _UId.ToString();
                    ObjUserClass.UserName = txtUserName.Text;
                    ObjUserClass.LoginName = txtLoginName.Text;
                    ObjUserClass.Password = txtPassword.Text;
                    ObjUserClass.Role = cmbRole.Text;
                    if (this.chkActive.Checked == true)
                    {
                        ObjUserClass.Active = "Yes";
                    }
                    else
                    {
                        ObjUserClass.Active = "No";
                    }

                    if (this._Mode == "NEW")
                    {
                        ObjUserClass.CreateNewUser();
                        this.lblMessageBox.ForeColor = Color.Green;
                        this.lblMessageBox.Text = "New user create successfully.";
                        ResetAll();
                        GenerateNumber();
                        dataUsersView.Rows.Clear();
                        BindData();
                    }
                }
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
                if (txtConfirmPSW.Text == string.Empty)
                {
                    this.lblMessageBox.ForeColor = Color.Red;
                    this.lblMessageBox.Text = "Confirm password is empty.";
                    txtConfirmPSW.Focus();
                    return;
                }
                if (txtPassword.Text != txtConfirmPSW.Text)
                {
                    this.lblMessageBox.ForeColor = Color.Red;
                    this.lblMessageBox.Text = "Password or confirm password is not matched.";
                    txtConfirmPSW.Clear();
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                    return;
                }
                else
                {
                    ObjUserClass.UserId = _UId.ToString();
                    ObjUserClass.UserName = txtUserName.Text;
                    ObjUserClass.LoginName = txtLoginName.Text;
                    ObjUserClass.Password = txtPassword.Text;
                    ObjUserClass.Role = cmbRole.Text;
                    if (this.chkActive.Checked == true)
                    {
                        ObjUserClass.Active = "Yes";
                    }
                    else
                    {
                        ObjUserClass.Active = "No";
                    }

                    ObjUserClass.UpdateUsers();
                    this.lblMessageBox.ForeColor = Color.Green;
                    this.lblMessageBox.Text = "Update Successfully.";
                    ResetAll();
                    dataUsersView.Rows.Clear();
                    BindData();
                    NewMode(true);
                }
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
                Result = MessageBox.Show("Do you want to delete this record?", Global.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    ObjUserClass.UserId = _UId;
                    ObjUserClass.DeleteUser();
                    this.lblMessageBox.ForeColor = Color.Green;
                    this.lblMessageBox.Text = "Delete Successfully.";
                    ResetAll();
                    dataUsersView.Rows.Clear();
                    BindData();
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