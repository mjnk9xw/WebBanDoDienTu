USE [master]
GO
/****** Object:  Database [ThucTap_Nhom]    Script Date: 4/29/2019 10:50:01 PM ******/
CREATE DATABASE [ThucTap_Nhom]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ThucTap_Nhom', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ThucTap_Nhom.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ThucTap_Nhom_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ThucTap_Nhom_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ThucTap_Nhom] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ThucTap_Nhom].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ThucTap_Nhom] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET ARITHABORT OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ThucTap_Nhom] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ThucTap_Nhom] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ThucTap_Nhom] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ThucTap_Nhom] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ThucTap_Nhom] SET  MULTI_USER 
GO
ALTER DATABASE [ThucTap_Nhom] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ThucTap_Nhom] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ThucTap_Nhom] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ThucTap_Nhom] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ThucTap_Nhom] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ThucTap_Nhom]
GO
/****** Object:  Table [dbo].[AlbumAnh]    Script Date: 4/29/2019 10:50:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlbumAnh](
	[AnhID] [int] IDENTITY(1,1) NOT NULL,
	[SanPhamID] [int] NULL,
	[Link] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[AnhID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 4/29/2019 10:50:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[ChiTietHoaDonID] [int] IDENTITY(1,1) NOT NULL,
	[HoaDonID] [int] NULL,
	[SanPhamID] [int] NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[ChiTietHoaDonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 4/29/2019 10:50:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[HoaDonID] [int] IDENTITY(1,1) NOT NULL,
	[KhachHangID] [int] NULL,
	[Time] [smalldatetime] NULL,
	[TongTien] [int] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[HoaDonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 4/29/2019 10:50:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[KhachHangID] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](max) NULL,
	[GioiTinh] [bit] NULL,
	[NgaySInh] [smalldatetime] NULL,
	[CMT] [varchar](12) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[MatKhau_MaHoa] [varchar](max) NULL,
	[TaiKhoan] [varchar](50) NULL,
	[Tien] [int] NULL,
	[Quyen] [int] NULL,
	[SDT] [varchar](12) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[KhachHangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LienHe]    Script Date: 4/29/2019 10:50:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LienHe](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](13) NULL,
	[NoiDung] [nvarchar](max) NULL,
 CONSTRAINT [PK_LienHe] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NSX]    Script Date: 4/29/2019 10:50:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NSX](
	[NSXID] [int] IDENTITY(1,1) NOT NULL,
	[TenNSX] [nvarchar](max) NULL,
	[Mota] [nvarchar](max) NULL,
 CONSTRAINT [PK_NSX] PRIMARY KEY CLUSTERED 
(
	[NSXID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 4/29/2019 10:50:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[SanPhamID] [int] IDENTITY(1,1) NOT NULL,
	[TheLoaiID] [int] NULL,
	[TenSanPham] [nvarchar](max) NULL,
	[GiaKM] [int] NULL,
	[Gia] [int] NULL,
	[SoLuong] [int] NULL,
	[AnhDaiDien] [nvarchar](100) NULL,
	[NSXID] [int] NULL,
	[Ngay] [smalldatetime] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[SanPhamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 4/29/2019 10:50:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[TheLoaiID] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](max) NULL,
	[Mota] [nvarchar](max) NULL,
 CONSTRAINT [PK_TheLoai] PRIMARY KEY CLUSTERED 
(
	[TheLoaiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([KhachHangID], [TenKhachHang], [GioiTinh], [NgaySInh], [CMT], [DiaChi], [MatKhau_MaHoa], [TaiKhoan], [Tien], [Quyen], [SDT]) VALUES (1, N'Nguyen Van Minh', NULL, NULL, NULL, NULL, N'Gj6mkHm21Es=', N'admin', NULL, 99, NULL)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[NSX] ON 

INSERT [dbo].[NSX] ([NSXID], [TenNSX], [Mota]) VALUES (1, N'Apple', N'Máy tính bảng, điện thoại')
INSERT [dbo].[NSX] ([NSXID], [TenNSX], [Mota]) VALUES (2, N'Samsung', N'Máy tính bảng, điện thoại')
INSERT [dbo].[NSX] ([NSXID], [TenNSX], [Mota]) VALUES (3, N'Canon', N'Máy in,máy chiếu, máy ảnh')
INSERT [dbo].[NSX] ([NSXID], [TenNSX], [Mota]) VALUES (4, N'Sony', N'Loa,máy in, máy chiếu, máy ảnh')
INSERT [dbo].[NSX] ([NSXID], [TenNSX], [Mota]) VALUES (5, N'Xiaomi', N'Điện Thoại,Loa, Đồ điện tử')
INSERT [dbo].[NSX] ([NSXID], [TenNSX], [Mota]) VALUES (6, N'Viettel', N'Điện Thoại')
INSERT [dbo].[NSX] ([NSXID], [TenNSX], [Mota]) VALUES (7, N'Nokia', N'Điện Thoại')
INSERT [dbo].[NSX] ([NSXID], [TenNSX], [Mota]) VALUES (8, N'FPT', N'Viễn thông, điện thoại')
INSERT [dbo].[NSX] ([NSXID], [TenNSX], [Mota]) VALUES (9, N'Vin', N'Điện thoại')
INSERT [dbo].[NSX] ([NSXID], [TenNSX], [Mota]) VALUES (10, N'Abey', N'Bàn phím')
INSERT [dbo].[NSX] ([NSXID], [TenNSX], [Mota]) VALUES (11, N'XKeyboard', N'Bàn phím')
INSERT [dbo].[NSX] ([NSXID], [TenNSX], [Mota]) VALUES (12, N'Jbail', N'Loa')
SET IDENTITY_INSERT [dbo].[NSX] OFF
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (1, 1, N'Apple Ipad Air 2', 0, 5000000, 100, N'Apple Ipad Air 2.jpg', 1, CAST(N'2019-02-02 00:00:00' AS SmallDateTime))
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (2, 1, N'Apple Ipad Pro', 0, 20000000, 50, N'Apple Ipad Pro.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (3, 1, N'Apple Ipad 2019', 0, 11000000, 30, N'Apple Ipad 2019.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (4, 1, N'SamSung Pad', 0, 9000000, 50, N'SamSung Pad.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (5, 1, N'Xiaomi Pad', 0, 8000000, 40, N'Xiaomi Pad.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (6, 2, N'Nokia E63', 0, 300000, 15, N'Nokia E63.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (7, 2, N'Nokia 1110i', 0, 80000, 90, N'Nokia 1110i.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (8, 2, N'Nokia E72', 0, 400000, 20, N'Nokia E72.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (9, 2, N'Nokia 8800', 0, 250000, 18, N'Nokia E72.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (10, 2, N'Viettel VT10', 0, 150000, 20, N'Viettel VT10.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (11, 2, N'Viettel VT60', 0, 450000, 40, N'Viettel VT60.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (12, 2, N'FPT FT1', 0, 350000, 25, N'FPT FT1.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (13, 2, N'FPT FT2', 0, 550000, 30, N'FPT FT2.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (14, 3, N'Vin Smart Joy1', 0, 5000000, 50, N'Vin Smart Joy1.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (15, 3, N'Vin Smart Joy2', 0, 8000000, 80, N'Vin Smart Joy2.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (16, 3, N'Vin Smart Joy3', 0, 12000000, 40, N'Vin Smart Joy3.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (17, 3, N'Iphone XS Max 64Gb', 0, 22500000, 25, N'Iphone XS Max 64Gb.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (18, 3, N'Iphone XS Max 128Gb', 0, 24500000, 20, N'Iphone XS Max 128Gb.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (19, 3, N'Iphone XS Max 256Gb', 0, 27500000, 30, N'Iphone XS Max 256Gb.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (20, 3, N'Samsung Glaxy S8  Edge', 0, 8800000, 10, N'Samsung Glaxy S8  Edge.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (21, 3, N'Samsung Galaxy S8', 0, 7900000, 10, N'Samsung Galaxy S8.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (22, 3, N'Samsung Galaxy S9', 0, 12000000, 15, N'Samsung Galaxy S9.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (23, 3, N'Samsung Galaxy S9+', 0, 13800000, 25, N'Samsung Galaxy S9plus.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (24, 3, N'Samsung Galaxy S10', 0, 19000000, 25, N'Samsung Galaxy S10.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (25, 3, N'Samsung Galaxy S10+', 0, 21500000, 20, N'Samsung Galaxy S10plus.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (26, 3, N'Samsung Galaxy Note 9', 0, 20900000, 10, N'Samsung Galaxy Note 9.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (27, 4, N'Samsung 4K HD Infinity', 0, 16000000, 15, N'Samsung 4K HD Infinity.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (28, 4, N'Samsung 2k Edge', 0, 13000000, 15, N'Samsung 2k Edge.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (29, 4, N'Xiaomi Display 4k infinity', 0, 11000000, 10, N'Xiaomi Display 4k infinity.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (30, 4, N'Xiaomi Display Infinity O', 0, 9000000, 15, N'Xiaomi Display Infinity O.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (31, 5, N'Canon 100D', 0, 5000000, 20, N'Canon 100D.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (32, 5, N'Canon 200D', 0, 6500000, 20, N'Canon 200D.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (33, 6, N'Canon LP150H', 0, 4500000, 10, N'Canon LP150H.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (34, 6, N'Canon LP250H', 0, 7500000, 15, N'Canon LP250H.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (35, 6, N'Canon LP XT2', 0, 15000000, 10, N'Canon LP XT2.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (36, 7, N'XKeyboard 2T', 0, 2200000, 20, N'XKeyboard 2T.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (37, 7, N'XKeyboard J6', 0, 1100000, 20, N'XKeyboard J6.jpg', 1, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (38, 7, N'AbeyKB 9', 0, 3500000, 10, N'AbeyKB 9.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (39, 7, N'AbeyKB X', 0, 4500000, 15, N'AbeyKB X.jpg', 3, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (40, 8, N'Fulhen J700', 0, 800000, 50, N'Fulhen J700.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (41, 8, N'Fulhen J900', 0, 1200000, 30, N'Fulhen J900.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (42, 8, N'Fulhen MX1', 0, 1500000, 10, N'Fulhen MX2.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (43, 8, N'Fulhen MX2', 0, 1650000, 15, N'Fulhen MX2.jpg', 1, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (44, 8, N'Newmen 10i', 0, 750000, 25, N'Newmen 10i.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (45, 8, N'Newmen XT1', 0, 1600000, 20, N'Newmen XT1.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (46, 9, N'Jbail Bose B1', 0, 3500000, 8, N'Jbail Bose B1.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (47, 9, N'Jbail Bose B2', 0, 4500000, 10, N'Jbail Bose B2.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (48, 9, N'Sony Bass SB1', 0, 8000000, 10, N'Sony Bass SB1.jpg', 2, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (49, 9, N'Sony Bass XSB', 0, 15000000, 15, N'Sony Bass XSB.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (50, 10, N'Captix C1', 0, 2500000, 10, N'Captix C1.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (51, 10, N'Captix C2', 0, 2800000, 10, N'Captix C2.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (52, 10, N'Ecap E1', 0, 1600000, 15, N'Ecap E1.jpg', 1, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (53, 10, N'Ecap E2', 0, 1800000, 15, N'Ecap E2.jpg', 1, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (54, 11, N'Canon 70D', 0, 25000000, 10, N'Canon 70D.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (55, 11, N'Canon 60D', 0, 20000000, 10, N'Canon 60D.jpg', 1, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (56, 11, N'Sony RX100 Mark 5', 0, 24000000, 15, N'Sony RX100 Mark 5.jpg', NULL, NULL)
INSERT [dbo].[SanPham] ([SanPhamID], [TheLoaiID], [TenSanPham], [GiaKM], [Gia], [SoLuong], [AnhDaiDien], [NSXID], [Ngay]) VALUES (57, 11, N'Sony RX100 Mark 6', 0, 28000000, 20, N'Sony RX100 Mark 6.jpg', NULL, NULL)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
SET IDENTITY_INSERT [dbo].[TheLoai] ON 

INSERT [dbo].[TheLoai] ([TheLoaiID], [TenLoai], [Mota]) VALUES (1, N'Máy Tính Bảng', NULL)
INSERT [dbo].[TheLoai] ([TheLoaiID], [TenLoai], [Mota]) VALUES (2, N'Điện Thoại Bàn Phím', NULL)
INSERT [dbo].[TheLoai] ([TheLoaiID], [TenLoai], [Mota]) VALUES (3, N'Điện Thoại Cảm Ứng', NULL)
INSERT [dbo].[TheLoai] ([TheLoaiID], [TenLoai], [Mota]) VALUES (4, N'Màn Hinh', NULL)
INSERT [dbo].[TheLoai] ([TheLoaiID], [TenLoai], [Mota]) VALUES (5, N'Máy Chiếu', NULL)
INSERT [dbo].[TheLoai] ([TheLoaiID], [TenLoai], [Mota]) VALUES (6, N'Máy In', NULL)
INSERT [dbo].[TheLoai] ([TheLoaiID], [TenLoai], [Mota]) VALUES (7, N'Bàn Phím', NULL)
INSERT [dbo].[TheLoai] ([TheLoaiID], [TenLoai], [Mota]) VALUES (8, N'Chuột', NULL)
INSERT [dbo].[TheLoai] ([TheLoaiID], [TenLoai], [Mota]) VALUES (9, N'Loa', NULL)
INSERT [dbo].[TheLoai] ([TheLoaiID], [TenLoai], [Mota]) VALUES (10, N'Sạc Không Dây', NULL)
INSERT [dbo].[TheLoai] ([TheLoaiID], [TenLoai], [Mota]) VALUES (11, N'Máy Ảnh', NULL)
SET IDENTITY_INSERT [dbo].[TheLoai] OFF
ALTER TABLE [dbo].[AlbumAnh]  WITH CHECK ADD  CONSTRAINT [FK_Image_SanPham] FOREIGN KEY([SanPhamID])
REFERENCES [dbo].[SanPham] ([SanPhamID])
GO
ALTER TABLE [dbo].[AlbumAnh] CHECK CONSTRAINT [FK_Image_SanPham]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([HoaDonID])
REFERENCES [dbo].[HoaDon] ([HoaDonID])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_SanPham] FOREIGN KEY([SanPhamID])
REFERENCES [dbo].[SanPham] ([SanPhamID])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_SanPham]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([KhachHangID])
REFERENCES [dbo].[KhachHang] ([KhachHangID])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_NSX] FOREIGN KEY([NSXID])
REFERENCES [dbo].[NSX] ([NSXID])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_NSX]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_TheLoai] FOREIGN KEY([TheLoaiID])
REFERENCES [dbo].[TheLoai] ([TheLoaiID])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_TheLoai]
GO
USE [master]
GO
ALTER DATABASE [ThucTap_Nhom] SET  READ_WRITE 
GO
