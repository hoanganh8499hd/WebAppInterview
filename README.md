# Interview preparation project from https://dotnettutorials.net/


ASP.NET Core MVC Request Life Cycle:

1. Incoming Request:
Một client (như trình duyệt, ứng dụng di động, API client,...) gửi một HTTP request đến ứng dụng ASP.NET Core.

2. HTTP Request Pipeline:
Yêu cầu được xử lý qua ASP.NET Core HTTP request pipeline,, bao gồm nhiều middleware. Mỗi middleware có thể đảm nhận các tác vụ như: xác thực (authentication), phân quyền (authorization), ghi log, kiểm soát lỗi, v.v.

3. Routing:
Middleware định tuyến (routing middleware) sẽ phân tích URL yêu cầu để xác định controller và action tương ứng sẽ tiếp nhận và xử lý request đó. Các route được cấu hình trong file Startup.cs/Program.cs thông qua phương thức app.UseEndpoints.

4. Controller Creation:
Sau khi xác định được route phù hợp, the MVC framework sẽ khởi tạo một instance của controller tương ứng để tiếp nhận yêu cầu.

5. Action Method Selection:
Framework tiếp tục tìm và chọn action method cụ thể trong controller để xử lý yêu cầu, dựa vào cấu hình route đã định nghĩa.

6. Model Binding:
ASP.NET Core thực hiện ánh xạ (binding) dữ liệu từ yêu cầu (tham số query string, dữ liệu form, giá trị route, v.v.) tới các tham số của action method. Việc ánh xạ được thực hiện tự động dựa trên tên tham số và kiểu dữ liệu tương ứng.

7. Action Execution:
Action method đã chọn sẽ được thực thi. Trong quá trình này, logic nghiệp vụ có thể được xử lý, truy xuất cơ sở dữ liệu, và chuẩn bị dữ liệu cho view (nếu có).

8. View Rendering:
Nếu action trả về một view, framework sẽ render view (thường là template HTML). View có thể chứa các placeholder sẽ được thay thế bằng dữ liệu động tại thời điểm rendering.

9. View Engine xử lý (View Engine):
The view engine (ví dụ: Razor) sẽ xử lý view, thay thế các placeholder bằng dữ liệu thực, và tạo ra HTML hoàn chỉnh.

10. Response:
HTML sinh ra từ view engine sẽ được đóng gói vào HTTP response. Trước khi gửi đi, các middleware ở tầng phản hồi có thể thực hiện thêm các tác vụ như nén (compression), cache, hoặc ghi log.

11. Outgoing Response Pipeline:
Phản hồi đi qua pipeline phản hồi HTTP, có thể bao gồm các middleware xử lý output configured.

12. Client Receives Response:
The processed response được gửi trở lại client ban đầu (trình duyệt, API consumer, v.v.) – nơi đã gửi request.

https://learn.microsoft.com/vi-vn/aspnet/mvc/overview/getting-started/lifecycle-of-an-aspnet-mvc-5-application