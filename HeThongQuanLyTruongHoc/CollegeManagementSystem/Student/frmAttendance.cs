using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

namespace CollegeManagementSystem.Student
{
    public partial class frmAttendance : Form
    {
        #region "Object and variables"
        private string Sid;
        private string CourseId;
        private int AttendanceId;
        private int indexRow;
        lib.StudentDetails ObjAttendance = new lib.StudentDetails();
        Global objGlobal = new Global();
        #endregion

        public frmAttendance()
        {
            InitializeComponent();
        }

        #region "Form events"
        private void frmAttendance_Load(object sender, EventArgs e)
        {
            CheckDataGridTable();
            GenerateGridViewAutoNo();
            CourseList();
        }

        private void frmAttendance_KeyDown(object sender, KeyEventArgs e)
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

        #region "Methods"
        private void ResetAll()
        {
            this.Sid = "";
            this.CourseId = "";
            picStudent.Image = null;
            cmbCourse.SelectedIndex = -1;
            cmbSemester.SelectedIndex = -1;
            cmbStudentName.ResetText();
            cmbStudentName.Items.Clear();
            cmbStudentName.DropDownHeight = 106;
            txtRollNo.Clear();
            rdPresent.Checked = false;
            rdAbsent.Checked = false;
            cmbStudentName.Focus();
        }

        private void CheckDataGridTable()
        {
            if (this.gridStudentAttendanceData.Rows.Count != 0)
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
            AttendanceId = Global.AutoNumber("Select max(Id) From StuAttendance", 1);
            foreach (DataGridViewRow row in gridStudentAttendanceData.Rows)
            {
                row.Cells["Id"].Value = AttendanceId;
                AttendanceId++;
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
                CourseId = dr["Id"].ToString();
            }
        }

        private bool CheckValidation()
        {
            bool isValid = true;
            if (this.cmbCourse.Text == string.Empty)
            {
                MessageBox.Show("Select course.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbCourse.Focus();
                isValid = false;
            }
            else
                if (this.cmbSemester.Text == string.Empty)
                {
                    MessageBox.Show("Select semester.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbSemester.Focus();
                    isValid = false;
                }
                else
                    if (this.cmbStudentName.Text == string.Empty)
                    {
                        MessageBox.Show("Select Student name.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cmbStudentName.Focus();
                        isValid = false;
                    }
                    else
                        if (this.txtRollNo.Text == string.Empty)
                        {
                            MessageBox.Show("Roll no is empty, Select student name to display roll no.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtRollNo.Focus();
                            isValid = false;
                        }
                        else
                            if (this.rdPresent.Checked==false && this.rdAbsent.Checked==false)
                            {
                                MessageBox.Show("Choose attendance .", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                isValid = false;
                            }
            return isValid;
        }
        #endregion

        #region "ComboBox and Gridview events"
        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbSemester.Enabled = true;
            BindDataA("SELECT * from Course Where CourseName='" + cmbCourse.Text + "'");
        }

        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbStudentName.ResetText();
            this.cmbStudentName.Items.Clear();
            this.cmbStudentName.DropDownHeight = 106;
            txtRollNo.Clear();
            picStudent.Image = null;
            Sid = "";
            CourseId = "";
            BindDataB("SELECT * from Course Where CourseName='" + cmbCourse.Text + "' AND Semester='" + cmbSemester.Text + "'");
            var sql = "SELECT * from RegStudent Where Course='" + cmbCourse.Text + "' AND Semester='" + cmbSemester.Text + "'";
            var getdata = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = getdata.getSearchData(sql);
            foreach (DataRow dr in dt.Rows)
            {
                this.cmbStudentName.Items.Add(dr["StudentName"]);
            }
        }

        private void cmbStudentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sql = "SELECT * from RegStudent Where StudentName='" + cmbStudentName.Text + "'";
            var getdata = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = getdata.getSearchData(sql);
            foreach (DataRow dr in dt.Rows)
            {
                this.Sid = dr["Id"].ToString();
                this.txtRollNo.Text = dr["RollNo"].ToString();
                objGlobal.getPictureFromDatabase(picStudent, dt, 0, "StudentPic");
            }
        }

        private void gridStudentAttendanceData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex > 8)  // ignore header row and any column
                return;
            indexRow = e.RowIndex;
            DataGridViewRow row = gridStudentAttendanceData.Rows[indexRow];
            this.AttendanceId = Convert.ToInt32(row.Cells[0].Value.ToString());
            this.cmbCourse.Text = row.Cells[1].Value.ToString();
            this.cmbSemester.Text = row.Cells[2].Value.ToString();
            this.cmbStudentName.Text = row.Cells[3].Value.ToString();
            this.txtRollNo.Text = row.Cells[4].Value.ToString();
            this.datePicker.Text = row.Cells[5].Value.ToString();
            if (row.Cells[6].Value.ToString().Equals(rdPresent.Text) == true)
            {
                this.rdPresent.Checked = true;
            }
            else
            {
                this.rdAbsent.Checked = true;
            }
            this.Sid = row.Cells[7].Value.ToString();
            this.CourseId = row.Cells[8].Value.ToString();

            this.btnAdd.Text = "Modify";
            this.btnDelete.Enabled = true;
        }
        #endregion

        #region "Button events [Save, Update, Delete]"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckValidation())
                return;
            try
            {
                if (this.btnAdd.Text == "Thêm")
                {
                    gridStudentAttendanceData.Rows.Add();
                    gridStudentAttendanceData.Rows[gridStudentAttendanceData.Rows.Count - 1].Cells["Id"].Value = AttendanceId;
                    gridStudentAttendanceData.Rows[gridStudentAttendanceData.Rows.Count - 1].Cells["StudentName"].Value = cmbStudentName.Text;
                    gridStudentAttendanceData.Rows[gridStudentAttendanceData.Rows.Count - 1].Cells["RollNo"].Value = txtRollNo.Text;
                    gridStudentAttendanceData.Rows[gridStudentAttendanceData.Rows.Count - 1].Cells["Course"].Value = cmbCourse.Text;
                    gridStudentAttendanceData.Rows[gridStudentAttendanceData.Rows.Count - 1].Cells["Semester"].Value = cmbSemester.Text;
                    gridStudentAttendanceData.Rows[gridStudentAttendanceData.Rows.Count - 1].Cells["AttendanceDate"].Value = datePicker.Text;
                    if (this.rdPresent.Checked == true)
                    {
                        gridStudentAttendanceData.Rows[gridStudentAttendanceData.Rows.Count - 1].Cells["Attendance"].Value = rdPresent.Text;
                    }
                    else
                        if (this.rdAbsent.Checked == true)
                        {
                            gridStudentAttendanceData.Rows[gridStudentAttendanceData.Rows.Count - 1].Cells["Attendance"].Value = rdAbsent.Text;
                        }
                    gridStudentAttendanceData.Rows[gridStudentAttendanceData.Rows.Count - 1].Cells["StuId"].Value = Sid;
                    gridStudentAttendanceData.Rows[gridStudentAttendanceData.Rows.Count - 1].Cells["CId"].Value = CourseId;
                    MessageBox.Show("Thêm thành công.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetAll();
                }
                else
                    if (this.btnAdd.Text == "Modify")
                    {
                        DataGridViewRow newDataRow = gridStudentAttendanceData.Rows[indexRow];
                        newDataRow.Cells[0].Value = AttendanceId;
                        newDataRow.Cells[1].Value = cmbCourse.Text;
                        newDataRow.Cells[2].Value = cmbSemester.Text;
                        newDataRow.Cells[3].Value = cmbStudentName.Text;
                        newDataRow.Cells[4].Value = txtRollNo.Text;
                        newDataRow.Cells[5].Value = datePicker.Text;
                        if (this.rdPresent.Checked == true)
                        {
                            newDataRow.Cells[6].Value = rdPresent.Text;
                        }
                        else
                            if (this.rdAbsent.Checked == true)
                            {
                                newDataRow.Cells[6].Value = rdAbsent.Text;
                            }
                        newDataRow.Cells[7].Value = Sid;
                        newDataRow.Cells[8].Value = CourseId;
                        MessageBox.Show("Xác nhận thành công.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetAll();
                        this.btnAdd.Text = "Thêm";
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
            if (MessageBox.Show("Bạn chắc chắn muốn xóa?", Global.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information).ToString().ToLower() == "yes")
            {
                this.gridStudentAttendanceData.Rows.Remove(this.gridStudentAttendanceData.Rows[indexRow]);
                MessageBox.Show("Xóa thành công.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ResetAll();
            this.btnAdd.Text = "Thêm";
            this.btnDelete.Enabled = false;
            GenerateGridViewAutoNo();
            CheckDataGridTable();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridStudentAttendanceData.Rows.Count; i++)
                {
                    ObjAttendance.AttendanceId = Convert.ToInt32(gridStudentAttendanceData.Rows[i].Cells["Id"].Value.ToString());
                    ObjAttendance.StudentName = gridStudentAttendanceData.Rows[i].Cells["StudentName"].Value.ToString();
                    ObjAttendance.RollNo = gridStudentAttendanceData.Rows[i].Cells["RollNo"].Value.ToString();
                    ObjAttendance.Course = gridStudentAttendanceData.Rows[i].Cells["Course"].Value.ToString();
                    ObjAttendance.Semester = gridStudentAttendanceData.Rows[i].Cells["Semester"].Value.ToString();
                    ObjAttendance.AttendanceDate = gridStudentAttendanceData.Rows[i].Cells["AttendanceDate"].Value.ToString();
                    ObjAttendance.Attendance = gridStudentAttendanceData.Rows[i].Cells["Attendance"].Value.ToString();
                    ObjAttendance.SId = gridStudentAttendanceData.Rows[i].Cells["StuId"].Value.ToString();
                    ObjAttendance.CourseId = gridStudentAttendanceData.Rows[i].Cells["CId"].Value.ToString();
                    ObjAttendance.AddAttendance();
                }
                MessageBox.Show("Lưu thành công.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridStudentAttendanceData.Rows.Clear();
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

        private void button1_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox1.Text = openFileDialog1.FileName;
            }


            string PathCpnn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";

            OleDbConnection conn = new OleDbConnection(PathCpnn);

            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from[sheet1$]", conn);
            DataTable dt = new DataTable();

            myDataAdapter.Fill(dt);

            gridStudentAttendanceData.DataSource = dt;*/

            Microsoft.Office.Interop.Excel._Application importExcelToDataGridViewApp;
            Microsoft.Office.Interop.Excel._Workbook importExcelToDataGridViewWorkbook;
            Microsoft.Office.Interop.Excel._Worksheet importExcelToDataGridViewWorksheet;
            Microsoft.Office.Interop.Excel.Range importExcelToDataGridViewRange;

            try
            {
                importExcelToDataGridViewApp = new Microsoft.Office.Interop.Excel.Application();

                OpenFileDialog importExcelToDataGridViewOpenFileDialog = new OpenFileDialog();
                //importExcelToDataGridViewOpenFileDialog.InitialDirectory = @"C:/Users/Authentic/Desktop";
                //importExcelToDataGridViewOpenFileDialog.RestoreDirectory = true;
                //Dialog Box Title
                importExcelToDataGridViewOpenFileDialog.Title = "Import Excel File To DataGridView";
                //filter Excel Files Only
                importExcelToDataGridViewOpenFileDialog.Filter = "Choose Excel File | *.xlsx;*.xls;*.xlm";
                //If Open Button Is Clicked
                if (importExcelToDataGridViewOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    importExcelToDataGridViewWorkbook = importExcelToDataGridViewApp.Workbooks.Open(importExcelToDataGridViewOpenFileDialog.FileName);
                    importExcelToDataGridViewWorksheet = importExcelToDataGridViewWorkbook.ActiveSheet;
                    importExcelToDataGridViewRange = importExcelToDataGridViewWorksheet.UsedRange;

                    //Start Importing from the second row. Since the first row is column header
                    for (int excelWorkSheetRowIndex = 2; excelWorkSheetRowIndex < importExcelToDataGridViewRange.Rows.Count + 1; excelWorkSheetRowIndex++)
                    {
                        //Convert The Path to image and display it in datagridviewimagecolumn
                        gridStudentAttendanceData.Rows.Add(importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 1].Value, importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 2].Value, importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 3].Value, importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 4].Value, importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 5].Value, importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 6].Value, importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 7].Value, importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 8].Value, importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 9].Value);
                    }
                }
                ResetAll();

            }
            catch (Exception importExcelToDataGridViewException)
            {
                MessageBox.Show("Error" + importExcelToDataGridViewException);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
