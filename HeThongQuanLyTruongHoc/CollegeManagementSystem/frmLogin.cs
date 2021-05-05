using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CollegeManagementSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        #region "Object and methods"
        lib.UserInfo ObjUserClass = new lib.UserInfo();
        Global objGlobal = new Global();
        #endregion

        #region "Form events"
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            else
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
        }
        #endregion

        #region "Button events"
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == string.Empty)
            {
                MessageBox.Show("User name is required.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUserName.Focus();
                return;
            }
            else
                if (objGlobal.IsAllDigits(txtUserName.Text))
                {
                    MessageBox.Show("User name can not accepted digits.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUserName.Focus();
                    txtUserName.SelectAll();
                    return;
                }
            else
                if (txtPassword.Text == string.Empty)
                {
                    MessageBox.Show("Password is required.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPassword.Focus();
                    return;
                }
                else
                {
                    try
                    {
                        ObjUserClass.LoginName = txtUserName.Text;
                        ObjUserClass.Password = txtPassword.Text;
                    using (DataTable dtable = ObjUserClass.LoginUser())
                        {
                            // user login from database
                            if (dtable.Rows.Count < 1)
                            {
                                MessageBox.Show("Incorrect user name or password, Please! Try again.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtUserName.Focus();
                                txtUserName.SelectAll();
                            }
                            else
                            {
                                if (dtable.Rows[0]["Active"].ToString().Trim().Equals("Yes") == true)
                                {
                                    Global.UserName = dtable.Rows[0]["UserName"].ToString();
                                    Global.Password = dtable.Rows[0]["Password"].ToString();
                                    Global.UserType = dtable.Rows[0]["UserType"].ToString();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Sorry!\nYour account is not active. please, contact your administrator.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtUserName.Focus();
                                    txtUserName.SelectAll();
                                    return;
                                }
                            }
                        }
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}