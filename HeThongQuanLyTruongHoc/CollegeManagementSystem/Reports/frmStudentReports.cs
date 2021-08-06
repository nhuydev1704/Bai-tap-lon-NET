using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CollegeManagementSystem.Reports
{
    public partial class frmStudentReports : Form
    {
        public frmStudentReports()
        {
            InitializeComponent();
        }

        private void frmStudentReports_Load(object sender, EventArgs e)
        {
            lib.CourseDetails objCourseDetails = new lib.CourseDetails();
            var selectQuery = "SELECT Distinct CourseName from Course";
            var sql = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = sql.getData(selectQuery);
            foreach (DataRow dr in dt.Rows)
            {
                this.comboBox1.Items.Add(dr["CourseName"]);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            /* TODO: This line of code loads data into the 'collegeDataSet.RegStudent' table. You can move, or remove it, as needed.
                regStudentTableAdapter1.Fill(this.collegeDataSet1.RegStudent, "lap trinh");
                this.reportStudentViewer.RefreshReport();*/
                collegeDataSet1.EnforceConstraints = false;
                var strr = comboBox1.Items;
            
                // TODO: This line of code loads data into the 'feeDataSet.FeeMaster' table. You can move, or remove it, as needed.
                this.regStudentTableAdapter1.Fill(this.collegeDataSet1.RegStudent, "Lap Trinh");
                // TODO: This line of code loads data into the 'feeDataSet.FeeDetails' table. You can move, or remove it, as needed.
                
                reportStudentViewer.RefreshReport();
            
        }

        private void regStudentBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void timKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
