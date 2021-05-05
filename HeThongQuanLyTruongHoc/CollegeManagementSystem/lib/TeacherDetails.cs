using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CollegeManagementSystem.lib
{
    #region "Teacher Details Class"
    public class TeacherDetails : DatabaseConnection
    {
        /// <summary>
        /// All Variables
        /// </summary>
        /// 
        private SqlCommand cmd;
        private string _teacherid;
        private int _attendanceid;
        private string _registerdate;
        private string _teachername;
        private string _gender;
        private string _address;
        private string _phoneno;
        private string _email;
        private string _experience;
        private PictureBox _teacherphoto;
        private string _attendancedate;
        private string _attendance;
        private string sql = "";

        /// <summary>
        /// All Propertis
        /// </summary>
        /// 
        public string TeacherId
        {
            get { return _teacherid; }
            set { _teacherid = value; }
        }

        public string RegisterDate
        {
            get { return _registerdate; }
            set { _registerdate = value; }
        }

        public string TeacherName
        {
            get { return _teachername; }
            set { _teachername = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string PhoneNo
        {
            get { return _phoneno; }
            set { _phoneno = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Experience
        {
            get { return _experience; }
            set { _experience = value; }
        }

        public PictureBox TeacherPhoto
        {
            get { return _teacherphoto; }
            set { _teacherphoto = value; }
        }

        public int AttendanceId
        {
            get { return _attendanceid; }
            set { _attendanceid = value; }
        }

        public string AttendanceDate
        {
            get { return _attendancedate; }
            set { _attendancedate = value; }
        }

        public string Attendance
        {
            get { return _attendance; }
            set { _attendance = value; }
        }

        /// <summary>
        /// saved picture in database
        /// </summary>
        /// <param name="pic"></param>
        /// <param name="imageColumn"></param>
        /// 
        private void ConvertPic(PictureBox pic, string imageColumn)
        {
            if (pic.Image != null)
            {
                cmd.Parameters.Add(imageColumn, SqlDbType.VarBinary).Value = Global.SetPic(pic.Image, pic);
                //cmd.Parameters.Add(imageColumn, SqlDbType.VarBinary).Value = "NULL";
            }
            //else
            //{
            //    cmd.Parameters.AddWithValue(imageColumn, null);
            //}
        }

        /// <summary>
        /// Teacher Register
        /// </summary>
        /// 
        public void InsertTeacher()
        {
            sql = "INSERT INTO TeacherRegister(Id,TeacherName,Gender,Address,RegisterDate,PhoneNo,Email,Experience,TPhoto) Values (@Id,@TeacherName,@Gender,@Address,@RegisterDate,@PhoneNo,@Email,@Experience,@TPhoto)";
            cmd = new SqlCommand(sql, GlobalConnection());
            cmd.Parameters.AddWithValue("@Id", _teacherid);
            cmd.Parameters.AddWithValue("@RegisterDate", _registerdate);
            cmd.Parameters.AddWithValue("@TeacherName", _teachername);
            cmd.Parameters.AddWithValue("@Gender", _gender);
            cmd.Parameters.AddWithValue("@Address", _address);
            cmd.Parameters.AddWithValue("@PhoneNo", _phoneno);
            cmd.Parameters.AddWithValue("@Email", _email);
            cmd.Parameters.AddWithValue("@Experience", _experience);
            ConvertPic(_teacherphoto, "@TPhoto");
            cmd.ExecuteNonQuery();
        }

        public void UpdateTeacher()
        {
            sql = "UPDATE TeacherRegister SET TeacherName=@TeacherName,Gender=@Gender,Address=@Address,RegisterDate=@RegisterDate,PhoneNo=@PhoneNo,Email=@Email,Experience=@Experience,TPhoto=@TPhoto Where Id=@Id";
            cmd = new SqlCommand(sql, GlobalConnection());
            cmd.Parameters.AddWithValue("@Id", _teacherid);
            cmd.Parameters.AddWithValue("@RegisterDate", _registerdate);
            cmd.Parameters.AddWithValue("@TeacherName", _teachername);
            cmd.Parameters.AddWithValue("@Gender", _gender);
            cmd.Parameters.AddWithValue("@Address", _address);
            cmd.Parameters.AddWithValue("@PhoneNo", _phoneno);
            cmd.Parameters.AddWithValue("@Email", _email);
            cmd.Parameters.AddWithValue("@Experience", _experience);
            ConvertPic(_teacherphoto, "@TPhoto");
            cmd.ExecuteNonQuery();
        }

        public bool DeleteTeacher()
        {
            sql = "Delete From TeacherRegister Where Id='" + _teacherid + "'";
            return ExecuteNonQuery(sql);
        }

        /// <summary>
        /// Teacher attendance methods
        /// </summary>
        /// <returns></returns>
        /// 
        public bool AddTeacherAttendance()
        {
            sql = "INSERT INTO TeacherAttendance(Id,TeacherName,AttendanceDate,Attendance,TeacherId)Values('" + _attendanceid + "', '" + _teachername + "', '" + _attendancedate + "', '" + _attendance + "', '" + _teacherid + "')";
            return ExecuteNonQuery(sql);
        }
    }
    #endregion

    #region "Time Schedule Class"
    public class TimeSchedule : DatabaseConnection
    {
        private int _scheduleid;
        private int _teacherid;
        private int _coursecode;
        private int _subjectcode;
        private string _teachername;
        private string _course;
        private string _semester;
        private string _subjectname;
        private string _day;
        private string _shift;
        private string _time;
        private string _period;
        private string sql = "";

        public int ScheduleId
        {
            get { return _scheduleid; }
            set { _scheduleid = value; }
        }

        public int TeacherId
        {
            get { return _teacherid; }
            set { _teacherid = value; }
        }

        public int CourseCode
        {
            get { return _coursecode; }
            set { _coursecode = value; }
        }

        public int SubjectCode
        {
            get { return _subjectcode; }
            set { _subjectcode = value; }
        }

        public string TeacherName
        {
            get { return _teachername; }
            set { _teachername = value; }
        }

        public string Course
        {
            get { return _course; }
            set { _course = value; }
        }

        public string Semester
        {
            get { return _semester; }
            set { _semester = value; }
        }

        public string SubjectName
        {
            get { return _subjectname; }
            set { _subjectname = value; }
        }

        public string Day
        {
            get { return _day; }
            set { _day = value; }
        }

        public string Shift
        {
            get { return _shift; }
            set { _shift = value; }
        }

        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public string Period
        {
            get { return _period; }
            set { _period = value; }
        }

        public bool AddTimeSchedule()
        {
            sql = "INSERT INTO Schedule(Id, TeacherName, Course, Semester, SubjectName, SDay, Shift, STime, Period, TeacherCode, CourseCode,SubjectCode) Values ('"
            + _scheduleid + "','" + _teachername + "','" + _course + "','" + _semester + "','" + _subjectname + "','" + _day + "','"
            + _shift + "','" + _time + "','" + _period + "', '" + _teacherid + "','" + _coursecode + "','" + _subjectcode + "')";
            return ExecuteNonQuery(sql);
        }
    }
#endregion
}
