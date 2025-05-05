using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Reflection;
using WebAppModelBinding.Models;

namespace WebAppModelBinding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //Example Without Using Model Binding in ASP.NET Core MVC

        //Keys – Retrieves all the keys in the form collection.It will hold all the form field names.
        //ContainsKey(key) – Determines if a specific key is present in the form collection.
        //TryGetValue(key, out value) – Attempts to get the value associated with a specific key.

        [HttpPost]
        public IActionResult SubmitFormIFormCollection(IFormCollection form)
        {
            Console.WriteLine(form.Keys);

            if (form.TryGetValue("UserName", out var userName) &&
                form.TryGetValue("UserEmail", out var userEmail))
            {
                ViewBag.Message = $"User Created: UserName: {userName}, UserEmail: {userEmail}";
            }
            else
            {
                ViewBag.Message = "Thiếu thông tin: UserName hoặc UserEmail.";
            }

            return View("Index");
        }

        //Model Binding

        [HttpPost]
        public IActionResult SubmitForm(User user)
        {
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    // Store success message in ViewBag
                    ViewBag.Message = $"User Created: UserName: {user.UserName}, UserEmail: {user.UserEmail}";
                    // Optionally, you could clear the model to reset the form if needed
                    ModelState.Clear();
                    return View("Index");
                }
            }
            return View("Index", user); // Return the Index view with the user model
        }
    }

}
