namespace CollegeManagementSystem.Reports
{
    partial class frmStudentReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.regStudentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.timKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reportStudentViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.regStudentBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // regStudentBindingSource
            // 
            this.regStudentBindingSource.DataMember = "RegStudent";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.timKiem);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(803, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sinh viên đăng ký báo cáo";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(464, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(53, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // timKiem
            // 
            this.timKiem.Location = new System.Drawing.Point(148, 21);
            this.timKiem.Name = "timKiem";
            this.timKiem.Size = new System.Drawing.Size(301, 20);
            this.timKiem.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm theo tên sinh viên";
            // 
            // reportStudentViewer
            // 
            this.reportStudentViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportStudentViewer.BackColor = System.Drawing.Color.SlateGray;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.regStudentBindingSource;
            this.reportStudentViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.reportStudentViewer.LocalReport.ReportEmbeddedResource = "CollegeManagementSystem.Reports.Report1.rdlc";
            this.reportStudentViewer.Location = new System.Drawing.Point(12, 70);
            this.reportStudentViewer.Name = "reportStudentViewer";
            this.reportStudentViewer.Size = new System.Drawing.Size(803, 316);
            this.reportStudentViewer.TabIndex = 1;
            // 
            // frmStudentReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 398);
            this.Controls.Add(this.reportStudentViewer);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmStudentReports";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo của sinh viên";
            this.Load += new System.EventHandler(this.frmStudentReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.regStudentBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportStudentViewer;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox timKiem;
        private System.Windows.Forms.Label label1;
        private CollegeDataSet collegeDataSet;
        private System.Windows.Forms.BindingSource regStudentBindingSource;
        private CollegeDataSetTableAdapters.RegStudentTableAdapter regStudentTableAdapter;
    }
}