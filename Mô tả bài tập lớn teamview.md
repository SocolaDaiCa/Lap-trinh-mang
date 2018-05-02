Mô tả bài tập lớn teamview
Ứng dụng có thể đóng vai trò lá máy điều khiển (A) cũng có thể đóng vai trò là máy bị điều khiển (B).
- B tạo 1 server bằng TcpListener và đợi A kết nối tới
- A sử dụng IP và mật khẩu do B để kết nối tới B bằng TCPClient
- B nhận kết nối và kiểm tra mật khẩu, nếu mật khẩu trùng khớp thì khởi tạo 1 thead để truyền tải hình ảnh cho A, A tạo 1 cửa số và 1 thread để nhận và hiển thị hình ảnh màn hình của B gửi sang, trong trường hợp mật khẩu không khớp, B khởi tạo lại server và chờ kết nối mới.
- Khi A nhấn, nhả, hoặc kích đúp hoặc di chuột lên 1 tọa độ trên ảnh ứng dụng gửi tên hành động, tọa độ trên ảnh và kích thước khung ảnh qua cho B.
- B nhận tên hành động, tọa độ trên ảnh và kích thước khung ảnh do A gửi qua để thực hiện hành động theo tỉ lệ tọa độ * kích thước màn hình / kích thước ảnh.
- Khi A gõ 1 phím bất kì sẽ gửi key code qua cho B với hành động là press. B nhận lệnh và gõ phím tương ứng