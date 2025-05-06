using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebAppModelBinding.Models.CustomModelBinding
{
    public class ComplexUser
    {
        [FromHeader(Name = "X-Username")]
        public string? Username { get; set; }
        [FromQuery(Name = "age")]
        public int Age { get; set; }
        [FromRoute(Name = "country")]
        public string? Country { get; set; }
        [FromQuery(Name = "refid")]
        public string? ReferenceId { get; set; }
    }
    public class ComplexUserModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var headers = bindingContext.HttpContext.Request.Headers;
            var routeData = bindingContext.HttpContext.Request.RouteValues;
            var query = bindingContext.HttpContext.Request.Query;
            var user = new ComplexUser
            {
                Username = headers["X-Username"].ToString(),
                Country = routeData["country"].ToString(),
                Age = int.TryParse(query["age"].ToString(), out var age) ? age : 0,
                ReferenceId = query["refId"].ToString()
            };
            bindingContext.Result = ModelBindingResult.Success(user);
            return Task.CompletedTask;
        }
    }
}
