using Microsoft.AspNetCore.Mvc;
using WebAppActionResults.ActionResults;

namespace WebAppActionResults.Controllers
{
    public class LogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // url /Log/DownloadLog
        public IActionResult DownloadLog()
        {
            string logContent = "User logged in\nAction: Download report\nStatus: Success";

            return new CustomFileLogResult(logContent, "activity-log.log");
        }
    }
}
