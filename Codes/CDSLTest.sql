create database CSDLTest
go

use master
go

use CSDLTest
go

create table DanhMuc (
MaDanhMuc nvarchar(50) primary key not null,
TenDanhMuc nvarchar(50) not null,
)

create table SanPham (
Ma nvarchar(50) primary key not null,
Ten nvarchar (50) not null,
DonGia money not null,
MaDanhMuc nvarchar(50) not null,
constraint fk_madanhmuc foreign key (MaDanhMuc) references DanhMuc(MaDanhMuc),
)

insert into DanhMuc (MaDanhMuc, TenDanhMuc) values
('M01', N'Quần Nam'),
('M02', N'Quần Nữ'),
('M03', N'Áo Nam'),
('M04', N'Áo Nữ');

select * from DanhMuc

insert into SanPham (Ma, Ten, DonGia, MaDanhMuc) values
('SP01', N'Quần dài', 300000, 'M01'),
('SP02', N'Quần ngắn', 205000, 'M01'),
('SP03', N'Quần bó', 240000, 'M02'),
('SP04', N'Quần cộc', 321000, 'M02'),
('SP05', N'Áo dài tay', 300000, 'M03'),
('SP06', N'Áo thun co giãn', 205000, 'M03'),
('SP07', N'Áo croptop', 240000, 'M04'),
('SP08', N'Áo giữ nhiệt', 321000, 'M04');

select * from DanhMuc



