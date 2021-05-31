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
    public partial class frmMDIMasterPage : Form
    {
        public frmMDIMasterPage()
        {
            InitializeComponent();
            this.toolMenuFeeReports.Visible = true;
            this.mnuStripCMS.Renderer = new ToolStripProfessionalRenderer(new lib.CustomMenuColor());
        }
        
        private void frmMDIMasterPage_Load(object sender, EventArgs e)
        {
            frmLogin UserLogin = new frmLogin();
            UserLogin.ShowDialog();
            LoginMode(true);
            MenuEvent(true);
        }

        private void LoginMode(bool Mode)
        {
            if (Mode == true)
            {
                toolStripUserName.Text = "[Tên Người Dùng:- " + Global.UserName + "]";
                toolStripRole.Text = "[Chức Vụ:- " + Global.UserType + "]";
            }
            else
            {
                this.toolStripUserName.Text = "Process...";
                this.toolStripRole.Text = "Process...";
            }
        }

        private void MenuEvent(bool Mode)
        {
            if (Mode == true)
            {
                if (Global.UserType == "User")
                {
                    editToolStripMenuItem.Enabled = false;
                }
                else
                {
                    editToolStripMenuItem.Enabled = true;
                }
            }
        }

        #region "MDI Master page menus"

        #region "File Menu"
        private void mnuItemLogOff_Click(object sender, EventArgs e)
        {
            LoginMode(false);
            frmLogin UserLogin = new frmLogin();
            UserLogin.ShowDialog();
            LoginMode(true);
            MenuEvent(true);
        }

        private void mnuItemChngPsw_Click(object sender, EventArgs e)
        {
            Users.frmChangePassword ChangePassword = new Users.frmChangePassword();
            ChangePassword.ShowDialog();
        }

        private void mnuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region "Edit Menu"
        private void toolMenuCreateUsers_Click(object sender, EventArgs e)
        {
            Users.frmCreateUser mnuCreateUsers = new Users.frmCreateUser();
            mnuCreateUsers.ShowDialog();
        }

        private void toolMenuSemester_Click(object sender, EventArgs e)
        {
            CourseDetails.frmSemester mnuSemester = new CourseDetails.frmSemester();
            mnuSemester.ShowDialog();
        }

        private void toolMenuCourse_Click(object sender, EventArgs e)
        {
            CourseDetails.frmCourse mnuCourse = new CourseDetails.frmCourse();
            mnuCourse.ShowDialog();
        }

        private void toolMenuSubject_Click(object sender, EventArgs e)
        {
            CourseDetails.frmSubject mnuSubject = new CourseDetails.frmSubject();
            mnuSubject.ShowDialog();
        }

        private void toolMenuFeeManage_Click(object sender, EventArgs e)
        {
            Utility.frmFeeManage FeeManage = new Utility.frmFeeManage();
            FeeManage.ShowDialog();
        }
        #endregion

        #region "Student Menu"
        private void toolMenuStudentAdmission_Click(object sender, EventArgs e)
        {
            Student.frmStudentRegister mnuStudentReg = new Student.frmStudentRegister();
            mnuStudentReg.ShowDialog();
        }

        private void toolMenuAttendance_Click(object sender, EventArgs e)
        {
            Student.frmAttendance mnuAttendance = new Student.frmAttendance();
            mnuAttendance.ShowDialog();
        }

        private void toolMenuAttendanceHistory_Click(object sender, EventArgs e)
        {
            Student.frmSAttendanceHistory SAttendanceHistory = new Student.frmSAttendanceHistory();
            SAttendanceHistory.ShowDialog();
        }

        private void toolMenuStudentFee_Click(object sender, EventArgs e)
        {
            Student.frmStudentAccount StudentAccount = new Student.frmStudentAccount();
            StudentAccount.ShowDialog();
        }

        private void toolMenuFeeView_Click(object sender, EventArgs e)
        {
            frmStudentFeeView frmStudentFeeView = new frmStudentFeeView();
            frmStudentFeeView.ShowDialog();
        }
        #endregion

        #region "Teacher Menu"
        private void toolMenuTeacherRegister_Click(object sender, EventArgs e)
        {
            Teacher.frmTeacherRegister TeacherRegister = new Teacher.frmTeacherRegister();
            TeacherRegister.ShowDialog();
        }

        private void toolMenuTeacherAttendance_Click(object sender, EventArgs e)
        {
            Teacher.frmTeacherAttendance TeacherAttendance = new Teacher.frmTeacherAttendance();
            TeacherAttendance.ShowDialog();
        }

        private void toolMenuTimeSchedule_Click(object sender, EventArgs e)
        {
            Teacher.frmTimeSchedule TimeSchedule = new Teacher.frmTimeSchedule();
            TimeSchedule.ShowDialog();
        }

        private void toolMenuTeacherAttendanceHistory_Click(object sender, EventArgs e)
        {
            Teacher.frmTAttendanceHistory TAttendanceHistory = new Teacher.frmTAttendanceHistory();
            TAttendanceHistory.ShowDialog();
        }

        private void toolMenuScheduleHistory_Click(object sender, EventArgs e)
        {
            Teacher.frmTimeScheduleHistory TimeScheduleHisrory = new Teacher.frmTimeScheduleHistory();
            TimeScheduleHisrory.ShowDialog();
        }
        #endregion

        #region "Reports Menu"
        private void toolMenuStudentReports_Click(object sender, EventArgs e)
        {
            Reports.frmStudentReports StudentReports = new Reports.frmStudentReports();
            StudentReports.ShowDialog();
        }

        private void toolMenuFeeReports_Click(object sender, EventArgs e)
        {
            Reports.frmFeeReport FeeReports = new Reports.frmFeeReport();
            FeeReports.ShowDialog();
        }
        #endregion

        #region "Tools Menu"
        private void toolMenudatabaseBackupRestore_Click(object sender, EventArgs e)
        {
            DatabaseBackup.frmDatabaseBackup DatabaseBackups = new DatabaseBackup.frmDatabaseBackup();
            DatabaseBackups.ShowDialog();
        }
        #endregion

        #region "Help Menu"
        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutUs AboutUs = new frmAboutUs();
            AboutUs.ShowDialog();
        }
        #endregion

        #endregion
    }
}
