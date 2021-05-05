using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace CollegeManagementSystem.Reports
{
    public partial class frmFeeReport : Form
    {
        public frmFeeReport()
        {
            InitializeComponent();
        }

        private void frmFeeReport_Load(object sender, EventArgs e)
        {
            
        }

        private void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("FeeDetailsDataSet", (object)this.feeDataSet.FeeDetails));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                MessageBox.Show("Enter Fee id.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSearch.Focus();
                return;
            }
            else
            {
                // TODO: This line of code loads data into the 'feeDataSet.FeeMaster' table. You can move, or remove it, as needed.
                this.feeMasterTableAdapter.Fill(this.feeDataSet.FeeMaster, Convert.ToInt32(txtSearch.Text));
                // TODO: This line of code loads data into the 'feeDataSet.FeeDetails' table. You can move, or remove it, as needed.
                this.feeDetailsTableAdapter.Fill(this.feeDataSet.FeeDetails, Convert.ToInt32(txtSearch.Text));
                this.rptFeeViewer.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(SubreportProcessingEventHandler);
                rptFeeViewer.RefreshReport();
            }
        }
    }
}
