using Microsoft.AspNetCore.Mvc;
using WebAppModelBinding.Models;

namespace WebAppModelBinding.Controllers
{
    public class BuiltinModelBindersController : Controller
    {
        // Simple Type Model Binder: Binding các kiểu đơn giản như int, string
        [HttpGet]
        public IActionResult GetUser(int id, string userName)
        {
            ViewBag.Message = $"User ID: {id}, User Name: {userName}";
            return View();
        }

        // Complex Type Model Binder: Binding một đối tượng phức tạp (UserModel)
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Giả sử chúng ta lưu người dùng vào cơ sở dữ liệu
                ViewBag.Message = $"User Registered: {model.UserName}, {model.UserEmail}, {model.DateOfBirth.ToShortDateString()}";

                // Lưu ảnh đại diện nếu có
                if (model.ProfilePicture != null)
                {
                    string filePath = $"wwwroot/uploads/{model.ProfilePicture.FileName}";
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        model.ProfilePicture.CopyTo(stream);
                    }
                    ViewBag.Message += $" Profile Picture uploaded: {model.ProfilePicture.FileName}";
                }

                return View("Success");
            }
            return View("Register");
        }

        // Array and Collection Model Binder: Binding từ một danh sách
        //[HttpPost]
        public IActionResult ProcessNumbers(List<int> numbers)
        {
            int sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }

            ViewBag.Message = $"Sum of numbers: {sum}";
            return View();
        }

        // Dictionary Model Binder: Binding từ một từ điển (key-value pairs)
        [HttpPost]
        public IActionResult ProcessDictionary(Dictionary<string, string> data)
        {
            string result = string.Join(", ", data.Select(d => $"{d.Key}: {d.Value}"));
            ViewBag.Message = $"Received dictionary: {result}";
            return View();
        }

        // DateTime Model Binder: Binding từ kiểu DateTime
        [HttpGet]
        public IActionResult ProcessDate(DateTime dateOfBirth)
        {
            ViewBag.Message = $"Date of Birth: {dateOfBirth.ToShortDateString()}";
            return View();
        }

        // FormFile Model Binder: Binding file upload
        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string filePath = $"wwwroot/uploads/{file.FileName}";
                using (var stream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(stream);
                }
                ViewBag.Message = $"File uploaded: {file.FileName}";
            }
            else
            {
                ViewBag.Message = "No file uploaded.";
            }

            return View();
        }

        // FormCollection Model Binder: Binding dữ liệu form (IFormCollection)
        [HttpPost]
        public IActionResult SubmitForm(IFormCollection form)
        {
            string userName = form["UserName"];
            string userEmail = form["UserEmail"];
            ViewBag.Message = $"User Name: {userName}, User Email: {userEmail}";
            return View("Success");
        }

        // Enum Model Binder: Binding Enum giá trị
        public enum UserRole
        {
            Admin,
            User,
            Guest
        }

        [HttpPost]
        public IActionResult AssignRole(UserRole role)
        {
            ViewBag.Message = $"User role assigned: {role}";
            return View();
        }
    }
}
