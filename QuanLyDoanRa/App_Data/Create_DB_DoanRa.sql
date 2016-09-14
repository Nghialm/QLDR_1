--USE [QuanLyDoanRa]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VnsChungTu_VnsLoaiChungTu]') AND parent_object_id = OBJECT_ID(N'[dbo].[VnsChungTu]'))
ALTER TABLE [dbo].[VnsChungTu] DROP CONSTRAINT [FK_VnsChungTu_VnsLoaiChungTu]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VnsDoanCongTac_VnsLoaiDoanRa]') AND parent_object_id = OBJECT_ID(N'[dbo].[VnsDoanCongTac]'))
ALTER TABLE [dbo].[VnsDoanCongTac] DROP CONSTRAINT [FK_VnsDoanCongTac_VnsLoaiDoanRa]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VnsDuToanDoan_VnsLichCongTac]') AND parent_object_id = OBJECT_ID(N'[dbo].[VnsDuToanDoan]'))
ALTER TABLE [dbo].[VnsDuToanDoan] DROP CONSTRAINT [FK_VnsDuToanDoan_VnsLichCongTac]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VnsGiaoDich_VnsChungTu]') AND parent_object_id = OBJECT_ID(N'[dbo].[VnsGiaoDich]'))
ALTER TABLE [dbo].[VnsGiaoDich] DROP CONSTRAINT [FK_VnsGiaoDich_VnsChungTu]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VnsLichCongTac_VnsDoanCongTac]') AND parent_object_id = OBJECT_ID(N'[dbo].[VnsLichCongTac]'))
ALTER TABLE [dbo].[VnsLichCongTac] DROP CONSTRAINT [FK_VnsLichCongTac_VnsDoanCongTac]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VnsQuyetToanDoan_VnsLichCongTac]') AND parent_object_id = OBJECT_ID(N'[dbo].[VnsQuyetToanDoan]'))
ALTER TABLE [dbo].[VnsQuyetToanDoan] DROP CONSTRAINT [FK_VnsQuyetToanDoan_VnsLichCongTac]
GO

--USE [QuanLyDoanRa]
GO

/****** Object:  Table [dbo].[VnsChungTu]    Script Date: 10/07/2013 08:49:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VnsChungTu]') AND type in (N'U'))
DROP TABLE [dbo].[VnsChungTu]
GO

/****** Object:  Table [dbo].[VnsDinhMuc]    Script Date: 10/07/2013 08:49:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VnsDinhMuc]') AND type in (N'U'))
DROP TABLE [dbo].[VnsDinhMuc]
GO

/****** Object:  Table [dbo].[VnsDmHeThong]    Script Date: 10/07/2013 08:49:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VnsDmHeThong]') AND type in (N'U'))
DROP TABLE [dbo].[VnsDmHeThong]
GO

/****** Object:  Table [dbo].[VnsDmMucTieuMuc]    Script Date: 10/07/2013 08:49:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VnsDmMucTieuMuc]') AND type in (N'U'))
DROP TABLE [dbo].[VnsDmMucTieuMuc]
GO

/****** Object:  Table [dbo].[VnsDmQuocGia]    Script Date: 10/07/2013 08:49:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VnsDmQuocGia]') AND type in (N'U'))
DROP TABLE [dbo].[VnsDmQuocGia]
GO

/****** Object:  Table [dbo].[VnsDoanCongTac]    Script Date: 10/07/2013 08:49:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VnsDoanCongTac]') AND type in (N'U'))
DROP TABLE [dbo].[VnsDoanCongTac]
GO

/****** Object:  Table [dbo].[VnsDuToanDoan]    Script Date: 10/07/2013 08:49:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VnsDuToanDoan]') AND type in (N'U'))
DROP TABLE [dbo].[VnsDuToanDoan]
GO

/****** Object:  Table [dbo].[VnsGiaoDich]    Script Date: 10/07/2013 08:49:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VnsGiaoDich]') AND type in (N'U'))
DROP TABLE [dbo].[VnsGiaoDich]
GO

/****** Object:  Table [dbo].[VnsLichCongTac]    Script Date: 10/07/2013 08:49:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VnsLichCongTac]') AND type in (N'U'))
DROP TABLE [dbo].[VnsLichCongTac]
GO

/****** Object:  Table [dbo].[VnsLoaiChungTu]    Script Date: 10/07/2013 08:49:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VnsLoaiChungTu]') AND type in (N'U'))
DROP TABLE [dbo].[VnsLoaiChungTu]
GO

/****** Object:  Table [dbo].[VnsLoaiDoanRa]    Script Date: 10/07/2013 08:49:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VnsLoaiDoanRa]') AND type in (N'U'))
DROP TABLE [dbo].[VnsLoaiDoanRa]
GO

/****** Object:  Table [dbo].[VnsNghiepVu]    Script Date: 10/07/2013 08:49:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VnsNghiepVu]') AND type in (N'U'))
DROP TABLE [dbo].[VnsNghiepVu]
GO

/****** Object:  Table [dbo].[VnsQuyetToanDoan]    Script Date: 10/07/2013 08:49:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VnsQuyetToanDoan]') AND type in (N'U'))
DROP TABLE [dbo].[VnsQuyetToanDoan]
GO

/****** Object:  Table [dbo].[VnsThanhVien]    Script Date: 10/07/2013 08:49:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VnsThanhVien]') AND type in (N'U'))
DROP TABLE [dbo].[VnsThanhVien]
GO

--USE [QuanLyDoanRa]
GO

/****** Object:  Table [dbo].[VnsChungTu]    Script Date: 10/07/2013 08:49:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VnsChungTu](
	[ChungTuId] [uniqueidentifier] NOT NULL,
	[NgayCt] [datetime] NULL,
	[NgayHt] [datetime] NULL,
	[SoCt] [varchar](32) NULL,
	[LoaiChungTutId] [uniqueidentifier] NULL,
	[MaLoaiChungTu] [varchar](32) NULL,
	[NoiDung] [nvarchar](512) NULL,
	[NguoiLapPhieu] [nvarchar](128) NULL,
	[NguoiGiaoDich] [nvarchar](128) NULL,
 CONSTRAINT [PK_VnsChungTu] PRIMARY KEY CLUSTERED 
(
	[ChungTuId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

--USE [QuanLyDoanRa]
GO

/****** Object:  Table [dbo].[VnsDinhMuc]    Script Date: 10/07/2013 08:49:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VnsDinhMuc](
	[DinhMucId] [uniqueidentifier] NOT NULL,
	[NgayApDung] [datetime] NOT NULL,
	[NhomNuoc] [int] NOT NULL,
	[LoaiCapVu] [int] NOT NULL,
	[MucId] [uniqueidentifier] NOT NULL,
	[DinhMuc] [numeric](18, 2) NOT NULL,
	[NuocId] [varchar](32) NULL,
	[CachTinh] [int] NOT NULL,
 CONSTRAINT [PK_VnsDinhMuc] PRIMARY KEY CLUSTERED 
(
	[DinhMucId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

--USE [QuanLyDoanRa]
GO

/****** Object:  Table [dbo].[VnsDmHeThong]    Script Date: 10/07/2013 08:49:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VnsDmHeThong](
	[HeThongId] [uniqueidentifier] NOT NULL,
	[Ma] [varchar](32) NOT NULL,
	[Ten] [nvarchar](128) NOT NULL,
	[DoiTuong] [varchar](32) NOT NULL,
	[GiaTri] [int] NOT NULL,
	[ThuTu] [int] NOT NULL,
 CONSTRAINT [PK_VnsDmHeThong] PRIMARY KEY CLUSTERED 
(
	[HeThongId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

--USE [QuanLyDoanRa]
GO

/****** Object:  Table [dbo].[VnsDmMucTieuMuc]    Script Date: 10/07/2013 08:49:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VnsDmMucTieuMuc](
	[MucId] [uniqueidentifier] NOT NULL,
	[MaMuc] [varchar](32) NOT NULL,
	[TenMuc] [nvarchar](128) NULL,
	[IdMucCha] [uniqueidentifier] NULL,
 CONSTRAINT [PK_VnsDmMucTieuMuc_1] PRIMARY KEY CLUSTERED 
(
	[MucId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

--USE [QuanLyDoanRa]
GO

/****** Object:  Table [dbo].[VnsDmQuocGia]    Script Date: 10/07/2013 08:49:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VnsDmQuocGia](
	[NuocId] [uniqueidentifier] NOT NULL,
	[MaNuoc] [varchar](32) NOT NULL,
	[TenNuoc] [nvarchar](128) NOT NULL,
	[PhanLoai] [int] NOT NULL,
 CONSTRAINT [PK_VnsDmQuocGia_1] PRIMARY KEY CLUSTERED 
(
	[NuocId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CAP_BAC_QG' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VnsDmQuocGia', @level2type=N'COLUMN',@level2name=N'PhanLoai'
GO

--USE [QuanLyDoanRa]
GO

/****** Object:  Table [dbo].[VnsDoanCongTac]    Script Date: 10/07/2013 08:49:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VnsDoanCongTac](
	[CongTacId] [uniqueidentifier] NOT NULL,
	[TruongDoan] [nvarchar](128) NULL,
	[Ten] [nvarchar](128) NULL,
	[MoTa] [nvarchar](512) NULL,
	[NgayDi] [datetime] NULL,
	[NgayVe] [datetime] NULL,
	[TrangThai] [int] NOT NULL,
	[LoaiDoanRaId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_VnsDoanCongTac] PRIMARY KEY CLUSTERED 
(
	[CongTacId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRANGTHAI_DOANRA' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VnsDoanCongTac', @level2type=N'COLUMN',@level2name=N'TrangThai'
GO

--USE [QuanLyDoanRa]
GO

/****** Object:  Table [dbo].[VnsDuToanDoan]    Script Date: 10/07/2013 08:49:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VnsDuToanDoan](
	[DuToanId] [uniqueidentifier] NOT NULL,
	[LichCongTacId] [uniqueidentifier] NOT NULL,
	[CongTacId] [uniqueidentifier] NOT NULL,
	[MucId] [uniqueidentifier] NOT NULL,
	[TenKhoanChi] [nvarchar](256) NULL,
	[SoTienDuToan] [numeric](18, 2) NULL,
	[DienGiai] [nvarchar](512) NULL,
	[NgayDuToan] [datetime] NULL,
 CONSTRAINT [PK_VnsDuToanDoan_1] PRIMARY KEY CLUSTERED 
(
	[DuToanId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--USE [QuanLyDoanRa]
GO

/****** Object:  Table [dbo].[VnsGiaoDich]    Script Date: 10/07/2013 08:49:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VnsGiaoDich](
	[GiaoDichId] [uniqueidentifier] NOT NULL,
	[ChungTuId] [uniqueidentifier] NOT NULL,
	[NghiepVuId] [uniqueidentifier] NULL,
	[MaNghiepVu] [varchar](32) NULL,
	[TenNghiepVu] [nvarchar](128) NULL,
	[PhanLoai] [bit] NULL,
	[SoTien] [decimal](18, 0) NULL,
	[TyGia] [decimal](14, 2) NULL,
	[SoTienNt] [decimal](18, 2) NULL,
	[KhachHangId] [uniqueidentifier] NULL,
	[DoanRaId] [uniqueidentifier] NULL,
	[LoaiDoanRaId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_VnsGiaoDich] PRIMARY KEY CLUSTERED 
(
	[GiaoDichId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

--USE [QuanLyDoanRa]
GO

/****** Object:  Table [dbo].[VnsLichCongTac]    Script Date: 10/07/2013 08:49:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VnsLichCongTac](
	[LichCongTacId] [uniqueidentifier] NOT NULL,
	[CongTacId] [uniqueidentifier] NOT NULL,
	[NuocId] [nchar](10) NULL,
	[DiaDiem] [nvarchar](128) NOT NULL,
	[NgayDi] [datetime] NULL,
	[NgayVe] [datetime] NULL,
	[TrangThai] [int] NULL,
	[MoTa] [nvarchar](512) NULL,
	[LoaiQuocGia] [int] NULL,
 CONSTRAINT [PK_VnsLichCongTac] PRIMARY KEY CLUSTERED 
(
	[LichCongTacId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--USE [QuanLyDoanRa]
GO

/****** Object:  Table [dbo].[VnsLoaiChungTu]    Script Date: 10/07/2013 08:49:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VnsLoaiChungTu](
	[LoaiChungTuId] [uniqueidentifier] NOT NULL,
	[MaLoaiChungTu] [varchar](32) NULL,
	[Ten] [nvarchar](128) NULL,
	[LoaiPhieu] [int] NULL,
	[MaTkNo] [varchar](128) NULL,
	[MaTkCo] [varchar](128) NULL,
	[MoTa] [nvarchar](512) NULL,
 CONSTRAINT [PK_VnsLoaiChungTu] PRIMARY KEY CLUSTERED 
(
	[LoaiChungTuId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

--USE [QuanLyDoanRa]
GO

/****** Object:  Table [dbo].[VnsLoaiDoanRa]    Script Date: 10/07/2013 08:49:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VnsLoaiDoanRa](
	[LoaiDoanRaId] [uniqueidentifier] NOT NULL,
	[MaLoaiDoanRa] [varchar](32) NOT NULL,
	[TenLoaiDoanRa] [nvarchar](128) NULL,
 CONSTRAINT [PK_VnsLoaiDoanRa_1] PRIMARY KEY CLUSTERED 
(
	[LoaiDoanRaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

--USE [QuanLyDoanRa]
GO

/****** Object:  Table [dbo].[VnsNghiepVu]    Script Date: 10/07/2013 08:49:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VnsNghiepVu](
	[NghiepVuId] [uniqueidentifier] NOT NULL,
	[MaNghiepVu] [varchar](32) NULL,
	[TenNghiepVu] [nvarchar](128) NULL,
	[MoTa] [nvarchar](512) NULL,
	[LoaiNghiepVu] [int] NULL,
 CONSTRAINT [PK_VnsNghiepVu] PRIMARY KEY CLUSTERED 
(
	[NghiepVuId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

--USE [QuanLyDoanRa]
GO

/****** Object:  Table [dbo].[VnsQuyetToanDoan]    Script Date: 10/07/2013 08:49:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VnsQuyetToanDoan](
	[QuyetToanId] [uniqueidentifier] NOT NULL,
	[LichCongTacId] [uniqueidentifier] NOT NULL,
	[CongTacId] [uniqueidentifier] NOT NULL,
	[MucId] [uniqueidentifier] NOT NULL,
	[TenKhoanChi] [nvarchar](256) NULL,
	[SoTien] [numeric](18, 2) NULL,
	[DienGiai] [nvarchar](512) NULL,
	[NgayCt] [datetime] NULL,
	[NgayHt] [datetime] NULL,
 CONSTRAINT [PK_VnsQuyetToanDoan] PRIMARY KEY CLUSTERED 
(
	[QuyetToanId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--USE [QuanLyDoanRa]
GO

/****** Object:  Table [dbo].[VnsThanhVien]    Script Date: 10/07/2013 08:49:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VnsThanhVien](
	[ThanhVienId] [uniqueidentifier] NOT NULL,
	[TenThanhVien] [nvarchar](512) NULL,
	[SoLuong] [int] NULL,
	[PhanLoai] [int] NULL,
	[LichCongTacId] [uniqueidentifier] NULL,
	[CongTacId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_VnsThanhVien] PRIMARY KEY CLUSTERED 
(
	[ThanhVienId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CAP_BAC_TV' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VnsThanhVien', @level2type=N'COLUMN',@level2name=N'PhanLoai'
GO

ALTER TABLE [dbo].[VnsChungTu]  WITH CHECK ADD  CONSTRAINT [FK_VnsChungTu_VnsLoaiChungTu] FOREIGN KEY([LoaiChungTutId])
REFERENCES [dbo].[VnsLoaiChungTu] ([LoaiChungTuId])
GO

ALTER TABLE [dbo].[VnsChungTu] CHECK CONSTRAINT [FK_VnsChungTu_VnsLoaiChungTu]
GO

ALTER TABLE [dbo].[VnsDoanCongTac]  WITH CHECK ADD  CONSTRAINT [FK_VnsDoanCongTac_VnsLoaiDoanRa] FOREIGN KEY([LoaiDoanRaId])
REFERENCES [dbo].[VnsLoaiDoanRa] ([LoaiDoanRaId])
GO

ALTER TABLE [dbo].[VnsDoanCongTac] CHECK CONSTRAINT [FK_VnsDoanCongTac_VnsLoaiDoanRa]
GO

ALTER TABLE [dbo].[VnsDuToanDoan]  WITH CHECK ADD  CONSTRAINT [FK_VnsDuToanDoan_VnsLichCongTac] FOREIGN KEY([LichCongTacId])
REFERENCES [dbo].[VnsLichCongTac] ([LichCongTacId])
GO

ALTER TABLE [dbo].[VnsDuToanDoan] CHECK CONSTRAINT [FK_VnsDuToanDoan_VnsLichCongTac]
GO

ALTER TABLE [dbo].[VnsGiaoDich]  WITH CHECK ADD  CONSTRAINT [FK_VnsGiaoDich_VnsChungTu] FOREIGN KEY([ChungTuId])
REFERENCES [dbo].[VnsChungTu] ([ChungTuId])
GO

ALTER TABLE [dbo].[VnsGiaoDich] CHECK CONSTRAINT [FK_VnsGiaoDich_VnsChungTu]
GO

ALTER TABLE [dbo].[VnsLichCongTac]  WITH CHECK ADD  CONSTRAINT [FK_VnsLichCongTac_VnsDoanCongTac] FOREIGN KEY([CongTacId])
REFERENCES [dbo].[VnsDoanCongTac] ([CongTacId])
GO

ALTER TABLE [dbo].[VnsLichCongTac] CHECK CONSTRAINT [FK_VnsLichCongTac_VnsDoanCongTac]
GO

ALTER TABLE [dbo].[VnsQuyetToanDoan]  WITH CHECK ADD  CONSTRAINT [FK_VnsQuyetToanDoan_VnsLichCongTac] FOREIGN KEY([LichCongTacId])
REFERENCES [dbo].[VnsLichCongTac] ([LichCongTacId])
GO

ALTER TABLE [dbo].[VnsQuyetToanDoan] CHECK CONSTRAINT [FK_VnsQuyetToanDoan_VnsLichCongTac]
GO


USE [QuanLyDoanRa]
GO

/****** Object:  Table [dbo].[VnsDanhMucChucVu]    Script Date: 10/10/2013 15:58:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VnsDanhMucChucVu](
	[ChucVuId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[TenChucVu] [nvarchar](50) NULL,
	[HeSoA] [float] NULL,
	[HeSoB] [float] NULL,
 CONSTRAINT [PK_VnsDanhMucChucVu] PRIMARY KEY CLUSTERED 
(
	[ChucVuId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[VnsDanhMucChucVu] ADD  CONSTRAINT [DF_VnsDanhMucChucVu_ChucVuId]  DEFAULT (newid()) FOR [ChucVuId]
GO


alter table VnsDoanCongTac add ChucVuTruongDoanId uniqueidentifier