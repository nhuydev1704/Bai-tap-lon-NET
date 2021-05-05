using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CollegeManagementSystem.Utility
{
    public partial class frmFeeManage : Form
    {
        public frmFeeManage()
        {
            InitializeComponent();
        }

        #region "Object and variable"
        private string FeeCategoryId;
        lib.FeeManage ObjFeeManage = new lib.FeeManage();
        #endregion

        #region "Form Methods"
        private void frmFeeManage_Load(object sender, EventArgs e)
        {
            AutoNumber();
            BindData();
        }

        private void frmFeeManage_KeyDown(object sender, KeyEventArgs e)
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
                    this.btnSave.Text = "&Save";
                    this.btnDelete.Enabled = false;
                }
        }
        #endregion

        #region "Methods"
        private void ClearAll()
        {
            FeeCategoryId = "";
            txtCategory.Clear();
            txtAmount.Clear();
            AutoNumber();
            txtCategory.Focus();
        }

        private void BindData()
        {
            string Data = "SELECT * From FeeManage";
            var getdata = new lib.DatabaseConnection();
            DataTable dt = new DataTable();
            dt = getdata.getTable(Data);
            foreach (DataRow dr in dt.Rows)
            {
                dataGridFeeManage.Rows.Add();
                dataGridFeeManage.Rows[dataGridFeeManage.Rows.Count - 1].Cells["Id"].Value = dr["Id"];
                dataGridFeeManage.Rows[dataGridFeeManage.Rows.Count - 1].Cells["Category"].Value = dr["Category"];
                dataGridFeeManage.Rows[dataGridFeeManage.Rows.Count - 1].Cells["Amount"].Value = dr["Amount"];
            }
        }

        protected void AutoNumber()
        {
            FeeCategoryId = Global.AutoNumber("Select max(Id) From FeeManage", 1).ToString();
        }
        #endregion

        #region "GridView events"
        private void dataGridFeeManage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex > 2)  // ignore header row and any column
                return;
            this.FeeCategoryId = dataGridFeeManage.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCategory.Text = dataGridFeeManage.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtAmount.Text = dataGridFeeManage.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.btnSave.Text = "&Update";
            this.btnDelete.Enabled = true;
        }
        #endregion

        #region "Button events"
        private void btnSave_Click(object sender, EventArgs e)
        {
            var objCon = new lib.DatabaseConnection();
            if (this.txtCategory.Text == string.Empty)
            {
                MessageBox.Show("Category name is required.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCategory.Focus();
                return;
            }
            else
                if (txtAmount.Text == string.Empty)
                {
                    MessageBox.Show("Amount is required.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAmount.Focus();
                    return;
                }
                else
                {
                    try
                    {
                        ObjFeeManage.CategoryId = Convert.ToInt32(FeeCategoryId.ToString());
                        ObjFeeManage.CategoryName = txtCategory.Text;
                        ObjFeeManage.TotalAmount =Convert.ToInt32(txtAmount.Text);
                        if (this.btnSave.Text == "&Save")
                        {
                            if (!string.IsNullOrEmpty(objCon.GetSqlData("Select Category from FeeManage Where Category= '" + txtCategory.Text.Trim() + "'")))
                            {
                                MessageBox.Show("A duplicate category can not be applied.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtCategory.Focus();
                                txtCategory.SelectAll();
                                return;
                            }
                            ObjFeeManage.AddFeeManage();
                            MessageBox.Show("Saved Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            if (this.btnSave.Text == "&Update")
                            {
                                ObjFeeManage.UpdateFeeManage();
                                MessageBox.Show("Update Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.btnSave.Text = "&Save";
                                this.btnDelete.Enabled = false;
                            }
                        ClearAll();
                        dataGridFeeManage.Rows.Clear();
                        BindData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                    ObjFeeManage.CategoryId = Convert.ToInt32(FeeCategoryId.ToString());
                    ObjFeeManage.DeleteFeeManage();
                    MessageBox.Show("Delete Successfully.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                    dataGridFeeManage.Rows.Clear();
                    BindData();
                    this.btnSave.Text = "&Save";
                    this.btnDelete.Enabled = false;
                }
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
