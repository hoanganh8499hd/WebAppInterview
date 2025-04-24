using Microsoft.AspNetCore.Mvc;
using System.Buffers.Text;
using System;

namespace WebAppRouting.Controllers
{
    // Prefix tất cả route: /attribute
    [Route("attribute")]
    public class AttributeRoutingController : Controller
    {
        // Các attribute như [HttpGet], [HttpPost] = [Route] + giới hạn HTTP method.

        //Attribute Routing → được ưu tiên nếu có mặt.
        //Convention-based Routing (trong Program.cs) → chỉ dùng cho controller/action không có[Route].

        //attribute ✅
        //attribute/index ✅
        //AttributeRouting/Index ❌ (vì Attribute Routing override cái convention rồi)

        // GET: /attribute
        [Route("")]
        [Route("index")]
        public string Index()
        {
            return "Welcome to the AttributeRoutingController - Index";
        }

        // GET: /attribute/about
        [HttpGet("about")]
        public string About()
        {
            return "This is the About page.";
        }

        // GET: /attribute/details/5
        [HttpGet("details/{id}")]
        public string Details(int id)
        {
            return $"Details of item with ID: {id}";
        }

        // GET: /attribute/search?query=abc
        [HttpGet("search")]
        public string Search([FromQuery] string query)
        {
            return $"You searched for: {query}";
        }

        // GET: /attribute/profile/anna or /attribute/profile (name optional)
        [HttpGet("profile/{name?}")]
        public string Profile(string name = "Guest")
        {
            return $"Hello, {name}";
        }

        // POST: /attribute/save
        [HttpPost("save")]
        public IActionResult Save([FromForm] string data)
        {
            return Ok($"Data received: {data}");
        }

        // GET: /custom-home (bỏ qua prefix /attribute)
        [HttpGet("~/custom-home")]
        public string CustomHome()
        {
            return "This is a custom global route, not under /attribute.";
        }

    }
}
