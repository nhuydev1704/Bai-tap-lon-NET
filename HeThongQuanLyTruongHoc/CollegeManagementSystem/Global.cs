using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace CollegeManagementSystem
{
    public class Global
    {
        public static string Caption = "Quản lý khóa học";

        // Server Login for Database
        public static string ServerName = @"DESKTOP-FDLG94H";
        public static string SUserId = @"DESKTOP-FDLG94H";
        public static string SPassword = "";
        public static string Database="College";

        // User Login for Application
        public static string UserId;
        public static string UserName;
        public static string Password;
        public static string UserType;

        /// <summary>
        /// Variables
        /// </summary>
        /// 
        MemoryStream ms;
        byte[] photo_aray;
        private static int a = 1;
        private static SqlCommand cmd;

        #region "Methods"
        public const String Emailpattern =
                   @"^([0-9a-zA-Z]" + //Start with a digit or alphabate
                   @"([\+\-_\.][0-9a-zA-Z]+)*" + // No continues or ending +-_. chars in email
                   @")+" + @"@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$";

        //public const String PatternA = @"^([a-zA-Z]\d";

        public bool getInvalidInput(string InputBox, string ExpressionPattern, string Message, string MessageTitleBar)
        {
            bool valid;

            valid = Regex.Match(InputBox, ExpressionPattern).Success;
            if (!valid)
            {
                MessageBox.Show(Message, MessageTitleBar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return valid;
        }

        public static int AutoNumber(string SelectQuery, int StartNumber)
        {
            cmd = new SqlCommand(SelectQuery, lib.DatabaseConnection.GlobalConnection());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                dr.Close();
                if (val == "")
                {
                    a = StartNumber;
                }
                else
                {
                    a = Convert.ToInt32(val) + 1;
                }
            }
            return a;
        }

        public bool IsAllDigits(string InputBox)
        {
            return InputBox.All(Char.IsDigit);
        }

        public bool IsPositive(int number)
        {
            return number > 0;
        }

        public bool IsNegative(int number)
        {
            return number < 0;
        }

        public bool IsZero(int number)
        {
            return number == 0;
        }

        public bool IsAwesome(int number)
        {
            return IsNegative(number) && IsPositive(number) && IsZero(number);
        }

        /// <summary>
        /// convert picture in binary code
        /// </summary>
        /// <param name="img"></param>
        /// <param name="picture"></param>
        /// <returns></returns>
        /// 
        public static byte[] SetPic(Image img, PictureBox picture)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(picture.Image);
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Position = 0;
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                return data;
            }
        }

        public void getPictureFromDatabase(PictureBox pic, DataTable dt, int x, string rowindex)
        {
            pic.Image = null;
            if (dt.Rows[x][rowindex] != System.DBNull.Value)
            {
                photo_aray = (byte[])dt.Rows[x][rowindex];
                ms = new MemoryStream(photo_aray);
                pic.Image = Image.FromStream(ms);
            }
        }

        public void getPictureFromDataGridView(PictureBox pic, DataGridView gridTable, DataGridViewCellEventArgs e, int rowindex)
        {
            pic.Image = null;
            if (gridTable.Rows[e.RowIndex].Cells[rowindex].Value != System.DBNull.Value)
            {
                photo_aray = (byte[])gridTable.Rows[e.RowIndex].Cells[rowindex].Value;
                ms = new MemoryStream(photo_aray);
                pic.Image = Image.FromStream(ms);
            }
            //else
            //{
            //    pic.ErrorImage = global::CollegeManagementSystem.Properties.Resources.Edit;
            //}
        }

        public static void AutoComplete(TextBox txtAutoSearch, string sql)
        {
            using (cmd = new SqlCommand(sql, lib.DatabaseConnection.GlobalConnection()))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                }
                txtAutoSearch.AutoCompleteCustomSource = MyCollection;
            }
        }

        //public int Total(DataGridView datagridTotal, int cellTotal)
        //{
        //    int Total;
        //    int totalMarks = 0;
        //    foreach (DataGridViewRow rCells in datagridTotal.Rows)
        //    {
        //        Total = Convert.ToInt32(rCells.Cells[cellTotal].Value);
        //        totalMarks = totalMarks + Total;
        //    }
        //    return totalMarks;
        //}
        #endregion
    }
}
