using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CollegeManagementSystem.Users
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
            txtUserName.Text = Global.UserName;
        }

        lib.UserInfo objUser = new lib.UserInfo();

        private void btnPWChange_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Nhập mật khẩu mới của bạn và xác nhận mật khẩu", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPassword.Focus();
                return;
            }
            else if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                MessageBox.Show("Mật khẩu mới hoặc xác nhận không khớp", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtConfirmPassword.SelectAll();
                txtConfirmPassword.Focus();
                return;
            }
            else
            {
                objUser.UserName = txtUserName.Text;
                objUser.Password = txtNewPassword.Text;
                objUser.ChangePassword();
                MessageBox.Show("Thay đổi thành công", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
