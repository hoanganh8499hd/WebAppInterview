using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace WebAppModelBinding.Models.CustomModelBinding
{
    public class DateRange
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class DateRangeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            // Lấy tham số từ chuỗi truy vấn
            var query = bindingContext.HttpContext.Request.Query;
            // Kiểm tra xem khóa "range" có tồn tại trong chuỗi truy vấn không
            if (!query.ContainsKey("range"))
            {
                // Nếu không tồn tại, kết thúc mà không làm gì
                return Task.CompletedTask;
            }

            var DateRangeQueryString = query["range"].ToString();
            // Kiểm tra nếu giá trị là null hoặc rỗng
            if (string.IsNullOrEmpty(DateRangeQueryString))
            {
                return Task.CompletedTask;
            }

            // Tách giá trị theo dấu "-"
            var dateValues = DateRangeQueryString.Split('-');
            if (dateValues.Length != 2)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Invalid Date Range Format.");
                return Task.CompletedTask;
            }

            if (DateTime.TryParseExact(dateValues[0], "MM/dd/yyyy", provider, DateTimeStyles.None, out DateTime startDate) &&
                DateTime.TryParseExact(dateValues[1], "MM/dd/yyyy", provider, DateTimeStyles.None, out DateTime endDate))
            {
                var dateRange = new DateRange { StartDate = startDate, EndDate = endDate };
                bindingContext.Result = ModelBindingResult.Success(dateRange);
                return Task.CompletedTask;
            }
            else
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Invalid Date Range Format.");
                return Task.CompletedTask;
            }
        }

    }
}
