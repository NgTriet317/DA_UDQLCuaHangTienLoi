__🛒 Ứng Dụng Quản Lý Cửa Hàng Tiện Lợi (DA_UDQLCuaHangTienLoi)
Ứng dụng quản lý cửa hàng tiện lợi giúp tối ưu hóa quy trình bán hàng, quản lý kho bãi, nhân viên và theo dõi doanh thu một cách hiệu quả, chính xác.__

__📌 Tính năng chính__
  1. Quản lý hệ thống
    Đăng nhập/Đăng xuất: Phân quyền người dùng (Quản trị viên và Nhân viên).

  2. Nghiệp vụ bán hàng
    Lập hóa đơn: tính tiền tự động, áp dụng giảm giá.
    In hóa đơn: Hỗ trợ xuất file PDF hoặc in trực tiếp cho khách hàng.

  3. Quản lý danh mục
    Sản phẩm: Thêm, sửa, xóa sản phẩm, quản lý mã vạch, loại hàng, hạn sử dụng.
    Nhân viên: Quản lý thông tin hồ sơ, ca làm việc và tiền lương.
    Khách hàng: Lưu trữ thông tin khách hàng thân thiết, tích điểm.
    Nhà cung cấp: Quản lý nguồn hàng và thông tin liên hệ.

  4. Quản lý kho
    Nhập hàng: Quản lý phiếu nhập và lịch sử nhập hàng từ nhà cung cấp.
    Tồn kho: Cảnh báo khi hàng hóa sắp hết hoặc hết hạn sử dụng.

  5. Thống kê & Báo cáo
    Doanh thu: Thống kê theo ngày, tháng.

__🛠 Công nghệ sử dụng__
  Ngôn ngữ: C# (.NET Framework / .NET Core)
  Giao diện: Windows Forms (WinForms) / WPF
  Cơ sở dữ liệu: Microsoft SQL Server

__Thư viện hỗ trợ:__
  Guna UI (Thiết kế giao diện hiện đại)
  Crystal Reports (Xuất báo cáo)

=====================================================================================

__🚀 Hướng dẫn cài đặt__
Để chạy dự án này trên máy cục bộ, hãy thực hiện các bước sau:
1. Clone repository:
  git clone [https://github.com/username/DA_UDQLCuaHangTienLoi.git](https://github.com/username/DA_UDQLCuaHangTienLoi.git)

2. Cấu hình Cơ sở dữ liệu:
  Mở SQL Server Management Studio (SSMS).
  Chạy file QLCHTL.sql & sp.sql trong thư mục Database để tạo bảng và dữ liệu mẫu.

3. Mở Project:
  Mở file .sln bằng Visual Studio 2022.  
  
4. Cấu hình kết nối:
  Thay đổi chuỗi kết nối (Connection String) trong file App.config để phù hợp với Server của bạn.

5. Build & Run:
  Nhấn F5 để trải nghiệm ứng dụng.
