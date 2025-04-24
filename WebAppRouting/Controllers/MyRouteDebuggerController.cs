using Microsoft.AspNetCore.Mvc;

namespace WebAppRouting.Controllers
{
    public class MyRouteDebuggerController : Controller
    {
        private readonly EndpointDataSource _endpointSource;

        public MyRouteDebuggerController(EndpointDataSource endpointSource)
        {
            _endpointSource = endpointSource;
        }

        public IActionResult Index()
        {
            // This action method returns a view that displays the list of registered routes
            var endpoints = _endpointSource.Endpoints;
            var output = endpoints.Select(e => e.DisplayName).ToList();
            return Json(output);
        }

        public IActionResult RouteDataAction()
        {
            // Accessing RouteData to get the current route information
            //HttpContext.GetRouteData()

            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            return Content($"Controller: {controller}, Action: {action}, HttpContext.GetRouteData() {HttpContext.GetRouteData().Values["controller"]}" );
        }
    }
}
