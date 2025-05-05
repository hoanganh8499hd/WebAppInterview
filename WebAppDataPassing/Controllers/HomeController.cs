using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAppDataPassing.Models;

namespace WebAppDataPassing.Controllers;

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

    //ViewData là một dictionary (ViewDataDictionary)
    //cho phép lưu trữ dữ liệu dưới dạng key-value, và dữ liệu được lưu dưới dạng object.
    public ViewResult ViewDataAction()
    {
        //String string Data
        ViewData["Title"] = "Student Details Page";
        ViewData["Header"] = "Student Details";
        Student student = new Student()
        {
            StudentId = 101,
            Name = "James",
            Branch = "CSE",
            Section = "A",
            Gender = "Male"
        };
        //storing Student Data
        ViewData["Student"] = student;
        return View();
    }

    public ActionResult ViewDataRedirectToAbout()
    {
        ViewData["Message"] = "Đây là thông điệp trước khi redirect.";
        return RedirectToAction("About");
    }

    public ActionResult About()
    {
        //ViewData["Message"] = "About";

        // Tại đây ViewData["Message"] sẽ là null, vì nó không tồn tại sau redirect.
        return View();
    }

    //Sử dụng dynamic để lưu trữ dữ liệu
    public ActionResult ViewBagAction()
    {
        ViewBag.Title = "Student Details Page";
        ViewBag.Header = "Student Details";
        Student student = new Student()
        {
            StudentId = 101,
            Name = "James",
            Branch = "CSE",
            Section = "A",
            Gender = "Male"
        };
        ViewBag.Student = student;
        //return View();

        return RedirectToAction("About");
    }
}
