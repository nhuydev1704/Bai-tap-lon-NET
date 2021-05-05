using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace CollegeManagementSystem.lib
{
    public class StudentDetails : DatabaseConnection
    {
        private SqlCommand cmd;
        private string sql = "";

        /// <summary>
        /// Student register details
        /// </summary>
        /// 
        private string _sid;
        private string _studentname;
        private string _rollno;
        private string _gender;
        private string _address;
        private string _dateofbirth;
        private string _admissiondate;
        private string _phoneno;
        private string _email;
        private string _country;
        private string _shift;
        private string _course;
        private string _semester;
        private PictureBox _studentphoto;

        /// <summary>
        /// Student attendance details
        /// </summary>
        /// 
        private int _attendanceid;
        private string _courseid;
        private string _attendancedate;
        private string _attendance;

        /// <summary>
        /// Student register properties
        /// </summary>
        /// 
        public string SId
        {
            get { return _sid; }
            set { _sid = value; }
        }

        public string StudentName
        {
            get { return _studentname; }
            set { _studentname = value; }
        }

        public string RollNo
        {
            get { return _rollno; }
            set { _rollno = value; }
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

        public string DateOfBirth
        {
            get { return _dateofbirth; }
            set { _dateofbirth = value; }
        }

        public string AdmissionDate
        {
            get { return _admissiondate; }
            set { _admissiondate = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneno; }
            set { _phoneno = value; }
        }

        public string EmailId
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string Shift
        {
            get { return _shift; }
            set { _shift = value; }
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

        public PictureBox StudentPicture
        {
            get { return _studentphoto; }
            set { _studentphoto = value; }
        }

        /// <summary>
        /// Student register properties
        /// </summary>
        /// 
        public int AttendanceId
        {
            get { return _attendanceid; }
            set { _attendanceid = value; }
        }

        public string CourseId
        {
            get { return _courseid; }
            set { _courseid = value; }
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

        public void AddStuAdmission()
        {
            sql = "INSERT INTO Regstudent(Id,RollNo,StudentName,Gender,Address,DateOfBirth,AdmissionDate,PhoneNo,Email,Country,Shift,Course,Semester,StudentPic) Values (@Id,@RollNo,@StudentName,@Gender,@Address,@DateOfBirth,@AdmissionDate,@PhoneNo,@Email,@Country,@Shift,@Course,@Semester,@StudentPic)";
            cmd = new SqlCommand(sql, GlobalConnection());
            cmd.Parameters.AddWithValue("@Id", _sid);
            cmd.Parameters.AddWithValue("@RollNo", _rollno);
            cmd.Parameters.AddWithValue("@StudentName", _studentname);
            cmd.Parameters.AddWithValue("@Gender", _gender);
            cmd.Parameters.AddWithValue("@Address", _address);
            cmd.Parameters.AddWithValue("@DateOfBirth", _dateofbirth);
            cmd.Parameters.AddWithValue("@AdmissionDate", _admissiondate);
            cmd.Parameters.AddWithValue("@PhoneNo", _phoneno);
            cmd.Parameters.AddWithValue("@Email", _email);
            cmd.Parameters.AddWithValue("@Country", _country);
            cmd.Parameters.AddWithValue("@Shift", _shift);
            cmd.Parameters.AddWithValue("@Course", _course);
            cmd.Parameters.AddWithValue("@Semester", _semester);
            ConvertPic(_studentphoto, "@StudentPic");
            cmd.ExecuteNonQuery();
        }

        public void UpdateStuAdmission()
        {
            sql = "Update Regstudent Set RollNo=@RollNo,StudentName=@StudentName,Gender=@Gender,Address=@Address,DateOfBirth=@DateOfBirth,AdmissionDate=@AdmissionDate,PhoneNo=@PhoneNo,Email=@Email,Country=@Country,Shift=@Shift,Course=@Course,Semester=@Semester,StudentPic=@StudentPic Where Id=@Id";
            cmd = new SqlCommand(sql, GlobalConnection());
            cmd.Parameters.AddWithValue("@Id", _sid);
            cmd.Parameters.AddWithValue("@RollNo", _rollno);
            cmd.Parameters.AddWithValue("@StudentName", _studentname);
            cmd.Parameters.AddWithValue("@Gender", _gender);
            cmd.Parameters.AddWithValue("@Address", _address);
            cmd.Parameters.AddWithValue("@DateOfBirth", _dateofbirth);
            cmd.Parameters.AddWithValue("@AdmissionDate", _admissiondate);
            cmd.Parameters.AddWithValue("@PhoneNo", _phoneno);
            cmd.Parameters.AddWithValue("@Email", _email);
            cmd.Parameters.AddWithValue("@Country", _country);
            cmd.Parameters.AddWithValue("@Shift", _shift);
            cmd.Parameters.AddWithValue("@Course", _course);
            cmd.Parameters.AddWithValue("@Semester", _semester);
            ConvertPic(_studentphoto, "@StudentPic");
            cmd.ExecuteNonQuery();
        }

        public bool DeleteStuAdmission()
        {
            sql = "Delete From Regstudent Where Id='" + _sid + "'";
            return ExecuteNonQuery(sql);
        }

        /// <summary>
        /// Student attendance methods
        /// </summary>
        /// <returns></returns>
        /// 
        public bool AddAttendance()
        {
            sql = "INSERT INTO StuAttendance(Id, StudentName, RollNo, Course, Semester, AttendanceDate, Attendance, StuId, CourseId)Values('" + _attendanceid + "','"
            + _studentname + "', '" + _rollno + "', '" + _course + "', '" + _semester + "', '" 
            + _attendancedate + "', '" + _attendance + "', '" + _sid + "', '" + _courseid + "')";
            return ExecuteNonQuery(sql);
        }
    }
}
