namespace CollegeManagementSystem.Student
{
    partial class frmAttendance
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picStudent = new System.Windows.Forms.PictureBox();
            this.rdAbsent = new System.Windows.Forms.RadioButton();
            this.rdPresent = new System.Windows.Forms.RadioButton();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.txtRollNo = new System.Windows.Forms.TextBox();
            this.cmbStudentName = new System.Windows.Forms.ComboBox();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridStudentAttendanceData = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Semester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RollNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendanceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attendance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StuId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStudentAttendanceData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picStudent);
            this.groupBox1.Controls.Add(this.rdAbsent);
            this.groupBox1.Controls.Add(this.rdPresent);
            this.groupBox1.Controls.Add(this.datePicker);
            this.groupBox1.Controls.Add(this.txtRollNo);
            this.groupBox1.Controls.Add(this.cmbStudentName);
            this.groupBox1.Controls.Add(this.cmbSemester);
            this.groupBox1.Controls.Add(this.cmbCourse);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(725, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết sinh  viên tham dự";
            // 
            // picStudent
            // 
            this.picStudent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picStudent.BackgroundImage = global::CollegeManagementSystem.Properties.Resources.empty_profile;
            this.picStudent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picStudent.Location = new System.Drawing.Point(538, 17);
            this.picStudent.Name = "picStudent";
            this.picStudent.Size = new System.Drawing.Size(174, 167);
            this.picStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStudent.TabIndex = 15;
            this.picStudent.TabStop = false;
            // 
            // rdAbsent
            // 
            this.rdAbsent.AutoSize = true;
            this.rdAbsent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAbsent.Location = new System.Drawing.Point(180, 122);
            this.rdAbsent.Name = "rdAbsent";
            this.rdAbsent.Size = new System.Drawing.Size(77, 19);
            this.rdAbsent.TabIndex = 7;
            this.rdAbsent.TabStop = true;
            this.rdAbsent.Text = "Vắng mặt";
            this.rdAbsent.UseVisualStyleBackColor = true;
            // 
            // rdPresent
            // 
            this.rdPresent.AutoSize = true;
            this.rdPresent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPresent.Location = new System.Drawing.Point(107, 122);
            this.rdPresent.Name = "rdPresent";
            this.rdPresent.Size = new System.Drawing.Size(64, 19);
            this.rdPresent.TabIndex = 6;
            this.rdPresent.TabStop = true;
            this.rdPresent.Text = "Có mặt";
            this.rdPresent.UseVisualStyleBackColor = true;
            // 
            // datePicker
            // 
            this.datePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(399, 91);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(123, 21);
            this.datePicker.TabIndex = 5;
            // 
            // txtRollNo
            // 
            this.txtRollNo.BackColor = System.Drawing.Color.White;
            this.txtRollNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRollNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRollNo.Location = new System.Drawing.Point(107, 91);
            this.txtRollNo.Name = "txtRollNo";
            this.txtRollNo.ReadOnly = true;
            this.txtRollNo.Size = new System.Drawing.Size(240, 21);
            this.txtRollNo.TabIndex = 4;
            // 
            // cmbStudentName
            // 
            this.cmbStudentName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbStudentName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStudentName.FormattingEnabled = true;
            this.cmbStudentName.Location = new System.Drawing.Point(107, 58);
            this.cmbStudentName.Name = "cmbStudentName";
            this.cmbStudentName.Size = new System.Drawing.Size(415, 23);
            this.cmbStudentName.TabIndex = 3;
            this.cmbStudentName.SelectedIndexChanged += new System.EventHandler(this.cmbStudentName_SelectedIndexChanged);
            // 
            // cmbSemester
            // 
            this.cmbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemester.Enabled = false;
            this.cmbSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSemester.ForeColor = System.Drawing.Color.Black;
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Location = new System.Drawing.Point(429, 26);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(93, 23);
            this.cmbSemester.TabIndex = 2;
            this.cmbSemester.SelectedIndexChanged += new System.EventHandler(this.cmbSemester_SelectedIndexChanged);
            // 
            // cmbCourse
            // 
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCourse.ForeColor = System.Drawing.Color.Black;
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(107, 25);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(240, 23);
            this.cmbCourse.TabIndex = 1;
            this.cmbCourse.SelectedIndexChanged += new System.EventHandler(this.cmbCourse_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(16, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tham dự";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(360, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(16, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã sinh  viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên sinh viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(360, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kỳ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Môn học";
            // 
            // gridStudentAttendanceData
            // 
            this.gridStudentAttendanceData.AllowUserToAddRows = false;
            this.gridStudentAttendanceData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridStudentAttendanceData.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.gridStudentAttendanceData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStudentAttendanceData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Course,
            this.Semester,
            this.StudentName,
            this.RollNo,
            this.AttendanceDate,
            this.Attendance,
            this.StuId,
            this.CId});
            this.gridStudentAttendanceData.Location = new System.Drawing.Point(12, 257);
            this.gridStudentAttendanceData.Name = "gridStudentAttendanceData";
            this.gridStudentAttendanceData.ReadOnly = true;
            this.gridStudentAttendanceData.RowHeadersVisible = false;
            this.gridStudentAttendanceData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridStudentAttendanceData.Size = new System.Drawing.Size(725, 256);
            this.gridStudentAttendanceData.TabIndex = 3;
            this.gridStudentAttendanceData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridStudentAttendanceData_CellClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(258, 212);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 29);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(584, 519);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 29);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(663, 519);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 29);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(336, 212);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 29);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Course
            // 
            this.Course.HeaderText = "Môn Học";
            this.Course.Name = "Course";
            this.Course.ReadOnly = true;
            // 
            // Semester
            // 
            this.Semester.HeaderText = "Học Kỳ";
            this.Semester.Name = "Semester";
            this.Semester.ReadOnly = true;
            // 
            // StudentName
            // 
            this.StudentName.HeaderText = "Tên Sinh Viên";
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            // 
            // RollNo
            // 
            this.RollNo.HeaderText = "Mã Sinh Viên";
            this.RollNo.Name = "RollNo";
            this.RollNo.ReadOnly = true;
            // 
            // AttendanceDate
            // 
            this.AttendanceDate.HeaderText = "Ngày Tham Dự";
            this.AttendanceDate.Name = "AttendanceDate";
            this.AttendanceDate.ReadOnly = true;
            // 
            // Attendance
            // 
            this.Attendance.HeaderText = "Tham Dự";
            this.Attendance.Name = "Attendance";
            this.Attendance.ReadOnly = true;
            // 
            // StuId
            // 
            this.StuId.HeaderText = "StudentId";
            this.StuId.Name = "StuId";
            this.StuId.ReadOnly = true;
            this.StuId.Visible = false;
            // 
            // CId
            // 
            this.CId.HeaderText = "CourseId";
            this.CId.Name = "CId";
            this.CId.ReadOnly = true;
            this.CId.Visible = false;
            // 
            // frmAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(749, 556);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridStudentAttendanceData);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAttendance";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sinh viên tham dự";
            this.Load += new System.EventHandler(this.frmAttendance_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAttendance_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStudentAttendanceData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView gridStudentAttendanceData;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbStudentName;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.TextBox txtRollNo;
        private System.Windows.Forms.RadioButton rdAbsent;
        private System.Windows.Forms.RadioButton rdPresent;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.PictureBox picStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.DataGridViewTextBoxColumn Semester;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RollNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendanceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attendance;
        private System.Windows.Forms.DataGridViewTextBoxColumn StuId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CId;
    }
}