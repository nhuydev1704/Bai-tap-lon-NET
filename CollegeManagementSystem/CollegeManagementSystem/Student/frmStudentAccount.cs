using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CollegeManagementSystem.Student
{
    public partial class frmStudentAccount : Form
    {
        public frmStudentAccount()
        {
            //Select ProductGroup.GrpDesc,SGrpCode,SGrpDesc,SGrpShortName from ProductGroup left outer join  ProductSubGroup on ProductGroup.GrpCode=ProductSubGroup.GrpCode
            InitializeComponent();
            rdInsertPart.Checked = true;
            cmbFilter.SelectedIndex = 0;
        }

        #region "Object and variable"
        private string SelectMode = "";
        private string FeeId;
        private int indexRow;
        Global objGlobal = new Global();
        lib.FeeManage ObjFeeManage = new lib.FeeManage();
        #endregion

        #region "Form Events"
        private void frmStudentAccount_Load(object sender, EventArgs e)
        {
            SelectMode = "INSERT";
            AutoNumber();
            BindCategory();
            Filter();
            SearchAutoComplete();
        }
        #endregion

        #region "Methods"
        private void ClearAllA()
        {
            txtStudentName.Clear();
            txtRollNo.Clear();
            txtCourse.Clear();
            txtSemester.Clear();
            picStudent.Image = null;
            txtSearch.Focus();
        }

        private void ClearAllB()
        {
            this.cmbCategory.SelectedIndex = -1;
            this.txtAmount.Clear();
            this.mtxtPaidDate.Clear();
            this.txtPaidAmount.Clear();
            this.txtDueAmount.Text = "0";
        }

        private void BindGrid(string sql)
        {
            var getdata = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = getdata.getSearchData(sql);
            if (dt.Rows.Count > 0)
            {
                FeeId = dt.Rows[0]["FeeId"].ToString();
                txtStudentName.Text = dt.Rows[0]["StudentName"].ToString();
                txtRollNo.Text = dt.Rows[0]["RollNo"].ToString();
                txtCourse.Text = dt.Rows[0]["Course"].ToString();
                txtSemester.Text = dt.Rows[0]["Semester"].ToString();
                objGlobal.getPictureFromDatabase(picStudent, dt, 0, "StudentPic");
                foreach (DataRow dr in dt.Rows)
                {
                    dataGridFeeView.Rows.Add();
                    dataGridFeeView.Rows[dataGridFeeView.Rows.Count - 1].Cells["Id"].Value = dr["FeeId"];
                    dataGridFeeView.Rows[dataGridFeeView.Rows.Count - 1].Cells["CategoryName"].Value = dr["CategoryName"];
                    dataGridFeeView.Rows[dataGridFeeView.Rows.Count - 1].Cells["PaidDate"].Value = dr["PaidDate"];
                    dataGridFeeView.Rows[dataGridFeeView.Rows.Count - 1].Cells["TotalAmount"].Value = dr["TotalAmount"];
                    dataGridFeeView.Rows[dataGridFeeView.Rows.Count - 1].Cells["PaidAmount"].Value = dr["PaidAmount"];
                    dataGridFeeView.Rows[dataGridFeeView.Rows.Count - 1].Cells["DueAmount"].Value = dr["DueAmount"];
                }
            }
            else
            {
                MessageBox.Show("Record not found!", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSearch.Focus();
                txtSearch.SelectAll();
            }
        }

        private bool Validation()
        {
            bool isValid = true;
            if (objGlobal.IsNegative(Convert.ToInt32(txtPaidAmount.Text)))
            {
                MessageBox.Show("Enter Positive Value!", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaidAmount.Focus();
                txtPaidAmount.SelectAll();
                isValid = false;
            }
            return isValid;
        }

        private void AutoNumber()
        {
            FeeId = Global.AutoNumber("Select max(FeeId) From FeeMaster", 1).ToString();
        }

        private void BindCategory()
        {
            var selectQuery = "SELECT * from FeeManage";
            var sql = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = sql.getData(selectQuery);
            foreach (DataRow dr in dt.Rows)
            {
                this.cmbCategory.Items.Add(dr["Category"]);
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

        private void SearchAutoComplete()
        {
            switch (cmbFilter.Text)
            {
                case "Roll no":
                    Global.AutoComplete(txtSearch, "Select RollNo From Regstudent");
                    break;
                case "Student name":
                    Global.AutoComplete(txtSearch, "Select StudentName From Regstudent");
                    break;
                case "Phone no":
                    Global.AutoComplete(txtSearch, "Select PhoneNo From Regstudent");
                    break;
                case "Email":
                    Global.AutoComplete(txtSearch, "Select Email From Regstudent");
                    break;
            }
        }

        private void GetDataBind(string sql)
        {
            var getdata = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = getdata.getSearchData(sql);
            if (dt.Rows.Count > 0)
            {
                txtStudentName.Text = dt.Rows[0]["StudentName"].ToString();
                txtRollNo.Text = dt.Rows[0]["RollNo"].ToString();
                txtCourse.Text = dt.Rows[0]["Course"].ToString();
                txtSemester.Text = dt.Rows[0]["Semester"].ToString();
                objGlobal.getPictureFromDatabase(picStudent, dt, 0, "StudentPic");
            }
            else
            {
                MessageBox.Show("Record not found!", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSearch.Focus();
                txtSearch.SelectAll();
            }
        }

        private void _FeeDetails()
        {
            for (int i = 0; i < dataGridFeeView.Rows.Count; i++)
            {
                ObjFeeManage.FeeId = Convert.ToInt32(FeeId);
                ObjFeeManage.CategoryName = dataGridFeeView.Rows[i].Cells["CategoryName"].Value.ToString();
                ObjFeeManage.TotalAmount = Convert.ToInt32(dataGridFeeView.Rows[i].Cells["TotalAmount"].Value.ToString());
                ObjFeeManage.PaidDate = dataGridFeeView.Rows[i].Cells["PaidDate"].Value.ToString();
                ObjFeeManage.PaidAmount = Convert.ToInt32(dataGridFeeView.Rows[i].Cells["PaidAmount"].Value.ToString());
                ObjFeeManage.DueAmount = dataGridFeeView.Rows[i].Cells["DueAmount"].Value.ToString();
                if (this.SelectMode == "INSERT")
                {
                    ObjFeeManage.AddFeeDetails();
                }
                else
                    if (this.SelectMode == "VIEWUPDATE")
                    {
                        ObjFeeManage.UpdateFeeDetails();
                    }
            }
        }
        #endregion

        #region "All Events"
        private void rdInsertPart_CheckedChanged(object sender, EventArgs e)
        {
            this.SelectMode = "INSERT";
            this.cmbFilter.Enabled = true;
            this.cmbFilter.SelectedIndex = 0;
            this.txtSearch.Clear();
            picStudent.Image = null;
            Filter();
            AutoNumber();
            this.btnSave.Enabled = true;
            this.btnUpdate.Enabled = false;
            this.btnDelete.Enabled = false;
        }

        private void rdViewAndUpdatePart_CheckedChanged(object sender, EventArgs e)
        {
            this.SelectMode = "VIEWUPDATE";
            this.cmbFilter.Enabled = false;
            this.cmbFilter.SelectedIndex = 2;
            this.txtSearch.Enabled = true;
            this.btnSearch.Enabled = true;
            this.btnSave.Enabled = false;
            this.btnUpdate.Enabled = true;
            this.btnDelete.Enabled = true;
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
            txtSearch.Clear();
            txtStudentName.Clear();
            txtRollNo.Clear();
            txtCourse.Clear();
            txtSemester.Clear();
            SearchAutoComplete();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtPaidAmount.Clear();
            //this.txtDueAmount.Clear();
            var selectQuery = "SELECT * from FeeManage Where Category='" + cmbCategory.Text + "'";
            var sql = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = sql.getData(selectQuery);
            foreach (DataRow dr in dt.Rows)
            {
                this.txtAmount.Text = dr["Amount"].ToString();
            }
        }

        private void dataGridFeeView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex > 5)  // ignore header row and any column
                return;
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridFeeView.Rows[indexRow];
            this.FeeId = row.Cells[0].Value.ToString();
            this.cmbCategory.Text = row.Cells[1].Value.ToString();
            this.mtxtPaidDate.Text = row.Cells[2].Value.ToString();
            this.txtAmount.Text = row.Cells[3].Value.ToString();
            this.txtPaidAmount.Text = row.Cells[4].Value.ToString();
            this.txtDueAmount.Text = row.Cells[5].Value.ToString();
            this.btnAdd.Text = "Modify";
            this.btnDeleteFee.Enabled = true;
        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtDueAmount.Text = ObjFeeManage.CalculateFee(Convert.ToInt32(txtAmount.Text), Convert.ToInt32(txtPaidAmount.Text)).ToString();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (this.SelectMode == "INSERT")
                {
                    switch (cmbFilter.Text)
                    {
                        case "Roll no":
                            GetDataBind("Select * From Regstudent Where RollNo='" + txtSearch.Text + "'");
                            break;
                        case "Student name":
                            GetDataBind("Select * From Regstudent Where StudentName='" + txtSearch.Text + "'");
                            break;
                        case "Phone no":
                            GetDataBind("Select * From Regstudent Where PhoneNo='" + txtSearch.Text + "'");
                            break;
                        case "Email":
                            GetDataBind("Select * From Regstudent Where Email='" + txtSearch.Text + "'");
                            break;
                    }
                }
                else
                    if (this.SelectMode == "VIEWUPDATE")
                    {
                        BindGrid("Select FeeMaster.FeeId,FeeMaster.StudentName, FeeMaster.RollNo, FeeMaster.Course, FeeMaster.Semester,RegStudent.StudentPic, FeeDetails.CategoryName, FeeDetails.PaidDate, FeeDetails.TotalAmount, FeeDetails.PaidAmount,FeeDetails.DueAmount From FeeMaster,FeeDetails,RegStudent Where RegStudent.StudentName=FeeMaster.StudentName AND FeeMaster.StudentName='" + txtSearch.Text + "'");
                    }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation())
                {
                    return;
                }
                else
                {
                    if (this.btnAdd.Text == "Add")
                    {
                        dataGridFeeView.Rows.Add();
                        dataGridFeeView.Rows[dataGridFeeView.Rows.Count - 1].Cells["Id"].Value = FeeId;
                        dataGridFeeView.Rows[dataGridFeeView.Rows.Count - 1].Cells["CategoryName"].Value = cmbCategory.Text;
                        dataGridFeeView.Rows[dataGridFeeView.Rows.Count - 1].Cells["PaidDate"].Value = mtxtPaidDate.Text;
                        dataGridFeeView.Rows[dataGridFeeView.Rows.Count - 1].Cells["TotalAmount"].Value = txtAmount.Text;
                        dataGridFeeView.Rows[dataGridFeeView.Rows.Count - 1].Cells["PaidAmount"].Value = txtPaidAmount.Text;
                        dataGridFeeView.Rows[dataGridFeeView.Rows.Count - 1].Cells["DueAmount"].Value = txtDueAmount.Text;
                        MessageBox.Show("Add Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        if (this.btnAdd.Text == "Modify")
                        {
                            DataGridViewRow row = dataGridFeeView.Rows[indexRow];
                            row.Cells[0].Value = FeeId;
                            row.Cells[1].Value = cmbCategory.Text;
                            row.Cells[2].Value = mtxtPaidDate.Text;
                            row.Cells[3].Value = txtAmount.Text;
                            row.Cells[4].Value = txtPaidAmount.Text;
                            row.Cells[5].Value = txtDueAmount.Text;
                            MessageBox.Show("Modify Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.btnAdd.Text = "Add";
                            this.btnDeleteFee.Enabled = false;
                        }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteFee_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete?", Global.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information).ToString().ToLower() == "yes")
            {
                this.dataGridFeeView.Rows.Remove(this.dataGridFeeView.Rows[indexRow]);
                MessageBox.Show("Delete Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.btnAdd.Text = "Add";
            this.btnDeleteFee.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dataGridFeeView.Rows.Count == 0)
            {
                MessageBox.Show("Please! first insert any data in gridview table.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                try
                {
                    ObjFeeManage.FeeId = Convert.ToInt32(FeeId);
                    ObjFeeManage.StudentName = txtStudentName.Text;
                    ObjFeeManage.RollNo = txtRollNo.Text;
                    ObjFeeManage.Course = txtCourse.Text;
                    ObjFeeManage.Semester = txtSemester.Text;
                    if (this.SelectMode == "INSERT")
                    {
                        ObjFeeManage.AddFeeMaster();
                        _FeeDetails();
                        MessageBox.Show("Saved Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearAllA();
                        dataGridFeeView.Rows.Clear();
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ObjFeeManage.FeeId = Convert.ToInt32(FeeId);
                ObjFeeManage.StudentName = txtStudentName.Text;
                ObjFeeManage.RollNo = txtRollNo.Text;
                ObjFeeManage.Course = txtCourse.Text;
                ObjFeeManage.Semester = txtSemester.Text;
                if (this.SelectMode == "VIEWUPDATE")
                {
                    _FeeDetails();
                    MessageBox.Show("Update Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllA();
                    dataGridFeeView.Rows.Clear();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //        DialogResult Result;
            //        Result = MessageBox.Show("Do You Want to Delete this Record?", Global.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (Result == DialogResult.Yes)
            //        {
            //            MessageBox.Show("Your Record has been Delete Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //catch (Exception Ex)
            //{
            //    MessageBox.Show(Ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}