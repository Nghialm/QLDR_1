using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
namespace QuanLyDoanRa
{
    public partial class BackupDatabase : Form
    {
        DataTable dtServers = SmoApplication.EnumAvailableSqlServers(true);
        //private static Server srvr;

        private SqlConnection Conn;
        private SqlCommand command;
        private SqlDataReader reader;
        string sql = "";
        string connectionString = "";
        public bool restore_flag = false;
        public BackupDatabase()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BackupDatabase_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            WindowState = FormWindowState.Normal;

            btnBackUp.Enabled = true;
            btnRestore.Enabled = true;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtLocation.Text = dlg.SelectedPath;
            }
        }


        private void btnBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lstInfo = GetXmlInfo.GetServerInfo();
                string server = "";
                string database = "";
                string user_db = "";
                string pass = "";
                if (lstInfo.Count > 0)
                {
                    server = lstInfo[0];
                    database = lstInfo[1];
                    user_db = lstInfo[2];
                    pass = lstInfo[3];
                }
                connectionString = "Data Source = " + server + "; User Id = " + user_db + "; Password = " + pass;
                Conn = new SqlConnection(connectionString);
                Conn.Open();
                sql = "BACKUP DATABASE " + database + " TO DISK = '" + txtLocation.Text + "\\" + database + "-" + DateTime.Now.Ticks.ToString() + ".bak'";
                command = new SqlCommand(sql, Conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Quá trình sao lưu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnBrowseRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Backup Files(*.bak)|*.bak|All Files(*.*)|*.*";
            dlg.FilterIndex = 0;
            if (dlg.ShowDialog() == DialogResult.OK)
                txtRestoreLocation.Text = dlg.FileName;

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lstInfo = GetXmlInfo.GetServerInfo();
                string server = "";
                string database = "";
                string user_db = "";
                string pass = "";
                if (lstInfo.Count > 0)
                {
                    server = lstInfo[0];
                    database = lstInfo[1];
                    user_db = lstInfo[2];
                    pass = lstInfo[3];
                }
                connectionString = "Data Source = " + server + "; User Id = " + user_db + "; Password = " + pass;
                Conn = new SqlConnection(connectionString);
                Conn.Open();
                sql = "Alter Database " + database + " Set SINGLE_USER WITH ROLLBACK IMMEDIATE ";
                sql += "Restore Database " + database + " FROM Disk = '" + txtRestoreLocation.Text + "' WITH REPLACE;";
                if (MessageBox.Show("Bạn có muốn khôi phục lại dữ liệu?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    command = new SqlCommand(sql, Conn);
                    command.ExecuteNonQuery();
                    Conn.Close();
                    Conn.Dispose();
                    MessageBox.Show("Quá trình khôi phục dữ liệu thành công!");
                    this.restore_flag = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
