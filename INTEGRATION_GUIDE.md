# INTEGRATION_GUIDE – Quy ước tích hợp code (Hệ thống Quản lý Thư viện)

Tài liệu do Thành viên 1 (Leader) quản lý. Mọi thành viên đọc trước khi nộp code.

## 1. Mở và chạy project
1. Cài **Visual Studio mới có workload ".NET desktop development" và .NET 10 SDK** (project target `net10.0-windows`, solution định dạng `.slnx`). Nếu máy nhóm không có .NET 10, thống nhất cả nhóm hạ `TargetFramework` trong `QuanLyThuVien.csproj` (ví dụ `net8.0-windows`) – chỉ Leader được sửa file này.
2. Mở `QuanLyThuVien.slnx` → Build → Start.
3. Tạo CSDL: chạy `Database/TaoCSDL_QuanLyThuVien.sql` (script của TV2) trong SSMS. **Cảnh báo:** script có lệnh `DROP TABLE` và tạo lại dữ liệu mẫu → chỉ chạy trên CSDL dùng cho dự án, sẽ **xóa dữ liệu đang có**.
4. Tạo/sửa `appsettings.local.json` cạnh `appsettings.json` (xem mục 3).
5. Tài khoản mẫu: `admin / 123456` (Admin), `lan / 123456` (NhanVien).

## 2. Cấu trúc thư mục và quy tắc đặt file
```
QuanLyThuVien.slnx / .csproj   (chỉ Leader sửa)
Program.cs                     (chỉ Leader sửa)
appsettings.json               cấu hình chung (commit)
appsettings.local.json         cấu hình riêng từng máy (KHÔNG commit)
Classes/                       class dùng chung, không có giao diện
  DataProcesser.cs             TV2: kết nối + truy vấn CSDL (dùng chung)
  CauHinhKetNoi.cs             Leader: đọc appsettings
  TaiKhoanDangNhap.cs          Leader: phiên đăng nhập + phân quyền
Forms/
  FrmDangNhap, FrmMain         Leader
  FrmNhanVien, FrmSinhVien, FrmSach, FrmTheLoai, FrmMuonTra, FrmThongKe   TV3 (giao diện) + TV4 (logic)
  FrmTrangChu                  giữ chỗ (xem mục 6)
Database/TaoCSDL_QuanLyThuVien.sql   TV2: script tạo CSDL (có DROP TABLE!)
```
- Namespace **cố định**: `Hệ_Thống_Quản_Lý_Thư_Viện.Forms` cho form, `Hệ_Thống_Quản_Lý_Thư_Viện.Classes` cho class. Không tự đổi namespace.
- Mỗi form gồm `.cs` + `.Designer.cs` (+ `.resx` nếu có tài nguyên). Tên form `FrmXxx`.
- Class mới (ví dụ hằng số UI của TV3, hàm kiểm tra dữ liệu của TV4) đặt trong `Classes/`, tên file = tên class, **không trùng tên** class đã có.

## 3. Kết nối CSDL (quy tắc bắt buộc)
- **Chỉ dùng `DataProcesser`** để truy cập CSDL (`DocBang`, `CapNhatDuLieu`, `LayGiaTri`, `DataProcesser.Tham`, `DaTonTai`, `SinhMa`). Không tự `new SqlConnection` trong form.
- Luôn dùng **tham số** (`@ten` + `DataProcesser.Tham`) – không nối chuỗi dữ liệu người dùng vào SQL.
- Không viết cứng tên server. Mỗi người sửa `appsettings.local.json`:
```json
{ "Database": { "Server": "TEN-MAY\\SQLEXPRESS" } }
```
  Dùng SQL Authentication: thêm `"IntegratedSecurity": false, "User": "...", "Password": "..."` (chỉ trong file local; không commit mật khẩu).
- Không đổi cấu trúc bảng/tên cột/giá trị `Quyen` (`Admin`, `NhanVien`). Cần đổi → báo TV2 và Leader.

## 4. Phân quyền
- Phiên đăng nhập: `TaiKhoanDangNhap.TenDangNhap / TenNhanVien / MaNV / Quyen`.
- Kiểm tra quyền bằng `TaiKhoanDangNhap.CoQuyen(ChucNang.X)` – chính sách nằm tại một chỗ duy nhất (`Classes/TaiKhoanDangNhap.cs`):
  - Admin: tất cả chức năng.
  - Nhân viên: **không** dùng Quản lý nhân viên và Thống kê báo cáo (mặc định Leader chọn; đổi trong `CoQuyen` nếu nhóm quyết định khác).
- `FrmMain` kiểm tra quyền **trước khi mở form** (không chỉ ẩn nút). Nếu form của bạn có hành động chỉ Admin được làm (ví dụ xóa), tự kiểm tra `TaiKhoanDangNhap.CoQuyen(...)`/`LaAdmin` trong form.

## 5. Quy ước cho Form con (TV3, TV4)
- Form con được `FrmMain` nhúng vào `pnlContent` (TopLevel=false, không viền, Dock=Fill). **Không** tự gọi `Show()`/`ShowDialog()` form chính, không gọi `Application.Exit()`, không tạo `FrmDangNhap`/`FrmMain` mới.
- **Form con chỉ chứa phần nội dung**: KHÔNG tự vẽ thanh tiêu đề, menu bên trái, footer hay lời chào (đã có trong `FrmMain`); kích thước thiết kế **880×580** (vùng `pnlContent`), dùng `Anchor`/`Dock` để co giãn, không đặt `MinimumSize`/`StartPosition`. Thiết kế bằng Designer (kéo thả), không tạo control bằng code trong `.Designer.cs`.
- Đặt tên control theo tiền tố (mục 7): `btnThem`, `txtMaSV`, `dgvSinhVien`... Không dùng tên tiếng Anh tự đặt (`addButton`, `idTextBox`). Không gõ sẵn dữ liệu mẫu vào ô nhập/bảng.
- Mẫu tham khảo: `Forms/FrmSinhVien` (đã chuyển từ bản `Form1` của TV3).
- Giữ nguyên tên lớp `FrmXxx` và constructor không tham số (`FrmMain` gọi `new FrmXxx()`). Cần tham số → báo Leader.
- Đừng giữ kết nối CSDL mở (mỗi lần gọi `DataProcesser` tự mở/đóng).
- Khi `Dispose`, giải phóng tài nguyên của riêng form (timer, ảnh...). Chỗ TODO trong từng form ghi rõ: **TV3 = giao diện (màu/font/control), TV4 = logic nghiệp vụ**.

### Phần còn chờ (chưa có code của TV3/TV4)
| Form | Chờ |
|---|---|
| FrmNhanVien, FrmSinhVien, FrmSach, FrmTheLoai, FrmMuonTra, FrmThongKe | TV3: giao diện; TV4: logic. Hiện chỉ là form rỗng |
| Quy chuẩn UI (bảng màu, font, tiền tố control) | TV3 cung cấp; Leader bổ sung vào mục 7 |
| Thẻ thống kê trang chủ | đang dùng 4 truy vấn đơn giản trong `FrmMain.TaiThongKeTrangChu`; TV4 có thể thay bằng logic chính thức |

### Trạng thái các form con (cập nhật sau khi ghép giao diện TV3)
| Form | Giao diện | Logic |
|---|---|---|
| FrmSinhVien | xong (TV3, chuyển thành form con) | chờ TV4 |
| FrmNhanVien, FrmSach, FrmTheLoai, FrmMuonTra, FrmThongKe | đã ghép từ bản của TV3 (bỏ header/menu/nút đăng xuất vì đã có ở FrmMain; giữ màu, bố cục, control) | chờ TV4 (xem TODO trong từng file) |
- `FrmThongKe` dùng control Chart -> gói NuGet `WinForms.DataVisualization` (đã khai báo trong `.csproj`, Visual Studio tự tải khi build, cần Internet lần đầu).
- Chênh lệch giao diện/CSDL cần nhóm thống nhất: `FrmNhanVien` có ô Email nhưng `tblNhanVien` không có cột Email (và thiếu GioiTinh/NgaySinh/DiaChi); `FrmSach` dùng ComboBox cho Nhà xuất bản và thiếu NamXuatBan; `FrmThongKe` đang có chữ/số mẫu cố định.
- Bố cục TV3 là kích thước cố định: trong vùng 880x580 sẽ còn khoảng trống (chỉ bảng của FrmNhanVien và FrmSach co giãn theo cửa sổ). TV3 có thể tinh chỉnh thêm.

## 6. FrmTrangChu
Trang chủ hiện nằm trong `FrmMain` (lời chào + 4 thẻ). `FrmTrangChu` là form giữ chỗ chưa được mở; **không xóa**. Muốn dùng, chuyển nội dung sang form này và đổi `LoadTrangChu` trong `FrmMain` thành `MoChucNang(ChucNang.TrangChu, ..., () => new FrmTrangChu())`.

## 7. Quy ước chung (điền tiếp khi TV3 gửi quy chuẩn)
- Tiền tố control: `btn`, `txt`, `lbl`, `dgv`, `cbo`, `dtp`, `pnl`, `card`.
- Tên hàm/biến nghiệp vụ: tiếng Việt không dấu, PascalCase cho hàm (`LayDanhSachSach`), camelCase cho biến cục bộ.
- Màu hiện tại của FrmMain: menu `#4285F4`, đang chọn `#2196F3`, đăng xuất `#E53935`. TV3 có thể đề xuất thay.

### Quy chuẩn giao diện Form quản lý (lấy `FrmSinhVien` làm mẫu)
Áp dụng cho FrmSinhVien, FrmNhanVien, FrmSach, FrmTheLoai, FrmMuonTra, FrmThongKe. **Không** áp dụng cho FrmDangNhap/FrmMain.
| Thành phần | Quy chuẩn |
|---|---|
| Form | `ClientSize` 880×580, `BackColor` WhiteSmoke, `AutoScaleDimensions` 7F×15F, `AutoScaleMode.Font` |
| Tiêu đề `lblTieuDe` | Dock Top, cao 47, nền `(0,153,150)`, chữ trắng, Segoe UI 13 đậm, căn giữa |
| Lề / lưới | Lề ngoài 20px; cột trái x=20 rộng 335; cột phải x=370 rộng 490 (đến x=860); vùng nội dung y=60 → 530 |
| Khu nhập liệu `pnlNhapLieu` | (20,60) 335×470, Anchor Top+Bottom+Left |
| Label | x=0, rộng 112, cao 28, Segoe UI 10 đậm, căn phải |
| TextBox / ComboBox | x=120, rộng 193, cao 23; hàng đầu y=30, bước 53px (Form 6 trường: bước 45px) |
| Nút Thêm/Sửa/Xóa | 99×46 tại (0,300), (114,300), (228,300) |
| Nút Ghi/Hủy bỏ | 99×46 tại (57,362), (171,362) |
| Nút Flat | nền trắng, viền/chữ `(133,178,174)`, Segoe UI 10 thường |
| Nhóm tìm kiếm `grpTimKiem` | (370,60) 490×75, Anchor Top+Left+Right; radio (16,29) và (132,29); `txtTimKiem` (250,26) 225×23 |
| Bảng `dgv...` | (370,150) 490×380, Anchor 4 phía; Fill; nền DarkGray; header cao 28, nền `(211,231,242)`; không row header; chọn cả dòng; chỉ đọc |
| Form đặc thù (MuonTra, ThongKe) | Dùng cùng tiêu đề, màu, font, lề 20px, cột trái 335 / cột phải 490, nút 46px cao |
**Lưu ý kích thước khi chạy:** `pnlContent` của FrmMain có `Padding = 30` và Form con `Dock = Fill`, nên lúc chạy Form con chỉ còn **820×520** (nhỏ hơn 60px mỗi chiều so với 880×580 thiết kế). Vì vậy: (1) mọi control phải neo `Top` hoặc co giãn (`Top+Bottom`, `Left+Right`); **không neo chỉ `Bottom`** cho khối có kích thước cố định vì sẽ bị đẩy lên và đè lên khối phía trên; (2) nội dung cố định phải nhét vừa 820×520. Khi chỉnh Form nên kiểm tra bằng cách chạy từ FrmMain, không chỉ xem trong Designer.
Cột bảng được khai báo sẵn với `DataPropertyName` trùng tên cột SQL (`AutoGenerateColumns = false`); riêng cột "Thể loại" của FrmSach gắn với `MaTL` (muốn hiện tên thể loại thì JOIN và đổi `DataPropertyName` thành `TenTL`).

## 8. Quy trình Git
- Mỗi người một nhánh (`tv2-sql`, `tv3-ui`, `tv4-logic`), chỉ sửa file thuộc phần mình. Leader merge vào `main`.
- Không commit `bin/`, `obj/`, `.vs/`, `appsettings.local.json` (đã có trong `.gitignore`).
- Trước khi gửi: Build thành công + chạy thử đăng nhập → mở form của mình → đăng xuất.

## 9. Kiểm thử nhanh (Leader/mọi người)
1. Đăng nhập sai mật khẩu → báo sai, ô mật khẩu bị xóa.
2. Tắt SQL Server (hoặc sai tên server) → báo "Không kết nối được SQL Server" sau ≤ vài giây, không lộ mật khẩu.
3. `admin/123456` → thấy đủ 7 nút. `lan/123456` → không thấy "Quản lý nhân viên", "Thống kê báo cáo".
4. Bấm lần lượt cả 7 chức năng nhiều vòng → không lỗi, không form chồng nhau.
5. Đăng xuất → quay lại đăng nhập (không thoát chương trình); đăng nhập lại được. Bấm X ở FrmMain → thoát chương trình.
