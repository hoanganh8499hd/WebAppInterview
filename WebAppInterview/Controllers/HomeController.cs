using Microsoft.AspNetCore.Mvc;
using WebAppInterview.Models;

namespace WebAppInterview.Controllers
{
    public class HomeController : Controller
    {
        //Create a reference variable of IStudentRepository
        private readonly IStudentRepository? _repository = null;
        private readonly SomeOtherService? _someOtherService = null;

        //Initialize the variable through constructor
        public HomeController(IStudentRepository repository, SomeOtherService someOtherService)
        {
            _repository = repository;
            _someOtherService = someOtherService;
        }
        public JsonResult Index()
        {
            DateTime dt = new DateTime(2025, 1, 1);

            Console.WriteLine(dt.DayOfWeek);


            List<Student>? allStudentDetails = _repository?.GetAllStudent();
            _someOtherService?.SomeMethod();
            return Json(allStudentDetails);
        }
        public JsonResult GetStudentDetails(int Id)
        {
            Student? studentDetails = _repository?.GetStudentById(Id);
            _someOtherService?.SomeMethod();
            return Json(studentDetails);
        }

        // GET: /Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.AddStudent(student);
            }
            return View(student);
        }
    }
}
