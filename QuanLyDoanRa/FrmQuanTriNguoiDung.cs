using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Web.Security;

namespace QuanLyDoanRa
{
    public partial class FrmQuanTriNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        public QuanLyDoanRa.FormUpdate FormStatus;
        MembershipUser _SelectedUser;
        public MembershipUser SelectedUser
        {
            get { return _SelectedUser; }
            set { _SelectedUser = value; }
        }
        IList<MembershipUser> listusers = new List<MembershipUser>();
        
        String _UserName = "";
        public String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public FrmQuanTriNguoiDung()
        {
            InitializeComponent();
        }

        public void BindData()
        {
            listusers = new List<MembershipUser>();
            int totalRecord;
            MembershipUserCollection Users = System.Web.Security.Membership.GetAllUsers();
            System.Collections.IEnumerator imu = Users.GetEnumerator();
            while (imu.MoveNext())
            {
                listusers.Add((MembershipUser)imu.Current);
            }
            this.gcNguoiDung.DataSource = null;
            this.gcNguoiDung.DataSource = listusers;
            this.gcNguoiDung.Refresh();
        }

        private void FrmQuanTriNguoiDung_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void gvDanhSachNguoiDung_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //if(gvDanhSachNguoiDung.)
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            UserName = this.txtUsername.Text;
            if (UserName == string.Empty || FormStatus == QuanLyDoanRa.FormUpdate.Insert)//Thêm mới người dùng
            {
                System.Web.Security.MembershipCreateStatus mcs = new System.Web.Security.MembershipCreateStatus();
                try
                {
                    if (txtUsername.Text == string.Empty)
                    {
                        MessageBox.Show("Tên đăng nhập không được để trống");
                        txtUsername.Focus();
                        return;
                    }
                    if (txtPassWord.Text == string.Empty)
                    {
                        MessageBox.Show("Mật khẩu không được để trống");
                        txtPassWord.Focus();
                        return;
                    }
                    if (txtThuDienTu.Text == string.Empty)
                    {
                        MessageBox.Show("Địa chỉ hòm thư không được để trống");
                        txtThuDienTu.Focus();
                        return;
                    }
                    System.Web.Security.Membership.CreateUser(txtUsername.Text, txtPassWord.Text, txtThuDienTu.Text, "Who are you?", "It's me", true, out mcs);
                    System.Web.Security.MembershipUser u = System.Web.Security.Membership.GetUser(txtUsername.Text);

                    u.IsApproved = true;
                    System.Web.Security.Membership.UpdateUser(u);
                }
                catch
                {
                    if (mcs == System.Web.Security.MembershipCreateStatus.DuplicateUserName)
                        MessageBox.Show("Tên đăng nhập đã tồn tại!");
                    if (mcs == System.Web.Security.MembershipCreateStatus.InvalidPassword)
                        MessageBox.Show("Mật khẩu phải từ 7 kí tự và chứa kí tự đặc biệt!");
                }
            }
            else//Sửa thông tin người dùng
            {
                System.Web.Security.MembershipUser u = System.Web.Security.Membership.GetUser(txtUsername.Text);
                System.Web.Security.MembershipCreateStatus mcs = new System.Web.Security.MembershipCreateStatus();
                //oldPass = u.GetPassword();
                //u.ChangePassword(oldPass, txtMatKhau.Text);

                if (txtPassWord.Text != string.Empty && txtRePass.Text != string.Empty && txtRePass.Visible == true)
                {
                    //string password = u.ResetPassword()
                    //u.ChangePassword(txtPassWord.Text, txtRePass.Text);
                    System.Web.Security.Membership.DeleteUser(u.UserName);
                    MessageBox.Show("Đồi mật khẩu thành công!");
                }
                else
                {
                    MessageBox.Show("Cần nhập mật khẩu cũ và mật khẩu mới");
                    txtPassWord.Focus();
                    return;
                }
                System.Web.Security.Membership.CreateUser(txtUsername.Text, txtRePass.Text, txtThuDienTu.Text, "Who are you?", "It's me", true, out mcs);
                System.Web.Security.MembershipUser new_user = System.Web.Security.Membership.GetUser(txtUsername.Text);
                new_user.Email = txtThuDienTu.Text;
                new_user.IsApproved = true;
                System.Web.Security.Membership.UpdateUser(new_user);
                
            }
            FormStatus = QuanLyDoanRa.FormUpdate.View;
            SetStatus(FormStatus);
            BindData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            DialogResult dlr = MessageBox.Show("Bạn có muốn xóa tài khoản này ra khỏi hệ thống không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (dlr == DialogResult.OK)
            {
                try
                {
                    SelectedUser = (MembershipUser)gvDanhSachNguoiDung.GetRow(gvDanhSachNguoiDung.FocusedRowHandle);
                    if (SelectedUser == null) return;
                    System.Web.Security.Membership.DeleteUser(SelectedUser.UserName);
                    FormStatus = QuanLyDoanRa.FormUpdate.Update;
                 
                }
                catch { }
                BindData();
            }
        }

        private void gvDanhSachNguoiDung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SelectedUser = (MembershipUser)gvDanhSachNguoiDung.GetRow(gvDanhSachNguoiDung.FocusedRowHandle);

            if (SelectedUser == null) return;

            FormStatus = QuanLyDoanRa.FormUpdate.Update;
            SetObjectToControl(SelectedUser);
        }
        
        private void SetObjectToControl(MembershipUser objDonvi)
        {
            this.txtUsername.EditValue = objDonvi.UserName;
            this.txtThuDienTu.EditValue = objDonvi.Email;
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            FormStatus = QuanLyDoanRa.FormUpdate.View;
            SetStatus(FormStatus);
        }
        private void SetStatus(QuanLyDoanRa.FormUpdate status)
        {
            switch (status)
            {
                case QuanLyDoanRa.FormUpdate.Insert:
                    btnThem.Enabled = false;
                    btnLuu.Enabled = true;
                    btnXoa.Enabled = false;
                    btnHuy.Enabled = true;
                    txtRePass.Visible = false;
                    lblRePass.Visible = false;
                    break;
                case QuanLyDoanRa.FormUpdate.Update:
                    btnThem.Enabled = true;
                    btnLuu.Enabled = true;
                    btnXoa.Enabled = true;
                    btnHuy.Enabled = false;                    
                    txtRePass.Visible = false;
                    lblRePass.Visible = false;

                    break;
                case QuanLyDoanRa.FormUpdate.View:
                    btnThem.Enabled = true;
                    btnLuu.Enabled = true;
                    btnXoa.Enabled = true;
                    btnHuy.Enabled = false;
                    
                    txtRePass.Visible = false;
                    lblRePass.Visible = false;

                    break;
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormStatus = QuanLyDoanRa.FormUpdate.Insert;
            SetStatus(FormStatus);
            this.txtUsername.Text = string.Empty;
            this.txtThuDienTu.Text = string.Empty;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            lblRePass.Visible = true;
            txtRePass.Visible = true;
            txtRePass.Text = string.Empty;
        }
    }
}