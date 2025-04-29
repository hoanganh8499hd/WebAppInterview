using Microsoft.AspNetCore.Mvc;

namespace WebAppActionResults.Controllers
{
    public class StatusCodeController : Controller
    {
        // Trả về mã HTTP 200 OK với thông điệp JSON
        // Thường sử dụng khi yêu cầu được xử lý thành công và có dữ liệu trả về.
        public IActionResult OkExample()
        {
            // Trả về một đối tượng JSON với thông điệp "Request successful."
            return Ok(new { Message = "Request successful." });
        }

        // Trả về mã HTTP 400 Bad Request với thông điệp lỗi
        // Sử dụng khi yêu cầu không hợp lệ hoặc thiếu tham số.
        public IActionResult BadRequestExample()
        {
            // Trả về thông báo lỗi "Invalid request parameters."
            return BadRequest(new { Error = "Invalid request parameters." });
        }

        // Trả về mã HTTP 401 Unauthorized với thông điệp yêu cầu xác thực
        // Sử dụng khi người dùng không được phép truy cập tài nguyên do thiếu quyền xác thực.
        public IActionResult UnauthorizedExample()
        {
            // Trả về thông báo yêu cầu xác thực
            return Unauthorized(new { Message = "Authentication required." });
        }

        // Trả về mã HTTP 404 Not Found với thông điệp lỗi
        // Sử dụng khi tài nguyên yêu cầu không tồn tại.
        public IActionResult NotFoundExample()
        {
            // Trả về thông báo lỗi "Requested resource not found."
            return NotFound("Requested resource not found.");
        }

        // Trả về mã HTTP 500 Internal Server Error với thông điệp lỗi
        // Sử dụng khi xảy ra lỗi hệ thống trên server, không thể xử lý yêu cầu.
        public IActionResult InternalServerErrorExample()
        {
            // Trả về thông báo lỗi với mã lỗi 500
            return StatusCode(500, new { Message = "Internal server error occurred." });
        }

        // Trả về mã HTTP 403 Forbidden với thông điệp lỗi
        // Sử dụng khi người dùng không có quyền truy cập tài nguyên mặc dù đã được xác thực.
        public IActionResult ForbiddenExample()
        {
            // Trả về thông báo lỗi "Access to this resource is forbidden."
            return StatusCode(403, "Access to this resource is forbidden.");
        }

        // Trả về mã HTTP tùy chỉnh theo mã trạng thái người dùng cung cấp
        // Sử dụng khi bạn muốn trả về mã trạng thái tùy chỉnh, ví dụ như 418 (I'm a teapot).
        public IActionResult CustomStatusCodeExample(int code)
        {
            // Trả về mã trạng thái tùy chỉnh và thông điệp tương ứng
            return StatusCode(code, $"This is a custom status code: {code}");
        }
    }
}
