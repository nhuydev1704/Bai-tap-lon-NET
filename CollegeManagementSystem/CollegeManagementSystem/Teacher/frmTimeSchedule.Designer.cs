namespace CollegeManagementSystem.Teacher
{
    partial class frmTimeSchedule
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
            this.picTeacher = new System.Windows.Forms.PictureBox();
            this.cmbPeriod = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTime = new System.Windows.Forms.ComboBox();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.cmbDay = new System.Windows.Forms.ComboBox();
            this.cmbSubjectName = new System.Windows.Forms.ComboBox();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.cmbTeacherName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridTimeScheduleData = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeacherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Semester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeacherCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTeacher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTimeScheduleData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picTeacher);
            this.groupBox1.Controls.Add(this.cmbPeriod);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbTime);
            this.groupBox1.Controls.Add(this.cmbShift);
            this.groupBox1.Controls.Add(this.cmbDay);
            this.groupBox1.Controls.Add(this.cmbSubjectName);
            this.groupBox1.Controls.Add(this.cmbSemester);
            this.groupBox1.Controls.Add(this.cmbCourse);
            this.groupBox1.Controls.Add(this.cmbTeacherName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(769, 220);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thời khóa biểu";
            // 
            // picTeacher
            // 
            this.picTeacher.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picTeacher.BackgroundImage = global::CollegeManagementSystem.Properties.Resources.empty_profile;
            this.picTeacher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picTeacher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTeacher.Location = new System.Drawing.Point(554, 20);
            this.picTeacher.Name = "picTeacher";
            this.picTeacher.Size = new System.Drawing.Size(174, 167);
            this.picTeacher.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTeacher.TabIndex = 16;
            this.picTeacher.TabStop = false;
            // 
            // cmbPeriod
            // 
            this.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPeriod.FormattingEnabled = true;
            this.cmbPeriod.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbPeriod.Location = new System.Drawing.Point(351, 180);
            this.cmbPeriod.Name = "cmbPeriod";
            this.cmbPeriod.Size = new System.Drawing.Size(137, 23);
            this.cmbPeriod.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(285, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Giai đoạn";
            // 
            // cmbTime
            // 
            this.cmbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTime.FormattingEnabled = true;
            this.cmbTime.Items.AddRange(new object[] {
            "11:00 to 12:00 AM",
            "12:00 to 1:00 AM",
            "1:00 to 2:00 AM",
            "2:00 to 3:00 AM",
            "3:00 to 4:00 AM",
            "4:00 to 5:00 AM",
            "5:00 to 6:00 AM",
            "6:00 to 7:00 AM",
            "7:00 to 8:00 AM",
            "8:00 to 9:00 AM",
            "9:00 to 10:00 AM",
            "10:00 to 11:00 AM",
            "11:00 to 12:00 PM",
            "12:00 to 1:00 PM",
            "1:00 to 2:00 PM",
            "2:00 to 3:00 PM",
            "3:00 to 4:00 PM",
            "4:00 to 5:00 PM",
            "5:00 to 6:00 PM",
            "6:00 to 7:00 PM",
            "7:00 to 8:00 PM",
            "8:00 to 9:00 PM",
            "9:00 to 10:00 PM",
            "10:00 to 11:00 PM"});
            this.cmbTime.Location = new System.Drawing.Point(117, 180);
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.Size = new System.Drawing.Size(137, 23);
            this.cmbTime.TabIndex = 13;
            // 
            // cmbShift
            // 
            this.cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Items.AddRange(new object[] {
            "Morning",
            "Day",
            "Evening",
            "Night"});
            this.cmbShift.Location = new System.Drawing.Point(351, 151);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(162, 23);
            this.cmbShift.TabIndex = 12;
            // 
            // cmbDay
            // 
            this.cmbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDay.FormattingEnabled = true;
            this.cmbDay.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.cmbDay.Location = new System.Drawing.Point(117, 151);
            this.cmbDay.Name = "cmbDay";
            this.cmbDay.Size = new System.Drawing.Size(162, 23);
            this.cmbDay.TabIndex = 11;
            // 
            // cmbSubjectName
            // 
            this.cmbSubjectName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubjectName.FormattingEnabled = true;
            this.cmbSubjectName.Location = new System.Drawing.Point(117, 97);
            this.cmbSubjectName.Name = "cmbSubjectName";
            this.cmbSubjectName.Size = new System.Drawing.Size(396, 23);
            this.cmbSubjectName.TabIndex = 10;
            this.cmbSubjectName.SelectedIndexChanged += new System.EventHandler(this.cmbSubjectName_SelectedIndexChanged);
            // 
            // cmbSemester
            // 
            this.cmbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemester.Enabled = false;
            this.cmbSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Location = new System.Drawing.Point(351, 68);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(162, 23);
            this.cmbSemester.TabIndex = 9;
            this.cmbSemester.SelectedIndexChanged += new System.EventHandler(this.cmbSemester_SelectedIndexChanged);
            // 
            // cmbCourse
            // 
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(117, 68);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(162, 23);
            this.cmbCourse.TabIndex = 8;
            this.cmbCourse.SelectedIndexChanged += new System.EventHandler(this.cmbCourse_SelectedIndexChanged);
            // 
            // cmbTeacherName
            // 
            this.cmbTeacherName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTeacherName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTeacherName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTeacherName.FormattingEnabled = true;
            this.cmbTeacherName.Location = new System.Drawing.Point(117, 30);
            this.cmbTeacherName.Name = "cmbTeacherName";
            this.cmbTeacherName.Size = new System.Drawing.Size(396, 23);
            this.cmbTeacherName.TabIndex = 7;
            this.cmbTeacherName.SelectedIndexChanged += new System.EventHandler(this.cmbTeacherName_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Thời gian";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(285, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Thay đổi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên chủ đề";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(285, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Học kỳ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Môn học";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Giảng viên";
            // 
            // gridTimeScheduleData
            // 
            this.gridTimeScheduleData.AllowUserToAddRows = false;
            this.gridTimeScheduleData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTimeScheduleData.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gridTimeScheduleData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTimeScheduleData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SId,
            this.TeacherName,
            this.Course,
            this.Semester,
            this.SubjectName,
            this.Day,
            this.Shift,
            this.Time,
            this.Period,
            this.TeacherCode,
            this.CourseCode,
            this.SubjectCode});
            this.gridTimeScheduleData.Location = new System.Drawing.Point(12, 275);
            this.gridTimeScheduleData.Name = "gridTimeScheduleData";
            this.gridTimeScheduleData.ReadOnly = true;
            this.gridTimeScheduleData.RowHeadersVisible = false;
            this.gridTimeScheduleData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTimeScheduleData.Size = new System.Drawing.Size(843, 261);
            this.gridTimeScheduleData.TabIndex = 1;
            this.gridTimeScheduleData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTimeScheduleData_CellClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(268, 240);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 29);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(346, 240);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 29);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(709, 544);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 29);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(631, 544);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(72, 29);
            this.btnConfirm.TabIndex = 16;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // SId
            // 
            this.SId.HeaderText = "ScheduleId";
            this.SId.Name = "SId";
            this.SId.ReadOnly = true;
            this.SId.Visible = false;
            // 
            // TeacherName
            // 
            this.TeacherName.HeaderText = "Tên Giảng Viên";
            this.TeacherName.Name = "TeacherName";
            this.TeacherName.ReadOnly = true;
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
            // SubjectName
            // 
            this.SubjectName.HeaderText = "Tên Chủ Đề";
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.ReadOnly = true;
            // 
            // Day
            // 
            this.Day.HeaderText = "Ngày";
            this.Day.Name = "Day";
            this.Day.ReadOnly = true;
            // 
            // Shift
            // 
            this.Shift.HeaderText = "Thay Đổi";
            this.Shift.Name = "Shift";
            this.Shift.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.HeaderText = "Thời Gian";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // Period
            // 
            this.Period.HeaderText = "Giai Đoạn";
            this.Period.Name = "Period";
            this.Period.ReadOnly = true;
            // 
            // TeacherCode
            // 
            this.TeacherCode.HeaderText = "TeacherCode";
            this.TeacherCode.Name = "TeacherCode";
            this.TeacherCode.ReadOnly = true;
            this.TeacherCode.Visible = false;
            // 
            // CourseCode
            // 
            this.CourseCode.HeaderText = "CourseCode";
            this.CourseCode.Name = "CourseCode";
            this.CourseCode.ReadOnly = true;
            this.CourseCode.Visible = false;
            // 
            // SubjectCode
            // 
            this.SubjectCode.HeaderText = "SubjectCode";
            this.SubjectCode.Name = "SubjectCode";
            this.SubjectCode.ReadOnly = true;
            this.SubjectCode.Visible = false;
            // 
            // frmTimeSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(867, 581);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridTimeScheduleData);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTimeSchedule";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thời khóa biểu giảng viên";
            this.Load += new System.EventHandler(this.frmTimeSchedule_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTimeSchedule_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTeacher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTimeScheduleData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTime;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.ComboBox cmbDay;
        private System.Windows.Forms.ComboBox cmbSubjectName;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.ComboBox cmbTeacherName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPeriod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView gridTimeScheduleData;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.PictureBox picTeacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn SId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeacherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.DataGridViewTextBoxColumn Semester;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shift;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeacherCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectCode;
    }
}