using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.QuanLyDoanRa.Domain;
using QuanLyDoanRa.Commons;
using Vns.QuanLyDoanRa;

namespace QuanLyDoanRa.Controls
{
    public partial class GetSoDu4Input : Form
    {
        public Guid ChungTuId = new Guid();

        public IReportService ReportService;
        public IVnsLoaiDoanRaService VnsLoaiDoanRaService;

        public GetSoDu4Input()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this._IsOk = false;
            this.Close();
        }

        IList<VnsLoaiDoanRa> lstLoaiDoanRa = new List<VnsLoaiDoanRa>();
        private void BindCombo()
        {
            lstLoaiDoanRa = VnsLoaiDoanRaService.GetAll();
            cboLoaiDoanRa.Properties.DataSource = lstLoaiDoanRa;
        }

        private void GetSoDu4Input_Load(object sender, EventArgs e)
        {
            BindCombo();
        }

        IList<RP_Doan_CongNo> lst = new List<RP_Doan_CongNo>();
        private void btLaySoLieu_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) return;

            VnsLoaiDoanRa tmp = (VnsLoaiDoanRa)ComboHelper.GetSelectData(cboLoaiDoanRa);

            DateTime ngaytinh = (DateTime)txtNgayTinh.EditValue;

            if (tmp == null) return;

            String nghiepvu = "";
            if (rbTienMat.Checked) nghiepvu = Globals.TkTienMat;
            else nghiepvu = Globals.TkTienChuyenKhoan;

            IList<RP_Doan_CongNo> lsttmp = new List<RP_Doan_CongNo>();
            lsttmp = ReportService.GetListSoDu(nghiepvu, Null.NullDate, ngaytinh, tmp.Id, tmp.Id, ChungTuId);

            lst = new List<RP_Doan_CongNo>();
            foreach (RP_Doan_CongNo tmpdl in lsttmp)
            {
                tmpdl.TinhToanSoDU();
                if (tmpdl.DuLuong > 0) lst.Add(tmpdl);
            }

            gvSoTien.DataSource = lst;
        }

        private void btXacNhan_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) return;

            Decimal _sotienphanbo = (Decimal)txtSoTien.EditValue;
            Decimal _sotiendaphanbo = 0;
            _lstPhanBo =new List<RP_Doan_CongNo>();
            foreach (RP_Doan_CongNo tmp in lst)
            {
                _sotiendaphanbo += tmp.SoTienXuat;
                if (tmp.DuLuong < tmp.SoTienXuat)
                {
                    MessageBox.Show("Số tiền xuất ra lớn hơn số tiền còn lại!");
                    return;
                }

                if (tmp.SoTienXuat > 0)
                    _lstPhanBo.Add(tmp);
            }

            if (_sotiendaphanbo > _sotienphanbo)
            {
                MessageBox.Show("Số tiền đã phân bổ lớn hơn số tiền cần phân bổ!");
                return; 
            }
            _IsOk = true;
            this.Close();
        }

        private Boolean _IsOk = false;

        public Boolean IsOk
        {
            get { return _IsOk; }
            set { _IsOk = value; }
        }
        private IList<RP_Doan_CongNo> _lstPhanBo = new List<RP_Doan_CongNo>();

        public IList<RP_Doan_CongNo> LstPhanBo
        {
            get { return _lstPhanBo; }
            set { _lstPhanBo = value; }
        }

        private void btTuDong_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) return;

            Decimal _sotienphanbo = (Decimal)txtSoTien.EditValue;
            foreach (RP_Doan_CongNo tmp in lst)
            {
                if (_sotienphanbo == 0) break;

                if (_sotienphanbo >= tmp.DuLuong)
                {
                    tmp.SoTienXuat = tmp.DuLuong;
                    _sotienphanbo -= tmp.DuLuong;
                }
                else
                {
                    tmp.SoTienXuat = _sotienphanbo;
                    _sotienphanbo = 0;
                    break;
                }
            }

            gvSoTien.RefreshDataSource();

        }

        private void txtNgayTinh_Validating(object sender, CancelEventArgs e)
        {
            if (txtNgayTinh.EditValue == null)
            {
                dxErrorProvider1.SetError(txtNgayTinh, "Yêu cầu nhập số liệu!");
                e.Cancel = true;
            }
            else
            {
                dxErrorProvider1.SetError(txtNgayTinh, "");
            }
        }

        private void cboLoaiDoanRa_Validating(object sender, CancelEventArgs e)
        {
            VnsLoaiDoanRa tmp = (VnsLoaiDoanRa)ComboHelper.GetSelectData(cboLoaiDoanRa);
            if (tmp == null)
            {
                dxErrorProvider1.SetError(cboLoaiDoanRa, "Yêu cầu nhập số liệu!");
                e.Cancel = true;
            }
            else
            {
                dxErrorProvider1.SetError(cboLoaiDoanRa, "");
            }
        }

        private void GetSoDu4Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
