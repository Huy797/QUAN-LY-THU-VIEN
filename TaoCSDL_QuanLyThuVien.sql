IF DB_ID(N'QuanLyThuVien') IS NULL
    CREATE DATABASE QuanLyThuVien;
GO
USE QuanLyThuVien;
GO

/* ---------- Xóa theo thứ tự phụ thuộc ---------- */
IF OBJECT_ID(N'v_QuaHan')    IS NOT NULL DROP VIEW v_QuaHan;
IF OBJECT_ID(N'v_DangMuon')  IS NOT NULL DROP VIEW v_DangMuon;
IF OBJECT_ID(N'tblChiTietMuon') IS NOT NULL DROP TABLE tblChiTietMuon;
IF OBJECT_ID(N'tblPhieuMuon')   IS NOT NULL DROP TABLE tblPhieuMuon;
IF OBJECT_ID(N'tblSach')        IS NOT NULL DROP TABLE tblSach;
IF OBJECT_ID(N'tblTheLoai')     IS NOT NULL DROP TABLE tblTheLoai;
IF OBJECT_ID(N'tblSinhVien')    IS NOT NULL DROP TABLE tblSinhVien;
IF OBJECT_ID(N'tblTaiKhoan')    IS NOT NULL DROP TABLE tblTaiKhoan;
IF OBJECT_ID(N'tblNhanVien')    IS NOT NULL DROP TABLE tblNhanVien;
GO

/* ---------- Nhân viên (thủ thư) ---------- */
CREATE TABLE tblNhanVien
(
    MaNV         nvarchar(10)  NOT NULL PRIMARY KEY,
    TenNV        nvarchar(50)  NOT NULL,
    GioiTinh     nvarchar(5)   NULL,
    NgaySinh     date          NULL,
    DiaChi       nvarchar(200) NULL,
    SoDienThoai  nvarchar(15)  NULL,
    ChucVu       nvarchar(30)  NULL
);

/* ---------- Tài khoản đăng nhập (mỗi tài khoản thuộc 1 nhân viên) ---------- */
CREATE TABLE tblTaiKhoan
(
    TenDangNhap  nvarchar(30) NOT NULL PRIMARY KEY,
    MatKhau      nvarchar(50) NOT NULL,
    MaNV         nvarchar(10) NOT NULL
        CONSTRAINT FK_TaiKhoan_NhanVien REFERENCES tblNhanVien(MaNV),
    Quyen        nvarchar(20) NOT NULL DEFAULT N'NhanVien'   -- Admin / NhanVien
);

/* ---------- Sinh viên - Độc giả ---------- */
CREATE TABLE tblSinhVien
(
    MaSV         nvarchar(10) NOT NULL PRIMARY KEY,
    TenSV        nvarchar(50) NOT NULL,
    NganhHoc     nvarchar(30) NULL,
    KhoaHoc      nvarchar(10) NULL,
    SoDienThoai  nvarchar(15) NULL
);

/* ---------- Thể loại sách ---------- */
CREATE TABLE tblTheLoai
(
    MaTL   nvarchar(10) NOT NULL PRIMARY KEY,
    TenTL  nvarchar(50) NOT NULL
);

/* ---------- Sách ---------- */
CREATE TABLE tblSach
(
    MaSach      nvarchar(10)  NOT NULL PRIMARY KEY,
    TenSach     nvarchar(100) NOT NULL,
    TacGia      nvarchar(50)  NULL,
    MaTL        nvarchar(10)  NULL
        CONSTRAINT FK_Sach_TheLoai REFERENCES tblTheLoai(MaTL),
    NhaXuatBan  nvarchar(50)  NULL,
    NamXuatBan  int           NULL,
    SoLuong     int           NOT NULL DEFAULT 0     -- số cuốn CÒN trong thư viện
        CONSTRAINT CK_Sach_SoLuong CHECK (SoLuong >= 0)
);

/* ---------- Phiếu mượn ---------- */
CREATE TABLE tblPhieuMuon
(
    MaPM      nvarchar(10) NOT NULL PRIMARY KEY,
    MaSV      nvarchar(10) NOT NULL
        CONSTRAINT FK_PhieuMuon_SinhVien REFERENCES tblSinhVien(MaSV),
    MaNV      nvarchar(10) NOT NULL
        CONSTRAINT FK_PhieuMuon_NhanVien REFERENCES tblNhanVien(MaNV),
    NgayMuon  date NOT NULL DEFAULT (CONVERT(date, GETDATE())),
    HanTra    date NOT NULL,
    CONSTRAINT CK_PhieuMuon_Han CHECK (HanTra >= NgayMuon)
);

/* ---------- Chi tiết mượn (NgayTra = NULL nghĩa là chưa trả) ---------- */
CREATE TABLE tblChiTietMuon
(
    MaPM     nvarchar(10) NOT NULL
        CONSTRAINT FK_CTM_PhieuMuon REFERENCES tblPhieuMuon(MaPM),
    MaSach   nvarchar(10) NOT NULL
        CONSTRAINT FK_CTM_Sach REFERENCES tblSach(MaSach),
    SoLuong  int  NOT NULL DEFAULT 1
        CONSTRAINT CK_CTM_SoLuong CHECK (SoLuong > 0),
    NgayTra  date NULL,
    CONSTRAINT PK_ChiTietMuon PRIMARY KEY (MaPM, MaSach)
);
GO

/* ---------- View phục vụ Mượn trả sách và Báo cáo - Thống kê ---------- */
CREATE VIEW v_DangMuon AS
SELECT p.MaPM, p.MaSV, sv.TenSV, c.MaSach, s.TenSach, c.SoLuong,
       p.NgayMuon, p.HanTra
FROM tblChiTietMuon c
JOIN tblPhieuMuon p  ON p.MaPM = c.MaPM
JOIN tblSinhVien sv  ON sv.MaSV = p.MaSV
JOIN tblSach s       ON s.MaSach = c.MaSach
WHERE c.NgayTra IS NULL;
GO
CREATE VIEW v_QuaHan AS
SELECT MaPM, MaSV, TenSV, MaSach, TenSach, SoLuong, NgayMuon, HanTra,
       DATEDIFF(day, HanTra, CONVERT(date, GETDATE())) AS SoNgayQuaHan
FROM v_DangMuon
WHERE HanTra < CONVERT(date, GETDATE());
GO

/* ================== DỮ LIỆU MẪU ================== */
INSERT INTO tblNhanVien (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, SoDienThoai, ChucVu) VALUES
(N'NV01', N'Quang Huy',        N'Nam', '2003-05-12', N'Hà Nội',  N'0903554540', N'Thủ thư'),
(N'NV02', N'Nguyễn Thị Lan',   N'Nữ',  '2002-09-20', N'Hà Nội',  N'0912345678', N'Thủ thư');

INSERT INTO tblTaiKhoan (TenDangNhap, MatKhau, MaNV, Quyen) VALUES
(N'admin', N'123456', N'NV01', N'Admin'),
(N'lan',   N'123456', N'NV02', N'NhanVien');

INSERT INTO tblSinhVien (MaSV, TenSV, NganhHoc, KhoaHoc, SoDienThoai) VALUES
(N'1001', N'Quang Huy',          N'CNTT', N'K63', N'90355454'),
(N'1002', N'Trần Đình Dũng',     N'CNTT', N'K62', N'17682488'),
(N'1003', N'Trần Anh Hoàng',     N'CNTT', N'K62', N'63623523'),
(N'1004', N'Nguyễn Văn Nam',     N'CNTT', N'K62', N'90355454'),
(N'1005', N'Trần Văn Thắng',     N'CNTT', N'K62', N'90355454'),
(N'1006', N'Trần Huy Nam',       N'CNTT', N'K62', N'90355454'),
(N'1007', N'Trần Quang Đạt',     N'CNTT', N'K62', N'90355454'),
(N'1008', N'Trần Anh Vinh',      N'CNTT', N'K61', N'63623523'),
(N'1009', N'Ba Huy',             N'GDTH', N'K61', N'987654321');

INSERT INTO tblTheLoai (MaTL, TenTL) VALUES
(N'TL01', N'Công nghệ thông tin'),
(N'TL02', N'Toán - Khoa học'),
(N'TL03', N'Văn học'),
(N'TL04', N'Kinh tế');

INSERT INTO tblSach (MaSach, TenSach, TacGia, MaTL, NhaXuatBan, NamXuatBan, SoLuong) VALUES
(N'S001', N'Lập trình C# căn bản',          N'Nguyễn Thu Hường', N'TL01', N'NXB Giao thông vận tải', 2023, 10),
(N'S002', N'Cơ sở dữ liệu',                 N'Nguyễn Văn Ba',    N'TL01', N'NXB Khoa học kỹ thuật',  2021, 8),
(N'S003', N'Giải tích 1',                   N'Trần Văn Hai',     N'TL02', N'NXB Giáo dục',           2020, 15),
(N'S004', N'Tuyển tập truyện ngắn',         N'Nam Cao',          N'TL03', N'NXB Văn học',            2019, 5),
(N'S005', N'Kinh tế vi mô',                 N'Lê Thị Hoa',       N'TL04', N'NXB Kinh tế quốc dân',   2022, 6),
(N'S006', N'Cấu trúc dữ liệu và giải thuật', N'Phạm Minh Tuấn',  N'TL01', N'NXB Khoa học kỹ thuật',  2022, 12);

/* 2 phiếu mượn mẫu: PM001 chưa trả (đã quá hạn), PM002 đã trả */
INSERT INTO tblPhieuMuon (MaPM, MaSV, MaNV, NgayMuon, HanTra) VALUES
(N'PM001', N'1001', N'NV01', '2026-10-01', '2026-10-15'),
(N'PM002', N'1002', N'NV02', '2026-10-20', '2026-11-03');

INSERT INTO tblChiTietMuon (MaPM, MaSach, SoLuong, NgayTra) VALUES
(N'PM001', N'S001', 1, NULL),
(N'PM001', N'S002', 1, NULL),
(N'PM002', N'S003', 1, '2026-10-28');

/* Cuốn chưa trả thì trừ khỏi số lượng còn (S001, S002); phiếu đã trả thì không trừ */
UPDATE tblSach SET SoLuong = SoLuong - 1 WHERE MaSach IN (N'S001', N'S002');
GO

SELECT * FROM tblSinhVien;
SELECT * FROM tblSach;
SELECT * FROM v_DangMuon;
SELECT * FROM v_QuaHan;
