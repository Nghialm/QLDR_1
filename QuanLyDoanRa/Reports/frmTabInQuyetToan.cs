using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.Erp.Core;
using System.Reflection;
//using Microsoft.Office.Interop.Word;
//using Microsoft.Office.Core;
//using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using Vns.QuanLyDoanRa.Service.Interface;
using Microsoft.CSharp;

using System.IO;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;//<- this is what I am talking about

namespace QuanLyDoanRa.Reports
{
    public partial class frmTabInQuyetToan : DevExpress.XtraEditors.XtraForm
    {

        public IVnsLichCongTacService VnsLichCongTacService;
        public IVnsThanhVienService VnsThanhVienService;
        public IVnsDmQuocGiaService VnsDmQuocGiaService;
        public IVnsDanhMucChucVuService VnsDanhMucChucVuService;
        public frmTabInQuyetToan()
        {
            InitializeComponent();
        }
        private InQuyetToan Phan2;
        private InBiaQuyetToan Phan1;
        private IList<VnsInQtTu> m_lst;
        private VnsDoanCongTac m_objDoanRa;
        private String LoaiDoanRa = "";
        private Boolean _InKemThongBao = true;
        public Boolean InKemThongBao
        {
            get { return _InKemThongBao; }
            set { _InKemThongBao = value; }
        }

        private bool KieuBaoCao = false;

        String TenDoanRa = "";
        String TruongDoan = "";
        String ChucVu = "";
        String NoiDen = "";
        String NuocCongTac = "Nơi đến : ";
        String TenBaoCao = "";
        String DoanGom = "";
        String TuNgayDenNgay = "";
        String VanPhong = "";
        string CanCuHoSo = "";
        string SoThongBao = "Số ";
        IList<VnsInQtTu> lstQT = new List<VnsInQtTu>();
        public frmTabInQuyetToan(IList<VnsInQtTu> p_lst, VnsDoanCongTac p_objDoanRa, string Flag, bool p_KieuBaoCao)
        {
            InitializeComponent();
            m_lst = p_lst;
            m_objDoanRa = p_objDoanRa;
            LoaiDoanRa = Flag;
            KieuBaoCao = p_KieuBaoCao;
        }


        private void frmTabInQuyetToan_Load(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPage = xtraTabPage1;

            Phan2 = new InQuyetToan(m_lst, m_objDoanRa, LoaiDoanRa);
            this.printControl2.PrintingSystem = Phan2.PrintingSystem;
            this.Phan2.CreateDocument();

            Phan1 = (InBiaQuyetToan)ObjectFactory.GetObject("InBiaQuyetToan");
            Phan1.InKemThongBao = _InKemThongBao;
            this.printControl1.PrintingSystem = Phan1.PrintingSystem;
            this.Phan1.LoadData(m_lst, m_objDoanRa, LoaiDoanRa, KieuBaoCao);
            this.Phan1.CreateDocument();

            Phan1.Pages.AddRange(Phan2.Pages);
            Phan1.PrintingSystem.ContinuousPageNumbering = true;
            //Mac dinh Tab dau tien
            printBarManager.PrintControl = printControl1;

            VnsLichCongTacService = (IVnsLichCongTacService)ObjectFactory.GetObject("VnsLichCongTacService");
            VnsThanhVienService = (IVnsThanhVienService)ObjectFactory.GetObject("VnsThanhVienService");
            VnsDmQuocGiaService = (IVnsDmQuocGiaService)ObjectFactory.GetObject("VnsDmQuocGiaService");
            VnsDanhMucChucVuService = (IVnsDanhMucChucVuService)ObjectFactory.GetObject("VnsDanhMucChucVuService");
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
                {
                    printBarManager.PrintControl = printControl1;
                }
                else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
                {
                    printBarManager.PrintControl = printControl2;
                }
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //  Just to kill WINWORD.EXE if it is running
                //killprocess("winword");
                //  copy letter format to temp.doc
                SaveFileDialog frm = new SaveFileDialog();
                string FileDocName = "";

                frm.DefaultExt = "doc";
                frm.Filter = "Doc files (*.doc)|";
                frm.InitialDirectory =
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                frm.ShowDialog();

                FileDocName = frm.FileName;

                if (string.IsNullOrEmpty(FileDocName))
                {
                    return;
                }
                
                File.Copy(General.CurrReport + "temp.doc", FileDocName, true);
                //  create missing object
                object missing = Missing.Value;
                //  create Word application object
                Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                //  create Word document object
                Word.Document aDoc = null;
                //  create & define filename object with temp.doc
                object filename = FileDocName;
                //  if temp.doc available
                if (File.Exists((string)filename))
                {
                    object readOnly = false;
                    object isVisible = false;
                    //  make visible Word application
                    wordApp.Visible = false;
                    //  open Word document named temp.doc
                    aDoc = wordApp.Documents.Open(ref filename, ref missing,
        ref readOnly, ref missing, ref missing, ref missing,
        ref missing, ref missing, ref missing, ref missing,
        ref missing, ref isVisible, ref missing, ref missing,
        ref missing, ref missing);
                    aDoc.Activate();
                    //  Call FindAndReplace()function for each change

                    SoThongBao += _InKemThongBao ? m_objDoanRa.SoThongBaoDuToan : "        ";  //objDoanRa.SoThongBaoDuToan; //Trong to trinh khong co so thong bao du toan
                    String ngay = _InKemThongBao ? General.NgayIn.ToString("dd") : "  ";
                    string thang = _InKemThongBao ? General.NgayIn.ToString("MM") : "  ";
                    string nam = _InKemThongBao ? General.NgayIn.ToString("yyyy") : "      ";

                    if (LoaiDoanRa == "QT")
                    {
                        if (KieuBaoCao)
                        {
                            TenBaoCao = "phê duyệt quyết toán đoàn ra";
                        }
                        else
                            TenBaoCao = "phê duyệt quyết toán bổ sung đoàn ra";
                        VanPhong += "Văn phòng Trung ương Đảng thông báo quyết toán chi đoàn đi công tác nước ngoài như sau: ";
                        CanCuHoSo = "- Căn cứ hồ sơ quyết toán đoàn ra";
                        SoThongBao += _InKemThongBao ? m_objDoanRa.SoThongBaoQuyetToan : "        "; //objDoanRa.SoThongBaoQuyetToan; //Trong in to trinh chua co so thong bao du toan
                    }
                    else
                    {
                        TenBaoCao = "phê duyệt dự toán đoàn ra";
                        VanPhong += "Văn phòng Trung ương Đảng thông báo dự toán chi đoàn đi công tác nước ngoài như sau: ";
                        CanCuHoSo = "- Căn cứ hồ sơ dự toán đoàn ra";
                        SoThongBao += _InKemThongBao ? m_objDoanRa.SoThongBaoDuToan : "        ";  //objDoanRa.SoThongBaoDuToan; //Trong to trinh khong co so thong bao du toan
                    }

                    if (General.SoCanCuHoSo != string.Empty)
                        CanCuHoSo += String.Format(" số {0}, ", General.SoCanCuHoSo);
                    CanCuHoSo += " ngày " + General.NgayCanCu + " do " + m_objDoanRa.Ten + " lập,";
                    TenDoanRa = m_objDoanRa.Ten;
                    TruongDoan = "Trưởng đoàn : Đồng chí " + m_objDoanRa.TruongDoan;
                    TuNgayDenNgay = ", đi từ ngày " + m_objDoanRa.NgayDi.ToString("dd-MM-yyyy") + " đến ngày " + m_objDoanRa.NgayVe.ToString("dd-MM-yyyy");

                    IList<VnsLichCongTac> lstLCT = this.VnsLichCongTacService.GetByDoanCongTac(m_objDoanRa.Id);
                    int songuoiA = 0;
                    int songuoiB = 0;
                    VnsDanhMucChucVu objChucVu = this.VnsDanhMucChucVuService.GetById(m_objDoanRa.ChucVuTruongDoanId);
                    if (objChucVu != null) ChucVu = "Chức vụ : " + objChucVu.TenChucVu;
                    for (int i = 0; i < lstLCT.Count; i++)
                    {
                        VnsLichCongTac obj = lstLCT[i];
                        NuocCongTac += obj.objNuocDen.TenNuoc;
                        if (lstLCT.Count > 1 && i < lstLCT.Count - 1)
                            NuocCongTac += ", ";
                        IList<VnsThanhVien> lstTV = this.VnsThanhVienService.GetThanhVienByLichCongTacDoanRa(obj.Id, obj.CongTacId);
                        foreach (VnsThanhVien objTV in lstTV)
                        {
                            if (objTV.PhanLoai == 1)
                                songuoiA = objTV.SoLuong;
                            if (objTV.PhanLoai == 2)
                                songuoiB = objTV.SoLuong;
                        }
                    }
                    DoanGom = "Đoàn gồm : ";
                    if (songuoiA > 0)
                    {
                        DoanGom += songuoiA.ToString() + "A";
                    }
                    if (!(songuoiA < 1 || songuoiB < 1))
                    {
                        DoanGom += " và ";
                    }
                    if (songuoiB > 0)
                        DoanGom += songuoiB.ToString() + "B ";
                    int SoNguoi = songuoiB + songuoiA;
                    DoanGom += "(" + SoNguoi.ToString() + " người)" + TuNgayDenNgay;
                    lstQT = m_lst;

                    this.FindAndReplace(wordApp, "<SoTB>", SoThongBao);
                    this.FindAndReplace(wordApp, "<xrNgay>", ngay);
                    this.FindAndReplace(wordApp, "<xrThang>", thang);
                    this.FindAndReplace(wordApp, "<xrNam>", nam);

                    this.FindAndReplace(wordApp, "<TenBaoCao>", TenBaoCao);
                    
                    this.FindAndReplace(wordApp, "<xrCanCu>", CanCuHoSo);
                    this.FindAndReplace(wordApp, "<xrVanPhong>", VanPhong);
                    this.FindAndReplace(wordApp, "<xrDoanDaiBieu>", TenDoanRa);
                    this.FindAndReplace(wordApp, "<xrTruongDoan>", TruongDoan);
                    this.FindAndReplace(wordApp, "<xrChucVu>", ChucVu);
                    this.FindAndReplace(wordApp, "<xrNoiDen>", NuocCongTac);

                    String tmpTheoCongVan = General.TheoCongVan;
                    int count = tmpTheoCongVan.Length;
                    int indexStart = 0;
                    int indexEnd = 0;

                    for (int i = 0; i <= 5; i++)
                    {
                        indexStart = i * 100;
                        indexEnd = indexStart + 100;

                        if (count < indexStart)
                        {
                            tmpTheoCongVan = "";
                        }

                        if (count > indexEnd)
                        {
                            tmpTheoCongVan = General.TheoCongVan.Substring(indexStart, 100);
                        }

                        if (count >= indexStart && count <= indexEnd)
                        {
                            tmpTheoCongVan = General.TheoCongVan.Substring(indexStart);
                        }

                        this.FindAndReplace(wordApp, string.Format("<xrTheoCongVan{0}>", i.ToString()), tmpTheoCongVan);
                    }

                    //this.FindAndReplace(wordApp, "<xrTheoCongVan>", General.TheoCongVan);
                    
                    this.FindAndReplace(wordApp, "<xrDoanGom>", DoanGom);

                    ModifeTable(aDoc, lstQT);

                    string GiaTri = "";
                    string strPrInQuyetToan = "";
                    string lblNguoiPheDuyet = "";
                    if (LoaiDoanRa == "QT")
                    {
                        GiaTri = "Giá trị quyết toán :";
                        strPrInQuyetToan = "Quyết toán tiền (USD)";
                        lblNguoiPheDuyet = General.NguoiPheDuyetQuyetToan;
                        //lblChucDanhPheDuyet.Text = General.ChucDanhDuyetQuyetToan;
                    }
                    else
                    {
                        GiaTri = "Giá trị dự toán :";
                        strPrInQuyetToan = "Dự toán tiền (USD)";
                        lblNguoiPheDuyet = General.NguoiPheDuyetDuToan;
                        //lblChucDanhPheDuyet.Text = General.ChucDanhDuyetDuToan;
                    }

                    long dSoTien = 0;
                    long dSoTienVND = 0;

                    String TienViet = "";
                    String TienUSD = "";
                    foreach (VnsInQtTu obj in lstQT)
                    {
                        dSoTien += (long)obj.SoTien;
                        dSoTienVND += (long)obj.SoTienVND;
                    }

                    TienUSD += "- Tiền USD: ";
                    TienUSD += String.Format("{0:0,0}", dSoTien) + " USD (";
                    TienUSD += Commons.Commons.DocTienBangChu(dSoTien, "");
                    TienUSD += " đô la Mỹ).";

                    TienViet += "- Tiền Việt Nam đồng: ";
                    TienViet += String.Format("{0:0,0}", dSoTienVND) + " đồng (";
                    TienViet += Commons.Commons.DocTienBangChu(dSoTienVND, "");
                    TienViet += " đồng).";
                    
                    this.FindAndReplace(wordApp, "<xrGiaTriQuyetToan>", GiaTri);
                    this.FindAndReplace(wordApp, "<xrGiaTriUSD>", TienUSD);
                    this.FindAndReplace(wordApp, "<xrGiaTriVND>", TienViet);
                    this.FindAndReplace(wordApp, "<xrNguoiPheDuyet>", lblNguoiPheDuyet);

                    //  save temp.doc after modified
                    aDoc.Save();

                    
                    MessageBox.Show("Đã thực hiện thành công!");
                }
                else
                    MessageBox.Show("File does not exist.",
            "No File", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
                //killprocess("winword");

                aDoc.Close();
                wordApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in process.", "Internal Error:" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindAndReplace(Word.Application wordApp,
            object findText, object replaceText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            wordApp.Selection.Find.Execute(ref findText, ref matchCase,
                ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
                ref matchAllWordForms, ref forward, ref wrap, ref format,
                ref replaceText, ref replace, ref matchKashida,
                        ref matchDiacritics,
                ref matchAlefHamza, ref matchControl);
        }

        private void ModifeTable(Word.Document aDoc, IList<VnsInQtTu> lstQT)
        {
            int whichTable = 1; //starting index is 1, not 0
            bool isFound = false;
            object missing = Missing.Value;

            do
            {
                isFound = aDoc.Tables[whichTable].Range.Find.Execute("6800", ref missing, ref missing, ref missing, ref missing,
                           ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                           ref missing, ref missing, ref missing);

                if (isFound == true)
                {
                    //everytime, isFound returns true. The right must be 2
                    break;
                }
                whichTable++;
            } while (true);

            Word.Table tbl = aDoc.Tables[whichTable];

            //Alter table

            string group = "";
            int dem = 2;
            int dongnhomtruoc = 0;
            decimal tongtien = 0;
            decimal tongtiengroup = 0;

            decimal tongtienVND = 0;
            decimal tongtiengroupVND = 0;
            
            List<VnsInQtTu> lsttmp = new List<VnsInQtTu>(lstQT);
            lsttmp.Sort(VnsInQtTu.CompareSoQuyetToan);
            foreach (VnsInQtTu tmp in lsttmp)
            {
                if (tmp.MaMuc != group)
                {
                    group = tmp.MaMuc;
                    dem++;
                    tbl.Rows.Add(ref missing);
                    tbl.Cell(dem, 2).Range.Font.Bold = 1;
                    tbl.Cell(dem, 2).Range.Text = tmp.MaMuc;
                    tbl.Cell(dem, 3).Range.Font.Bold = 1;
                    tbl.Cell(dem, 3).Range.Text = tmp.TenMuc;

                    if (dongnhomtruoc != 0)
                    {
                        if (tongtiengroup != 0) tbl.Cell(dongnhomtruoc, 5).Range.Text = tongtiengroup.ToString("n0");
                        if (tongtiengroupVND != 0)  tbl.Cell(dongnhomtruoc, 6).Range.Text = tongtiengroupVND.ToString("n0");
                    }

                    tongtiengroup = 0;
                    tongtiengroupVND = 0;
                    dongnhomtruoc = dem;
                }

                dem++;
                tbl.Rows.Add(ref missing);
                tbl.Cell(dem, 3).Range.Font.Bold = 0;
                tbl.Cell(dem, 3).Range.Text = tmp.TenKhoanChi;
                tbl.Cell(dem, 4).Range.Font.Bold = 0;
                tbl.Cell(dem, 4).Range.Text = tmp.DienGiai;
                
                tbl.Cell(dem, 5).Range.Font.Bold = 0;
                if (tmp.SoTien != 0) tbl.Cell(dem, 5).Range.Text = tmp.SoTien.ToString("n0");
                
                tbl.Cell(dem, 6).Range.Font.Bold = 0;
                if (tmp.SoTienVND != 0) tbl.Cell(dem, 6).Range.Text = tmp.SoTienVND.ToString("n0");

                if (tmp.NgoaiTeId == Vns.QuanLyDoanRa.Globals.NgoaiTeId)
                {
                    tongtien += tmp.SoTien;
                    tongtiengroup += tmp.SoTien;
                }

                if (tmp.NgoaiTeId == Vns.QuanLyDoanRa.Globals.NoiTeId)
                {
                    tongtienVND += tmp.SoTienVND;
                    tongtiengroupVND += tmp.SoTienVND;
                }
            }

            if (dongnhomtruoc != 0)
            {
                if (tongtiengroup != 0) tbl.Cell(dongnhomtruoc, 5).Range.Text = tongtiengroup.ToString("n0");
                if (tongtiengroupVND != 0) tbl.Cell(dongnhomtruoc, 6).Range.Text = tongtiengroupVND.ToString("n0");
            }

            if (tongtien != 0) tbl.Cell(2, 5).Range.Text = tongtien.ToString("n0");
            else tbl.Cell(2, 5).Range.Text = "";

            if (tongtienVND != 0) tbl.Cell(2, 6).Range.Text = tongtienVND.ToString("n0");
            else tbl.Cell(2, 6).Range.Text = "";
        }


        private void LoadData(IList<VnsInQtTu> lst, VnsDoanCongTac objDoanRa, string Flag, bool pKieuBaoCao)
        {

            if (Flag == "QT")
            {
                if (pKieuBaoCao)
                {
                    TenBaoCao = "Phê duyệt quyết toán đoàn ra";
                }
                else
                    TenBaoCao = "Phê duyệt quyết toán bổ sung đoàn ra";
                VanPhong += "Văn phòng Trung ương Đảng thông báo quyết toán chi đoàn đi công tác nước ngoài như sau: ";
                CanCuHoSo = "Căn cứ hồ sơ quyết toán đoàn ra";
                SoThongBao += "        "; //objDoanRa.SoThongBaoQuyetToan; //Trong in to trinh chua co so thong bao du toan
            }
            else
            {
                TenBaoCao = "Phê duyệt dự toán đoàn ra";
                VanPhong += "Văn phòng Trung ương Đảng thông báo dự toán chi đoàn đi công tác nước ngoài như sau: ";
                CanCuHoSo = "Căn cứ hồ sơ dự toán đoàn ra";
                SoThongBao += "        ";  //objDoanRa.SoThongBaoDuToan; //Trong to trinh khong co so thong bao du toan
            }
            if (General.SoCanCuHoSo != string.Empty)
                CanCuHoSo += String.Format("số {0}, ", General.SoCanCuHoSo);
            CanCuHoSo += " ngày " + General.NgayCanCu + " do " + objDoanRa.Ten + " lập,";
            TenDoanRa = "Đoàn đại biểu : " + objDoanRa.Ten;
            TruongDoan = "Trưởng đoàn : Đồng chí " + objDoanRa.TruongDoan;
            TuNgayDenNgay = ", đi từ ngày " + objDoanRa.NgayDi.ToString("dd-MM-yyyy") + " đến ngày " + objDoanRa.NgayVe.ToString("dd-MM-yyyy");
            SoThongBao += "-TB/VPTW/nb";
            IList<VnsLichCongTac> lstLCT = this.VnsLichCongTacService.GetByDoanCongTac(objDoanRa.Id);
            int songuoiA = 0;
            int songuoiB = 0;
            VnsDanhMucChucVu objChucVu = this.VnsDanhMucChucVuService.GetById(objDoanRa.ChucVuTruongDoanId);
            if (objChucVu != null) ChucVu = "Chức vụ : " + objChucVu.TenChucVu;
            for (int i = 0; i < lstLCT.Count; i++)
            {
                VnsLichCongTac obj = lstLCT[i];
                NuocCongTac += obj.objNuocDen.TenNuoc;
                if (lstLCT.Count > 1 && i < lstLCT.Count - 1)
                    NuocCongTac += ", ";
                IList<VnsThanhVien> lstTV = this.VnsThanhVienService.GetThanhVienByLichCongTacDoanRa(obj.Id, obj.CongTacId);
                foreach (VnsThanhVien objTV in lstTV)
                {
                    if (objTV.PhanLoai == 1)
                        songuoiA = objTV.SoLuong;
                    if (objTV.PhanLoai == 2)
                        songuoiB = objTV.SoLuong;
                }
            }
            DoanGom = "Đoàn gồm : ";
            if (songuoiA > 0)
            {
                DoanGom += songuoiA.ToString() + "A";
            }
            if (!(songuoiA < 1 || songuoiB < 1))
            {
                DoanGom += " và ";
            }
            if (songuoiB > 0)
                DoanGom += songuoiB.ToString() + "B ";
            int SoNguoi = songuoiB + songuoiA;
            DoanGom += "(" + SoNguoi.ToString() + " người)" + TuNgayDenNgay;
            lstQT = lst;

            object templatefile = Directory.GetCurrentDirectory() + "\\TempReport\\" + "BiaQuyetToan.docx";
            object desfile = Directory.GetCurrentDirectory() + "\\TempReport\\" + "Bia_exported.docx";
            //CreateWordDocument(templatefile, desfile, Commons.Commons.ToDataTable<VnsInQtTu>(lstQT));

            //CreateWordTableWithDataTable();
        }
        //Methode Find and Replace:
        #region rao tam
        //private void FindAndReplace(Microsoft.Office.Interop.Word.Application wordApp, object findText, object replaceWithText)
        //{
        //    object matchCase = true;
        //    object matchWholeWord = true;
        //    object matchWildCards = false;
        //    object matchSoundLike = false;
        //    object nmatchAllForms = false;
        //    object forward = true;
        //    object format = false;
        //    object matchKashida = false;
        //    object matchDiactitics = false;
        //    object matchAlefHamza = false;
        //    object matchControl = false;
        //    object read_only = false;
        //    object visible = true;
        //    object replace = 2;
        //    object wrap = 1;

        //    wordApp.Selection.Find.Execute(ref findText,
        //                ref matchCase, ref matchWholeWord,
        //                ref matchWildCards, ref matchSoundLike,
        //                ref nmatchAllForms, ref forward,
        //                ref wrap, ref format, ref replaceWithText,
        //                ref replace, ref matchKashida,
        //                ref matchDiactitics, ref matchAlefHamza,
        //                ref matchControl);
        //}

        //private void CreateWordDocument(object filename, object savaAs, System.Data.DataTable dt)
        //{
        //    object missing = Missing.Value;
        //    string tempPath = null;
        //    Word.Application wordApp = new Word.Application();

        //    Word.Document aDoc = null;

        //    if (File.Exists((string)filename))
        //    {
        //        DateTime today = DateTime.Now;

        //        object readOnly = false; //default
        //        object isVisible = false;

        //        wordApp.Visible = false;

        //        aDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
        //                                    ref missing, ref missing, ref missing,
        //                                    ref missing, ref missing, ref missing,
        //                                    ref missing, ref missing, ref missing,
        //                                    ref missing, ref missing, ref missing, ref missing);

        //        aDoc.Activate();
        //        //Find and replace:
        //        this.FindAndReplace(wordApp, "<rpCanCu>", CanCuHoSo);
        //        this.FindAndReplace(wordApp, "<rpVanPhong>", VanPhong);
        //        this.FindAndReplace(wordApp, "<rpDoanDaiBieu>", TenDoanRa);
        //        this.FindAndReplace(wordApp, "<prTruongDoan>", TruongDoan);
        //        this.FindAndReplace(wordApp, "<rpChucVu>", ChucVu);
        //        this.FindAndReplace(wordApp, "<rpNoiDen>", NuocCongTac);
        //        this.FindAndReplace(wordApp, "<rpTheoCongVan>", General.TheoCongVan);
        //        this.FindAndReplace(wordApp, "<rpDoanGom>", DoanGom);
        //        this.FindAndReplace(wordApp, "<reportName>", TenBaoCao);
        //        this.FindAndReplace(wordApp, "<rpNgayIn>", String.Format("Hà Nội, ngày {0} tháng {1} năm {2}", "  ", "  ", "    "));

        //        //insert the picture:
        //        //Image img = resizeImage(pathImage, new Size(200, 90));
        //        //tempPath = System.Windows.Forms.Application.StartupPath + "\\Images\\~Temp\\temp.jpg";
        //        //img.Save(tempPath);

        //        //Object oMissed = aDoc.Paragraphs[1].Range; //the position you want to insert
        //        //Object oLinkToFile = false;  //default
        //        //Object oSaveWithDocument = true;//default
        //        //aDoc.InlineShapes.AddPicture(tempPath, ref  oLinkToFile, ref  oSaveWithDocument, ref oMissed);

        //        #region Print Document :





        //        //aDoc.Content.
        //        /*object copies = "1";
        //        object pages = "1";
        //        object range = Word.WdPrintOutRange.wdPrintCurrentPage;
        //        object items = Word.WdPrintOutItem.wdPrintDocumentContent;
        //        object pageType = Word.WdPrintOutPages.wdPrintAllPages;
        //        object oTrue = true;
        //        object oFalse = false;

        //        Word.Document document = aDoc;
        //        object nullobj = Missing.Value;
        //        int dialogResult = wordApp.Dialogs[Microsoft.Office.Interop.Word.WdWordDialog.wdDialogFilePrint].Show(ref nullobj);
        //        wordApp.Visible = false;
        //        if (dialogResult == 1)
        //        {
        //            document.PrintOut(
        //            ref oTrue, ref oFalse, ref range, ref missing, ref missing, ref missing,
        //            ref items, ref copies, ref pages, ref pageType, ref oFalse, ref oTrue,
        //            ref missing, ref oFalse, ref missing, ref missing, ref missing, ref missing);
        //        }
        //        */
        //        #endregion

        //    }
        //    else
        //    {
        //        MessageBox.Show("file dose not exist.");
        //        return;
        //    }

        //    //Save as: filename
        //    aDoc.SaveAs(ref savaAs, ref missing, ref missing, ref missing,
        //            ref missing, ref missing, ref missing,
        //            ref missing, ref missing, ref missing,
        //            ref missing, ref missing, ref missing,
        //            ref missing, ref missing, ref missing);
        //    //Word.Document oDoc = new Word.Document();
        //    aDoc.Application.Visible = true;
        //    aDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;
        //    int RowCount = dt.Rows.Count;
        //    int ColumnCount = dt.Columns.Count;
        //    //object missing = Missing.Value;
        //    Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];
        //    //int RowCount = 0; int ColumnCount = 0;
        //    int r = 0;
        //    for (int c = 0; c < ColumnCount; c++)
        //    {
        //        DataArray[r, c] = dt.Columns[c].ColumnName;
        //        for (r = 0; r < RowCount; r++)
        //        {
        //            DataArray[r, c] = dt.Rows[r][c];
        //        } //end row loop
        //    } //end column loop

        //    Range oRange = aDoc.Content.Application.Selection.Range;
        //    String oTemp = "";
        //    for (r = 0; r < RowCount; r++)
        //    {
        //        for (int c = 0; c < ColumnCount; c++)
        //        {
        //            oTemp = oTemp + DataArray[r, c] + "\t";
        //        }
        //    }
        //    oRange.Text = oTemp;
        //    object Separator = Word.WdTableFieldSeparator.wdSeparateByDefaultListSeparator;
        //    object Format = Word.WdTableFormat.wdTableFormatWeb1;
        //    object ApplyBorders = true;
        //    object AutoFit = true;
        //    object object_rowcount = RowCount;
        //    object object_columncount = ColumnCount;
        //    object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;
        //    oRange.ConvertToTable(ref Separator, ref object_rowcount, ref object_columncount, ref missing, ref Format, ref ApplyBorders,
        //        ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref AutoFit,
        //        ref AutoFitBehavior, ref missing);
        //    oRange.Select();
        //    aDoc.Application.Selection.Tables[1].Select();
        //    aDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
        //    aDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
        //    aDoc.Application.Selection.Tables[1].Rows[1].Select();
        //    aDoc.Application.Selection.InsertRowsAbove(1);
        //    aDoc.Application.Selection.Tables[1].Rows[1].Select();

        //    //gotta do the header row manually
        //    for (int c = 0; c < ColumnCount; c++)
        //    {
        //        aDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = dt.Columns[c].ColumnName;
        //    }

        //    aDoc.Application.Selection.Tables[1].Rows[1].Select();
        //    aDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //    //Close Document:
        //    aDoc.Close(ref missing, ref missing, ref missing);
        //    //File.Delete(tempPath);
        //    MessageBox.Show("File created.");
        //}

        //public void CreateWordTableWithDataTable(System.Data.DataTable dt)
        //{
        //    int RowCount = dt.Rows.Count;
        //    int ColumnCount = dt.Columns.Count;
        //    object missing = Missing.Value;
        //    Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];
        //    //int RowCount = 0; int ColumnCount = 0;
        //    int r = 0;
        //    for (int c = 0; c < ColumnCount; c++)
        //    {
        //        DataArray[r, c] = dt.Columns[c].ColumnName;
        //        for (r = 0; r < RowCount; r++)
        //        {
        //            DataArray[r, c] = dt.Rows[r][c];
        //        } //end row loop
        //    } //end column loop

        //    Word.Document oDoc = new Word.Document();
        //    oDoc.Application.Visible = true;
        //    oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

        //    Range oRange = oDoc.Content.Application.Selection.Range;
        //    String oTemp = "";
        //    for (r = 0; r < RowCount; r++)
        //    {
        //        for (int c = 0; c < ColumnCount; c++)
        //        {
        //            oTemp = oTemp + DataArray[r, c] + "\t";
        //        }
        //    }
        //    oRange.Text = oTemp;           
        //    object Separator = Word.WdTableFieldSeparator.wdSeparateByDefaultListSeparator;
        //    object Format = Word.WdTableFormat.wdTableFormatWeb1;
        //    object ApplyBorders = true;
        //    object AutoFit = true;
        //    object object_rowcount = RowCount;
        //    object object_columncount = ColumnCount;
        //    object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;
        //    oRange.ConvertToTable(ref Separator, ref object_rowcount, ref object_columncount, ref missing, ref Format, ref ApplyBorders,
        //        ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref AutoFit,
        //        ref AutoFitBehavior, ref missing);

        //    oRange.Select();
        //    oDoc.Application.Selection.Tables[1].Select();
        //    oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
        //    oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
        //    oDoc.Application.Selection.Tables[1].Rows[1].Select();
        //    oDoc.Application.Selection.InsertRowsAbove(1);
        //    oDoc.Application.Selection.Tables[1].Rows[1].Select();

        //    //gotta do the header row manually
        //    for (int c = 0; c < ColumnCount; c++)
        //    {
        //       oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = dt.Columns[c].ColumnName;
        //    }

        //    oDoc.Application.Selection.Tables[1].Rows[1].Select();
        //    oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;                      
        //}
        #endregion

    }
}