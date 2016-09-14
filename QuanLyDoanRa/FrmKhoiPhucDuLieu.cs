using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QuanLyDoanRa
{
    public partial class FrmKhoiPhucDuLieu : Form
    {
        String _ThuMucRestore = "";
        string _FileRestore = "";
        string _FileRestoreFull = "";
        string _FileInfo = "";
        
        public FrmKhoiPhucDuLieu()
        {
            InitializeComponent();
        }

        private void btnBrower_Click(object sender, EventArgs e)
        {
            string filebackup = "";
            string[] temp;
            openFileDialog1.AddExtension = true;
            openFileDialog1.Filter = "mdb files (*.db)|*.db|All files (*.*)|*.*";
            openFileDialog1.DefaultExt = "db";
            openFileDialog1.FileName = "";
            //openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filebackup = openFileDialog1.FileName;

                temp = filebackup.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                _FileRestore = temp[temp.Length - 1];
                _ThuMucRestore = filebackup.Replace(_FileRestore, "");                
                _FileRestoreFull = openFileDialog1.FileName;
                txtDuongDan.Text = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn file để khôi phục", "Thông báo");
            }
        }

        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            try
            {
                File.Copy(_FileRestoreFull, General.FileDataBase, true);
                MessageBox.Show("Quá trình khôi phục dữ liệu thành công.", "Thông báo");               
                this.Close();

            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình thực hiện. Kiểm tra thư mục sao lưu.", "Thông báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
