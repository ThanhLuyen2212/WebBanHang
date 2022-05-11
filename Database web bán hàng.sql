drop database WebBanHang
create database WebBanHang
use WebBanHang
go 

create table KhachHang
(
	IDKH int primary key Identity(1,1),
	TenKH nvarchar(50), 
	SDT nvarchar(50) ,
	DiaChi nvarchar(50) ,
	NgaySinh datetime,
	UserName nvarchar(50)  , 
	Password nvarchar(50)  ,
)

create table Admin
(
	IDAdmin int primary key Identity(1,1),
	TenAdmin nvarchar(50), 
	SDT nvarchar(50) ,
	DiaChi nvarchar(50) ,
	NgaySinh datetime,
	UserName nvarchar(50)  , 
	Password nvarchar(50)  ,
)

create table LoaiMatHang
(
	IDLoaiMH int primary key Identity(1,1),
	TenLoaiMH NVARCHAR(50),
)

create table MatHang
(
	IDMH int primary key Identity(1,1),
	TenMH NVARCHAR(50)  ,
	IDLoaiMH int,
	MoTa NVARCHAR(max),
	DonGia int,		
	HinhAnh1 NVARCHAR(max) ,
	HinhAnh2 NVARCHAR(max) ,
	HinhAnh3 NVARCHAR(max) ,
	CONSTRAINT FK_MATHANG_LOAIMATHANG FOREIGN KEY (IDLoaiMH) REFERENCES LoaiMatHang(IDLoaiMH),
)

create table PhuongThucThanhToan
(
	IDPT int primary key Identity(1,1),
	TenPT nvarchar(50),
)

create table HoaDon
(
	IDHD int primary key Identity(1,1),  
	NgayMua datetime,
	TongSoluong int,
	TongTien int,
	
	IDKH int,
	IDPT int,	

	CONSTRAINT FK_HOADON_KHACHHANG FOREIGN KEY (IDKH) REFERENCES KhachHang(IDKH),
	CONSTRAINT FK_HOADON_PHUONGTHUC FOREIGN KEY (IDPT) REFERENCES PhuongThucThanhToan(IDPT),
)

DROP TABLE CHITIETHOADON
create table ChiTietHoaDon
(
	IDChiTietHD int primary key Identity(1,1),  
	IDHD int,
	IDMH int,
	SoluongMH int,	

	CONSTRAINT FK_CHITIETHOADON_HOADON FOREIGN KEY (IDHD) REFERENCES HoaDon(IDHD),
	CONSTRAINT FK_CHITIETHOADON_MATHANG FOREIGN KEY (IDMH) REFERENCES MatHang(IDMH),
)

select * from mathang
