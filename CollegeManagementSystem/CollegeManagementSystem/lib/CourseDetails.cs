using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace CollegeManagementSystem.lib
{
    public class CourseDetails : DatabaseConnection
    {
        private string _courseid;
        private string _subjectcode;
        private string _coursename;
        private string _semester;
        private string _subjectname;
        private string _credits;
        private string sql = "";

        public string CourseId
        {
            get { return _courseid; }
            set { _courseid = value; }
        }

        public string CourseName
        {
            get { return _coursename; }
            set { _coursename = value; }
        }

        public string Semester
        {
            get { return _semester; }
            set { _semester = value; }
        }

        public string SubjectCode
        {
            get { return _subjectcode; }
            set { _subjectcode = value; }
        }

        public string SubjectName
        {
            get { return _subjectname; }
            set { _subjectname = value; }
        }

        public string Credits
        {
            get { return _credits; }
            set { _credits = value; }
        }

        public bool AddSemester()
        {
            sql = "INSERT INTO Semester(SemesterId) Values ('" + _semester + "')";
            return ExecuteNonQuery(sql);
        }

        public bool DeleteSemester()
        {
            sql = "DELETE FROM Semester Where SemesterId='" + _semester + "'";
            return ExecuteNonQuery(sql);
        }

        public bool AddCourse()
        {
            sql = "INSERT INTO Course(Id, CourseName, Semester)values('" + _courseid + "', '" + _coursename + "', '" + _semester + "')";
            return ExecuteNonQuery(sql);
        }

        public bool DeleteCourse()
        {
            sql = "DELETE FROM Course Where Id='" + _courseid + "'";
            return ExecuteNonQuery(sql);
        }

        public bool AddSubject()
        {
            sql = "INSERT INTO SubjectDetails(Id, CourseName, Semester, SubjectName, Credits, CourseId) Values ('" + _subjectcode + "', '" + _coursename + "', '" + _semester + "', '" + _subjectname + "', '" + _credits + "', '" + _courseid + "')";
            return ExecuteNonQuery(sql);
        }

        public bool UpdateSubject()
        {
            sql = "UPDATE SubjectDetails SET CourseName='" + _coursename + "', Semester='" + _semester + "', SubjectName='" + _subjectname + "', Credits='" + _credits + "', CourseId='" + _courseid + "' Where Id='" + SubjectCode + "'";
            return ExecuteNonQuery(sql);
        }

        public bool DeleteSubject()
        {
            sql = "DELETE FROM SubjectDetails Where Id='" + _subjectcode + "'";
            return ExecuteNonQuery(sql);
        }
    }
}
