using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebAppDataPassing.Models;

namespace WebAppDataPassing.Controllers
{
    public class TempDataController : Controller
    {
        public ActionResult Index()
        {
            TempData["Name"] = "Pranaya";
            TempData["Age"] = 30;


            //Retention of All keys of TempData for the next request
            //TempData.Keep();
            //Retention of Individual keys of TempData for the next request
            TempData.Keep("Name");
            TempData.Keep("Age");

            //Create the Complex Object
            var student = new Student()
            {
                StudentId = 1,
                Name = "Pranaya",
                Gender = "Male",
                Branch = "CSE",
                Section = "A"
            };
            //Convert the Complex Object to Json
            string jsonStudent = JsonSerializer.Serialize(student);
            //Store the JSON Objec into the TempData
            TempData["StudentObject"] = jsonStudent;
            //return RedirectToAction("Privacy", "Home");
            return RedirectToAction("About");


            //return View();
        }
        public ActionResult Privacy()
        {

            //Retention of Individual keys of TempData for the next request
            if (TempData.ContainsKey("Name"))
            {
                //Peek Method will read the data and preserve the key for next request
                ViewData["Name"] = TempData.Peek("Name");
            }
            if (TempData.ContainsKey("Age"))
            {
                //Peek Method will read the data and preserve the key for next request
                ViewData["Age"] = TempData.Peek("Age");
            }


            ////Retention of Individual keys of TempData for the next request
            //TempData.Keep("Name");
            //TempData.Keep("Age");

            return View();
        }
        public ActionResult About()
        {
            //Retention of Individual keys of TempData for the next request
            //TempData.Keep("Name");
            //TempData.Keep("Age");
            Student? student = new Student();
            if (TempData["StudentObject"] is string jsonStudent)
            {
                //Deserialize the Json Object to Actual Student Object
                student = JsonSerializer.Deserialize<Student>(jsonStudent);
                //You can use the Student
                // The following line keeps the data for another request

            }
            return View(student);

            //return View();
        }
    }
}
