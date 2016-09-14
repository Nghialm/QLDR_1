using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.Security;
using System.Security.Principal;
using System.Threading;

namespace QuanLyDoanRa
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

       
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn thoát ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            bool ok = Membership.ValidateUser(txtUserName.Text, txtPassword.Text);
            if (ok)
            {

                MembershipUser user;
                user = Membership.GetUser(txtUserName.Text);
                GenericIdentity identity = new GenericIdentity(user.UserName);
                String[] roles = { "Users", "Administrators" };// should query from membership
                roles = Roles.GetAllRoles();
                GenericPrincipal principal = new GenericPrincipal(identity, roles);
                Thread.CurrentPrincipal = principal;
                //Program.CurrentUser = user;
                Program.IsAuthenticated = ok;
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại. Mời bạn nhập lại!");
            }
            

            //TaiKhoan = new SpringSample.Core.Domain.VnsTaiKhoan();
            //TaiKhoan = this.VnsTaiKhoanService.GetByKey("Username", this.txtUser.Text.ToString().Trim());
            //if (TaiKhoan != null)
            //{
            //    if (TaiKhoan.Password == txtPass.Text.ToString())
            //    {
            //        MessageBox.Show("dang nhap thanh cong", "thong bao");
            //        FrmDev frm = (FrmDev)ObjectFactory.GetObject("frmDev");
            //        frm.ShowDialog();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Sai pass", "Thong Bao");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Khong Co Tai Khoan", "Thong Bao");
            //}
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            AcceptButton = btnLogin;
        }
    }
}
