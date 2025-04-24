using System.Text.RegularExpressions;

namespace WebAppRouting.Models
{
    public class AlphaNumericConstraint : IRouteConstraint
    {
        //chứa cả chữ và số.

        //https://localhost:5001/Student/Details/abc123
        //Match(httpContext, route, "id", values, routeDirection)
        //"id" chính là routeKey
        //values là dictionary { "controller": "Student", "action": "Details", "id": "abc123" }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var routeValue))
            {
                var value = Convert.ToString(routeValue);
                return Regex.IsMatch(value ?? "", "^(?=.*[a-zA-Z])(?=.*[0-9])[A-Za-z0-9]+$");
            }
            return false;
        }
    }
}
