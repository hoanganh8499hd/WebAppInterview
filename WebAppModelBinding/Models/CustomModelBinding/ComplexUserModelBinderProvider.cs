using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebAppModelBinding.Models.CustomModelBinding
{
    public class ComplexUserModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            //ModelType: Gets the model type represented by the current instance
            if (context.Metadata.ModelType == typeof(ComplexUser))
            {
                return new ComplexUserModelBinder();
            }
            return null;
        }
    }
}
