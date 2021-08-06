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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.regStudentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.collegeDataSet1 = new CollegeManagementSystem.CollegeDataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.reportStudentViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.regStudentTableAdapter1 = new CollegeManagementSystem.CollegeDataSetTableAdapters.RegStudentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.regStudentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collegeDataSet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // regStudentBindingSource
            // 
            this.regStudentBindingSource.DataMember = "RegStudent";
            this.regStudentBindingSource.DataSource = this.collegeDataSet1;
            this.regStudentBindingSource.CurrentChanged += new System.EventHandler(this.regStudentBindingSource_CurrentChanged);
            // 
            // collegeDataSet1
            // 
            this.collegeDataSet1.DataSetName = "CollegeDataSet";
            this.collegeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(803, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sinh viên đăng ký báo cáo";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(213, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(141, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(390, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(114, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "In báo cáo";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Báo cáo sinh viên theo khóa học";
            // 
            // reportStudentViewer
            // 
            this.reportStudentViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportStudentViewer.BackColor = System.Drawing.Color.SlateGray;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.regStudentBindingSource;
            this.reportStudentViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportStudentViewer.LocalReport.ReportEmbeddedResource = "CollegeManagementSystem.Reports.Report1.rdlc";
            this.reportStudentViewer.Location = new System.Drawing.Point(12, 70);
            this.reportStudentViewer.Name = "reportStudentViewer";
            this.reportStudentViewer.Size = new System.Drawing.Size(803, 316);
            this.reportStudentViewer.TabIndex = 1;
            // 
            // regStudentTableAdapter1
            // 
            this.regStudentTableAdapter1.ClearBeforeFill = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.collegeDataSet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportStudentViewer;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private CollegeDataSet collegeDataSet;
        private System.Windows.Forms.BindingSource regStudentBindingSource;
        private CollegeDataSetTableAdapters.RegStudentTableAdapter regStudentTableAdapter;
        private CollegeDataSet collegeDataSet1;
        private CollegeDataSetTableAdapters.RegStudentTableAdapter regStudentTableAdapter1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}