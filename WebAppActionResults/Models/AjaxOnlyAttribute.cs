using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Extensions.Primitives;

namespace WebAppActionResults.Models
{
    //public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    //{
    //    public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor actionDescriptor)
    //    {
    //        if (routeContext.HttpContext.Request.Headers.ContainsKey("X-Requested-With") &&
    //            routeContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
    //        {
    //            return true;
    //        }
    //        return false;
    //    }
    //}

    // This attribute is used to restrict the action method to be called only via AJAX requests.
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AjaxOnlyAttribute : Attribute, IActionConstraint
    {
        public int Order => 0; // thứ tự ưu tiên trong quá trình chọn action

        public bool Accept(ActionConstraintContext context)
        {
            var headers = context.RouteContext.HttpContext.Request.Headers;

            if (headers.TryGetValue("X-Requested-With", out StringValues value))
            {
                return value == "XMLHttpRequest"; // xác định có phải AJAX không
            }

            return false; // nếu không có header hoặc không phải XMLHttpRequest
        }
    }
}
