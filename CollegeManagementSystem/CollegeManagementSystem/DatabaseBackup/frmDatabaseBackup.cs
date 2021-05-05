using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;
using CollegeManagementSystem.lib;

namespace CollegeManagementSystem.DatabaseBackup
{
    public partial class frmDatabaseBackup : Form
    {
        public frmDatabaseBackup()
        {
            InitializeComponent();
            this.rdBackup.Checked = true;
        }

        #region "Form events"
        private void frmDatabaseBackup_Load(object sender, EventArgs e)
        {
            txtServerName.Text = Global.ServerName;
            txtLogin.Text = Global.SUserId;
            txtPassword.Text = Global.SPassword;
            LoadDatabase();
        }
        #endregion

        #region "Methods"
        private bool Validation()
        {
            bool isvalid = true;
            if (btnBackup.Text == "Backup")
            {
                if (cmbDatabaseName.Text == string.Empty)
                {
                    MessageBox.Show("Choose database name.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbDatabaseName.Focus();
                    isvalid = false;
                }
                else
                    if (txtSelectFolder.Text == string.Empty)
                    {
                        MessageBox.Show("Select folder path.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        isvalid = false;
                    }
            }
            else
                if (btnBackup.Text == "Restore")
                {
                    if (txtDatabaseName.Text == string.Empty)
                    {
                        MessageBox.Show("Database name required.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtDatabaseName.Focus();
                        isvalid = false;
                    }
                    else
                        if (txtSelectPath.Text == string.Empty)
                        {
                            MessageBox.Show("Open folder path.", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            isvalid = false;
                        }
                }
            return isvalid;
        }

        private void LoadDatabase()
        {
            try
            {
                var selectQuery = "SELECT * FROM sys.databases";
                var sql = new lib.DatabaseConnection();
                DataTable dt = new DataTable();
                dt = sql.getTable(selectQuery);
                foreach (DataRow dr in dt.Rows)
                {
                    this.cmbDatabaseName.Items.Add(dr["Name"]);
                }
            }
            catch (SqlException sqlException)
            {
                MessageBox.Show(sqlException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReadBackupFile()
        {
            String path = txtSelectFolder.Text;
            try
            {
                if (!Directory.Exists(@path))
                {
                    Directory.CreateDirectory(@path);
                }
                string[] files = Directory.GetFiles(@path, "*.bak");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region "Radio button events"
        private void rdBackup_CheckedChanged(object sender, EventArgs e)
        {
            this.grpBox1.Enabled = true;
            this.grpBox2.Enabled = false;
            this.btnBackup.Text = "Backup";
        }

        private void rdRestore_CheckedChanged(object sender, EventArgs e)
        {
            this.grpBox2.Enabled = true;
            this.grpBox1.Enabled = false;
            this.btnBackup.Text = "Restore";
        }
        #endregion

        #region "Button events"
        private void btnFolderBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSelectFolder.Text = folderBrowser.SelectedPath;
            }
        }

        private void btnPathBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlgFile = new OpenFileDialog())
            {
                dlgFile.Filter = "SQL SERVER database backup files|*.bak";
                dlgFile.Title = "Database restore";

                if (dlgFile.ShowDialog() == DialogResult.OK)
                {
                    txtSelectPath.Text = dlgFile.FileName;
                }
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (!Validation())
                return;
            try
            {
                if (this.btnBackup.Text == "Backup")
                {
                    String BackupPath = txtSelectFolder.Text;
                    string DatabaseName = cmbDatabaseName.Text;
                    string BackupName = DatabaseName + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".bak";
                    SqlConnection sqlConnection = new SqlConnection();
                    string sqlQuery = @"BACKUP DATABASE " + DatabaseName + " TO DISK = '" + BackupPath + "\\" + BackupName + "' WITH FORMAT, MEDIANAME = 'Z_SQLServerBackups', NAME = '" + BackupName + "';";
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, lib.DatabaseConnection.GlobalConnection());
                    sqlCommand.CommandType = CommandType.Text;
                    int iRows = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Database backup successfully.", Global.Caption + "[Databse Backup]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    if (this.btnBackup.Text == "Restore")
                    {

                        string DatabaseName = txtDatabaseName.Text;
                        string BackupName = txtSelectPath.Text;
                        string sqlQuery = @"RESTORE DATABASE " + DatabaseName + " FROM DISK ='" + BackupName + "'";
                        SqlCommand sqlCommand = new SqlCommand(sqlQuery, lib.DatabaseConnection.GlobalConnection());
                        sqlCommand.CommandType = CommandType.Text;
                        int iRows = sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Database restore Successfully", Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
