using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebAppModelBinding.Models.CustomModelBinding
{
    public class DateRangeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            //ModelType: Gets the model type represented by the current instance
            if (context.Metadata.ModelType == typeof(DateRange))
            {
                return new DateRangeModelBinder();
            }
            return null;
        }
    }
}
