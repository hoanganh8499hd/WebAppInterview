using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebAppActionResults.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace WebAppActionResults.Controllers;

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

    //The action method must be public.
    //It cannot be overloaded.
    //It cannot be a static method.
    //IActionResult is the base class of all the result types an action method returns.
    //They can accept parameters from the request (e.g., query strings, route data, form data).


    //public ActionResult Index(int id) => View();         // Action 1
    //public ActionResult Index(string name) => View();    // Action 2 
    //public static ActionResult Index()                   // Action 3
    //{
    //    return View();
    //}

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public ViewResult ViewResult()
    {
        Product product = new Product()
        {
            Id = 1,
            Name = "Test Product View",
        };
        return View(product);
    }

    [AjaxOnly]
    public PartialViewResult PartialViewResult()
    {
        Product product = new Product()
        {
            Id = 1,
            Name = "Test Product _ProductDetailsPartialView",
        };
        return PartialView("_ProductDetailsPartialView", product);
    }

    // Defining an action method named Index that returns a JsonResult
    public JsonResult JsonResult()
    {
        // Creating an anonymous object with properties Name, ID, and DateOfBirth
        var jsonData = new
        {
            Name = "Pranaya",
            ID = 4,
            DateOfBirth = new DateTime(1988, 02, 29)
        };
        // Returning a JsonResult object with the jsonData as the content to be serialized to JSON
        return new JsonResult(jsonData);
    }

    // Defining an action method named Index that returns a JsonResult
    public JsonResult Json()
    {
        // Creating an anonymous object with properties Name, ID, and DateOfBirth
        var jsonData = new
        {
            Name = "Pranaya",
            ID = 4,
            DateOfBirth = new DateTime(1988, 02, 29)
        };
        // Returning a JsonResult using the Json method of the Controller class
        // The Json method takes the jsonData object and serializes it to JSON format
        // and sets appropriate headers for the response to indicate the content type as application/json.
        return Json(jsonData);
    }

    public JsonResult GetData()
    {
        try
        {
            // Giả sử không có lỗi, dữ liệu được xử lý bình thường.
            var data = new { Name = "John", Age = 30 };

            // Khi không có lỗi: return Json(data); sẽ trả về mã trạng thái 200 OK.
            return Json(data);  // Mã trạng thái mặc định là 200 OK
        }
        catch (Exception ex)
        {
            // Giả sử có lỗi xảy ra, ví dụ như exception được ném ra.

            // Khi có lỗi: Nếu bạn không can thiệp vào mã trạng thái, return Json(data)
            // vẫn trả về 200 OK, dù có lỗi hay không. Điều này không phản ánh chính xác
            // tình trạng lỗi (lỗi xảy ra trong xử lý).

            // Để phản ánh đúng tình trạng lỗi, bạn nên sử dụng JsonResult với việc tùy chỉnh 
            // mã trạng thái như 500 (Internal Server Error) hoặc 400 (Bad Request), v.v.

            var errorData = new { Message = ex.Message };

            // Trả về lỗi với mã trạng thái 500 (Internal Server Error)
            return new JsonResult(errorData)
            {
                StatusCode = 500  // Mã trạng thái 500 cho lỗi trên server
            };
        }
    }


    public ActionResult JsonSerializerOptions()
    {
        var options = new JsonSerializerOptions()
        {
            // Property names will remain as defined in the class
            PropertyNamingPolicy = null,
            // JSON will be formatted with indents for readability
            WriteIndented = true,
        };

        try
        {
            //Based on the Category Fetch the Data from the database 
            //Here, we have hard coded the data
            List<Product> products = new List<Product>
                {
                    new Product{ Id = 1001, Name = "Laptop",  Description = "Dell Laptop" },
                    new Product{ Id = 1002, Name = "Desktop", Description = "HP Desktop" },
                    new Product{ Id = 1003, Name = "Mobile", Description = "Apple IPhone" }
                };
            //Please uncomment the following two lines if you want see what happend when exception occurred
            //int a = 10, b = 0;
            //int c = a / b;
            return Json(products, options);
        }
        catch (Exception ex)
        {
            var errorObject = new
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                ExceptionType = "Internal Server Error"
            };
            return new JsonResult(errorObject, options)
            {
                StatusCode = StatusCodes.Status500InternalServerError // Status code here 
            };
        }
    }


    // Define an action method named Index that returns a RedirectToActionResult
    public RedirectToActionResult RedirectToActionResult()
    {
        // Create an anonymous object to hold route values (id and name)
        // /Home/About/123?name=Test
        var routeValues = new { id = 123, name = "Test" };

        // Create a new instance of RedirectToActionResult
        // Specify the action name ("About"), controller name ("Home"), route values, 
        // and additional options (permanent and preserveMethod)
        var redirectResult = new RedirectToActionResult(
            actionName: "About",          // The action to redirect to
            controllerName: "Home",       // The controller to redirect to
            routeValues: routeValues,     // The route values to pass to the action
            permanent: false,             // Indicates if the redirect is permanent (HTTP 301)
            preserveMethod: true,         // Indicates if the HTTP method should be preserved
            fragment: "AboutSection"       //Indicates the URL Fragment, i.e., append in the URL as #AboutSection
        );

        ///Home/About/123?name=Test#AboutSection

        // Return the RedirectToActionResult to the framework, which will handle the redirection
        return redirectResult;
    }

}
