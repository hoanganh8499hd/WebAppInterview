using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebAppActionResults.ActionResults
{
    public class CustomFileLogResult : IActionResult
    {
        private readonly string _logContent;
        private readonly string _fileName;

        public CustomFileLogResult(string logContent, string fileName = "logfile.log")
        {
            _logContent = logContent;
            _fileName = fileName;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;

            response.ContentType = "text/plain";
            response.Headers["Content-Disposition"] = $"attachment; filename={_fileName}";

            var logBuilder = new StringBuilder();
            logBuilder.AppendLine("=== CUSTOM LOG START ===");
            logBuilder.AppendLine($"Timestamp: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}");
            logBuilder.AppendLine("Log Content:");
            logBuilder.AppendLine(_logContent);
            logBuilder.AppendLine("=== CUSTOM LOG END ===");

            await response.WriteAsync(logBuilder.ToString());
        }
    }

}
