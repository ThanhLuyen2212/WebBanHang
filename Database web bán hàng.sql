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
	Email nvarchar(50),
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
	NgayNhapHang datetime,
	SoLuong int,
	HinhAnh1 NVARCHAR(max) ,
	HinhAnh2 NVARCHAR(max) ,
	HinhAnh3 NVARCHAR(max) ,
	HinhAnh4 NVARCHAR(MAX),
	MoTaChiTiet nvarchar(MAX),
	CONSTRAINT FK_MATHANG_LOAIMATHANG FOREIGN KEY (IDLoaiMH) REFERENCES LoaiMatHang(IDLoaiMH),
)

create table PhuongThucThanhToan
(
	IDPT int primary key Identity(1,1),
	TenPT nvarchar(50),
)

create table TrangThai
(
	IDTrangThai int primary key identity(1,1),
	TenTrangThai nvarchar(20),
)

create table HoaDon
(
	IDHD int primary key Identity(1,1),  
	NgayMua datetime,
	TongSoluong int,
	TongTien int,	
	IDKH int,
	IDPT int,		
	IDTrangThai int,
	CONSTRAINT FK_HOADON_KHACHHANG FOREIGN KEY (IDKH) REFERENCES KhachHang(IDKH),
	CONSTRAINT FK_HOADON_PHUONGTHUC FOREIGN KEY (IDPT) REFERENCES PhuongThucThanhToan(IDPT),
	CONSTRAINT FK_HOADON_TRANGTHAI FOREIGN KEY (IDTrangThai) REFERENCES TrangThai(IDTrangThai),
)



create table ChiTietHoaDon
(
	IDChiTietHD int primary key Identity(1,1),  
	IDHD int,
	IDMH int,
	SoluongMH int,	
	CONSTRAINT FK_CHITIETHOADON_HOADON FOREIGN KEY (IDHD) REFERENCES HoaDon(IDHD),
	CONSTRAINT FK_CHITIETHOADON_MATHANG FOREIGN KEY (IDMH) REFERENCES MatHang(IDMH),
)

-- tạo dữ liệu khách hàng
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Kelp gull', '984-959-7682', 'mgooley0@yelp.com', '4/27/2022', '123', '123');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Kelp gull', '984-959-7682', 'mgooley0@yelp.com', '4/27/2022', 'rkear0', 'd7q71ERamH2x');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Boat-billed heron', '226-855-0571', 'hgolde1@godaddy.com', '1/18/2022', 'maylward1', 'Gk5W3L');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Alligator, mississippi', '373-240-9691', 'echapleo2@kickstarter.com', '10/10/2021', 'clittell2', 'siFzG0L');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Sandgrouse, yellow-throated', '590-121-0357', 'wdavidman3@surveymonkey.com', '7/14/2021', 'jfozard3', 'g52EIq');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Kirk''s dik dik', '516-215-5616', 'lbaddeley4@mit.edu', '7/31/2021', 'mgold4', 'CtZ1wf');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Pallas''s fish eagle', '910-352-4430', 'ddockery5@mediafire.com', '4/18/2022', 'asteuart5', 'eSoqDKc4Q');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Cat, civet', '454-996-8508', 'rberndsen6@ocn.ne.jp', '11/30/2021', 'adurber6', 'H0c5buxWvWD0');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Canadian river otter', '512-341-3646', 'agemmill7@un.org', '7/18/2021', 'aconeau7', 'HBZgyKJhd');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Stick insect', '986-918-7512', 'nlukins8@macromedia.com', '11/2/2021', 'jdumbrall8', 'yifM5G');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Common grenadier', '619-909-7413', 'bmusgrave9@goo.ne.jp', '2/10/2022', 'cstearne9', 'bxD9yxVu');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Wallaby, agile', '985-979-5402', 'spassinghama@dion.ne.jp', '8/15/2021', 'lcraftera', 'WfPsjjyl');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Fox, blue', '468-634-6046', 'msavileb@elegantthemes.com', '3/7/2022', 'clammertzb', 'hynqrwG0');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Black swan', '714-399-1760', 'itunnacliffec@dropbox.com', '11/24/2021', 'amorcombc', 'UpTdgCty');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Rainbow lory', '272-993-4231', 'mdunstond@sun.com', '8/21/2021', 'drivittd', 'DlCX8u');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Purple moorhen', '714-983-6820', 'ztimmermanne@baidu.com', '4/7/2022', 'egreensete', 'gUTjbiO');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Kori bustard', '515-866-1862', 'thurlestonef@typepad.com', '11/28/2021', 'dmatoshinf', 'zmd7Bz');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Zorro, common', '475-425-8684', 'bvidyaping@cisco.com', '1/22/2022', 'tristg', '1P9Q84XK2veT');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Black swan', '525-217-2623', 'mrameh@parallels.com', '12/18/2021', 'itunmoreh', 'pK2zSHg3cnWa');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Columbian rainbow boa', '355-927-9607', 'sspensleyi@disqus.com', '9/1/2021', 'dtedorenkoi', 'zxl37C');
insert into KhachHang (TenKH, SDT, DiaChi, NgaySinh, UserName, Password) values ('Grey heron', '166-665-2643', 'jwhimpennyj@tamu.edu', '11/1/2021', 'lbettingtonj', 'fxB7RlERmN');


-- Tạo dữ liệu Admin
insert into Admin (TenAdmin, SDT, DiaChi, NgaySinh, UserName, Password) values ('Squirrel, arctic ground', '332-214-3276', 'fcurmi0@t.co', '6/14/2021', 'afrogley0', 'pa7LMY');
insert into Admin (TenAdmin, SDT, DiaChi, NgaySinh, UserName, Password) values ('Squirrel, uinta ground', '828-747-2394', 'ttarver1@ovh.net', '1/1/2022', 'atoon1', 'hPuzMZ2p');
insert into Admin (TenAdmin, SDT, DiaChi, NgaySinh, UserName, Password) values ('Cockatoo, red-breasted', '329-923-8024', 'mjubert2@indiatimes.com', '9/23/2021', 'vworld2', 'PeKMRMIdlU');
insert into Admin (TenAdmin, SDT, DiaChi, NgaySinh, UserName, Password) values ('Gulls (unidentified)', '205-416-7076', 'pwinchcum3@multiply.com', '11/25/2021', 'lstrangeways3', 'JiGwoTtKbB');
insert into Admin (TenAdmin, SDT, DiaChi, NgaySinh, UserName, Password) values ('Weaver, red-billed buffalo', '956-321-1004', 'agerssam4@bravesites.com', '4/5/2022', 'fcordelle4', 'ipszvqEFciwN');
select * from Admin


--Tạo loại mặt hàng
insert into LoaiMatHang (TenLoaiMH) values ('Tomatoes Tear Drop');
insert into LoaiMatHang (TenLoaiMH) values ('Wine - White, Gewurtzraminer');
insert into LoaiMatHang (TenLoaiMH) values ('Tart - Lemon');
insert into LoaiMatHang (TenLoaiMH) values ('Container - Foam Dixie 12 Oz');
insert into LoaiMatHang (TenLoaiMH) values ('Jagermeister');
insert into LoaiMatHang (TenLoaiMH) values ('Spice - Chili Powder Mexican');
insert into LoaiMatHang (TenLoaiMH) values ('Plasticspoonblack');
insert into LoaiMatHang (TenLoaiMH) values ('Soup - Knorr, Chicken Noodle');
insert into LoaiMatHang (TenLoaiMH) values ('Pie Filling - Pumpkin');
insert into LoaiMatHang (TenLoaiMH) values ('Tomato - Tricolor Cherry');
delete LoaiMatHang



-- Reset id return from 0
DBCC CHECKIDENT (HoaDon, RESEED, 0)
DBCC CHECKIDENT (ChiTietHoaDon, RESEED, 0)
DBCC CHECKIDENT (HoaDon, RESEED, 0)

select * from KhachHang
select * from LoaiMatHang
select * from HoaDon
select * from ChiTietHoaDon
select * from MatHang

delete MatHang where IDMH = 11
delete hoadon
delete ChiTietHoaDon

update KhachHang set Email = '123@email.com'